using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SearchFile
{
    /// <summary>
    /// リストビューのアイテムの並べ替えのために使用する IComparer インターフェイスを実装したクラス
    /// </summary>
    class ListViewItemSorter : IComparer, IComparer<ListViewItem>
    {
        private int _column = 0;
        private SortOrder _sortOrder = SortOrder.Ascending;
        private readonly IList<IComparer<string>> _comparers = new List<IComparer<string>>();

        /// <summary>
        /// ListViewItemSorter クラスの新しいインスタンスを初期化する
        /// </summary>
        public ListViewItemSorter()
        {
        }

        /// <summary>
        /// ソートする列のインデックス番号を取得または設定する
        /// </summary>
        public int Column
        {
            get
            {
                return this._column;
            }
            set
            {
                if (this._column == value)
                {
                    // 以前と同じ列が指定された場合は並べ替え順序を入れ替える
                    if (this._sortOrder == SortOrder.Ascending)
                    {
                        this._sortOrder = SortOrder.Descending;
                    }
                    else if (this._sortOrder == SortOrder.Descending)
                    {
                        this._sortOrder = SortOrder.Ascending;
                    }
                    else
                    {
                        this._sortOrder = SortOrder.Ascending;
                    }
                }
                else
                {
                    // 以前と違う列が指定された場合は並べ替え方法を昇順に設定する
                    this._sortOrder = SortOrder.Ascending;
                }

                this._column = value;
            }
        }

        /// <summary>
        /// ソートの並べ替え方法を取得または設定する
        /// </summary>
        public SortOrder SortOrder
        {
            get
            {
                return this._sortOrder;
            }
            set
            {
                this._sortOrder = value;
            }
        }

        /// <summary>
        /// 列項目のソート時に文字列比較を行う IComparer&lt;string&gt; を格納するコレクション
        /// </summary>
        public IList<IComparer<string>> Comparers
        {
            get
            {
                return this._comparers;
            }
        }

        public int Compare(ListViewItem x, ListViewItem y)
        {
            // 並べ替えを行わない場合は 0 を返す
            if (_sortOrder == SortOrder.None)
            {
                return 0;
            }

            // 列インデックスが負数の場合
            if (_column < 0)
            {
                return 0;
            }

            // 指定列インデックスが引数で指定された ListViewItem の列範囲外の場合
            if (x.SubItems.Count <= _column || y.SubItems.Count <= _column)
            {
                return 0;
            }

            // 文字列比較オブジェクトが指定されていない場合
            if (_comparers.Count <= _column)
            {
                return 0;
            }

            // 項目の大小を比較する
            int result = _comparers[_column].Compare(x.SubItems[_column].Text, y.SubItems[_column].Text);

            // 並べ替え方法が降順の場合は比較結果を反転させる
            if (_sortOrder == SortOrder.Descending)
            {
                result = -result;
            }

            return result;
        }

        int IComparer.Compare(object x, object y)
        {
            return Compare((ListViewItem)x, (ListViewItem)y);
        }
    }
}
