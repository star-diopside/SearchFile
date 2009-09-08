using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace SearchFile
{
    /// <summary>
    /// �ʂ̃X���b�h�Ńt�@�C�����������s����B
    /// </summary>
    internal class BackgroundSearchFile : BackgroundWorker
    {
        // �X���b�h�̃��b�N���Ɏg�p����I�u�W�F�N�g�̃C���X�^���X
        private readonly object lockObject = new object();

        // �������s���f�B���N�g���p�X
        private string _searchPath = string.Empty;

        // �������s���t�@�C�����̐��K�\��
        private Regex _searchPattern = null;

        // �����͈͂��w�肷�� SearchOption �l
        private SearchOption _searchOption = SearchOption.TopDirectoryOnly;

        /// <summary>
        /// �������s���f�B���N�g���̎擾�܂��͐ݒ���s���B
        /// </summary>
        [Browsable(true)]
        public string SearchPath
        {
            get
            {
                return this._searchPath;
            }
            set
            {
                if (this.IsBusy)
                {
                    throw new InvalidOperationException();
                }

                lock (lockObject)
                {
                    this._searchPath = value;
                }
            }
        }

        /// <summary>
        /// SearchPath �v���p�e�B���i��������K�v�����邩�ǂ����������B
        /// </summary>
        internal virtual bool ShouldSerializeSearchPath()
        {
            return this.SearchPath == null || this.SearchPath.Length != 0;
        }

        /// <summary>
        /// SearchPath �v���p�e�B������l�Ƀ��Z�b�g����B
        /// </summary>
        public virtual void ResetSearchPath()
        {
            this.SearchPath = string.Empty;
        }

        /// <summary>
        /// �������s���t�@�C�����̐��K�\���̎擾�܂��͐ݒ���s���B
        /// </summary>
        [Browsable(true), DefaultValue(null)]
        public Regex SearchPattern
        {
            get
            {
                return this._searchPattern;
            }
            set
            {
                if (this.IsBusy)
                {
                    throw new InvalidOperationException();
                }

                lock (lockObject)
                {
                    this._searchPattern = value;
                }
            }
        }

        /// <summary>
        /// ��������ɂ��ׂẴT�u�f�B���N�g�����܂߂�̂��A�܂��͌��݂̃f�B���N�g���݂̂��܂߂�̂����w�肷�� SearchOption �l�̎擾�܂��͐ݒ���s���B
        /// </summary>
        [Browsable(true), DefaultValue(SearchOption.TopDirectoryOnly)]
        public SearchOption SearchOption
        {
            get
            {
                return this._searchOption;
            }
            set
            {
                if (this.IsBusy)
                {
                    throw new InvalidOperationException();
                }

                lock (lockObject)
                {
                    this._searchOption = value;
                }
            }
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            lock (lockObject)
            {
                base.OnDoWork(e);

                // �ċA�I�Ƀt�@�C���������s��
                e.Result = RecursiveSearchFile(this.SearchPath, this.SearchPattern, this.SearchOption);
            }
        }

        /// <summary>
        /// �ċA�I�Ƀt�@�C���������s���B
        /// </summary>
        /// <param name="path">��������f�B���N�g��</param>
        /// <param name="pattern">path ���̃t�@�C�����ƑΉ������鐳�K�\��</param>
        /// <param name="searchOption">��������ɂ��ׂẴT�u�f�B���N�g�����܂߂�̂��A�܂��͌��݂̃f�B���N�g���݂̂��܂߂�̂����w�肷�� SearchOption �l�� 1 ��</param>
        /// <returns>����������Ɉ�v��������</returns>
        protected int RecursiveSearchFile(string path, Regex pattern, SearchOption searchOption)
        {
            int hitCount = 0;

            lock (lockObject)
            {
                try
                {
                    // path �� null ���󕶎���̏ꍇ�͗�O���X���[����
                    if (path == null)
                    {
                        throw new ArgumentNullException();
                    }
                    else if (path.Length == 0)
                    {
                        throw new ArgumentException();
                    }

                    // �f�B���N�g�����̍Ō�Ƀf�B���N�g����؂蕶����ǉ�����
                    // �i�f�B���N�g���̖������S�p�X�y�[�X�̏ꍇ�̑Ή��j
                    if (path[path.Length - 1] != Path.DirectorySeparatorChar)
                    {
                        path += Path.DirectorySeparatorChar;
                    }

                    // ��������f�B���N�g������ʒm����
                    this.ReportProgress(0, new SearchResultDirectory(path));

                    // ProgressChanged �C�x���g�ł̏�������������܂őҋ@����
                    Monitor.Wait(lockObject);

                    // �t�@�C�������擾����
                    List<string> fileNames = new List<string>();

                    foreach (string fileName in Directory.GetFiles(path))
                    {
                        if (pattern.IsMatch(Path.GetFileName(fileName)))
                        {
                            fileNames.Add(fileName);
                        }
                    }

                    hitCount += fileNames.Count;

                    // �t�@�C�������������ꍇ
                    if (fileNames.Count > 0)
                    {
                        // �������ʂ�ʒm����
                        this.ReportProgress(0, new SearchResultFiles(fileNames));

                        // ProgressChanged �C�x���g�ł̏�������������܂őҋ@����
                        Monitor.Wait(lockObject);
                    }

                    // �ċA�I�Ƀf�B���N�g������������
                    if (searchOption == SearchOption.AllDirectories)
                    {
                        foreach (string directory in Directory.GetDirectories(path))
                        {
                            // �L�����Z���v�����������ꍇ�͌J��Ԃ����I������
                            if (this.CancellationPending)
                            {
                                break;
                            }

                            hitCount += RecursiveSearchFile(directory, pattern, searchOption);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
            }

            return hitCount;
        }

        protected override void OnProgressChanged(ProgressChangedEventArgs e)
        {
            lock (lockObject)
            {
                try
                {
                    base.OnProgressChanged(e);
                }
                finally
                {
                    Monitor.PulseAll(lockObject);
                }
            }
        }
    }
}
