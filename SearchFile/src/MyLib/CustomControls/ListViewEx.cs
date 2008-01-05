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

        #region Win32 API ���Ăяo�����߂̒�`

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
        /// �w�b�_�[�ɕ\��������̎��
        /// </summary>
        public enum HeaderSortArrows
        {
            None,
            SortUp,
            SortDown
        }

        /// <summary>
        /// �w�b�_�[�̃E�B���h�E�n���h�����擾����B
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
        /// �w�b�_�[�ɕ\���������ݒ肷��
        /// </summary>
        /// <param name="column">��w�b�_�[�̃C���f�b�N�X</param>
        /// <param name="style">���̎��</param>
        public void SetHeaderSortArrowStyle(int column, HeaderSortArrows style)
        {
            // �w�b�_�[�̃t�H�[�}�b�g�̎擾�E�ݒ���s�����߂̍\���̂̐ݒ���s��
            HDITEM item = new HDITEM();
            item.mask = HeaderItemMasks.HDI_FORMAT;

            // ���݂̃w�b�_�[�����擾����
            if (SendMessage(new HandleRef(this, this.HeaderHandle), (uint)HeaderMessages.HDM_GETITEM, (IntPtr)column, ref item) == IntPtr.Zero)
            {
                throw new Win32Exception();
            }

            // �w�b�_�[�X�^�C����ݒ肷��
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

            // �w�b�_�[����ݒ肷��
            if (SendMessage(new HandleRef(this, this.HeaderHandle), (uint)HeaderMessages.HDM_SETITEM, (IntPtr)column, ref item) == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
        }
    }
}
