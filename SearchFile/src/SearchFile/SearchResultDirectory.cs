using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFile
{
    /// <summary>
    /// スレッドから検索中のディレクトリ名を通知するクラス
    /// </summary>
    class SearchResultDirectory : ISearchResult
    {
        private string _searchingDirectoryPath;

        /// <summary>
        /// SearchResultDirectoryクラスの新しいインスタンスを生成する
        /// </summary>
        /// <param name="searchingDirectoryPath">通知対象の検索中ディレクトリ名</param>
        public SearchResultDirectory(string searchingDirectoryPath)
        {
            this._searchingDirectoryPath = searchingDirectoryPath;
        }

        /// <summary>
        /// 検索結果の表示を行う
        /// </summary>
        /// <param name="viewObject">検索結果の表示を行うオブジェクト</param>
        public void View(ISearchResultView viewObject)
        {
            viewObject.ViewSearchingDirectory(this._searchingDirectoryPath);
        }
    }
}
