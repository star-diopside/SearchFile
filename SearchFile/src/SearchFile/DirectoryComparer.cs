using System;
using System.Globalization;
using System.IO;

namespace SearchFile
{
    class DirectoryComparer : StringComparer
    {
        /// <summary>
        /// DirectoryComparer クラスの新しいインスタンスを初期化する。
        /// </summary>
        public DirectoryComparer()
            : base()
        {
        }

        /// <summary>
        /// DirectoryComparer クラスの新しいインスタンスを初期化する。
        /// </summary>
        /// <param name="ignoreCase">大文字と小文字を区別して比較するかどうかを示す値。</param>
        public DirectoryComparer(bool ignoreCase)
            : base(ignoreCase)
        {
        }

        /// <summary>
        /// DirectoryComparer クラスの新しいインスタンスを初期化する。
        /// </summary>
        /// <param name="ignoreCase">大文字と小文字を区別して比較するかどうかを示す値。</param>
        /// <param name="culture">カルチャ固有の比較情報を提供する CultureInfo オブジェクト。</param>
        public DirectoryComparer(bool ignoreCase, CultureInfo culture)
            : base(ignoreCase, culture)
        {
        }

        /// <summary>
        /// 指定した文字列を比較する。
        /// </summary>
        /// <param name="x">第 1 の文字列。</param>
        /// <param name="y">第 2 の文字列。</param>
        /// <returns>2 つの文字列の関係を示す 32 ビット符号付き整数。</returns>
        /// <exception cref="System.ArgumentNullException">x または y に null が指定された場合</exception>
        /// <exception cref="System.ArgumentException">x または y に空の文字列が指定された場合</exception>
        public override int Compare(string x, string y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }

            if (x.Length == 0 || y.Length == 0)
            {
                throw new ArgumentException();
            }

            string dirX, dirY;

            if (x[x.Length - 1] == Path.DirectorySeparatorChar)
            {
                dirX = x;
            }
            else
            {
                dirX = x + Path.DirectorySeparatorChar;
            }

            if (y[y.Length - 1] == Path.DirectorySeparatorChar)
            {
                dirY = y;
            }
            else
            {
                dirY = y + Path.DirectorySeparatorChar;
            }

            return base.Compare(dirX, dirY);
        }
    }
}
