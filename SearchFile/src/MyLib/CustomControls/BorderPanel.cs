using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib.CustomControls
{
    /// <summary>
    /// �P���Ȑ������E���Ƃ��ĕ\������ Panel �R���g���[����\���܂��B
    /// </summary>
    public class LineBorderPanel : Panel
    {
        private Color _lineColor = Color.Empty;

        /// <summary>
        /// BorderPanel �N���X�̐V�����C���X�^���X�����������܂��B
        /// </summary>
        public LineBorderPanel()
        {
            // �T�C�Y�ύX���ɍĕ`����s��
            this.ResizeRedraw = true;
        }

        /// <summary>
        /// ���E���̕`�掞�Ɏg�p����F���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [Category("�J�X�^���`��"), Description("���E���̕`�掞�Ɏg�p����F�ł��B")]
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
        /// LineColor�v���p�e�B���i��������K�v�����邩�ǂ����������B
        /// </summary>
        protected virtual bool ShouldSerializeLineColor()
        {
            return this.LineColor != SystemColors.ControlDark;
        }

        /// <summary>
        /// LineColor�v���p�e�B������l�Ƀ��Z�b�g����B
        /// </summary>
        protected virtual void ResetLineColor()
        {
            this.LineColor = SystemColors.ControlDark;
        }

        /// <summary>
        /// ���E���`��Ɏg�p����Pen�I�u�W�F�N�g�𐶐�����B
        /// </summary>
        /// <returns>���E���`��Ɏg�p����Pen�I�u�W�F�N�g</returns>
        protected virtual Pen CreateLinePen()
        {
            return new Pen(this.LineColor);
        }

        /// <summary>
        /// ���E����`�悵�APaint�C�x���g�𔭐�������B
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = this.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            using (Pen p = CreateLinePen())
            {
                e.Graphics.DrawRectangle(p, rect);
            }
        }
    }
}
