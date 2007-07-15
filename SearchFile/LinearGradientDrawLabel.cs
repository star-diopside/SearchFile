using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyLib.CustomControls
{
    /// <summary>
    /// ���`�O���f�[�V�����œh��Ԃ����s�� Label �R���g���[����\���܂��B
    /// </summary>
    public class LinearGradientDrawLabel : AbstractDrawLabel
    {
        private LinearGradientMode _linearGradientMode = LinearGradientMode.Horizontal;
        private Color _fillColor1 = Color.Empty;
        private Color _fillColor2 = Color.Empty;

        /// <summary>
        /// ���`�O���f�[�V�����̕������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [Category("�J�X�^���`��"), Description("���`�O���f�[�V�����̕����ł��B")]
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
        /// LinearGradientMode �v���p�e�B���i��������K�v�����邩�ǂ����������B
        /// </summary>
        private bool ShouldSerializeLinearGradientMode()
        {
            return this.LinearGradientMode != LinearGradientMode.Horizontal;
        }

        /// <summary>
        /// LinearGradientMode �v���p�e�B������l�Ƀ��Z�b�g����B
        /// </summary>
        private void ResetLinearGradientMode()
        {
            this.LinearGradientMode = LinearGradientMode.Horizontal;
        }

        /// <summary>
        /// �O���f�[�V�����̊J�n�F���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [Category("�J�X�^���`��"), Description("�h��Ԃ����s�����߂Ɏg�p����O���f�[�V�����̊J�n�F�ł��B")]
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
        /// FillColor1 �v���p�e�B���i��������K�v�����邩�ǂ����������B
        /// </summary>
        private bool ShouldSerializeFillColor1()
        {
            return this.FillColor1 != SystemColors.ActiveCaption;
        }

        /// <summary>
        /// FillColor1 �v���p�e�B������l�Ƀ��Z�b�g����B
        /// </summary>
        private void ResetFillColor1()
        {
            this.FillColor1 = SystemColors.ActiveCaption;
        }

        /// <summary>
        /// �O���f�[�V�����̏I���F���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        [Category("�J�X�^���`��"), Description("�h��Ԃ����s�����߂Ɏg�p����O���f�[�V�����̏I���F�ł��B")]
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
        /// FillColor2 �v���p�e�B���i��������K�v�����邩�ǂ����������B
        /// </summary>
        private bool ShouldSerializeFillColor2()
        {
            return this.FillColor2 != SystemColors.GradientActiveCaption;
        }

        /// <summary>
        /// FillColor2 �v���p�e�B������l�Ƀ��Z�b�g����B
        /// </summary>
        private void ResetFillColor2()
        {
            this.FillColor2 = SystemColors.GradientActiveCaption;
        }

        /// <summary>
        /// ���`�O���f�[�V�����œh��Ԃ����s�����߂� Brush �I�u�W�F�N�g�𐶐�����B
        /// </summary>
        /// <returns>���`�O���f�[�V�������ꂽ Brush �I�u�W�F�N�g</returns>
        protected override Brush CreateFillBrush()
        {
            return new LinearGradientBrush(this.ClientRectangle,
                                           this.FillColor1, this.FillColor2,
                                           this.LinearGradientMode);
        }
    }
}
