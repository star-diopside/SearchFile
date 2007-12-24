using System;
using System.Collections.Generic;

namespace SearchFile
{
    /// <summary>
    /// �t�@�C�������X���b�h�Ńf�[�^�̂����Ɏg�p�����i��񋟂���
    /// </summary>
    class SearchFileWorkerInfo
    {
        private readonly object lockObject = new object();

        private bool _havingSearchResult;
        private string _directoryPath;
        private IEnumerable<string> _fileNames;
        private ICollection<FileInfo> _files;

        /// <summary>
        /// ��������f�B���N�g������ʒm���悤�Ƃ��Ă���ꍇ��false�B�������ʂ�ʒm���悤�Ƃ��Ă���ꍇ��true�B
        /// </summary>
        public bool HavingSearchResult
        {
            get
            {
                lock (lockObject)
                {
                    return _havingSearchResult;
                }
            }
            set
            {
                lock (lockObject)
                {
                    _havingSearchResult = value;
                }
            }
        }

        /// <summary>
        /// �����Ώۂ̃f�B���N�g�������擾�܂��͐ݒ肷��B
        /// </summary>
        public string DirectoryPath
        {
            get
            {
                lock (lockObject)
                {
                    return _directoryPath;
                }
            }
            set
            {
                lock (lockObject)
                {
                    _directoryPath = value;
                }
            }
        }

        /// <summary>
        /// �������ʂ̃t�@�C�������擾�܂��͐ݒ肷��B
        /// </summary>
        public IEnumerable<string> FileNames
        {
            get
            {
                lock (lockObject)
                {
                    return _fileNames;
                }
            }
            set
            {
                lock (lockObject)
                {
                    _fileNames = value;

                    _files = new List<FileInfo>();
                    foreach (string fileName in _fileNames)
                    {
                        _files.Add(new FileInfo(fileName));
                    }
                }
            }
        }

        /// <summary>
        /// �������ʂ̃t�@�C�������擾����B
        /// </summary>
        public IEnumerable<FileInfo> Files
        {
            get
            {
                lock (lockObject)
                {
                    return _files;
                }
            }
        }
    }
}