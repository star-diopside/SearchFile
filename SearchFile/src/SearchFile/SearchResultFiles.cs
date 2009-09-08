using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFile
{
    /// <summary>
    /// スレッドから検索結果のファイル名を通知するクラス
    /// </summary>
    class SearchResultFiles : ISearchResult
    {
        private IEnumerable<FileInfo> _files;

        /// <summary>
        /// SearchResultFilesクラスの新しいインスタンスを生成する
        /// </summary>
        /// <param name="files">検索結果のファイル名</param>
        public SearchResultFiles(IEnumerable<string> fileNames)
        {
            List<FileInfo> files = new List<FileInfo>();

            foreach (string fileName in fileNames)
            {
                files.Add(new FileInfo(fileName));
            }

            this._files = files;
        }

        /// <summary>
        /// 検索結果の表示を行う
        /// </summary>
        /// <param name="viewObject">検索結果の表示を行うオブジェクト</param>
        public void View(ISearchResultView viewObject)
        {
            viewObject.AddFiles(this._files);
        }
    }
}
