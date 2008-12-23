using System;
using System.Windows.Forms;
using MyLib.CustomControls;

namespace SearchFile
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // フォームの既定の ToolStrip 描画スタイルを設定する
            ToolStripManager.VisualStylesEnabled = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SearchFileForm());
        }
    }
}