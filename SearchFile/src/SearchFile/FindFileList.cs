using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SearchFile
{
    class FindFileList : IList<FileInfo>
    {
        /// <summary>
        /// リスト操作を行うオブジェクト
        /// </summary>
        private List<FileInfo> _list;

        /// <summary>
        /// EnumerateItem メソッドで返される列挙子によって最後に列挙した要素のインデックス
        /// </summary>
        private int _enumeratedIndex = -1;

        /// <summary>
        /// EnumerateItem メソッドで返される列挙子によってリストの最後まで列挙したかどうかを示す値
        /// </summary>
        private bool _enumeratedEnd = true;

        /// <summary>
        /// EnumerateItem メソッドで返される列挙子によってリストの最後まで列挙したかどうかを示す値を取得する。
        /// </summary>
        public bool EnumeratedEnd
        {
            get
            {
                return this._enumeratedEnd;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FindFileList()
        {
            this._list = new List<FileInfo>();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="collection">新しいリストに要素をコピーするコレクション</param>
        public FindFileList(IEnumerable<FileInfo> collection)
        {
            this._list = new List<FileInfo>(collection);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="capacity">新しいリストに格納できる要素数の初期値</param>
        public FindFileList(int capacity)
        {
            this._list = new List<FileInfo>(capacity);
        }

        /// <summary>
        /// 指定されたインデックスの要素を列挙する
        /// </summary>
        /// <param name="collection">列挙する要素のインデックス</param>
        /// <returns></returns>
        public IEnumerable<FileInfo> GetSelectedItems(ListView.SelectedIndexCollection collection)
        {
            foreach (int index in collection)
            {
                yield return this._list[index];
            }
        }

        /// <summary>
        /// リストの要素を列挙する。列挙中に要素が変更されてもインデックスをもとに列挙を続け、例外はスローしない。
        /// </summary>
        /// <returns>リストの列挙</returns>
        /// <remarks>リストの列挙中に要素が変更された場合もインデックスをもとに列挙を続けるため、同一の要素が列挙されたり、列挙されない要素が発生する可能性がある。</remarks>
        public IEnumerable<FileInfo> EnumerateItem()
        {
            // enumeratedIndexの次の要素から列挙を開始する
            for (int i = this._enumeratedIndex + 1; i < this._list.Count; i++)
            {
                this._enumeratedIndex = i;
                yield return this._list[i];
            }

            // 最後まで列挙を行った場合は、EnumeratedEndフラグを設定する
            this._enumeratedIndex = -1;
            this._enumeratedEnd = true;
        }

        /// <summary>
        /// 指定したインデックスにある要素を取得または設定する。
        /// </summary>
        /// <param name="index">取得または設定する要素のインデックス番号</param>
        /// <returns>指定したインデックスにある要素</returns>
        public FileInfo this[int index]
        {
            get
            {
                return this._list[index];
            }
            set
            {
                this._list[index] = value;
            }
        }

        /// <summary>
        /// リストに実際に格納されている要素の数を取得する。
        /// </summary>
        public int Count
        {
            get
            {
                return this._list.Count;
            }
        }

        /// <summary>
        /// リストが読み取り専用かどうかを示す値を取得する。
        /// </summary>
        bool ICollection<FileInfo>.IsReadOnly
        {
            get
            {
                return ((ICollection<FileInfo>)this._list).IsReadOnly;
            }
        }

        /// <summary>
        /// リストの末尾にオブジェクトを追加する。
        /// </summary>
        /// <param name="item">リストの末尾に追加するオブジェクト</param>
        public void Add(FileInfo item)
        {
            this._list.Add(item);
            this._enumeratedEnd = false;
        }

        /// <summary>
        /// 指定したコレクションの要素をリストの末尾に追加する。
        /// </summary>
        /// <param name="collection">リストの末尾に要素が追加されるコレクション</param>
        /// <exception cref="System.ArgumentNullException">collection が null の場合</exception>
        public void AddRange(IEnumerable<FileInfo> collection)
        {
            this._list.AddRange(collection);
            this._enumeratedEnd = false;
        }

        /// <summary>
        /// リストからすべての要素を削除する。
        /// </summary>
        public void Clear()
        {
            this._list.Clear();
            this._enumeratedEnd = true;
        }

        /// <summary>
        /// ある要素がリスト内に存在するかどうかを判断する。
        /// </summary>
        /// <param name="item">リスト内で検索するオブジェクト</param>
        /// <returns>item がリストに存在する場合は true。それ以外の場合は false。</returns>
        public bool Contains(FileInfo item)
        {
            return this._list.Contains(item);
        }

        /// <summary>
        /// すべてのリスト要素を互換性のある 1 次元配列にコピーする。コピー操作は、コピー先の配列の指定したインデックスから始まる。
        /// </summary>
        /// <param name="array">リストから要素がコピーされる 1 次元配列</param>
        /// <param name="arrayIndex">コピーの開始位置となるインデックス番号</param>
        public void CopyTo(FileInfo[] array, int arrayIndex)
        {
            this._list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// リストを反復処理する列挙子を返す。
        /// </summary>
        /// <returns>リストを反復処理する列挙子</returns>
        public IEnumerator<FileInfo> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        /// <summary>
        /// リストを反復処理する列挙子を返す。
        /// </summary>
        /// <returns>リストを反復処理する列挙子</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        /// <summary>
        /// 指定したオブジェクトを検索し、リスト全体内で最初に見つかった位置のインデックスを返す。 
        /// </summary>
        /// <param name="item">リスト内で検索するオブジェクト。</param>
        /// <returns>リスト全体内で item が見つかった場合は、最初に見つかった位置のインデックス。それ以外の場合は –1。</returns>
        public int IndexOf(FileInfo item)
        {
            return this._list.IndexOf(item);
        }

        /// <summary>
        /// リスト内の指定したインデックスの位置に要素を挿入する。
        /// </summary>
        /// <param name="index">item を挿入する位置のインデックス番号</param>
        /// <param name="item">挿入するオブジェクト</param>
        public void Insert(int index, FileInfo item)
        {
            this._list.Insert(index, item);
            this._enumeratedEnd = false;
        }

        /// <summary>
        /// リスト内で最初に見つかった特定のオブジェクトを削除する。
        /// </summary>
        /// <param name="item">リストから削除するオブジェクト</param>
        /// <returns>item が正常に削除された場合は true。それ以外の場合は false。このメソッドは、item がリストに見つからなかった場合にも false を返す。</returns>
        public bool Remove(FileInfo item)
        {
            return this._list.Remove(item);
        }

        /// <summary>
        /// リストの指定したインデックスにある要素を削除する。
        /// </summary>
        /// <param name="index">削除する要素のインデックス番号</param>
        public void RemoveAt(int index)
        {
            this._list.RemoveAt(index);
        }
    }
}
