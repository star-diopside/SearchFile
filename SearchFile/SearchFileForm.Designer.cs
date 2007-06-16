﻿namespace SearchFile
{
    partial class SearchFileForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label labelSeparator;
            System.Windows.Forms.ToolStripSeparator contextFileListSeparator1;
            System.Windows.Forms.ToolStripSeparator contextFileListSeparator2;
            System.Windows.Forms.ToolStripSeparator contextFileListSeparator3;
            System.Windows.Forms.ToolStripSeparator contextFileListSeparator4;
            System.Windows.Forms.ToolStripSeparator mainToolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator mainToolStripSeparator2;
            System.Windows.Forms.Label labelDirectory;
            System.Windows.Forms.Label labelFile;
            System.Windows.Forms.ToolStripSeparator menuFileSeparator1;
            System.Windows.Forms.ToolStripSeparator menuFileSeparator2;
            System.Windows.Forms.ToolStripSeparator menuEditSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchFileForm));
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelSearching = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressSearching = new System.Windows.Forms.ToolStripProgressBar();
            this.inputSearchInfoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textDirectory = new System.Windows.Forms.TextBox();
            this.textFile = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDirectory = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonReverseSelection = new System.Windows.Forms.Button();
            this.buttonDeleteFile = new System.Windows.Forms.Button();
            this.checkMoveRecycler = new System.Windows.Forms.CheckBox();
            this.radioWildcard = new System.Windows.Forms.RadioButton();
            this.radioRegex = new System.Windows.Forms.RadioButton();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSelectDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditReverseSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.listViewFileName = new MyLib.CustomControls.ListViewEx();
            this.columnFileName = new System.Windows.Forms.ColumnHeader();
            this.columnExtension = new System.Windows.Forms.ColumnHeader();
            this.columnDirectoryName = new System.Windows.Forms.ColumnHeader();
            this.contextFileList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextFileListClear = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFileListResultCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFileListSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFileListReverseSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFileListAutoColumnWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFileListShowProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.imageFileList = new System.Windows.Forms.ImageList(this.components);
            this.mainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolFileClear = new System.Windows.Forms.ToolStripButton();
            this.toolFileSelectDirectory = new System.Windows.Forms.ToolStripButton();
            this.toolFileSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolEditResultCopy = new System.Windows.Forms.ToolStripButton();
            this.toolEditCut = new System.Windows.Forms.ToolStripButton();
            this.toolEditCopy = new System.Windows.Forms.ToolStripButton();
            this.toolEditPaste = new System.Windows.Forms.ToolStripButton();
            this.backgroundSearchFile = new SearchFile.BackgroundSearchFile();
            labelSeparator = new System.Windows.Forms.Label();
            contextFileListSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            contextFileListSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            contextFileListSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            contextFileListSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            mainToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            mainToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            labelDirectory = new System.Windows.Forms.Label();
            labelFile = new System.Windows.Forms.Label();
            menuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            menuFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            menuEditSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainStatusStrip.SuspendLayout();
            this.inputSearchInfoPanel.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.contextFileList.SuspendLayout();
            this.mainToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.mainToolStripContainer.ContentPanel.SuspendLayout();
            this.mainToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.mainToolStripContainer.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSeparator
            // 
            labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inputSearchInfoPanel.SetColumnSpan(labelSeparator, 2);
            labelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            labelSeparator.Location = new System.Drawing.Point(3, 170);
            labelSeparator.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            labelSeparator.Name = "labelSeparator";
            labelSeparator.Size = new System.Drawing.Size(189, 2);
            labelSeparator.TabIndex = 12;
            // 
            // contextFileListSeparator1
            // 
            contextFileListSeparator1.Name = "contextFileListSeparator1";
            contextFileListSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // contextFileListSeparator2
            // 
            contextFileListSeparator2.Name = "contextFileListSeparator2";
            contextFileListSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // contextFileListSeparator3
            // 
            contextFileListSeparator3.Name = "contextFileListSeparator3";
            contextFileListSeparator3.Size = new System.Drawing.Size(227, 6);
            // 
            // contextFileListSeparator4
            // 
            contextFileListSeparator4.Name = "contextFileListSeparator4";
            contextFileListSeparator4.Size = new System.Drawing.Size(227, 6);
            // 
            // mainToolStripSeparator1
            // 
            mainToolStripSeparator1.Name = "mainToolStripSeparator1";
            mainToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // mainToolStripSeparator2
            // 
            mainToolStripSeparator2.Name = "mainToolStripSeparator2";
            mainToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // labelDirectory
            // 
            labelDirectory.AutoSize = true;
            this.inputSearchInfoPanel.SetColumnSpan(labelDirectory, 2);
            labelDirectory.Location = new System.Drawing.Point(3, 8);
            labelDirectory.Name = "labelDirectory";
            labelDirectory.Size = new System.Drawing.Size(84, 12);
            labelDirectory.TabIndex = 0;
            labelDirectory.Text = global::SearchFile.Properties.Settings.Default.labelDirectory_Text;
            // 
            // labelFile
            // 
            labelFile.AutoSize = true;
            this.inputSearchInfoPanel.SetColumnSpan(labelFile, 2);
            labelFile.Location = new System.Drawing.Point(3, 74);
            labelFile.Name = "labelFile";
            labelFile.Size = new System.Drawing.Size(68, 12);
            labelFile.TabIndex = 3;
            labelFile.Text = global::SearchFile.Properties.Settings.Default.labelFile_Text;
            // 
            // menuFileSeparator1
            // 
            menuFileSeparator1.Name = "menuFileSeparator1";
            menuFileSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // menuFileSeparator2
            // 
            menuFileSeparator2.Name = "menuFileSeparator2";
            menuFileSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // menuEditSeparator1
            // 
            menuEditSeparator1.Name = "menuEditSeparator1";
            menuEditSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelSearching,
            this.statusProgressSearching});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 0);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(632, 22);
            this.mainStatusStrip.TabIndex = 2;
            // 
            // statusLabelSearching
            // 
            this.statusLabelSearching.Name = "statusLabelSearching";
            this.statusLabelSearching.Size = new System.Drawing.Size(617, 17);
            this.statusLabelSearching.Spring = true;
            this.statusLabelSearching.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusProgressSearching
            // 
            this.statusProgressSearching.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.statusProgressSearching.Name = "statusProgressSearching";
            this.statusProgressSearching.Size = new System.Drawing.Size(88, 16);
            this.statusProgressSearching.Visible = false;
            // 
            // inputSearchInfoPanel
            // 
            this.inputSearchInfoPanel.ColumnCount = 2;
            this.inputSearchInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inputSearchInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inputSearchInfoPanel.Controls.Add(labelDirectory, 0, 0);
            this.inputSearchInfoPanel.Controls.Add(this.textDirectory, 0, 1);
            this.inputSearchInfoPanel.Controls.Add(labelFile, 0, 3);
            this.inputSearchInfoPanel.Controls.Add(this.textFile, 0, 4);
            this.inputSearchInfoPanel.Controls.Add(this.buttonSearch, 0, 6);
            this.inputSearchInfoPanel.Controls.Add(this.buttonClear, 1, 6);
            this.inputSearchInfoPanel.Controls.Add(this.buttonDirectory, 0, 2);
            this.inputSearchInfoPanel.Controls.Add(this.buttonSelectAll, 0, 8);
            this.inputSearchInfoPanel.Controls.Add(this.buttonReverseSelection, 1, 8);
            this.inputSearchInfoPanel.Controls.Add(this.buttonDeleteFile, 0, 9);
            this.inputSearchInfoPanel.Controls.Add(this.checkMoveRecycler, 0, 10);
            this.inputSearchInfoPanel.Controls.Add(labelSeparator, 0, 7);
            this.inputSearchInfoPanel.Controls.Add(this.radioWildcard, 0, 5);
            this.inputSearchInfoPanel.Controls.Add(this.radioRegex, 1, 5);
            this.inputSearchInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputSearchInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.inputSearchInfoPanel.Name = "inputSearchInfoPanel";
            this.inputSearchInfoPanel.Padding = new System.Windows.Forms.Padding(0, 8, 8, 0);
            this.inputSearchInfoPanel.RowCount = 11;
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.inputSearchInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.inputSearchInfoPanel.Size = new System.Drawing.Size(203, 293);
            this.inputSearchInfoPanel.TabIndex = 0;
            // 
            // textDirectory
            // 
            this.textDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSearchInfoPanel.SetColumnSpan(this.textDirectory, 2);
            this.textDirectory.Location = new System.Drawing.Point(3, 23);
            this.textDirectory.Name = "textDirectory";
            this.textDirectory.Size = new System.Drawing.Size(189, 19);
            this.textDirectory.TabIndex = 1;
            this.textDirectory.Enter += new System.EventHandler(this.textDirectory_Enter);
            this.textDirectory.Leave += new System.EventHandler(this.textDirectory_Leave);
            // 
            // textFile
            // 
            this.textFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSearchInfoPanel.SetColumnSpan(this.textFile, 2);
            this.textFile.Location = new System.Drawing.Point(3, 89);
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(189, 19);
            this.textFile.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSearch.Location = new System.Drawing.Point(3, 136);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(91, 23);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = global::SearchFile.Properties.Settings.Default.buttonSearch_Text;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.SearchFileEvent);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClear.Location = new System.Drawing.Point(100, 136);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(92, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = global::SearchFile.Properties.Settings.Default.buttonClear_Text;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.FileListClearEvent);
            // 
            // buttonDirectory
            // 
            this.buttonDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSearchInfoPanel.SetColumnSpan(this.buttonDirectory, 2);
            this.buttonDirectory.Location = new System.Drawing.Point(64, 48);
            this.buttonDirectory.Name = "buttonDirectory";
            this.buttonDirectory.Size = new System.Drawing.Size(128, 23);
            this.buttonDirectory.TabIndex = 2;
            this.buttonDirectory.Text = global::SearchFile.Properties.Settings.Default.buttonDirectory_Text;
            this.buttonDirectory.UseVisualStyleBackColor = true;
            this.buttonDirectory.Click += new System.EventHandler(this.SelectDirectoryEvent);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSelectAll.Location = new System.Drawing.Point(3, 183);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(91, 23);
            this.buttonSelectAll.TabIndex = 8;
            this.buttonSelectAll.Text = global::SearchFile.Properties.Settings.Default.buttonSelectAll_Text;
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.SelectAllFileListEvent);
            // 
            // buttonReverseSelection
            // 
            this.buttonReverseSelection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonReverseSelection.Location = new System.Drawing.Point(100, 183);
            this.buttonReverseSelection.Name = "buttonReverseSelection";
            this.buttonReverseSelection.Size = new System.Drawing.Size(92, 23);
            this.buttonReverseSelection.TabIndex = 9;
            this.buttonReverseSelection.Text = global::SearchFile.Properties.Settings.Default.buttonReverseSelection_Text;
            this.buttonReverseSelection.UseVisualStyleBackColor = true;
            this.buttonReverseSelection.Click += new System.EventHandler(this.ReverseSelectionFileListEvent);
            // 
            // buttonDeleteFile
            // 
            this.buttonDeleteFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputSearchInfoPanel.SetColumnSpan(this.buttonDeleteFile, 2);
            this.buttonDeleteFile.Location = new System.Drawing.Point(23, 212);
            this.buttonDeleteFile.Name = "buttonDeleteFile";
            this.buttonDeleteFile.Size = new System.Drawing.Size(148, 23);
            this.buttonDeleteFile.TabIndex = 10;
            this.buttonDeleteFile.Text = global::SearchFile.Properties.Settings.Default.buttonDeleteFile_Text;
            this.buttonDeleteFile.UseVisualStyleBackColor = true;
            this.buttonDeleteFile.Click += new System.EventHandler(this.DeleteSelectionFilesEvent);
            // 
            // checkMoveRecycler
            // 
            this.checkMoveRecycler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkMoveRecycler.AutoSize = true;
            this.checkMoveRecycler.Checked = true;
            this.checkMoveRecycler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inputSearchInfoPanel.SetColumnSpan(this.checkMoveRecycler, 2);
            this.checkMoveRecycler.Location = new System.Drawing.Point(17, 241);
            this.checkMoveRecycler.Name = "checkMoveRecycler";
            this.checkMoveRecycler.Size = new System.Drawing.Size(175, 16);
            this.checkMoveRecycler.TabIndex = 11;
            this.checkMoveRecycler.Text = global::SearchFile.Properties.Settings.Default.checkMoveRecycler_Text;
            this.checkMoveRecycler.UseVisualStyleBackColor = true;
            // 
            // radioWildcard
            // 
            this.radioWildcard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioWildcard.AutoSize = true;
            this.radioWildcard.Checked = true;
            this.radioWildcard.Location = new System.Drawing.Point(4, 114);
            this.radioWildcard.Name = "radioWildcard";
            this.radioWildcard.Size = new System.Drawing.Size(88, 16);
            this.radioWildcard.TabIndex = 13;
            this.radioWildcard.TabStop = true;
            this.radioWildcard.Text = global::SearchFile.Properties.Settings.Default.radioWildcard_Text;
            this.radioWildcard.UseVisualStyleBackColor = true;
            // 
            // radioRegex
            // 
            this.radioRegex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioRegex.AutoSize = true;
            this.radioRegex.Location = new System.Drawing.Point(110, 114);
            this.radioRegex.Name = "radioRegex";
            this.radioRegex.Size = new System.Drawing.Size(71, 16);
            this.radioRegex.TabIndex = 14;
            this.radioRegex.Text = global::SearchFile.Properties.Settings.Default.radioRegex_Text;
            this.radioRegex.UseVisualStyleBackColor = true;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(632, 26);
            this.mainMenuStrip.TabIndex = 0;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileClear,
            this.menuFileSelectDirectory,
            menuFileSeparator1,
            this.menuFileSaveAs,
            menuFileSeparator2,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(85, 22);
            this.menuFile.Text = global::SearchFile.Properties.Settings.Default.menuFile_Text;
            // 
            // menuFileClear
            // 
            this.menuFileClear.Image = ((System.Drawing.Image)(resources.GetObject("menuFileClear.Image")));
            this.menuFileClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFileClear.Name = "menuFileClear";
            this.menuFileClear.Size = new System.Drawing.Size(214, 22);
            this.menuFileClear.Text = global::SearchFile.Properties.Settings.Default.menuFileClear_Text;
            this.menuFileClear.Click += new System.EventHandler(this.FileListClearEvent);
            // 
            // menuFileSelectDirectory
            // 
            this.menuFileSelectDirectory.Image = ((System.Drawing.Image)(resources.GetObject("menuFileSelectDirectory.Image")));
            this.menuFileSelectDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFileSelectDirectory.Name = "menuFileSelectDirectory";
            this.menuFileSelectDirectory.Size = new System.Drawing.Size(214, 22);
            this.menuFileSelectDirectory.Text = global::SearchFile.Properties.Settings.Default.menuFileSelectDirectory_Text;
            this.menuFileSelectDirectory.Click += new System.EventHandler(this.SelectDirectoryEvent);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("menuFileSaveAs.Image")));
            this.menuFileSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(214, 22);
            this.menuFileSaveAs.Text = global::SearchFile.Properties.Settings.Default.menuFileSaveAs_Text;
            this.menuFileSaveAs.Click += new System.EventHandler(this.SaveFileListEvent);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(214, 22);
            this.menuFileExit.Text = global::SearchFile.Properties.Settings.Default.menuFileExit_Text;
            this.menuFileExit.Click += new System.EventHandler(this.FormCloseEvent);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditCopy,
            menuEditSeparator1,
            this.menuEditSelectAll,
            this.menuEditReverseSelection});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(61, 22);
            this.menuEdit.Text = global::SearchFile.Properties.Settings.Default.menuEdit_Text;
            this.menuEdit.DropDownOpened += new System.EventHandler(this.menuEdit_DropDownOpened);
            // 
            // menuEditCopy
            // 
            this.menuEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuEditCopy.Image")));
            this.menuEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuEditCopy.Name = "menuEditCopy";
            this.menuEditCopy.Size = new System.Drawing.Size(190, 22);
            this.menuEditCopy.Text = global::SearchFile.Properties.Settings.Default.menuEditCopy_Text;
            this.menuEditCopy.Click += new System.EventHandler(this.ResultCopyEvent);
            // 
            // menuEditSelectAll
            // 
            this.menuEditSelectAll.Name = "menuEditSelectAll";
            this.menuEditSelectAll.Size = new System.Drawing.Size(190, 22);
            this.menuEditSelectAll.Text = global::SearchFile.Properties.Settings.Default.menuEditSelectAll_Text;
            this.menuEditSelectAll.Click += new System.EventHandler(this.SelectAllFileListEvent);
            // 
            // menuEditReverseSelection
            // 
            this.menuEditReverseSelection.Name = "menuEditReverseSelection";
            this.menuEditReverseSelection.Size = new System.Drawing.Size(190, 22);
            this.menuEditReverseSelection.Text = global::SearchFile.Properties.Settings.Default.menuEditReverseSelection_Text;
            this.menuEditReverseSelection.Click += new System.EventHandler(this.ReverseSelectionFileListEvent);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.listViewFileName);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.inputSearchInfoPanel);
            this.mainSplitContainer.Size = new System.Drawing.Size(632, 293);
            this.mainSplitContainer.SplitterDistance = 425;
            this.mainSplitContainer.TabIndex = 1;
            // 
            // listViewFileName
            // 
            this.listViewFileName.AllowColumnReorder = true;
            this.listViewFileName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFileName,
            this.columnExtension,
            this.columnDirectoryName});
            this.listViewFileName.ContextMenuStrip = this.contextFileList;
            this.listViewFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFileName.HideSelection = false;
            this.listViewFileName.Location = new System.Drawing.Point(0, 0);
            this.listViewFileName.Name = "listViewFileName";
            this.listViewFileName.Size = new System.Drawing.Size(425, 293);
            this.listViewFileName.SmallImageList = this.imageFileList;
            this.listViewFileName.TabIndex = 0;
            this.listViewFileName.UseCompatibleStateImageBehavior = false;
            this.listViewFileName.View = System.Windows.Forms.View.Details;
            this.listViewFileName.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewFileName_ColumnClick);
            // 
            // columnFileName
            // 
            this.columnFileName.Text = global::SearchFile.Properties.Settings.Default.columnFileName_Text;
            this.columnFileName.Width = 180;
            // 
            // columnExtension
            // 
            this.columnExtension.Text = global::SearchFile.Properties.Settings.Default.columnExtension_Text;
            this.columnExtension.Width = 120;
            // 
            // columnDirectoryName
            // 
            this.columnDirectoryName.Text = global::SearchFile.Properties.Settings.Default.columnDirectoryName_Text;
            this.columnDirectoryName.Width = 180;
            // 
            // contextFileList
            // 
            this.contextFileList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextFileListClear,
            contextFileListSeparator1,
            this.contextFileListResultCopy,
            contextFileListSeparator2,
            this.contextFileListSelectAll,
            this.contextFileListReverseSelection,
            contextFileListSeparator3,
            this.contextFileListAutoColumnWidth,
            contextFileListSeparator4,
            this.contextFileListShowProperty});
            this.contextFileList.Name = "contextFileList";
            this.contextFileList.Size = new System.Drawing.Size(231, 160);
            this.contextFileList.Opened += new System.EventHandler(this.contextFileList_Opened);
            // 
            // contextFileListClear
            // 
            this.contextFileListClear.Image = ((System.Drawing.Image)(resources.GetObject("contextFileListClear.Image")));
            this.contextFileListClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.contextFileListClear.Name = "contextFileListClear";
            this.contextFileListClear.Size = new System.Drawing.Size(230, 22);
            this.contextFileListClear.Text = global::SearchFile.Properties.Settings.Default.contextFileListClear_Text;
            this.contextFileListClear.Click += new System.EventHandler(this.FileListClearEvent);
            // 
            // contextFileListResultCopy
            // 
            this.contextFileListResultCopy.Image = ((System.Drawing.Image)(resources.GetObject("contextFileListResultCopy.Image")));
            this.contextFileListResultCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.contextFileListResultCopy.Name = "contextFileListResultCopy";
            this.contextFileListResultCopy.Size = new System.Drawing.Size(230, 22);
            this.contextFileListResultCopy.Text = global::SearchFile.Properties.Settings.Default.contextFileListResultCopy_Text;
            this.contextFileListResultCopy.Click += new System.EventHandler(this.ResultCopyEvent);
            // 
            // contextFileListSelectAll
            // 
            this.contextFileListSelectAll.Name = "contextFileListSelectAll";
            this.contextFileListSelectAll.Size = new System.Drawing.Size(230, 22);
            this.contextFileListSelectAll.Text = global::SearchFile.Properties.Settings.Default.contextFileListSelectAll_Text;
            this.contextFileListSelectAll.Click += new System.EventHandler(this.SelectAllFileListEvent);
            // 
            // contextFileListReverseSelection
            // 
            this.contextFileListReverseSelection.Name = "contextFileListReverseSelection";
            this.contextFileListReverseSelection.Size = new System.Drawing.Size(230, 22);
            this.contextFileListReverseSelection.Text = global::SearchFile.Properties.Settings.Default.contextFileListReverseSelection_Text;
            this.contextFileListReverseSelection.Click += new System.EventHandler(this.ReverseSelectionFileListEvent);
            // 
            // contextFileListAutoColumnWidth
            // 
            this.contextFileListAutoColumnWidth.Name = "contextFileListAutoColumnWidth";
            this.contextFileListAutoColumnWidth.Size = new System.Drawing.Size(230, 22);
            this.contextFileListAutoColumnWidth.Text = global::SearchFile.Properties.Settings.Default.contextFileListAutoColumnWidth_Text;
            this.contextFileListAutoColumnWidth.Click += new System.EventHandler(this.AutoFileListColumnWidthEvent);
            // 
            // contextFileListShowProperty
            // 
            this.contextFileListShowProperty.Name = "contextFileListShowProperty";
            this.contextFileListShowProperty.Size = new System.Drawing.Size(230, 22);
            this.contextFileListShowProperty.Text = global::SearchFile.Properties.Settings.Default.contextFileListShowProperty_Text;
            this.contextFileListShowProperty.Click += new System.EventHandler(this.ShowFilePropertyEvent);
            // 
            // imageFileList
            // 
            this.imageFileList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageFileList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageFileList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mainToolStripContainer
            // 
            // 
            // mainToolStripContainer.BottomToolStripPanel
            // 
            this.mainToolStripContainer.BottomToolStripPanel.Controls.Add(this.mainStatusStrip);
            // 
            // mainToolStripContainer.ContentPanel
            // 
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.mainSplitContainer);
            this.mainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(632, 293);
            this.mainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.mainToolStripContainer.Name = "mainToolStripContainer";
            this.mainToolStripContainer.Size = new System.Drawing.Size(632, 366);
            this.mainToolStripContainer.TabIndex = 3;
            // 
            // mainToolStripContainer.TopToolStripPanel
            // 
            this.mainToolStripContainer.TopToolStripPanel.Controls.Add(this.mainMenuStrip);
            this.mainToolStripContainer.TopToolStripPanel.Controls.Add(this.mainToolStrip);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFileClear,
            this.toolFileSelectDirectory,
            this.toolFileSaveAs,
            mainToolStripSeparator1,
            this.toolEditResultCopy,
            mainToolStripSeparator2,
            this.toolEditCut,
            this.toolEditCopy,
            this.toolEditPaste});
            this.mainToolStrip.Location = new System.Drawing.Point(3, 26);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(185, 25);
            this.mainToolStrip.TabIndex = 1;
            // 
            // toolFileClear
            // 
            this.toolFileClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFileClear.Image = ((System.Drawing.Image)(resources.GetObject("toolFileClear.Image")));
            this.toolFileClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileClear.Name = "toolFileClear";
            this.toolFileClear.Size = new System.Drawing.Size(23, 22);
            this.toolFileClear.Text = global::SearchFile.Properties.Settings.Default.toolFileClear_Text;
            this.toolFileClear.Click += new System.EventHandler(this.FileListClearEvent);
            // 
            // toolFileSelectDirectory
            // 
            this.toolFileSelectDirectory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFileSelectDirectory.Image = ((System.Drawing.Image)(resources.GetObject("toolFileSelectDirectory.Image")));
            this.toolFileSelectDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileSelectDirectory.Name = "toolFileSelectDirectory";
            this.toolFileSelectDirectory.Size = new System.Drawing.Size(23, 22);
            this.toolFileSelectDirectory.Text = global::SearchFile.Properties.Settings.Default.toolFileSelectDirectory_Text;
            this.toolFileSelectDirectory.Click += new System.EventHandler(this.SelectDirectoryEvent);
            // 
            // toolFileSaveAs
            // 
            this.toolFileSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFileSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolFileSaveAs.Image")));
            this.toolFileSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileSaveAs.Name = "toolFileSaveAs";
            this.toolFileSaveAs.Size = new System.Drawing.Size(23, 22);
            this.toolFileSaveAs.Text = global::SearchFile.Properties.Settings.Default.toolFileSaveAs_Text;
            this.toolFileSaveAs.Click += new System.EventHandler(this.SaveFileListEvent);
            // 
            // toolEditResultCopy
            // 
            this.toolEditResultCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditResultCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolEditResultCopy.Image")));
            this.toolEditResultCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditResultCopy.Name = "toolEditResultCopy";
            this.toolEditResultCopy.Size = new System.Drawing.Size(23, 22);
            this.toolEditResultCopy.Text = global::SearchFile.Properties.Settings.Default.toolEditResultCopy_Text;
            this.toolEditResultCopy.Click += new System.EventHandler(this.ResultCopyEvent);
            // 
            // toolEditCut
            // 
            this.toolEditCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditCut.Image = ((System.Drawing.Image)(resources.GetObject("toolEditCut.Image")));
            this.toolEditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditCut.Name = "toolEditCut";
            this.toolEditCut.Size = new System.Drawing.Size(23, 22);
            this.toolEditCut.Text = global::SearchFile.Properties.Settings.Default.toolEditCut_Text;
            this.toolEditCut.Click += new System.EventHandler(this.TextBoxBaseCutEvent);
            // 
            // toolEditCopy
            // 
            this.toolEditCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolEditCopy.Image")));
            this.toolEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditCopy.Name = "toolEditCopy";
            this.toolEditCopy.Size = new System.Drawing.Size(23, 22);
            this.toolEditCopy.Text = global::SearchFile.Properties.Settings.Default.toolEditCopy_Text;
            this.toolEditCopy.Click += new System.EventHandler(this.TextBoxBaseCopyEvent);
            // 
            // toolEditPaste
            // 
            this.toolEditPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolEditPaste.Image")));
            this.toolEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditPaste.Name = "toolEditPaste";
            this.toolEditPaste.Size = new System.Drawing.Size(23, 22);
            this.toolEditPaste.Text = global::SearchFile.Properties.Settings.Default.toolEditPaste_Text;
            this.toolEditPaste.Click += new System.EventHandler(this.TextBoxBasePasteEvent);
            // 
            // backgroundSearchFile
            // 
            this.backgroundSearchFile.WorkerReportsProgress = true;
            this.backgroundSearchFile.WorkerSupportsCancellation = true;
            this.backgroundSearchFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundSearchFile_RunWorkerCompleted);
            this.backgroundSearchFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundSearchFile_ProgressChanged);
            // 
            // SearchFileForm
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 366);
            this.Controls.Add(this.mainToolStripContainer);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "SearchFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = global::SearchFile.Properties.Settings.Default.SearchFileForm_Text;
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.inputSearchInfoPanel.ResumeLayout(false);
            this.inputSearchInfoPanel.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.contextFileList.ResumeLayout(false);
            this.mainToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.mainToolStripContainer.BottomToolStripPanel.PerformLayout();
            this.mainToolStripContainer.ContentPanel.ResumeLayout(false);
            this.mainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.mainToolStripContainer.TopToolStripPanel.PerformLayout();
            this.mainToolStripContainer.ResumeLayout(false);
            this.mainToolStripContainer.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.TableLayoutPanel inputSearchInfoPanel;
        private System.Windows.Forms.TextBox textDirectory;
        private System.Windows.Forms.Button buttonDirectory;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileClear;
        private System.Windows.Forms.ToolStripMenuItem menuFileSelectDirectory;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonReverseSelection;
        private System.Windows.Forms.Button buttonDeleteFile;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ColumnHeader columnFileName;
        private System.Windows.Forms.ColumnHeader columnExtension;
        private System.Windows.Forms.ColumnHeader columnDirectoryName;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelSearching;
        private System.Windows.Forms.CheckBox checkMoveRecycler;
        private System.Windows.Forms.ContextMenuStrip contextFileList;
        private System.Windows.Forms.ToolStripMenuItem contextFileListSelectAll;
        private System.Windows.Forms.ToolStripMenuItem contextFileListReverseSelection;
        private System.Windows.Forms.ToolStripMenuItem contextFileListResultCopy;
        private System.Windows.Forms.ToolStripMenuItem contextFileListClear;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuEditCopy;
        private System.Windows.Forms.ToolStripMenuItem menuEditSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuEditReverseSelection;
        private System.Windows.Forms.ToolStripMenuItem contextFileListAutoColumnWidth;
        private System.Windows.Forms.ToolStripProgressBar statusProgressSearching;
        private MyLib.CustomControls.ListViewEx listViewFileName;
        private System.Windows.Forms.ImageList imageFileList;
        private System.Windows.Forms.ToolStripMenuItem contextFileListShowProperty;
        private System.Windows.Forms.ToolStripContainer mainToolStripContainer;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton toolFileClear;
        private System.Windows.Forms.ToolStripButton toolFileSelectDirectory;
        private System.Windows.Forms.ToolStripButton toolFileSaveAs;
        private System.Windows.Forms.ToolStripButton toolEditCut;
        private System.Windows.Forms.ToolStripButton toolEditCopy;
        private System.Windows.Forms.ToolStripButton toolEditPaste;
        private System.Windows.Forms.ToolStripButton toolEditResultCopy;
        private System.Windows.Forms.RadioButton radioWildcard;
        private System.Windows.Forms.RadioButton radioRegex;
        private BackgroundSearchFile backgroundSearchFile;
    }
}

