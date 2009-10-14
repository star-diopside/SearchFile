using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MyLib.Utils
{
    static class ApplicationUtility
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        // ウィンドウメッセージ定数の定義
        private const int WM_NULL = 0x0000;

        /// <summary>
        /// 現在のスレッドでアイドルイベントを発生させる。
        /// </summary>
        /// <returns>ウィンドウメッセージ処理の呼び出しが成功した場合は true。ウィンドウメッセージ処理をサポートしていない場合は false。</returns>
        /// <exception cref="System.ComponentModel.Win32Exception">ウィンドウメッセージ処理でエラーが発生した場合</exception>
        /// <remarks>
        /// 通常、UI 操作を行わないと System.Windows.Forms.Application クラスの Idle イベントが発生しませんが、その場合にも Idle イベントを発生させる必要がある場合に使用します。
        /// 他のウィンドウメッセージが処理されている場合は Idle イベントは発生しません。
        /// </remarks>
        public static bool RaiseIdle()
        {
            try
            {
                if (!PostMessage(IntPtr.Zero, WM_NULL, IntPtr.Zero, IntPtr.Zero))
                {
                    throw new Win32Exception();
                }
                return true;
            }
            catch (DllNotFoundException)
            {
                return false;
            }
            catch (EntryPointNotFoundException)
            {
                return false;
            }
        }
    }
}
