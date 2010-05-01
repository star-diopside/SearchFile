using System.Collections.Generic;
using System.Linq;

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
            this._files = from fileName in fileNames.AsParallel()
                          select new FileInfo(fileName);
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
