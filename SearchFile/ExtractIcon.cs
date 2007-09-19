using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MyLib.WindowsShell
{
    /// <summary>
    /// 実行ファイルや拡張子に関連付けられたアイコンに関する機能を提供する
    /// </summary>
    public static class ExtractIcon
    {
        private const int MAX_PATH = 260;

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SHGetFileInfo(string pszPath, FileAttributes dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, SHGetFileInfoFlags uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        [Flags]
        private enum FileAttributes : uint
        {
            FILE_ATTRIBUTE_READONLY = 0x00000001,
            FILE_ATTRIBUTE_HIDDEN = 0x00000002,
            FILE_ATTRIBUTE_SYSTEM = 0x00000004,
            FILE_ATTRIBUTE_DIRECTORY = 0x00000010,
            FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
            FILE_ATTRIBUTE_DEVICE = 0x00000040,
            FILE_ATTRIBUTE_NORMAL = 0x00000080,
            FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
            FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,
            FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,
            FILE_ATTRIBUTE_COMPRESSED = 0x00000800,
            FILE_ATTRIBUTE_OFFLINE = 0x00001000,
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
            FILE_ATTRIBUTE_ENCRYPTED = 0x00004000,
            FILE_ATTRIBUTE_VIRTUAL = 0x00010000
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [Flags]
        private enum SHGetFileInfoFlags : uint
        {
            SHGFI_LARGEICON = 0x000000000,
            SHGFI_SMALLICON = 0x000000001,
            SHGFI_OPENICON = 0x000000002,
            SHGFI_SHELLICONSIZE = 0x000000004,
            SHGFI_PIDL = 0x000000008,
            SHGFI_USEFILEATTRIBUTES = 0x000000010,

            SHGFI_ICON = 0x000000100,
            SHGFI_DISPLAYNAME = 0x000000200,
            SHGFI_TYPENAME = 0x000000400,
            SHGFI_ATTRIBUTES = 0x000000800,
            SHGFI_ICONLOCATION = 0x000001000,
            SHGFI_EXETYPE = 0x000002000,
            SHGFI_SYSICONINDEX = 0x000004000,
            SHGFI_LINKOVERLAY = 0x000008000,
            SHGFI_SELECTED = 0x000010000,

            // NTDDI_VERSION >= NTDDI_WIN2K
            SHGFI_ATTR_SPECIFIED = 0x000020000,

            // _WIN32_IE >= 0x0500
            SHGFI_ADDOVERLAYS = 0x000000020,
            SHGFI_OVERLAYINDEX = 0x000000040
        }

        /// <summary>
        /// 取得するアイコンを指定する列挙体
        /// </summary>
        public enum IconSize : uint
        {
            Large = SHGetFileInfoFlags.SHGFI_LARGEICON,
            Small = SHGetFileInfoFlags.SHGFI_SMALLICON
        }

        /// <summary>
        /// ファイルに関連付けられたアイコンを取得する
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="iconSize">アイコンサイズ</param>
        /// <returns>ファイルに関連付けられたアイコン</returns>
        /// <exception cref="System.ComponentModel.Win32Exception">アイコンが取得できない場合</exception>
        /// <exception cref="System.DllNotFoundException">DLL が見つからない場合</exception>
        public static Icon ExtractFileIcon(string fileName, IconSize iconSize)
        {
            IntPtr? handle = null;

            try
            {
                // アイコンを識別する Windows ハンドルから GDI+ ICON を作成する
                handle = ExtractFileIconHandle(fileName, iconSize);
                using (Icon icon = Icon.FromHandle(handle.Value))
                {
                    return (Icon)icon.Clone();
                }
            }
            finally
            {
                // アイコンを破棄する
                if (handle.HasValue)
                {
                    DestroyIcon(handle.Value);
                }
            }
        }

        /// <summary>
        /// ファイルに関連付けられたアイコンを識別する Windows ハンドルを取得する
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="iconSize">アイコンサイズ</param>
        /// <returns>ファイルに関連付けられたアイコンを識別する Windows ハンドルを示す IntPtr</returns>
        /// <exception cref="System.ComponentModel.Win32Exception">アイコンが取得できない場合</exception>
        /// <exception cref="System.DllNotFoundException">DLL が見つからない場合</exception>
        private static IntPtr ExtractFileIconHandle(string fileName, IconSize iconSize)
        {
            // アイコンを取得する
            SHFILEINFO shfi = new SHFILEINFO();
            IntPtr result = SHGetFileInfo(fileName, 0, ref shfi, (uint)Marshal.SizeOf(shfi), SHGetFileInfoFlags.SHGFI_ICON | (SHGetFileInfoFlags)iconSize);

            // アイコンが取得できない場合は例外を発生させる
            if (result == IntPtr.Zero)
            {
                throw new Win32Exception();
            }

            // アイコンを識別する Windows ハンドルを返す
            return shfi.hIcon;
        }
    }
}
