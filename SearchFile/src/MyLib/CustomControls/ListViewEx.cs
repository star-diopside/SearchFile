using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyLib.CustomControls
{
    public class ListViewEx : ListView
    {
        private readonly WeakReference _headerHandleRef = new WeakReference(null);

        public ListViewEx()
        {
            this.DoubleBuffered = true;
        }

        #region Win32 API を呼び出すための定義

        [DllImport("user32.dll")]
        protected static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, ref HDITEM lParam);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        protected struct HDITEM
        {
            public HeaderItemMasks mask;
            public int cxy;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public IntPtr hbm;
            public int cchTextMax;
            public HeaderFormats fmt;
            public uint lParam;

            public int iImage;
            public int iOrder;

            public uint type;
            public IntPtr pvFilter;

            public uint state;
        }

        protected enum ListViewMessages : uint
        {
            LVM_FIRST = 0x1000,
            LVM_GETHEADER = LVM_FIRST + 31
        }

        protected enum HeaderMessages : uint
        {
            HDM_FIRST = 0x1200,
            HDM_GETITEM = HDM_FIRST + 11,
            HDM_SETITEM = HDM_FIRST + 12
        }

        [Flags]
        protected enum HeaderFormats : uint
        {
            HDF_SORTUP = 0x0400,
            HDF_SORTDOWN = 0x0200
        }

        [Flags]
        protected enum HeaderItemMasks : uint
        {
            None = 0,
            HDI_FORMAT = 0x0004
        }

        #endregion

        /// <summary>
        /// ヘッダーに表示する矢印の種類
        /// </summary>
        public enum HeaderSortArrows
        {
            None,
            SortUp,
            SortDown
        }

        /// <summary>
        /// ヘッダーのウィンドウハンドルを取得する。
        /// </summary>
        protected IntPtr HeaderHandle
        {
            get
            {
                IntPtr? headerHandle = this._headerHandleRef.Target as IntPtr?;

                if (headerHandle == null)
                {
                    headerHandle = SendMessage(new HandleRef(this, this.Handle), (uint)ListViewMessages.LVM_GETHEADER, (IntPtr)0, (IntPtr)0);
                    this._headerHandleRef.Target = headerHandle;
                }

                return headerHandle.Value;
            }
        }

        /// <summary>
        /// ヘッダーに表示する矢印を設定する
        /// </summary>
        /// <param name="column">列ヘッダーのインデックス</param>
        /// <param name="style">矢印の種類</param>
        public void SetHeaderSortArrowStyle(int column, HeaderSortArrows style)
        {
            // ヘッダーのフォーマットの取得・設定を行うための構造体の設定を行う
            HDITEM item = new HDITEM();
            item.mask = HeaderItemMasks.HDI_FORMAT;

            // 現在のヘッダー情報を取得する
            if (SendMessage(new HandleRef(this, this.HeaderHandle), (uint)HeaderMessages.HDM_GETITEM, (IntPtr)column, ref item) == IntPtr.Zero)
            {
                throw new Win32Exception();
            }

            // ヘッダースタイルを設定する
            switch (style)
            {
                case HeaderSortArrows.None:
                    item.fmt &= ~HeaderFormats.HDF_SORTDOWN;
                    item.fmt &= ~HeaderFormats.HDF_SORTUP;
                    break;

                case HeaderSortArrows.SortUp:
                    item.fmt &= ~HeaderFormats.HDF_SORTDOWN;
                    item.fmt |= HeaderFormats.HDF_SORTUP;
                    break;

                case HeaderSortArrows.SortDown:
                    item.fmt |= HeaderFormats.HDF_SORTDOWN;
                    item.fmt &= ~HeaderFormats.HDF_SORTUP;
                    break;

                default:
                    break;
            }

            // ヘッダー情報を設定する
            if (SendMessage(new HandleRef(this, this.HeaderHandle), (uint)HeaderMessages.HDM_SETITEM, (IntPtr)column, ref item) == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
        }
    }
}
