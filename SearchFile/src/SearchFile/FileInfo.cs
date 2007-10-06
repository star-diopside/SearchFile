using System;
using System.ComponentModel;
using System.Drawing;
using MyLib.WindowsShell;

namespace SearchFile
{
    /// <summary>
    /// ファイルに関する情報を取得するクラス
    /// </summary>
    class FileInfo
    {
        private System.IO.FileInfo _info;
        private Icon _smallIcon;
        private Icon _largeIcon;

        /// <summary>
        /// 指定されたファイルに関する情報を取得するクラスの新しいインスタンスを生成する
        /// </summary>
        /// <param name="fileName">新しいファイルの完全修飾名または相対ファイル名</param>
        public FileInfo(string fileName)
        {
            // 指定されたファイル名から System.IO.FileInfo クラスのインスタンスを生成する
            _info = new System.IO.FileInfo(fileName);
        }

        /// <summary>
        /// ディレクトリまたはファイルの絶対パスを取得する
        /// </summary>
        public string FullName
        {
            get
            {
                return _info.FullName;
            }
        }

        /// <summary>
        /// ファイルの名前を取得する
        /// </summary>
        public string Name
        {
            get
            {
                return _info.Name;
            }
        }

        /// <summary>
        /// ファイルの拡張子部分を表す文字列を取得する
        /// </summary>
        public string Extension
        {
            get
            {
                // 拡張子を取得する
                string ext = _info.Extension;

                // 拡張子の先頭のピリオドを削除する
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
        /// ディレクトリの絶対パスを表す文字列を取得する
        /// </summary>
        public string DirectoryName
        {
            get
            {
                return _info.DirectoryName;
            }
        }

        /// <summary>
        /// ファイルに関連付けられた小さいアイコンを取得する
        /// </summary>
        public Icon SmallIcon
        {
            get
            {
                if (_smallIcon == null)
                {
                    try
                    {
                        // ファイルに関連付けられたアイコンを取得する
                        _smallIcon = ExtractIcon.ExtractFileIcon(_info.FullName, ExtractIcon.IconSize.Small);
                    }
                    catch (Win32Exception)
                    {
                        // アイコンが取得できない場合は null を設定する
                        _smallIcon = null;
                    }
                }

                return _smallIcon;
            }
        }

        /// <summary>
        /// ファイルに関連付けられた大きいアイコンを取得する
        /// </summary>
        public Icon LargeIcon
        {
            get
            {
                if (_largeIcon == null)
                {
                    try
                    {
                        // ファイルに関連付けられたアイコンを取得する
                        _largeIcon = ExtractIcon.ExtractFileIcon(_info.FullName, ExtractIcon.IconSize.Large);
                    }
                    catch (Win32Exception)
                    {
                        // アイコンが取得できない場合は null を設定する
                        _largeIcon = null;
                    }
                }

                return _largeIcon;
            }
        }
    }
}
