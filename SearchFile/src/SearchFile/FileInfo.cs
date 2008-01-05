using System;
using System.ComponentModel;
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
        private readonly WeakReference _smallIconRef = new WeakReference(null);
        private readonly WeakReference _largeIconRef = new WeakReference(null);

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
                // �g���q���擾����
                string ext = _info.Extension;

                // �g���q�̐擪�̃s���I�h���폜����
                if (!string.IsNullOrEmpty(ext) && ext[0] == '.')
                {
                    return ext.Substring(1);
                }
                else
                {
                    return ext;
                }
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
                Icon smallIcon = this._smallIconRef.Target as Icon;

                if (smallIcon == null)
                {
                    try
                    {
                        // �t�@�C���Ɋ֘A�t����ꂽ�A�C�R�����擾����
                        smallIcon = ExtractIcon.ExtractFileIcon(_info.FullName, ExtractIcon.IconSize.Small);
                    }
                    catch (Win32Exception)
                    {
                        // �A�C�R�����擾�ł��Ȃ��ꍇ�� null ��ݒ肷��
                        smallIcon = null;
                    }

                    this._smallIconRef.Target = smallIcon;
                }

                return smallIcon;
            }
        }

        /// <summary>
        /// �t�@�C���Ɋ֘A�t����ꂽ�傫���A�C�R�����擾����
        /// </summary>
        public Icon LargeIcon
        {
            get
            {
                Icon largeIcon = this._largeIconRef.Target as Icon;

                if (largeIcon == null)
                {
                    try
                    {
                        // �t�@�C���Ɋ֘A�t����ꂽ�A�C�R�����擾����
                        largeIcon = ExtractIcon.ExtractFileIcon(_info.FullName, ExtractIcon.IconSize.Large);
                    }
                    catch (Win32Exception)
                    {
                        // �A�C�R�����擾�ł��Ȃ��ꍇ�� null ��ݒ肷��
                        largeIcon = null;
                    }

                    this._largeIconRef.Target = largeIcon;
                }

                return largeIcon;
            }
        }
    }
}
