using System.Collections.Generic;

namespace SearchFile
{
    /// <summary>
    /// 検索結果の表示を行うクラスが実装するインタフェース
    /// </summary>
    interface ISearchResultView
    {
        /// <summary>
        /// 検索中のディレクトリ名を表示する
        /// </summary>
        /// <param name="directoryPath">検索中のディレクトリ名</param>
        void ViewSearchingDirectory(string directoryPath);

        /// <summary>
        /// 検索結果のファイルを追加する
        /// </summary>
        /// <param name="files">検索結果のファイル情報</param>
        void AddFiles(IEnumerable<FileInfo> files);
    }
}
