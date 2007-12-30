using System;
using System.Collections.Generic;
using System.Text;
using MyLib.CustomControls;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SearchFile.Utils
{
    /// <summary>
    /// LinearGradientDrawLabel オブジェクトの状態管理を行う
    /// </summary>
    internal class LinearGradientDrawLabelStateManager
    {
        /// <summary>
        /// 状態管理用の内部クラス
        /// </summary>
        internal class ManageState
        {
            private LinearGradientDrawLabel _target;
            private Color _backColor;
            private Color _fillColor1;
            private Color _fillColor2;
            private LinearGradientMode _linearGradientMode;

            public ManageState(LinearGradientDrawLabel label)
            {
                this._target = label;
                Save();
            }

            /// <summary>
            /// 現在のオブジェクト状態を保存する
            /// </summary>
            public void Save()
            {
                this._backColor = this.Target.BackColor;
                this._fillColor1 = this.Target.FillColor1;
                this._fillColor2 = this.Target.FillColor2;
                this._linearGradientMode = this.Target.LinearGradientMode;
            }

            /// <summary>
            /// 保存時点の状態にオブジェクトを復元する
            /// </summary>
            public void Restore()
            {
                this.Target.BackColor = this.BackColor;
                this.Target.FillColor1 = this.FillColor1;
                this.Target.FillColor2 = this.FillColor2;
                this.Target.LinearGradientMode = this.LinearGradientMode;
            }

            public LinearGradientDrawLabel Target
            {
                get
                {
                    return this._target;
                }
            }

            public Color BackColor
            {
                get
                {
                    return this._backColor;
                }
            }

            public Color FillColor1
            {
                get
                {
                    return this._fillColor1;
                }
            }

            public Color FillColor2
            {
                get
                {
                    return this._fillColor2;
                }
            }

            public LinearGradientMode LinearGradientMode
            {
                get
                {
                    return this._linearGradientMode;
                }
            }
        }

        private List<ManageState> manageStates = new List<ManageState>();

        /// <summary>
        /// LinearGradientDrawLabelStateManager クラスのインスタンスを生成する。
        /// </summary>
        public LinearGradientDrawLabelStateManager()
        {
        }

        /// <summary>
        /// オブジェクトを管理対象に追加する。
        /// </summary>
        /// <param name="label">オブジェクト管理対象に追加する LinearGradientDrawLabel オブジェクト</param>
        public void Add(LinearGradientDrawLabel label)
        {
            this.manageStates.Add(new ManageState(label));
        }

        /// <summary>
        /// すべてのオブジェクトを管理対象から削除する。
        /// </summary>
        public void Clear()
        {
            this.manageStates.Clear();
        }

        /// <summary>
        /// すべてのオブジェクトの状態を復元する。
        /// </summary>
        public void RestoreAll()
        {
            foreach (ManageState target in this.manageStates)
            {
                target.Restore();
            }
        }
    }
}
