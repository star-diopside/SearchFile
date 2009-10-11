using System.Drawing;
using System.Windows.Forms;

namespace MyLib.CustomControls
{
    /// <summary>
    /// カスタムの塗りつぶしを行う Label コントロールの基本クラスを定義します。
    /// </summary>
    public abstract class AbstractDrawLabel : Label
    {
        /// <summary>
        /// AbstractDrawLabel クラスの新しいインスタンスを初期化します。
        /// </summary>
        public AbstractDrawLabel()
        {
        }

        /// <summary>
        /// 塗りつぶしに使用するBrushオブジェクトを生成する。
        /// </summary>
        protected abstract Brush CreateFillBrush();

        /// <summary>
        /// 塗りつぶしを行い、Paintイベントを発生させる。
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Brush b = CreateFillBrush())
            {
                e.Graphics.FillRectangle(b, this.ClientRectangle);
            }

            base.OnPaint(e);
        }
    }
}
