using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace SearchFile
{
    /// <summary>
    /// �������r���s���I�u�W�F�N�g��\���N���X
    /// </summary>
    class StringComparer : IComparer, IComparer<string>
    {
        private bool _ignoreCase;
        private CultureInfo _culture;

        /// <summary>
        /// StringComparer �N���X�̐V�����C���X�^���X������������B
        /// </summary>
        public StringComparer()
        {
            this._ignoreCase = false;
            this._culture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// StringComparer �N���X�̐V�����C���X�^���X������������B
        /// </summary>
        /// <param name="ignoreCase">�啶���Ə���������ʂ��Ĕ�r���邩�ǂ����������l�B</param>
        public StringComparer(bool ignoreCase)
        {
            this._ignoreCase = ignoreCase;
            this._culture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// StringComparer �N���X�̐V�����C���X�^���X������������B
        /// </summary>
        /// <param name="ignoreCase">�啶���Ə���������ʂ��Ĕ�r���邩�ǂ����������l�B</param>
        /// <param name="culture">�J���`���ŗL�̔�r����񋟂��� CultureInfo �I�u�W�F�N�g�B</param>
        public StringComparer(bool ignoreCase, CultureInfo culture)
        {
            this._ignoreCase = ignoreCase;

            if (culture == null)
            {
                this._culture = CultureInfo.CurrentCulture;
            }
            else
            {
                this._culture = culture;
            }
        }

        /// <summary>
        /// �啶���Ə���������ʂ��Ĕ�r���邩�ǂ����������l���擾�܂��͐ݒ肷��B
        /// </summary>
        public bool IgnoreCase
        {
            get
            {
                return this._ignoreCase;
            }
            set
            {
                this._ignoreCase = value;
            }
        }

        /// <summary>
        /// �J���`���ŗL�̔�r����񋟂��� CultureInfo �I�u�W�F�N�g���擾�܂��͐ݒ肷��B
        /// </summary>
        public CultureInfo Culture
        {
            get
            {
                return this._culture;
            }
            set
            {
                if (value == null)
                {
                    this._culture = CultureInfo.CurrentCulture;
                }
                else
                {
                    this._culture = value;
                }
            }
        }

        /// <summary>
        /// �w�肵����������r����B
        /// </summary>
        /// <param name="x">�� 1 �̕�����B</param>
        /// <param name="y">�� 2 �̕�����B</param>
        /// <returns>2 �̕�����̊֌W������ 32 �r�b�g�����t�������B</returns>
        public virtual int Compare(string x, string y)
        {
            return string.Compare(x, y, _ignoreCase, _culture);
        }

        /// <summary>
        /// �w�肵����������r����B
        /// </summary>
        /// <param name="x">�� 1 �̕�����B</param>
        /// <param name="y">�� 2 �̕�����B</param>
        /// <returns>2 �̕�����̊֌W������ 32 �r�b�g�����t�������B</returns>
        int IComparer.Compare(object x, object y)
        {
            return Compare((string)x, (string)y);
        }
    }
}
