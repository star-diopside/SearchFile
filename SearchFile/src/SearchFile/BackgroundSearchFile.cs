using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace SearchFile
{
    /// <summary>
    /// 個別のスレッドでファイル検索を実行する。
    /// </summary>
    internal class BackgroundSearchFile : BackgroundWorker
    {
        // スレッドのロック時に使用するオブジェクトのインスタンス
        private readonly object lockObject = new object();

        // 検索を行うディレクトリパス
        private string _searchPath = string.Empty;

        // 検索を行うファイル名の正規表現
        private Regex _searchPattern = null;

        // 検索範囲を指定する SearchOption 値
        private SearchOption _searchOption = SearchOption.TopDirectoryOnly;

        /// <summary>
        /// 検索を行うディレクトリの取得または設定を行う。
        /// </summary>
        [Browsable(true)]
        public string SearchPath
        {
            get
            {
                return this._searchPath;
            }
            set
            {
                if (this.IsBusy)
                {
                    throw new InvalidOperationException();
                }

                lock (lockObject)
                {
                    this._searchPath = value;
                }
            }
        }

        /// <summary>
        /// SearchPath プロパティを永続化する必要があるかどうかを示す。
        /// </summary>
        internal virtual bool ShouldSerializeSearchPath()
        {
            return this.SearchPath == null || this.SearchPath.Length != 0;
        }

        /// <summary>
        /// SearchPath プロパティを既定値にリセットする。
        /// </summary>
        public virtual void ResetSearchPath()
        {
            this.SearchPath = string.Empty;
        }

        /// <summary>
        /// 検索を行うファイル名の正規表現の取得または設定を行う。
        /// </summary>
        [Browsable(true), DefaultValue(null)]
        public Regex SearchPattern
        {
            get
            {
                return this._searchPattern;
            }
            set
            {
                if (this.IsBusy)
                {
                    throw new InvalidOperationException();
                }

                lock (lockObject)
                {
                    this._searchPattern = value;
                }
            }
        }

        /// <summary>
        /// 検索操作にすべてのサブディレクトリを含めるのか、または現在のディレクトリのみを含めるのかを指定する SearchOption 値の取得または設定を行う。
        /// </summary>
        [Browsable(true), DefaultValue(SearchOption.TopDirectoryOnly)]
        public SearchOption SearchOption
        {
            get
            {
                return this._searchOption;
            }
            set
            {
                if (this.IsBusy)
                {
                    throw new InvalidOperationException();
                }

                lock (lockObject)
                {
                    this._searchOption = value;
                }
            }
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            lock (lockObject)
            {
                base.OnDoWork(e);

                // 再帰的にファイル検索を行う
                e.Result = RecursiveSearchFile(this.SearchPath, this.SearchPattern, this.SearchOption);
            }
        }

        /// <summary>
        /// 再帰的にファイル検索を行う。
        /// </summary>
        /// <param name="path">検索するディレクトリ</param>
        /// <param name="pattern">path 内のファイル名と対応させる正規表現</param>
        /// <param name="searchOption">検索操作にすべてのサブディレクトリを含めるのか、または現在のディレクトリのみを含めるのかを指定する SearchOption 値の 1 つ</param>
        /// <returns>検索文字列に一致した件数</returns>
        protected int RecursiveSearchFile(string path, Regex pattern, SearchOption searchOption)
        {
            int totalCount = 0;

            lock (lockObject)
            {
                try
                {
                    // path が null か空文字列の場合は例外をスローする
                    if (path == null)
                    {
                        throw new ArgumentNullException();
                    }
                    else if (path.Length == 0)
                    {
                        throw new ArgumentException();
                    }

                    // ディレクトリ名の最後にディレクトリ区切り文字を追加する
                    // （ディレクトリの末尾が全角スペースの場合の対応）
                    if (path[path.Length - 1] != Path.DirectorySeparatorChar)
                    {
                        path += Path.DirectorySeparatorChar;
                    }

                    // 検索するディレクトリ名を通知する
                    this.ReportProgress(0, new SearchResultDirectory(path));

                    // ProgressChanged イベントでの処理が完了するまで待機する
                    Monitor.Wait(lockObject);

                    // ファイル名を取得する
                    var fileNames = from fileName in Directory.EnumerateFiles(path).AsParallel()
                                    where pattern.IsMatch(Path.GetFileName(fileName))
                                    select fileName;
                    int findCount = fileNames.Count();

                    totalCount += findCount;

                    // ファイルが見つかった場合
                    if (findCount > 0)
                    {
                        // 検索結果を通知する
                        this.ReportProgress(0, new SearchResultFiles(fileNames));

                        // ProgressChanged イベントでの処理が完了するまで待機する
                        Monitor.Wait(lockObject);
                    }

                    // 再帰的にディレクトリを検索する
                    if (searchOption == SearchOption.AllDirectories)
                    {
                        foreach (string directory in Directory.GetDirectories(path))
                        {
                            // キャンセル要求があった場合は繰り返しを終了する
                            if (this.CancellationPending)
                            {
                                break;
                            }

                            totalCount += RecursiveSearchFile(directory, pattern, searchOption);
                        }
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    // ディレクトリが見つからない場合、後続の処理を続行する
                    // （検索中にディレクトリが削除された場合の対応）
                }
                catch (UnauthorizedAccessException)
                {
                    // アクセスエラーの場合、後続の処理を続行する
                }
            }

            return totalCount;
        }

        protected override void OnProgressChanged(ProgressChangedEventArgs e)
        {
            lock (lockObject)
            {
                try
                {
                    base.OnProgressChanged(e);
                }
                finally
                {
                    Monitor.PulseAll(lockObject);
                }
            }
        }
    }
}
