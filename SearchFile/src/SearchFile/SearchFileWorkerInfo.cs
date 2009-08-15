using System;
using System.Collections.Generic;

namespace SearchFile
{
    /// <summary>
    /// ファイル検索スレッドでデータのやり取りに使用する手段を提供する
    /// </summary>
    class SearchFileWorkerInfo
    {
        private readonly object lockObject = new object();

        private bool _havingSearchResult;
        private string _directoryPath;
        private IEnumerable<string> _fileNames;
        private IEnumerable<FileInfo> _files;

        /// <summary>
        /// 検索するディレクトリ名を通知する場合はfalse。検索結果を通知する場合はtrue。
        /// </summary>
        public bool HavingSearchResult
        {
            get
            {
                lock (lockObject)
                {
                    return _havingSearchResult;
                }
            }
            set
            {
                lock (lockObject)
                {
                    _havingSearchResult = value;
                }
            }
        }

        /// <summary>
        /// 検索対象のディレクトリ名を取得または設定する。
        /// </summary>
        public string DirectoryPath
        {
            get
            {
                lock (lockObject)
                {
                    return _directoryPath;
                }
            }
            set
            {
                lock (lockObject)
                {
                    _directoryPath = value;
                }
            }
        }

        /// <summary>
        /// 検索結果のファイル名を取得または設定する。
        /// </summary>
        public IEnumerable<string> FileNames
        {
            get
            {
                lock (lockObject)
                {
                    return _fileNames;
                }
            }
            set
            {
                lock (lockObject)
                {
                    _fileNames = value;

                    List<FileInfo> files = new List<FileInfo>();
                    foreach (string fileName in _fileNames)
                    {
                        files.Add(new FileInfo(fileName));
                    }

                    _files = files;
                }
            }
        }

        /// <summary>
        /// 検索結果のファイル情報を取得する。
        /// </summary>
        public IEnumerable<FileInfo> Files
        {
            get
            {
                lock (lockObject)
                {
                    return _files;
                }
            }
        }
    }
}
