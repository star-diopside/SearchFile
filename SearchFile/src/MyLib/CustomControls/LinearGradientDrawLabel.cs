using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyLib.CustomControls
{
    /// <summary>
    /// 線形グラデーションで塗りつぶしを行う Label コントロールを表します。
    /// </summary>
    public class LinearGradientDrawLabel : AbstractDrawLabel
    {
        private LinearGradientMode _linearGradientMode = LinearGradientMode.Horizontal;
        private Color _fillColor1 = Color.Empty;
        private Color _fillColor2 = Color.Empty;

        /// <summary>
        /// 線形グラデーションの方向を取得または設定します。
        /// </summary>
        [Category("カスタム描画"), Description("線形グラデーションの方向です。")]
        public LinearGradientMode LinearGradientMode
        {
            get
            {
                return this._linearGradientMode;
            }
            set
            {
                if (this._linearGradientMode != value)
                {
                    this._linearGradientMode = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// LinearGradientMode プロパティを永続化する必要があるかどうかを示す。
        /// </summary>
        private bool ShouldSerializeLinearGradientMode()
        {
            return this.LinearGradientMode != LinearGradientMode.Horizontal;
        }

        /// <summary>
        /// LinearGradientMode プロパティを既定値にリセットする。
        /// </summary>
        private void ResetLinearGradientMode()
        {
            this.LinearGradientMode = LinearGradientMode.Horizontal;
        }

        /// <summary>
        /// グラデーションの開始色を取得または設定します。
        /// </summary>
        [Category("カスタム描画"), Description("塗りつぶしを行うために使用するグラデーションの開始色です。")]
        public Color FillColor1
        {
            get
            {
                if (this._fillColor1.IsEmpty)
                {
                    ResetFillColor1();
                }
                return this._fillColor1;
            }
            set
            {
                this._fillColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// FillColor1 プロパティを永続化する必要があるかどうかを示す。
        /// </summary>
        private bool ShouldSerializeFillColor1()
        {
            return this.FillColor1 != SystemColors.ActiveCaption;
        }

        /// <summary>
        /// FillColor1 プロパティを既定値にリセットする。
        /// </summary>
        private void ResetFillColor1()
        {
            this.FillColor1 = SystemColors.ActiveCaption;
        }

        /// <summary>
        /// グラデーションの終了色を取得または設定します。
        /// </summary>
        [Category("カスタム描画"), Description("塗りつぶしを行うために使用するグラデーションの終了色です。")]
        public Color FillColor2
        {
            get
            {
                if (this._fillColor2.IsEmpty)
                {
                    ResetFillColor2();
                }
                return this._fillColor2;
            }
            set
            {
                this._fillColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// FillColor2 プロパティを永続化する必要があるかどうかを示す。
        /// </summary>
        private bool ShouldSerializeFillColor2()
        {
            return this.FillColor2 != SystemColors.GradientActiveCaption;
        }

        /// <summary>
        /// FillColor2 プロパティを既定値にリセットする。
        /// </summary>
        private void ResetFillColor2()
        {
            this.FillColor2 = SystemColors.GradientActiveCaption;
        }

        /// <summary>
        /// 線形グラデーションで塗りつぶしを行うための Brush オブジェクトを生成する。
        /// </summary>
        /// <returns>線形グラデーションされた Brush オブジェクト</returns>
        protected override Brush CreateFillBrush()
        {
            return new LinearGradientBrush(this.ClientRectangle,
                                           this.FillColor1, this.FillColor2,
                                           this.LinearGradientMode);
        }
    }
}
