using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MyLib.WindowsShell;
using MyLib.CustomControls;

namespace SearchFile
{
    public partial class SearchFileForm : Form
    {
        // リストビューのソート時に使用するインスタンス
        private ListViewItemSorter listViewFileNameSorter;

        // 検索時にリストビューの列幅を自動調整するかどうかを示す値
        private bool _autoColumnWidth = true;

        public SearchFileForm()
        {
            InitializeComponent();

            // リストビューのソートに関する設定
            listViewFileNameSorter = new ListViewItemSorter();
            listViewFileNameSorter.Column = 2;
            listViewFileNameSorter.SortOrder = SortOrder.Ascending;
            StringComparer ignoreCaseComparer = new StringComparer(false);
            listViewFileNameSorter.Comparers.Add(ignoreCaseComparer);
            listViewFileNameSorter.Comparers.Add(ignoreCaseComparer);
            listViewFileNameSorter.Comparers.Add(ignoreCaseComparer);
            listViewFileName.ListViewItemSorter = listViewFileNameSorter;
            listViewFileName.SetHeaderSortArrowStyle(
                listViewFileNameSorter.Column,
                SelectHeaderSortArrows(listViewFileNameSorter.SortOrder));

            // 検索ディレクトリにシステムディレクトリのルートディレクトリを設定する
            textDirectory.Text = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Application.Idle += this.ApplicationIdleEvent;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Idle -= this.ApplicationIdleEvent;
        }

        /// <summary>
        /// アプリケーションのアイドル時に発生するイベントを処理するメソッド
        /// </summary>
        private void ApplicationIdleEvent(object sender, EventArgs e)
        {
            try
            {
                // リストビューの状態に応じてコピーの可否を UI に反映する
                toolEditResultCopy.Enabled = (listViewFileName.Items.Count != 0);

                // アクティブコントロールを取得する
                TextBoxBase activeControl = GetActiveInnerControl() as TextBoxBase;

                if (activeControl != null)
                {
                    // アクティブコントロールが TextBoxBase の場合
                    toolEditCut.Enabled = toolEditCopy.Enabled = (activeControl.SelectionLength > 0);
                    toolEditPaste.Enabled = Clipboard.ContainsText();
                }
                else
                {
                    toolEditCut.Enabled = false;
                    toolEditCopy.Enabled = false;
                    toolEditPaste.Enabled = false;
                }
            }
            catch (Exception)
            {
                toolEditResultCopy.Enabled = false;
                toolEditCut.Enabled = false;
                toolEditCopy.Enabled = false;
                toolEditPaste.Enabled = false;
            }
        }

        /// <summary>
        /// アクティブコントロールを取得する。ContainerControl がアクティブの場合には再帰的に内部のアクティブコントロールを取得する。
        /// </summary>
        /// <returns>一番内部のアクティブコントロール</returns>
        protected Control GetActiveInnerControl()
        {
            Control activeControl = this.ActiveControl;

            while (activeControl is ContainerControl)
            {
                activeControl = ((ContainerControl)activeControl).ActiveControl;
            }

            return activeControl;
        }

        /// <summary>
        /// フォームを閉じるイベントを処理するメソッド
        /// </summary>
        private void FormCloseEvent(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textDirectory_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = this.buttonDirectory;
        }

        private void textDirectory_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.buttonSearch;
        }

