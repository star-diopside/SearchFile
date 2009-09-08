namespace SearchFile
{
    /// <summary>
    /// 検索結果を通知するクラスが実装するインタフェース
    /// </summary>
    interface ISearchResult
    {
        /// <summary>
        /// 検索結果の表示を行う
        /// </summary>
        /// <param name="viewObject">検索結果の表示を行うオブジェクト</param>
        void View(ISearchResultView viewObject);
    }
}
