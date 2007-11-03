namespace SearchFile
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
            System.Windows.Forms.ToolStripSeparator contextFileListSeparator1;
            System.Windows.Forms.ToolStripSeparator contextFileListSeparator2;
            System.Windows.Forms.ToolStripSeparator contextFileListSeparator3;
            System.Windows.Forms.ToolStripSeparator contextFileListSeparator4;
            System.Windows.Forms.ToolStripSeparator mainToolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator mainToolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator menuFileSeparator1;
            System.Windows.Forms.ToolStripSeparator menuFileSeparator2;
            System.Windows.Forms.ToolStripSeparator menuEditSeparator1;
            System.Windows.Forms.Label labelDirectory;
            System.Windows.Forms.Label labelFile;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchFileForm));
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelSearching = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressSearching = new System.Windows.Forms.ToolStripProgressBar();
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
            this.inputSplitContainer = new System.Windows.Forms.SplitContainer();
            this.inputSearchInfoBorderPanel = new MyLib.CustomControls.LineBorderPanel();
            this.inputSearchInfoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textDirectory = new System.Windows.Forms.TextBox();
            this.textFile = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDirectory = new System.Windows.Forms.Button();
            this.radioWildcard = new System.Windows.Forms.RadioButton();
            this.radioRegex = new System.Windows.Forms.RadioButton();
            this.inputSearchInfoTitle = new MyLib.CustomControls.LinearGradientDrawLabel();
            this.inputActionInfoBorderPanel = new MyLib.CustomControls.LineBorderPanel();
            this.inputActionInfoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonReverseSelection = new System.Windows.Forms.Button();
            this.buttonDeleteFile = new System.Windows.Forms.Button();
            this.checkMoveRecycler = new System.Windows.Forms.CheckBox();
            this.inputActionInfoTitle = new MyLib.CustomControls.LinearGradientDrawLabel();
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
            contextFileListSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            contextFileListSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            contextFileListSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            contextFileListSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            mainToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            mainToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            menuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            menuFileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            menuEditSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            labelDirectory = new System.Windows.Forms.Label();
            labelFile = new System.Windows.Forms.Label();
            this.mainStatusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.contextFileList.SuspendLayout();
            this.inputSplitContainer.Panel1.SuspendLayout();
            this.inputSplitContainer.Panel2.SuspendLayout();
            this.inputSplitContainer.SuspendLayout();
            this.inputSearchInfoBorderPanel.SuspendLayout();
            this.inputSearchInfoPanel.SuspendLayout();
            this.inputActionInfoBorderPanel.SuspendLayout();
            this.inputActionInfoPanel.SuspendLayout();
            this.mainToolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.mainToolStripContainer.ContentPanel.SuspendLayout();
            this.mainToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.mainToolStripContainer.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
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
            // labelDirectory
            // 
            labelDirectory.AutoSize = true;
            this.inputSearchInfoPanel.SetColumnSpan(labelDirectory, 2);
            labelDirectory.Location = new System.Drawing.Point(7, 8);
            labelDirectory.Name = "labelDirectory";
            labelDirectory.Size = new System.Drawing.Size(84, 12);
            labelDirectory.TabIndex = 0;
            labelDirectory.Text = "ディレクトリ名(&D):";
            // 
            // labelFile
            // 
            labelFile.AutoSize = true;
            this.inputSearchInfoPanel.SetColumnSpan(labelFile, 2);
            labelFile.Location = new System.Drawing.Point(7, 74);
            labelFile.Name = "labelFile";
            labelFile.Size = new System.Drawing.Size(68, 12);
            labelFile.TabIndex = 3;
            labelFile.Text = "ファイル名(&F):";
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
            this.mainStatusStrip.TabIndex = 0;
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
            this.menuFile.Text = "ファイル(&F)";
            // 
            // menuFileClear
            // 
            this.menuFileClear.Image = ((System.Drawing.Image)(resources.GetObject("menuFileClear.Image")));
            this.menuFileClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFileClear.Name = "menuFileClear";
            this.menuFileClear.Size = new System.Drawing.Size(214, 22);
            this.menuFileClear.Text = "リストのクリア(&C)";
            this.menuFileClear.Click += new System.EventHandler(this.FileListClearEvent);
            // 
            // menuFileSelectDirectory
            // 
            this.menuFileSelectDirectory.Image = ((System.Drawing.Image)(resources.GetObject("menuFileSelectDirectory.Image")));
            this.menuFileSelectDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFileSelectDirectory.Name = "menuFileSelectDirectory";
            this.menuFileSelectDirectory.Size = new System.Drawing.Size(214, 22);
            this.menuFileSelectDirectory.Text = "ディレクトリの選択(&S)...";
            this.menuFileSelectDirectory.Click += new System.EventHandler(this.SelectDirectoryEvent);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("menuFileSaveAs.Image")));
            this.menuFileSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(214, 22);
            this.menuFileSaveAs.Text = "名前を付けて保存(&A)...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.SaveFileListEvent);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(214, 22);
            this.menuFileExit.Text = "終了(&X)";
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
            this.menuEdit.Text = "編集(&E)";
            this.menuEdit.DropDownOpened += new System.EventHandler(this.menuEdit_DropDownOpened);
            // 
            // menuEditCopy
            // 
            this.menuEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuEditCopy.Image")));
            this.menuEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuEditCopy.Name = "menuEditCopy";
            this.menuEditCopy.Size = new System.Drawing.Size(190, 22);
            this.menuEditCopy.Text = "検索結果をコピー(&C)";
            this.menuEditCopy.Click += new System.EventHandler(this.ResultCopyEvent);
            // 
            // menuEditSelectAll
            // 
            this.menuEditSelectAll.Name = "menuEditSelectAll";
            this.menuEditSelectAll.Size = new System.Drawing.Size(190, 22);
            this.menuEditSelectAll.Text = "すべて選択(&A)";
            this.menuEditSelectAll.Click += new System.EventHandler(this.SelectAllFileListEvent);
            // 
            // menuEditReverseSelection
            // 
            this.menuEditReverseSelection.Name = "menuEditReverseSelection";
            this.menuEditReverseSelection.Size = new System.Drawing.Size(190, 22);
            this.menuEditReverseSelection.Text = "選択の切り替え(&R)";
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
            this.mainSplitContainer.Panel2.Controls.Add(this.inputSplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(632, 407);
            this.mainSplitContainer.SplitterDistance = 423;
            this.mainSplitContainer.TabIndex = 0;
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
            this.listViewFileName.Size = new System.Drawing.Size(423, 407);
            this.listViewFileName.SmallImageList = this.imageFileList;
            this.listViewFileName.TabIndex = 0;
            this.listViewFileName.UseCompatibleStateImageBehavior = false;
            this.listViewFileName.View = System.Windows.Forms.View.Details;
            this.listViewFileName.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewFileName_ColumnClick);
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "ファイル名";
            this.columnFileName.Width = 180;
            // 
            // columnExtension
            // 
            this.columnExtension.Text = "拡張子";
            this.columnExtension.Width = 120;
            // 
            // columnDirectoryName
            // 
            this.columnDirectoryName.Text = "ディレクトリ";
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
            this.contextFileListClear.Text = "リストのクリア(&C)";
            this.contextFileListClear.Click += new System.EventHandler(this.FileListClearEvent);
            // 
            // contextFileListResultCopy
            // 
            this.contextFileListResultCopy.Image = ((System.Drawing.Image)(resources.GetObject("contextFileListResultCopy.Image")));
            this.contextFileListResultCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.contextFileListResultCopy.Name = "contextFileListResultCopy";
            this.contextFileListResultCopy.Size = new System.Drawing.Size(230, 22);
            this.contextFileListResultCopy.Text = "検索結果をコピー(&O)";
            this.contextFileListResultCopy.Click += new System.EventHandler(this.ResultCopyEvent);
            // 
            // contextFileListSelectAll
            // 
            this.contextFileListSelectAll.Name = "contextFileListSelectAll";
            this.contextFileListSelectAll.Size = new System.Drawing.Size(230, 22);
            this.contextFileListSelectAll.Text = "すべて選択(&A)";
            this.contextFileListSelectAll.Click += new System.EventHandler(this.SelectAllFileListEvent);
            // 
            // contextFileListReverseSelection
            // 
            this.contextFileListReverseSelection.Name = "contextFileListReverseSelection";
            this.contextFileListReverseSelection.Size = new System.Drawing.Size(230, 22);
            this.contextFileListReverseSelection.Text = "選択の切り替え(&R)";
            this.contextFileListReverseSelection.Click += new System.EventHandler(this.ReverseSelectionFileListEvent);
            // 
            // contextFileListAutoColumnWidth
            // 
            this.contextFileListAutoColumnWidth.Name = "contextFileListAutoColumnWidth";
            this.contextFileListAutoColumnWidth.Size = new System.Drawing.Size(230, 22);
            this.contextFileListAutoColumnWidth.Text = "検索時に列幅を自動調整(&W)";
            this.contextFileListAutoColumnWidth.Click += new System.EventHandler(this.AutoFileListColumnWidthEvent);
            // 
            // contextFileListShowProperty
            // 
            this.contextFileListShowProperty.Name = "contextFileListShowProperty";
            this.contextFileListShowProperty.Size = new System.Drawing.Size(230, 22);
            this.contextFileListShowProperty.Text = "プロパティの表示(&P)";
            this.contextFileListShowProperty.Click += new System.EventHandler(this.ShowFilePropertyEvent);
            // 
            // imageFileList
            // 
            this.imageFileList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageFileList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageFileList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // inputSplitContainer
            // 
            this.inputSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.inputSplitContainer.Name = "inputSplitContainer";
            this.inputSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // inputSplitContainer.Panel1
            // 
            this.inputSplitContainer.Panel1.Controls.Add(this.inputSearchInfoBorderPanel);
            // 
            // inputSplitContainer.Panel2
            // 
            this.inputSplitContainer.Panel2.Controls.Add(this.inputActionInfoBorderPanel);
            this.inputSplitContainer.Size = new System.Drawing.Size(205, 407);
            this.inputSplitContainer.SplitterDistance = 205;
            this.inputSplitContainer.TabIndex = 0;
            // 
            // inputSearchInfoBorderPanel
            // 
            this.inputSearchInfoBorderPanel.Controls.Add(this.inputSearchInfoPanel);
            this.inputSearchInfoBorderPanel.Controls.Add(this.inputSearchInfoTitle);
            this.inputSearchInfoBorderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputSearchInfoBorderPanel.Location = new System.Drawing.Point(0, 0);
            this.inputSearchInfoBorderPanel.Name = "inputSearchInfoBorderPanel";
            this.inputSearchInfoBorderPanel.Padding = new System.Windows.Forms.Padding(1);
            this.inputSearchInfoBorderPanel.Size = new System.Drawing.Size(205, 205);
            this.inputSearchInfoBorderPanel.TabIndex = 0;
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
            this.inputSearchInfoPanel.Controls.Add(this.radioWildcard, 0, 5);
            this.inputSearchInfoPanel.Controls.Add(this.radioRegex, 1, 5);
            this.inputSearchInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputSearchInfoPanel.Location = new System.Drawing.Point(1, 21);
            this.inputSearchInfoPanel.Name = "inputSearchInfoPanel";
            this.inputSearchInfoPanel.Padding = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.inputSearchInfoPanel.RowCount = 7;
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
            this.inputSearchInfoPanel.Size = new System.Drawing.Size(203, 183);
            this.inputSearchInfoPanel.TabIndex = 1;
            // 
            // textDirectory
            // 
            this.textDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSearchInfoPanel.SetColumnSpan(this.textDirectory, 2);
            this.textDirectory.Location = new System.Drawing.Point(7, 23);
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
            this.textFile.Location = new System.Drawing.Point(7, 89);
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(189, 19);
            this.textFile.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSearch.Location = new System.Drawing.Point(7, 136);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(91, 23);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "検索開始(&S)";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.SearchFileEvent);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClear.Location = new System.Drawing.Point(104, 136);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(92, 23);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "リストのクリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.FileListClearEvent);
            // 
            // buttonDirectory
            // 
            this.buttonDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSearchInfoPanel.SetColumnSpan(this.buttonDirectory, 2);
            this.buttonDirectory.Location = new System.Drawing.Point(68, 48);
            this.buttonDirectory.Name = "buttonDirectory";
            this.buttonDirectory.Size = new System.Drawing.Size(128, 23);
            this.buttonDirectory.TabIndex = 2;
            this.buttonDirectory.Text = "ディレクトリの選択";
            this.buttonDirectory.UseVisualStyleBackColor = true;
            this.buttonDirectory.Click += new System.EventHandler(this.SelectDirectoryEvent);
            // 
            // radioWildcard
            // 
            this.radioWildcard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioWildcard.AutoSize = true;
            this.radioWildcard.Checked = true;
            this.radioWildcard.Location = new System.Drawing.Point(8, 114);
            this.radioWildcard.Name = "radioWildcard";
            this.radioWildcard.Size = new System.Drawing.Size(88, 16);
            this.radioWildcard.TabIndex = 5;
            this.radioWildcard.TabStop = true;
            this.radioWildcard.Text = "ワイルドカード";
            this.radioWildcard.UseVisualStyleBackColor = true;
            // 
            // radioRegex
            // 
            this.radioRegex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioRegex.AutoSize = true;
            this.radioRegex.Location = new System.Drawing.Point(114, 114);
            this.radioRegex.Name = "radioRegex";
            this.radioRegex.Size = new System.Drawing.Size(71, 16);
            this.radioRegex.TabIndex = 6;
            this.radioRegex.Text = "正規表現";
            this.radioRegex.UseVisualStyleBackColor = true;
            // 
            // inputSearchInfoTitle
            // 
            this.inputSearchInfoTitle.AutoEllipsis = true;
            this.inputSearchInfoTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.inputSearchInfoTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputSearchInfoTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inputSearchInfoTitle.Location = new System.Drawing.Point(1, 1);
            this.inputSearchInfoTitle.Name = "inputSearchInfoTitle";
            this.inputSearchInfoTitle.Padding = new System.Windows.Forms.Padding(2);
            this.inputSearchInfoTitle.Size = new System.Drawing.Size(203, 20);
            this.inputSearchInfoTitle.TabIndex = 0;
            this.inputSearchInfoTitle.Text = "検索条件";
            this.inputSearchInfoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inputActionInfoBorderPanel
            // 
            this.inputActionInfoBorderPanel.Controls.Add(this.inputActionInfoPanel);
            this.inputActionInfoBorderPanel.Controls.Add(this.inputActionInfoTitle);
            this.inputActionInfoBorderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputActionInfoBorderPanel.Location = new System.Drawing.Point(0, 0);
            this.inputActionInfoBorderPanel.Name = "inputActionInfoBorderPanel";
            this.inputActionInfoBorderPanel.Padding = new System.Windows.Forms.Padding(1);
            this.inputActionInfoBorderPanel.Size = new System.Drawing.Size(205, 198);
            this.inputActionInfoBorderPanel.TabIndex = 0;
            // 
            // inputActionInfoPanel
            // 
            this.inputActionInfoPanel.ColumnCount = 2;
            this.inputActionInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inputActionInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inputActionInfoPanel.Controls.Add(this.buttonSelectAll, 0, 0);
            this.inputActionInfoPanel.Controls.Add(this.buttonReverseSelection, 1, 0);
            this.inputActionInfoPanel.Controls.Add(this.buttonDeleteFile, 0, 1);
            this.inputActionInfoPanel.Controls.Add(this.checkMoveRecycler, 0, 2);
            this.inputActionInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputActionInfoPanel.Location = new System.Drawing.Point(1, 19);
            this.inputActionInfoPanel.Name = "inputActionInfoPanel";
            this.inputActionInfoPanel.Padding = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.inputActionInfoPanel.RowCount = 3;
            this.inputActionInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputActionInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputActionInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputActionInfoPanel.Size = new System.Drawing.Size(203, 178);
            this.inputActionInfoPanel.TabIndex = 1;
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSelectAll.Location = new System.Drawing.Point(8, 11);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(89, 23);
            this.buttonSelectAll.TabIndex = 0;
            this.buttonSelectAll.Text = "すべて選択";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.SelectAllFileListEvent);
            // 
            // buttonReverseSelection
            // 
            this.buttonReverseSelection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonReverseSelection.Location = new System.Drawing.Point(105, 11);
            this.buttonReverseSelection.Name = "buttonReverseSelection";
            this.buttonReverseSelection.Size = new System.Drawing.Size(89, 23);
            this.buttonReverseSelection.TabIndex = 1;
            this.buttonReverseSelection.Text = "選択の切り替え";
            this.buttonReverseSelection.UseVisualStyleBackColor = true;
            this.buttonReverseSelection.Click += new System.EventHandler(this.ReverseSelectionFileListEvent);
            // 
            // buttonDeleteFile
            // 
            this.buttonDeleteFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputActionInfoPanel.SetColumnSpan(this.buttonDeleteFile, 2);
            this.buttonDeleteFile.Location = new System.Drawing.Point(27, 40);
            this.buttonDeleteFile.Name = "buttonDeleteFile";
            this.buttonDeleteFile.Size = new System.Drawing.Size(148, 23);
            this.buttonDeleteFile.TabIndex = 2;
            this.buttonDeleteFile.Text = "選択ファイルを削除する";
            this.buttonDeleteFile.UseVisualStyleBackColor = true;
            this.buttonDeleteFile.Click += new System.EventHandler(this.DeleteSelectionFilesEvent);
            // 
            // checkMoveRecycler
            // 
            this.checkMoveRecycler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkMoveRecycler.AutoSize = true;
            this.checkMoveRecycler.Checked = true;
            this.checkMoveRecycler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inputActionInfoPanel.SetColumnSpan(this.checkMoveRecycler, 2);
            this.checkMoveRecycler.Location = new System.Drawing.Point(21, 69);
            this.checkMoveRecycler.Name = "checkMoveRecycler";
            this.checkMoveRecycler.Size = new System.Drawing.Size(175, 16);
            this.checkMoveRecycler.TabIndex = 3;
            this.checkMoveRecycler.Text = "削除時にファイルをごみ箱に移す";
            this.checkMoveRecycler.UseVisualStyleBackColor = true;
            // 
            // inputActionInfoTitle
            // 
            this.inputActionInfoTitle.AutoEllipsis = true;
            this.inputActionInfoTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.inputActionInfoTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputActionInfoTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inputActionInfoTitle.Location = new System.Drawing.Point(1, 1);
            this.inputActionInfoTitle.Name = "inputActionInfoTitle";
            this.inputActionInfoTitle.Padding = new System.Windows.Forms.Padding(2);
            this.inputActionInfoTitle.Size = new System.Drawing.Size(203, 18);
            this.inputActionInfoTitle.TabIndex = 0;
            this.inputActionInfoTitle.Text = "アクション";
            this.inputActionInfoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.mainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(632, 407);
            this.mainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.mainToolStripContainer.Name = "mainToolStripContainer";
            this.mainToolStripContainer.Size = new System.Drawing.Size(632, 480);
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
            this.toolFileClear.Text = "リストのクリア";
            this.toolFileClear.Click += new System.EventHandler(this.FileListClearEvent);
            // 
            // toolFileSelectDirectory
            // 
            this.toolFileSelectDirectory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFileSelectDirectory.Image = ((System.Drawing.Image)(resources.GetObject("toolFileSelectDirectory.Image")));
            this.toolFileSelectDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileSelectDirectory.Name = "toolFileSelectDirectory";
            this.toolFileSelectDirectory.Size = new System.Drawing.Size(23, 22);
            this.toolFileSelectDirectory.Text = "ディレクトリの選択";
            this.toolFileSelectDirectory.Click += new System.EventHandler(this.SelectDirectoryEvent);
            // 
            // toolFileSaveAs
            // 
            this.toolFileSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFileSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolFileSaveAs.Image")));
            this.toolFileSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFileSaveAs.Name = "toolFileSaveAs";
            this.toolFileSaveAs.Size = new System.Drawing.Size(23, 22);
            this.toolFileSaveAs.Text = "名前を付けて保存";
            this.toolFileSaveAs.Click += new System.EventHandler(this.SaveFileListEvent);
            // 
            // toolEditResultCopy
            // 
            this.toolEditResultCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditResultCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolEditResultCopy.Image")));
            this.toolEditResultCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditResultCopy.Name = "toolEditResultCopy";
            this.toolEditResultCopy.Size = new System.Drawing.Size(23, 22);
            this.toolEditResultCopy.Text = "検索結果をコピー";
            this.toolEditResultCopy.Click += new System.EventHandler(this.ResultCopyEvent);
            // 
            // toolEditCut
            // 
            this.toolEditCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditCut.Image = ((System.Drawing.Image)(resources.GetObject("toolEditCut.Image")));
            this.toolEditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditCut.Name = "toolEditCut";
            this.toolEditCut.Size = new System.Drawing.Size(23, 22);
            this.toolEditCut.Text = "切り取り";
            this.toolEditCut.Click += new System.EventHandler(this.TextBoxBaseCutEvent);
            // 
            // toolEditCopy
            // 
            this.toolEditCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolEditCopy.Image")));
            this.toolEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditCopy.Name = "toolEditCopy";
            this.toolEditCopy.Size = new System.Drawing.Size(23, 22);
            this.toolEditCopy.Text = "コピー";
            this.toolEditCopy.Click += new System.EventHandler(this.TextBoxBaseCopyEvent);
            // 
            // toolEditPaste
            // 
            this.toolEditPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolEditPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolEditPaste.Image")));
            this.toolEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEditPaste.Name = "toolEditPaste";
            this.toolEditPaste.Size = new System.Drawing.Size(23, 22);
            this.toolEditPaste.Text = "貼り付け";
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
            this.ClientSize = new System.Drawing.Size(632, 480);
            this.Controls.Add(this.mainToolStripContainer);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "SearchFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ファイルの検索";
            this.Deactivate += new System.EventHandler(this.FormDeactivateEvent);
            this.Activated += new System.EventHandler(this.FormActivatedEvent);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.contextFileList.ResumeLayout(false);
            this.inputSplitContainer.Panel1.ResumeLayout(false);
            this.inputSplitContainer.Panel2.ResumeLayout(false);
            this.inputSplitContainer.ResumeLayout(false);
            this.inputSearchInfoBorderPanel.ResumeLayout(false);
            this.inputSearchInfoPanel.ResumeLayout(false);
            this.inputSearchInfoPanel.PerformLayout();
            this.inputActionInfoBorderPanel.ResumeLayout(false);
            this.inputActionInfoPanel.ResumeLayout(false);
            this.inputActionInfoPanel.PerformLayout();
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
        private MyLib.CustomControls.LineBorderPanel inputSearchInfoBorderPanel;
        private MyLib.CustomControls.LineBorderPanel inputActionInfoBorderPanel;
        private System.Windows.Forms.TableLayoutPanel inputActionInfoPanel;
        private System.Windows.Forms.SplitContainer inputSplitContainer;
        private MyLib.CustomControls.LinearGradientDrawLabel inputSearchInfoTitle;
        private MyLib.CustomControls.LinearGradientDrawLabel inputActionInfoTitle;
    }
}

