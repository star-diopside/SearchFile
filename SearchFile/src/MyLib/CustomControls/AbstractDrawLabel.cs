using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyLib.CustomControls
{
    /// <summary>
    /// �J�X�^���̓h��Ԃ����s�� Label �R���g���[���̊�{�N���X���`���܂��B
    /// </summary>
    public abstract class AbstractDrawLabel : Label
    {
        /// <summary>
        /// AbstractDrawLabel �N���X�̐V�����C���X�^���X�����������܂��B
        /// </summary>
        public AbstractDrawLabel()
        {
        }

        /// <summary>
        /// �h��Ԃ��Ɏg�p����Brush�I�u�W�F�N�g�𐶐�����B
        /// </summary>
        protected abstract Brush CreateFillBrush();

        /// <summary>
        /// �h��Ԃ����s���APaint�C�x���g�𔭐�������B
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
