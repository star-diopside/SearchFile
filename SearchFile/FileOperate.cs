using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MyLib.WindowsShell
{
    /// <summary>
    /// �t�@�C��������s���V�F�� API ���Ăяo��
    /// </summary>
    static class FileOperate
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
        private struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public SHFileOperationFunc wFunc;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pFrom;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pTo;
            public SHFileOperationFlags fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszProgressTitle;    // only used if FOF_SIMPLEPROGRESS
        }

        [Flags]
        private enum SHFileOperationFunc : uint
        {
            FO_MOVE = 0x0001,
            FO_COPY = 0x0002,
            FO_DELETE = 0x0003,
            FO_RENAME = 0x0004
        }

        [Flags]
        private enum SHFileOperationFlags : ushort
        {
            FOF_MULTIDESTFILES = 0x0001,
            FOF_CONFIRMMOUSE = 0x0002,
            FOF_SILENT = 0x0004,
            FOF_RENAMEONCOLLISION = 0x0008,
            FOF_NOCONFIRMATION = 0x0010,
            FOF_WANTMAPPINGHANDLE = 0x0020,
            FOF_ALLOWUNDO = 0x0040,
            FOF_FILESONLY = 0x0080,
            FOF_SIMPLEPROGRESS = 0x0100,
            FOF_NOCONFIRMMKDIR = 0x0200,
            FOF_NOERRORUI = 0x0400,

            // _WIN32_IE >= 0x0500
            FOF_NOCOPYSECURITYATTRIBS = 0x0800,
            FOF_NORECURSION = 0x1000,
            FOF_NO_CONNECTED_ELEMENTS = 0x2000,
            FOF_WANTNUKEWARNING = 0x4000,

            // _WIN32_WINNT >= 0x0501
            FOF_NORECURSEREPARSE = 0x8000,

            FOF_NO_UI = (FOF_SILENT | FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_NOCONFIRMMKDIR)  // don't display any UI at all
        }

        /// <summary>
        /// �����̃t�@�C�����폜����
        /// </summary>
        /// <param name="files">�폜����t�@�C���̃��X�g</param>
        /// <param name="recycle">�t�@�C�������ݔ��Ɉړ�����ꍇ��true�A���S�ɍ폜����ꍇ��false</param>
        public static void DeleteFiles(ICollection<string> files, bool recycle)
        {
            DeleteFiles(null, files, recycle);
        }

        /// <summary>
        /// �����̃t�@�C�����폜����
        /// </summary>
        /// <param name="owner">�_�C�A���O�{�b�N�X�����L���� IWin32Window �̎���</param>
        /// <param name="files">�폜����t�@�C���̃��X�g</param>
        /// <param name="recycle">�t�@�C�������ݔ��Ɉړ�����ꍇ��true�A���S�ɍ폜����ꍇ��false</param>
        public static void DeleteFiles(IWin32Window owner, ICollection<string> files, bool recycle)
        {
            if (files.Count == 0)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();

            // �폜�Ώ��t�@�C�����w�肷��
            foreach (string fileName in files)
            {
                if (File.Exists(fileName))
                {
                    sb.AppendFormat("{0}\0", Path.GetFullPath(fileName));
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            sb.Append('\0');

            // �t�@�C�����폜����V�F�� API ���Ăяo��
            SHFILEOPSTRUCT sh = new SHFILEOPSTRUCT();

            sh.hwnd = (owner == null ? IntPtr.Zero : owner.Handle);
            sh.wFunc = SHFileOperationFunc.FO_DELETE;
            sh.pFrom = sb.ToString();
            sh.fFlags = 0;
            if (recycle)
            {
                sh.fFlags |= SHFileOperationFlags.FOF_ALLOWUNDO;
            }

            if (SHFileOperation(ref sh) != 0)
            {
                throw new Win32Exception();
            }

            // �������L�����Z�����ꂽ�ꍇ
            if (sh.fAnyOperationsAborted)
            {
                throw new OperationCanceledException();
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
        private struct SHELLEXECUTEINFO
        {
            public uint cbSize;
            public ShellExecuteMaskFlag fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public ShellExecuteErrors hInstApp;

            // Optional fields
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        [Flags]
        private enum ShellExecuteMaskFlag : uint
        {
            SEE_MASK_CLASSNAME = 0x00000001,
            SEE_MASK_CLASSKEY = 0x00000003,
            SEE_MASK_IDLIST = 0x00000004,
            SEE_MASK_INVOKEIDLIST = 0x0000000c,
            SEE_MASK_ICON = 0x00000010,
            SEE_MASK_HOTKEY = 0x00000020,
            SEE_MASK_NOCLOSEPROCESS = 0x00000040,
            SEE_MASK_CONNECTNETDRV = 0x00000080,
            SEE_MASK_NOASYNC = 0x00000100,
            SEE_MASK_FLAG_DDEWAIT = SEE_MASK_NOASYNC,
            SEE_MASK_DOENVSUBST = 0x00000200,
            SEE_MASK_FLAG_NO_UI = 0x00000400,
            SEE_MASK_UNICODE = 0x00004000,
            SEE_MASK_NO_CONSOLE = 0x00008000,
            SEE_MASK_ASYNCOK = 0x00100000,
            SEE_MASK_HMONITOR = 0x00200000,
            SEE_MASK_NOZONECHECKS = 0x00800000,
            SEE_MASK_NOQUERYCLASSSTORE = 0x01000000,
            SEE_MASK_WAITFORINPUTIDLE = 0x02000000,
            SEE_MASK_FLAG_LOG_USAGE = 0x04000000
        }

        private enum ShellExecuteErrors : int
        {
            /// <summary>
            /// �t�@�C����������܂���B
            /// </summary>
            SE_ERR_FNF = 2,
            /// <summary>
            /// �p�X��������܂���B
            /// </summary>
            SE_ERR_PNF = 3,
            /// <summary>
            /// �t�@�C���A�N�Z�X�����ۂ���܂����B
            /// </summary>
            SE_ERR_ACCESSDENIED = 5,
            /// <summary>
            /// �������s���ł��B
            /// </summary>
            SE_ERR_OOM = 8,
            /// <summary>
            /// DLL ��������܂���B
            /// </summary>
            SE_ERR_DLLNOTFOUND = 32,
            /// <summary>
            /// ���L�ᔽ���������܂����B
            /// </summary>
            SE_ERR_SHARE = 26,
            /// <summary>
            /// �t�@�C���֘A�t�������S�ł͂Ȃ��������ł��B
            /// </summary>
            SE_ERR_ASSOCINCOMPLETE = 27,
            /// <summary>
            /// DDE �g�����U�N�V�������^�C���A�E�g�ɂ�蒆�f����܂����B
            /// </summary>
            SE_ERR_DDETIMEOUT = 28,
            /// <summary>
            /// DDE �g�����U�N�V���������s���܂����B
            /// </summary>
            SE_ERR_DDEFAIL = 29,
            /// <summary>
            /// ���� DDE �g�����U�N�V��������������Ă������� DDE �g�����U�N�V�������I���ł��܂���ł����B
            /// </summary>
            SE_ERR_DDEBUSY = 30,
            /// <summary>
            /// �t�@�C���֘A�t�����s���ł��B
            /// </summary>
            SE_ERR_NOASSOC = 31
        }

        /// <summary>
        /// �v���p�e�B�_�C�A���O��\������
        /// </summary>
        /// <param name="fileName">�v���p�e�B��\������t�@�C����</param>
        public static void ShowPropertyDialog(string fileName)
        {
            ShowPropertyDialog(null, fileName);
        }

        /// <summary>
        /// �v���p�e�B�_�C�A���O��\������
        /// </summary>
        /// <param name="owner">�_�C�A���O�{�b�N�X�����L���� IWin32Window �̎���</param>
        /// <param name="fileName">�v���p�e�B��\������t�@�C����</param>
        public static void ShowPropertyDialog(IWin32Window owner, string fileName)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();

            info.cbSize = (uint)Marshal.SizeOf(info);
            info.fMask = ShellExecuteMaskFlag.SEE_MASK_INVOKEIDLIST | ShellExecuteMaskFlag.SEE_MASK_FLAG_NO_UI;
            info.hwnd = (owner == null ? IntPtr.Zero : owner.Handle);
            info.lpFile = fileName;
            info.lpVerb = "properties";
            info.lpParameters = null;
            info.lpDirectory = null;
            info.nShow = 0;
            info.lpIDList = IntPtr.Zero;

            if (!ShellExecuteEx(ref info))
            {
                // �G���[�R�[�h�ɉ�������O���X���[����
                switch (info.hInstApp)
                {
                    case ShellExecuteErrors.SE_ERR_FNF:
                        throw new FileNotFoundException();
                    case ShellExecuteErrors.SE_ERR_PNF:
                        throw new DirectoryNotFoundException();
                    case ShellExecuteErrors.SE_ERR_ACCESSDENIED:
                        throw new UnauthorizedAccessException();
                    case ShellExecuteErrors.SE_ERR_OOM:
                        throw new OutOfMemoryException();
                    case ShellExecuteErrors.SE_ERR_DLLNOTFOUND:
                        throw new DllNotFoundException();
                    default:
                        throw new Win32Exception();
                }
            }
        }
    }
}
