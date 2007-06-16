using System;
using System.Drawing;
using MyLib.WindowsShell;

namespace SearchFile
{
    /// <summary>
    /// �t�@�C���Ɋւ�������擾����N���X
    /// </summary>
    class FileInfo
    {
        private System.IO.FileInfo _info;
        private Icon _smallIcon;
        private Icon _largeIcon;

        /// <summary>
        /// �w�肳�ꂽ�t�@�C���Ɋւ�������擾����N���X�̐V�����C���X�^���X�𐶐�����
        /// </summary>
        /// <param name="fileName">�V�����t�@�C���̊��S�C�����܂��͑��΃t�@�C����</param>
        public FileInfo(string fileName)
        {
            // �w�肳�ꂽ�t�@�C�������� System.IO.FileInfo �N���X�̃C���X�^���X�𐶐�����
            _info = new System.IO.FileInfo(fileName);
        }

        /// <summary>
        /// �f�B���N�g���܂��̓t�@�C���̐�΃p�X���擾����
        /// </summary>
        public string FullName
        {
            get
            {
                return _info.FullName;
            }
        }

        /// <summary>
        /// �t�@�C���̖��O���擾����
        /// </summary>
        public string Name
        {
            get
            {
                return _info.Name;
            }
        }

        /// <summary>
        /// �t�@�C���̊g���q������\����������擾����
        /// </summary>
        public string Extension
        {
            get
            {
                return _info.Extension;
            }
        }

        /// <summary>
        /// �f�B���N�g���̐�΃p�X��\����������擾����
        /// </summary>
        public string DirectoryName
        {
            get
            {
                return _info.DirectoryName;
            }
        }

        /// <summary>
        /// �t�@�C���Ɋ֘A�t����ꂽ�������A�C�R�����擾����
        /// </summary>
        public Icon SmallIcon
        {
            get
            {
                if (_smallIcon == null)
                {
                    try
                    {
                        // �t�@�C���Ɋ֘A�t����ꂽ�A�C�R�����擾����
                        _smallIcon = ExtractIcon.ExtractFileIcon(_info.FullName, ExtractIcon.IconSize.Small);
                    }
                    catch (Exception)
                    {
                        // �A�C�R�����擾�ł��Ȃ��ꍇ�� null ��ݒ肷��
                        _smallIcon = null;
                    }
                }

                return _smallIcon;
            }
        }

        /// <summary>
        /// �t�@�C���Ɋ֘A�t����ꂽ�傫���A�C�R�����擾����
        /// </summary>
        public Icon LargeIcon
        {
            get
            {
                if (_largeIcon == null)
                {
                    try
                    {
                        // �t�@�C���Ɋ֘A�t����ꂽ�A�C�R�����擾����
                        _largeIcon = ExtractIcon.ExtractFileIcon(_info.FullName, ExtractIcon.IconSize.Large);
                    }
                    catch (Exception)
                    {
                        // �A�C�R�����擾�ł��Ȃ��ꍇ�� null ��ݒ肷��
                        _largeIcon = null;
                    }
                }

                return _largeIcon;
            }
        }
    }
}
