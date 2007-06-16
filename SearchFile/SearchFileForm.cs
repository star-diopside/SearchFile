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
        // ���X�g�r���[�̃\�[�g���Ɏg�p����C���X�^���X
        private ListViewItemSorter listViewFileNameSorter;

        // �������Ƀ��X�g�r���[�̗񕝂������������邩�ǂ����������l
        private bool _autoColumnWidth = true;

        public SearchFileForm()
        {
            InitializeComponent();

            // ���X�g�r���[�̃\�[�g�Ɋւ���ݒ�
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

            // �����f�B���N�g���ɃV�X�e���f�B���N�g���̃��[�g�f�B���N�g����ݒ肷��
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
        /// �A�v���P�[�V�����̃A�C�h�����ɔ�������C�x���g���������郁�\�b�h
        /// </summary>
        private void ApplicationIdleEvent(object sender, EventArgs e)
        {
            try
            {
                // ���X�g�r���[�̏�Ԃɉ����ăR�s�[�̉ۂ� UI �ɔ��f����
                toolEditResultCopy.Enabled = (listViewFileName.Items.Count != 0);

                // �A�N�e�B�u�R���g���[�����擾����
                TextBoxBase activeControl = GetActiveInnerControl() as TextBoxBase;

                if (activeControl != null)
                {
                    // �A�N�e�B�u�R���g���[���� TextBoxBase �̏ꍇ
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
        /// �A�N�e�B�u�R���g���[�����擾����BContainerControl ���A�N�e�B�u�̏ꍇ�ɂ͍ċA�I�ɓ����̃A�N�e�B�u�R���g���[�����擾����B
        /// </summary>
        /// <returns>��ԓ����̃A�N�e�B�u�R���g���[��</returns>
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
        /// �t�H�[�������C�x���g���������郁�\�b�h
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
        /// �t�H���_�I���C�x���g���������郁�\�b�h
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
        /// �t�@�C���������ʂ��N���A����C�x���g���������郁�\�b�h
        /// </summary>
        private void FileListClearEvent(object sender, EventArgs e)
        {
            // �������ʂ��N���A����
            if (ClearFileList())
            {
                statusLabelSearching.Text = global::SearchFile.Properties.Resources.ClearFilesMessage;
            }
        }

        /// <summary>
        /// �t�@�C���������ʂ��N���A����
        /// </summary>
        /// <returns>�������ʂ��N���A���ꂽ�ꍇ��true�B�L�����Z�����ꂽ�ꍇ��false�B</returns>
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
        /// �t�@�C�������̎��s�E���~�����s����C�x���g���������郁�\�b�h
        /// </summary>
        private void SearchFileEvent(object sender, EventArgs e)
        {
            if (backgroundSearchFile.IsBusy)
            {
                // ���������̒��~��v������
                backgroundSearchFile.CancelAsync();

                // �{�^����s�����ɂ���
                buttonSearch.Enabled = false;
            }
            else
            {
                try
                {
                    string directoryName = textDirectory.Text.Trim();
                    string fileName = textFile.Text.Trim();

                    // �K�v�ȃf�[�^�����͂���Ă��邩�ǂ������`�F�b�N����
                    if (!Directory.Exists(directoryName))
                    {
                        throw new ArgumentException(global::SearchFile.Properties.Resources.DirectoryNotFoundMessage);
                    }
                    else if (fileName.Length == 0)
                    {
                        throw new ArgumentException(global::SearchFile.Properties.Resources.NotInputFileNameMessage);
                    }

                    // �����t�@�C�����̃`�F�b�N���s��
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

                    // ���݂̃t�@�C�����X�g���N���A����
                    if (!ClearFileList())
                    {
                        return;
                    }

                    // �t�@�C���p�^�[����\�����鐳�K�\���𐶐�����
                    string patternString;
                    Regex pattern;

                    if (radioWildcard.Checked)
                    {
                        // ���C���h�J�[�h�p�^�[��������𐳋K�\���p�^�[��������ɕϊ�����
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

                    // �t�@�C������������
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
        /// �t�@�C�����������ă��X�g�r���[�ɗ񋓂���
        /// </summary>
        /// <param name="path">��������f�B���N�g��</param>
        /// <param name="pattern">path ���̃t�@�C�����ƑΉ������鐳�K�\��</param>
        /// <param name="searchOption">��������ɂ��ׂẴT�u�f�B���N�g�����܂߂�̂��A�܂��͌��݂̃f�B���N�g���݂̂��܂߂�̂����w�肷�� SearchOption �l�� 1 ��</param>
        private void EnumerateFiles(string path, Regex pattern, SearchOption searchOption)
        {
            try
            {
                // �ʃX���b�h�Ńt�@�C�����������s����
                backgroundSearchFile.SearchPath = path;
                backgroundSearchFile.SearchPattern = pattern;
                backgroundSearchFile.SearchOption = searchOption;
                backgroundSearchFile.RunWorkerAsync();

                // �������ł��邱�Ƃ� UI �ɔ��f����
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
                    // ���X�g�r���[�̕`��𒆒f����
                    listViewFileName.BeginUpdate();

                    // �������ʂ̃A�C�e����ǉ�����
                    foreach (FileInfo file in info.Files)
                    {
                        // �t�@�C���A�C�R�����擾���A�C���[�W���X�g�ɒǉ�����
                        if (file.SmallIcon != null)
                        {
                            imageFileList.Images.Add(file.FullName, file.SmallIcon);
                        }

                        // ���X�g�r���[�ɍ��ڂ�ǉ�����
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

                    // ���X�g�r���[�̕`����ĊJ����
                    listViewFileName.EndUpdate();
                }
                else
                {
                    // �X�e�[�^�X�o�[�Ɍ������t�H���_�̏���\������
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
                    // ���������̒��~��v������
                    Debug.Assert(sender is BackgroundWorker);
                    (sender as BackgroundWorker).CancelAsync();

                    // �{�^����s�����ɂ���
                    buttonSearch.Enabled = false;
                }
            }
        }

        private void backgroundSearchFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // �X���b�h�̊�����Ԃɉ��������b�Z�[�W��\������
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

            // ���X�g�̊e�񕝂�������������
            if (this._autoColumnWidth)
            {
                AdjustListViewColumnWidth(this.listViewFileName);
            }

            // �X���b�h�������������Ƃ� UI �ɔ��f����
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
        /// �������ʂ̃t�@�C�����X�g�r���[�̑S���ڂ�I������
        /// </summary>
        private void SelectAllFileListEvent(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFileName.Items)
            {
                item.Selected = true;
            }
        }

        /// <summary>
        /// �������ʂ̃t�@�C�����X�g�r���[�̑I����Ԃ𔽓]����
        /// </summary>
        private void ReverseSelectionFileListEvent(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFileName.Items)
            {
                item.Selected = !item.Selected;
            }
        }

        /// <summary>
        /// �I�����ꂽ�t�@�C�����폜����C�x���g���������郁�\�b�h
        /// </summary>
        private void DeleteSelectionFilesEvent(object sender, EventArgs e)
        {
            try
            {
                int fileCount = listViewFileName.SelectedItems.Count;
                List<string> selectedFiles = new List<string>(fileCount);

                // �`�F�b�N����Ă���t�@�C�������擾����
                foreach (ListViewItem item in listViewFileName.SelectedItems)
                {
                    selectedFiles.Add(Path.Combine(item.SubItems[2].Text, item.Text));
                }

                // �t�@�C�����폜����
                FileOperate.DeleteFiles(this, selectedFiles, checkMoveRecycler.Checked);

                // �폜�����t�@�C�������X�g����폜����
                foreach (ListViewItem item in listViewFileName.SelectedItems)
                {
                    listViewFileName.Items.Remove(item);
                }

                // �폜���b�Z�[�W���X�e�[�^�X�o�[�ɕ\������
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
        /// �t�@�C���������ʂ��N���b�v�{�[�h�ɃR�s�[����C�x���g���������郁�\�b�h
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
                // �t�@�C���ꗗ���N���b�v�{�[�h�ɒǉ�����
                StringBuilder sb = new StringBuilder();

                foreach (ListViewItem item in listViewFileName.Items)
                {
                    sb.AppendLine(Path.Combine(item.SubItems[2].Text, item.Text));
                }

                Clipboard.SetText(sb.ToString());

                // �X�e�[�^�X�o�[�Ɍ��ʂ�\������
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
            // ���X�g�A�C�e�����ɉ����ăR���e�L�X�g���j���[�ɏ�Ԃ�ݒ肷��
            bool existedItem = (listViewFileName.Items.Count != 0);

            contextFileListResultCopy.Enabled = existedItem;
            contextFileListSelectAll.Enabled = existedItem;
            contextFileListReverseSelection.Enabled = existedItem;
            contextFileListAutoColumnWidth.Checked = this._autoColumnWidth;
            contextFileListShowProperty.Enabled = (listViewFileName.SelectedItems.Count > 0);
        }

        private void menuEdit_DropDownOpened(object sender, EventArgs e)
        {
            // ���X�g�A�C�e�����ɉ����ăR���e�L�X�g���j���[�ɏ�Ԃ�ݒ肷��
            bool existedItem = (listViewFileName.Items.Count != 0);

            menuEditCopy.Enabled = existedItem;
            menuEditSelectAll.Enabled = existedItem;
            menuEditReverseSelection.Enabled = existedItem;
        }

        private void AutoFileListColumnWidthEvent(object sender, EventArgs e)
        {
            // ���X�g�r���[�̗񕝎��������̐ݒ���s��
            this._autoColumnWidth = !this._autoColumnWidth;
        }

        /// <summary>
        /// ���X�g�r���[�̗񕝂����ڂɉ����Ē�������
        /// </summary>
        /// <param name="listView">�񕝂𒲐����� ListView �R���g���[��</param>
        private static void AdjustListViewColumnWidth(ListView listView)
        {
            if (listView.Items.Count > 0)
            {
                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        /// <summary>
        /// �t�@�C���������ʂ��t�@�C���ɕۑ�����C�x���g���������郁�\�b�h
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
                    // �������ʂ��t�@�C���ɕۑ�����
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
        /// �I�����ꂽ�t�@�C���̃v���p�e�B��\������C�x���g���������郁�\�b�h
        /// </summary>
        private void ShowFilePropertyEvent(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listViewFileName.SelectedItems)
                {
                    // �t�@�C���v���p�e�B��\������
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
        /// �w�b�_�[�ɕ\��������̎�ނ�I������
        /// </summary>
        /// <param name="order">���בւ����@</param>
        /// <returns>�w�b�_�[�ɕ\��������̎��</returns>
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
        /// ���C���h�J�[�h�p�^�[��������𐳋K�\���p�^�[��������ɕϊ�����
        /// </summary>
        /// <param name="wildcard">���C���h�J�[�h�p�^�[��������</param>
        /// <param name="fullMatch">���S��v���鐳�K�\���p�^�[��������𐶐����邩�������l</param>
        /// <returns>�ϊ���̐��K�\���p�^�[��������</returns>
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