        /// <summary>
        /// フォルダ選択イベントを処理するメソッド
        /// </summary>
        private void SelectDirectoryEvent(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = global::SearchFile.Properties.Resources.FolderBrowserDialogDescription;
            dialog.SelectedPath = textDirectory.Text;
            dialog.ShowNewFolderButton = false;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                textDirectory.Text = dialog.SelectedPath;
            }
        }

        /// <summary>
        /// ファイル検索結果をクリアするイベントを処理するメソッド
        /// </summary>
        private void FileListClearEvent(object sender, EventArgs e)
        {
            // 検索結果をクリアする
            if (ClearFileList())
            {
                statusLabelSearching.Text = global::SearchFile.Properties.Resources.ClearFilesMessage;
            }
        }

        /// <summary>
        /// ファイル検索結果をクリアする
        /// </summary>
        /// <returns>検索結果がクリアされた場合はtrue。キャンセルされた場合はfalse。</returns>
        private bool ClearFileList()
        {
            if (listViewFileName.Items.Count == 0)
            {
                return true;
            }
            else if (MessageBox.Show(this, global::SearchFile.Properties.Resources.QuestionFilesClearMessage,
                                     global::SearchFile.Properties.Resources.QuestionDialogCaption,
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return false;
            }
            else
            {
                listViewFileName.Items.Clear();
                imageFileList.Images.Clear();
                return true;
            }
        }

        /// <summary>
        /// ファイル検索の実行・中止を実行するイベントを処理するメソッド
        /// </summary>
        private void SearchFileEvent(object sender, EventArgs e)
        {
            if (backgroundSearchFile.IsBusy)
            {
                // 検索処理の中止を要求する
                backgroundSearchFile.CancelAsync();

                // ボタンを不活性にする
                buttonSearch.Enabled = false;
            }
            else
            {
                try
                {
                    string directoryName = textDirectory.Text.Trim();
                    string fileName = textFile.Text.Trim();

                    // 必要なデータが入力されているかどうかをチェックする
                    if (!Directory.Exists(directoryName))
                    {
                        throw new ArgumentException(global::SearchFile.Properties.Resources.DirectoryNotFoundMessage);
                    }
                    else if (fileName.Length == 0)
                    {
                        throw new ArgumentException(global::SearchFile.Properties.Resources.NotInputFileNameMessage);
                    }

                    // 検索ファイル名のチェックを行う
                    if (radioWildcard.Checked)
                    {
                        foreach (char c in Path.GetInvalidFileNameChars())
                        {
                            if (c == '?' || c == '*')
                            {
                                continue;
                            }

                            if (fileName.Contains(c.ToString()))
                            {
                                throw new ArgumentException(global::SearchFile.Properties.Resources.UsingInvalidFileNameMessage);
                            }
                        }
                    }
                    else if (radioRegex.Checked)
                    {
                        foreach (char c in Path.GetInvalidFileNameChars())
                        {
                            if (fileName.Contains(Regex.Escape(c.ToString())))
                            {
                                throw new ArgumentException(global::SearchFile.Properties.Resources.UsingInvalidFileNameMessage);
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException(global::SearchFile.Properties.Resources.NotSelectSearchPatternMessage);
                    }

                    // 現在のファイルリストをクリアする
                    if (!ClearFileList())
                    {
                        return;
                    }

                    // ファイルパターンを表現する正規表現を生成する
                    string patternString;
                    Regex pattern;

                    if (radioWildcard.Checked)
                    {
                        // ワイルドカードパターン文字列を正規表現パターン文字列に変換する
                        patternString = WildcardToRegex(fileName, true);
                    }
                    else if (radioRegex.Checked)
                    {
                        patternString = fileName;
                    }
                    else
                    {
                        throw new ArgumentException(global::SearchFile.Properties.Resources.NotSelectSearchPatternMessage);
                    }

                    pattern = new Regex(patternString, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

                    // ファイルを検索する
                    EnumerateFiles(directoryName, pattern, SearchOption.AllDirectories);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, ex.Message, global::SearchFile.Properties.Resources.ErrorDialogCaption,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// ファイルを検索してリストビューに列挙する
        /// </summary>
        /// <param name="path">検索するディレクトリ</param>
        /// <param name="pattern">path 内のファイル名と対応させる正規表現</param>
        /// <param name="searchOption">検索操作にすべてのサブディレクトリを含めるのか、または現在のディレクトリのみを含めるのかを指定する SearchOption 値の 1 つ</param>
        private void EnumerateFiles(string path, Regex pattern, SearchOption searchOption)
        {
            try
            {
                // 別スレッドでファイル検索を実行する
                backgroundSearchFile.SearchPath = path;
                backgroundSearchFile.SearchPattern = pattern;
                backgroundSearchFile.SearchOption = searchOption;
                backgroundSearchFile.RunWorkerAsync();

                // 検索中であることを UI に反映する
                buttonSearch.Text = global::SearchFile.Properties.Settings.Default.buttonSearch_StopText;
                buttonClear.Enabled = false;
                menuFileClear.Enabled = false;
                toolFileClear.Enabled = false;
                contextFileListClear.Enabled = false;
                statusLabelSearching.Text = string.Empty;
                statusProgressSearching.Style = ProgressBarStyle.Marquee;
                statusProgressSearching.Visible = true;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(this, ex.Message, global::SearchFile.Properties.Resources.ErrorDialogCaption,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundSearchFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.Assert(e.UserState is SearchFileWorkerInfo);
            SearchFileWorkerInfo info = e.UserState as SearchFileWorkerInfo;

            try
            {
                if (info.HavingSearchResult)
                {
                    // リストビューの描画を中断する
                    listViewFileName.BeginUpdate();

                    // 検索結果のアイテムを追加する
                    foreach (FileInfo file in info.Files)
                    {
                        // ファイルアイコンを取得し、イメージリストに追加する
                        if (file.SmallIcon != null)
                        {
                            imageFileList.Images.Add(file.FullName, file.SmallIcon);
                        }

                        // リストビューに項目を追加する
                        ListViewItem item = new ListViewItem();

                        if (file.SmallIcon != null)
                        {
                            item.ImageKey = file.FullName;
                        }
                        item.Text = Path.GetFileName(file.Name);
                        item.SubItems.Add(file.Extension);
                        item.SubItems.Add(file.DirectoryName);

                        listViewFileName.Items.Add(item);
                    }

                    // リストビューの描画を再開する
                    listViewFileName.EndUpdate();
                }
                else
                {
                    // ステータスバーに検索中フォルダの情報を表示する
                    statusLabelSearching.Text = string.Format(global::SearchFile.Properties.Resources.SearchingDirectoryMessage, info.DirectoryPath);
                }
            }
            catch (Exception ex)
            {
                string message;

                message = global::SearchFile.Properties.Resources.UIErrorQuestion +
                          Environment.NewLine +
                          Environment.NewLine +
                          global::SearchFile.Properties.Resources.ShowErrorDetailsTitle +
                          Environment.NewLine +
                          ex.Message;
                if (MessageBox.Show(this, message, global::SearchFile.Properties.Resources.ErrorDialogCaption,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    // 検索処理の中止を要求する
                    Debug.Assert(sender is BackgroundWorker);
                    (sender as BackgroundWorker).CancelAsync();

                    // ボタンを不活性にする
                    buttonSearch.Enabled = false;
                }
            }
        }

        private void backgroundSearchFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // スレッドの完了状態に応じたメッセージを表示する
            if (e.Cancelled)
            {
                statusLabelSearching.Text = global::SearchFile.Properties.Resources.SearchingStopMessage;
            }
            else if (e.Error != null)
            {
                string message;

                if (e.Error is ArgumentException)
                {
                    message = global::SearchFile.Properties.Resources.UsingInvalidFileNameMessage;
                }
                else
                {
                    message = e.Error.ToString();
                }

                MessageBox.Show(this, message, global::SearchFile.Properties.Resources.ErrorDialogCaption,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabelSearching.Text = global::SearchFile.Properties.Resources.SearchingErrorMessage;
            }
            else
            {
                statusLabelSearching.Text = string.Format(global::SearchFile.Properties.Resources.SearchingResultMessage, e.Result);
            }

            // リストの各列幅を自動調整する
            if (this._autoColumnWidth)
            {
                AdjustListViewColumnWidth(this.listViewFileName);
            }

            // スレッドが完了したことを UI に反映する
            buttonSearch.Text = global::SearchFile.Properties.Settings.Default.buttonSearch_Text;
            buttonSearch.Enabled = true;
            buttonClear.Enabled = true;
            menuFileClear.Enabled = true;
            toolFileClear.Enabled = true;
            contextFileListClear.Enabled = true;
            statusProgressSearching.Style = ProgressBarStyle.Blocks;
            statusProgressSearching.Visible = false;
        }

        /// <summary>
        /// 検索結果のファイルリストビューの全項目を選択する
        /// </summary>
        private void SelectAllFileListEvent(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFileName.Items)
            {
                item.Selected = true;
            }
        }

        /// <summary>
        /// 検索結果のファイルリストビューの選択状態を反転する
        /// </summary>
        private void ReverseSelectionFileListEvent(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFileName.Items)
            {
                item.Selected = !item.Selected;
            }
        }

        /// <summary>
        /// 選択されたファイルを削除するイベントを処理するメソッド
        /// </summary>
        private void DeleteSelectionFilesEvent(object sender, EventArgs e)
        {
            try
            {
                int fileCount = listViewFileName.SelectedItems.Count;
                List<string> selectedFiles = new List<string>(fileCount);

                // チェックされているファイル名を取得する
                foreach (ListViewItem item in listViewFileName.SelectedItems)
                {
                    selectedFiles.Add(Path.Combine(item.SubItems[2].Text, item.Text));
                }

                // ファイルを削除する
                FileOperate.DeleteFiles(this, selectedFiles, checkMoveRecycler.Checked);

                // 削除したファイルをリストから削除する
                foreach (ListViewItem item in listViewFileName.SelectedItems)
                {
                    listViewFileName.Items.Remove(item);
                }

                // 削除メッセージをステータスバーに表示する
                statusLabelSearching.Text = string.Format(global::SearchFile.Properties.Resources.FileDeleteMessage, fileCount);
            }
            catch (OperationCanceledException)
            {
                statusLabelSearching.Text = global::SearchFile.Properties.Resources.FileDeleteCancelMessage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, global::SearchFile.Properties.Resources.ErrorDialogCaption,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabelSearching.Text = global::SearchFile.Properties.Resources.FileDeleteErrorMessage;
            }
        }

        /// <summary>
        /// ファイル検索結果をクリップボードにコピーするイベントを処理するメソッド
        /// </summary>
        private void ResultCopyEvent(object sender, EventArgs e)
        {
            int fileCount = listViewFileName.Items.Count;

            if (fileCount == 0)
            {
                MessageBox.Show(this, global::SearchFile.Properties.Resources.CopyTargetFilesEmptyMessage,
                                global::SearchFile.Properties.Resources.WarningDialogCaption,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ファイル一覧をクリップボードに追加する
                StringBuilder sb = new StringBuilder();

                foreach (ListViewItem item in listViewFileName.Items)
                {
                    sb.AppendLine(Path.Combine(item.SubItems[2].Text, item.Text));
                }

                Clipboard.SetText(sb.ToString());

                // ステータスバーに結果を表示する
                statusLabelSearching.Text = string.Format(global::SearchFile.Properties.Resources.CopyFileNameMessage, fileCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, global::SearchFile.Properties.Resources.ErrorDialogCaption,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextFileList_Opened(object sender, EventArgs e)
        {
            // リストアイテム数に応じてコンテキストメニューに状態を設定する
            bool existedItem = (listViewFileName.Items.Count != 0);

            contextFileListResultCopy.Enabled = existedItem;
            contextFileListSelectAll.Enabled = existedItem;
            contextFileListReverseSelection.Enabled = existedItem;
            contextFileListAutoColumnWidth.Checked = this._autoColumnWidth;
            contextFileListShowProperty.Enabled = (listViewFileName.SelectedItems.Count > 0);
        }

        private void menuEdit_DropDownOpened(object sender, EventArgs e)
        {
            // リストアイテム数に応じてコンテキストメニューに状態を設定する
            bool existedItem = (listViewFileName.Items.Count != 0);

            menuEditCopy.Enabled = existedItem;
            menuEditSelectAll.Enabled = existedItem;
            menuEditReverseSelection.Enabled = existedItem;
        }

        private void AutoFileListColumnWidthEvent(object sender, EventArgs e)
        {
            // リストビューの列幅自動調整の設定を行う
            this._autoColumnWidth = !this._autoColumnWidth;
        }

        /// <summary>
        /// リストビューの列幅を項目に応じて調整する
        /// </summary>
        /// <param name="listView">列幅を調整する ListView コントロール</param>
        private static void AdjustListViewColumnWidth(ListView listView)
        {
            if (listView.Items.Count > 0)
            {
                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        /// <summary>
        /// ファイル検索結果をファイルに保存するイベントを処理するメソッド
        /// </summary>
        private void SaveFileListEvent(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = global::SearchFile.Properties.Resources.TextFileDialogFilter + "|" +
                            global::SearchFile.Properties.Resources.AllFileDialogFilter;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    // 検索結果をファイルに保存する
                    using (TextWriter writer = new StreamWriter(dialog.FileName, false, Encoding.Default))
                    {
                        foreach (ListViewItem item in listViewFileName.Items)
                        {
                            writer.WriteLine(Path.Combine(item.SubItems[2].Text, item.Text));
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, ex.Message, global::SearchFile.Properties.Resources.ErrorDialogCaption,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 選択されたファイルのプロパティを表示するイベントを処理するメソッド
        /// </summary>
        private void ShowFilePropertyEvent(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listViewFileName.SelectedItems)
                {
                    // ファイルプロパティを表示する
                    FileOperate.ShowPropertyDialog(this, Path.Combine(item.SubItems[2].Text, item.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, global::SearchFile.Properties.Resources.ErrorDialogCaption,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBoxBaseCutEvent(object sender, EventArgs e)
        {
            TextBoxBase activeControl = GetActiveInnerControl() as TextBoxBase;

            if (activeControl != null && activeControl.SelectionLength > 0)
            {
                activeControl.Cut();
            }
        }

        private void TextBoxBaseCopyEvent(object sender, EventArgs e)
        {
            TextBoxBase activeControl = GetActiveInnerControl() as TextBoxBase;

            if (activeControl != null && activeControl.SelectionLength > 0)
            {
                activeControl.Copy();
            }
        }

        private void TextBoxBasePasteEvent(object sender, EventArgs e)
        {
            TextBoxBase activeControl = GetActiveInnerControl() as TextBoxBase;

            if (activeControl != null && Clipboard.ContainsText())
            {
                activeControl.Paste();
            }
        }

        private void listViewFileName_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                listViewFileNameSorter.Column = e.Column;
                listViewFileName.Sort();

                ListViewEx lv = sender as ListViewEx;
                if (sender != null)
                {
                    for (int i = 0; i < lv.Columns.Count; i++)
                    {
                        lv.SetHeaderSortArrowStyle(i, ListViewEx.HeaderSortArrows.None);
                    }

                    lv.SetHeaderSortArrowStyle(e.Column, SelectHeaderSortArrows(listViewFileNameSorter.SortOrder));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, global::SearchFile.Properties.Resources.ErrorDialogCaption,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ヘッダーに表示する矢印の種類を選択する
        /// </summary>
        /// <param name="order">並べ替え方法</param>
        /// <returns>ヘッダーに表示する矢印の種類</returns>
        protected static ListViewEx.HeaderSortArrows SelectHeaderSortArrows(SortOrder order)
        {
            ListViewEx.HeaderSortArrows arrow;

            switch (order)
            {
                case SortOrder.Ascending:
                    arrow = ListViewEx.HeaderSortArrows.SortUp;
                    break;
                case SortOrder.Descending:
                    arrow = ListViewEx.HeaderSortArrows.SortDown;
                    break;
                default:
                    arrow = ListViewEx.HeaderSortArrows.None;
                    break;
            }

            return arrow;
        }

        /// <summary>
        /// ワイルドカードパターン文字列を正規表現パターン文字列に変換する
        /// </summary>
        /// <param name="wildcard">ワイルドカードパターン文字列</param>
        /// <param name="fullMatch">完全一致する正規表現パターン文字列を生成するかを示す値</param>
        /// <returns>変換後の正規表現パターン文字列</returns>
        protected static string WildcardToRegex(string wildcard, bool fullMatch)
        {
            StringBuilder sb = new StringBuilder(Regex.Escape(wildcard));

            sb.Replace(Regex.Escape("?"), ".");
            sb.Replace(Regex.Escape("*"), ".*");

            if (fullMatch)
            {
                sb.Insert(0, '^');
                sb.Append('$');
            }

            return sb.ToString();
        }
    }
}
