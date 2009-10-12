using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SearchFile.Extension
{
    /// <summary>
    /// アプリケーション固有の変換を行うメソッドを提供する
    /// </summary>
    static class ConvertExtensions
    {
        /// <summary>
        /// FileInfo オブジェクトの内容を表示する ListViewItem オブジェクトに変換する
        /// </summary>
        /// <param name="file">ファイルに関する情報を扱う FileInfo オブジェクト</param>
        /// <param name="images">ファイルに関連付く Icon オブジェクトを保持する ImageList オブジェクト</param>
        /// <returns>表示に使用する ListViewItem オブジェクト</returns>
        public static ListViewItem ConvertListViewItem(this FileInfo file, ImageList images)
        {
            ListViewItem item = new ListViewItem();

            item.Text = file.Name;
            item.SubItems.Add(file.Extension);
            item.SubItems.Add(file.DirectoryName);

            // ファイルアイコンを取得し、イメージリストに追加する
            if (file.SmallIcon != null)
            {
                if (!images.Images.ContainsKey(file.FullName))
                {
                    images.Images.Add(file.SmallIcon);
                }
                item.ImageIndex = images.Images.Count - 1;
            }

            return item;
        }

        /// <summary>
        /// 表示に使用する ListViewItem オブジェクトをファイル名に変換する
        /// </summary>
        /// <param name="item">表示に使用する ListViewItem オブジェクト</param>
        /// <returns>ファイル名</returns>
        public static string ConvertFileName(this ListViewItem item)
        {
            return Path.Combine(item.SubItems[2].Text, item.Text);
        }

        /// <summary>
        /// 表示に使用する ListViewItem オブジェクトを FileInfo オブジェクトに変換する
        /// </summary>
        /// <param name="item">表示に使用する ListViewItem オブジェクト</param>
        /// <returns>ファイルに関する情報を扱う FileInfo オブジェクト</returns>
        public static FileInfo ConvertFileInfo(this ListViewItem item)
        {
            return new FileInfo(item.ConvertFileName());
        }

        /// <summary>
        /// FileInfo オブジェクトの列挙から ListViewItem オブジェクトの列挙に変換する
        /// </summary>
        /// <param name="files">ファイルに関する情報を扱う FileInfo オブジェクトの列挙</param>
        /// <param name="images">ファイルに関連付く Icon オブジェクトを保持する ImageList オブジェクト</param>
        /// <returns>表示に使用する ListViewItem オブジェクトの列挙</returns>
        public static IEnumerable<ListViewItem> ConvertListViewItem(this IEnumerable<FileInfo> files, ImageList images)
        {
            return files.Select(file => file.ConvertListViewItem(images));
        }

        /// <summary>
        /// 表示に使用する ListViewItem オブジェクトの列挙をファイル名の列挙に変換する
        /// </summary>
        /// <param name="items">表示に使用する ListViewItem オブジェクトの列挙</param>
        /// <returns>ファイル名の列挙</returns>
        public static IEnumerable<string> ConvertFileName(this IEnumerable<ListViewItem> items)
        {
            return items.Select(item => item.ConvertFileName());
        }

        /// <summary>
        /// 表示に使用する ListViewItem オブジェクトの列挙を FileInfo オブジェクトの列挙に変換する
        /// </summary>
        /// <param name="items">表示に使用する ListViewItem オブジェクトの列挙</param>
        /// <returns>ファイルに関する情報を扱う FileInfo オブジェクトの列挙</returns>
        public static IEnumerable<FileInfo> ConvertFileInfo(this IEnumerable<ListViewItem> items)
        {
            return items.Select(item => item.ConvertFileInfo());
        }
    }
}
