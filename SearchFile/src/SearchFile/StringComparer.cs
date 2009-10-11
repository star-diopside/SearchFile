using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace SearchFile
{
    /// <summary>
    /// 文字列比較を行うオブジェクトを表すクラス
    /// </summary>
    class StringComparer : IComparer, IComparer<string>
    {
        private bool _ignoreCase;
        private CultureInfo _culture;

        /// <summary>
        /// StringComparer クラスの新しいインスタンスを初期化する。
        /// </summary>
        public StringComparer()
        {
            this._ignoreCase = false;
            this._culture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// StringComparer クラスの新しいインスタンスを初期化する。
        /// </summary>
        /// <param name="ignoreCase">大文字と小文字を区別して比較するかどうかを示す値。</param>
        public StringComparer(bool ignoreCase)
        {
            this._ignoreCase = ignoreCase;
            this._culture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// StringComparer クラスの新しいインスタンスを初期化する。
        /// </summary>
        /// <param name="ignoreCase">大文字と小文字を区別して比較するかどうかを示す値。</param>
        /// <param name="culture">カルチャ固有の比較情報を提供する CultureInfo オブジェクト。</param>
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
        /// 大文字と小文字を区別して比較するかどうかを示す値を取得または設定する。
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
        /// カルチャ固有の比較情報を提供する CultureInfo オブジェクトを取得または設定する。
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
        /// 指定した文字列を比較する。
        /// </summary>
        /// <param name="x">第 1 の文字列。</param>
        /// <param name="y">第 2 の文字列。</param>
        /// <returns>2 つの文字列の関係を示す 32 ビット符号付き整数。</returns>
        public virtual int Compare(string x, string y)
        {
            return string.Compare(x, y, _ignoreCase, _culture);
        }

        /// <summary>
        /// 指定した文字列を比較する。
        /// </summary>
        /// <param name="x">第 1 の文字列。</param>
        /// <param name="y">第 2 の文字列。</param>
        /// <returns>2 つの文字列の関係を示す 32 ビット符号付き整数。</returns>
        int IComparer.Compare(object x, object y)
        {
            return Compare((string)x, (string)y);
        }
    }
}
