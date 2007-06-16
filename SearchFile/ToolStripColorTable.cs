using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib.CustomControls
{
    /// <summary>
    /// ToolStripProfessionalRenderer の表示要素に使用する色を用意する
    /// </summary>
    public class ToolStripColorTable : ProfessionalColorTable
    {
        /// <summary>
        /// アルファブレンドした色を取得する
        /// </summary>
        /// <param name="begin">開始色を示す Color 構造体</param>
        /// <param name="end">終了色を示す Color 構造体</param>
        /// <param name="alpha">アルファ値 (0.0～1.0)</param>
        /// <returns>アルファブレンドした色を示す Color 構造体</returns>
        protected static Color GetAlphaBlendedColor(Color begin, Color end, float alpha)
        {
            if (alpha < 0.0 || alpha > 1.0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int a = (int)(begin.A * alpha + end.A * (1.0 - alpha));
            int r = (int)(begin.R * alpha + end.R * (1.0 - alpha));
            int g = (int)(begin.G * alpha + end.G * (1.0 - alpha));
            int b = (int)(begin.B * alpha + end.B * (1.0 - alpha));

            return Color.FromArgb(a, r, g, b);
        }

        public override Color ToolStripGradientBegin
        {
            get
            {
                return GetAlphaBlendedColor(SystemColors.ControlLight, SystemColors.ControlLightLight, 0.25f);
            }
        }

        public override Color ToolStripGradientMiddle
        {
            get
            {
                return GetAlphaBlendedColor(this.ToolStripGradientBegin, this.ToolStripGradientEnd, 0.7f);
            }
        }

        public override Color ToolStripGradientEnd
        {
            get
            {
                return ControlPaint.LightLight(this.ToolStripBorder);
            }
        }

        public override Color ToolStripBorder
        {
            get
            {
                return SystemColors.ControlDark;
            }
        }

        public override Color OverflowButtonGradientBegin
        {
            get
            {
                return ControlPaint.LightLight(SystemColors.ControlDark);
            }
        }

        public override Color OverflowButtonGradientMiddle
        {
            get
            {
                return GetAlphaBlendedColor(this.OverflowButtonGradientBegin, this.OverflowButtonGradientEnd, 0.7f);
            }
        }

        public override Color OverflowButtonGradientEnd
        {
            get
            {
                return SystemColors.ControlDarkDark;
            }
        }

        public override Color SeparatorLight
        {
            get
            {
                return SystemColors.ControlLightLight;
            }
        }

        public override Color SeparatorDark
        {
            get
            {
                return SystemColors.ControlDark;
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return SystemColors.ControlDarkDark;
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return base.ButtonSelectedHighlightBorder;
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return SystemColors.ControlLightLight;
            }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get
            {
                return GetAlphaBlendedColor(this.MenuItemPressedGradientBegin, this.MenuItemPressedGradientEnd, 0.3f);
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return GetAlphaBlendedColor(this.ImageMarginGradientEnd, SystemColors.Window, 0.5f);
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return base.ButtonSelectedHighlight;
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return this.MenuItemSelected;
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return this.MenuItemSelected;
            }
        }

        public override Color MenuStripGradientBegin
        {
            get
            {
                return SystemColors.Control;
            }
        }

        public override Color MenuStripGradientEnd
        {
            get
            {
                return GetAlphaBlendedColor(SystemColors.ControlLight, SystemColors.ControlLightLight, 0.25f);
            }
        }

        public override Color ToolStripPanelGradientBegin
        {
            get
            {
                return this.MenuStripGradientBegin;
            }
        }

        public override Color ToolStripPanelGradientEnd
        {
            get
            {
                return this.MenuStripGradientEnd;
            }
        }

        public override Color StatusStripGradientBegin
        {
            get
            {
                return this.MenuStripGradientBegin;
            }
        }

        public override Color StatusStripGradientEnd
        {
            get
            {
                return this.MenuStripGradientEnd;
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return SystemColors.ControlLightLight;
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return GetAlphaBlendedColor(this.ImageMarginGradientBegin, this.ImageMarginGradientEnd, 0.5f);
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return ControlPaint.LightLight(SystemColors.ControlDark);
            }
        }

        public override Color GripDark
        {
            get
            {
                return SystemColors.ControlDark;
            }
        }

        public override Color GripLight
        {
            get
            {
                return SystemColors.ControlLightLight;
            }
        }

        public override Color CheckBackground
        {
            get
            {
                return GetAlphaBlendedColor(base.ButtonCheckedHighlight, SystemColors.Window, 0.5f);
            }
        }

        public override Color CheckSelectedBackground
        {
            get
            {
                return base.ButtonPressedHighlight;
            }
        }

        public override Color CheckPressedBackground
        {
            get
            {
                return base.ButtonPressedHighlight;
            }
        }

        public override Color ButtonSelectedGradientBegin
        {
            get
            {
                return this.ButtonSelectedHighlight;
            }
        }

        public override Color ButtonSelectedGradientMiddle
        {
            get
            {
                return this.ButtonSelectedHighlight;
            }
        }

        public override Color ButtonSelectedGradientEnd
        {
            get
            {
                return this.ButtonSelectedHighlight;
            }
        }

        public override Color ButtonSelectedBorder
        {
            get
            {
                return this.ButtonSelectedHighlightBorder;
            }
        }

        public override Color ButtonPressedGradientBegin
        {
            get
            {
                return this.ButtonPressedHighlight;
            }
        }

        public override Color ButtonPressedGradientMiddle
        {
            get
            {
                return this.ButtonPressedHighlight;
            }
        }

        public override Color ButtonPressedGradientEnd
        {
            get
            {
                return this.ButtonPressedHighlight;
            }
        }

        public override Color ButtonPressedBorder
        {
            get
            {
                return this.ButtonPressedHighlightBorder;
            }
        }

        public override Color ButtonCheckedGradientBegin
        {
            get
            {
                return this.ButtonCheckedHighlight;
            }
        }

        public override Color ButtonCheckedGradientMiddle
        {
            get
            {
                return this.ButtonCheckedHighlight;
            }
        }

        public override Color ButtonCheckedGradientEnd
        {
            get
            {
                return this.ButtonCheckedHighlight;
            }
        }

        public override Color ButtonCheckedHighlight
        {
            get
            {
                return this.CheckBackground;
            }
        }
    }
}
