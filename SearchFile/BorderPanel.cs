using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib.CustomControls
{
    class BorderPanel : Panel
    {
        private Color _lineColor = Color.Empty;

        public BorderPanel()
        {
            // サイズ変更時に再描画を行う
            this.ResizeRedraw = true;
        }

        /// <summary>
        /// 境界線の描画時に使用する色を取得または設定します。
        /// </summary>
        [Category("カスタム描画"), Description("境界線の描画時に使用する色です。")]
        public virtual Color LineColor
        {
            get
            {
                if (this._lineColor.IsEmpty)
                {
                    ResetLineColor();
                }
                return this._lineColor;
            }
            set
            {
                this._lineColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// LineColorプロパティを永続化する必要があるかどうかを示す。
        /// </summary>
        protected virtual bool ShouldSerializeLineColor()
        {
            return this.LineColor != SystemColors.ControlDark;
        }

        /// <summary>
        /// LineColorプロパティを既定値にリセットする。
        /// </summary>
        protected virtual void ResetLineColor()
        {
            this.LineColor = SystemColors.ControlDark;
        }

        /// <summary>
        /// 境界線描画に使用するPenオブジェクトを生成する。
        /// </summary>
        /// <returns>境界線描画に使用するPenオブジェクト</returns>
        protected virtual Pen CreateLinePen()
        {
            return new Pen(this.LineColor);
        }

        /// <summary>
        /// 境界線を描画し、Paintイベントを発生させる。
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y,
                                           this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);

            using (Pen p = CreateLinePen())
            {
                e.Graphics.DrawRectangle(p, rect);
            }
        }
    }
}
