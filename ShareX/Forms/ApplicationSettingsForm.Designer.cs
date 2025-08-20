using ShareX.HelpersLib;
namespace ShareX
{
    partial class ApplicationSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationSettingsForm));
            this.cmsLanguages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tttvMain = new ShareX.HelpersLib.TabToTreeView();
            this.tpMainWindow = new System.Windows.Forms.TabPage();
            this.lblMainWindowTaskViewMode = new System.Windows.Forms.Label();
            this.cbMainWindowTaskViewMode = new System.Windows.Forms.ComboBox();
            this.cbMainWindowShowMenu = new System.Windows.Forms.CheckBox();
            this.gbThumbnailView = new System.Windows.Forms.GroupBox();
            this.cbThumbnailViewShowTitle = new System.Windows.Forms.CheckBox();
            this.lblThumbnailViewTitleLocation = new System.Windows.Forms.Label();
            this.cbThumbnailViewTitleLocation = new System.Windows.Forms.ComboBox();
            this.lblThumbnailViewThumbnailSize = new System.Windows.Forms.Label();
            this.lblThumbnailViewThumbnailClickAction = new System.Windows.Forms.Label();
            this.cbThumbnailViewThumbnailClickAction = new System.Windows.Forms.ComboBox();
            this.nudThumbnailViewThumbnailSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.nudThumbnailViewThumbnailSizeHeight = new System.Windows.Forms.NumericUpDown();
            this.lblThumbnailViewThumbnailSizeX = new System.Windows.Forms.Label();
            this.btnThumbnailViewThumbnailSizeReset = new System.Windows.Forms.Button();
            this.gbListView = new System.Windows.Forms.GroupBox();
            this.cbListViewShowColumns = new System.Windows.Forms.CheckBox();
            this.lblListViewImagePreviewVisibility = new System.Windows.Forms.Label();
            this.cbListViewImagePreviewVisibility = new System.Windows.Forms.ComboBox();
            this.lblListViewImagePreviewLocation = new System.Windows.Forms.Label();
            this.cbListViewImagePreviewLocation = new System.Windows.Forms.ComboBox();
            this.tpPaths = new System.Windows.Forms.TabPage();
            this.txtSaveImageSubFolderPattern = new System.Windows.Forms.TextBox();
            this.lblSaveImageSubFolderPatternPreview = new System.Windows.Forms.Label();
            this.lblSaveImageSubFolderPattern = new System.Windows.Forms.Label();
            this.cbUseCustomScreenshotsPath = new System.Windows.Forms.CheckBox();
            this.txtCustomScreenshotsPath = new System.Windows.Forms.TextBox();
            this.btnOpenPersonalFolderPath = new System.Windows.Forms.Button();
            this.btnBrowseCustomScreenshotsPath = new System.Windows.Forms.Button();
            this.txtPersonalFolderPath = new System.Windows.Forms.TextBox();
            this.lblPersonalFolderPath = new System.Windows.Forms.Label();
            this.btnBrowsePersonalFolderPath = new System.Windows.Forms.Button();
            this.lblPreviewPersonalFolderPath = new System.Windows.Forms.Label();
            this.btnOpenScreenshotsFolder = new System.Windows.Forms.Button();
            this.btnPersonalFolderPathApply = new System.Windows.Forms.Button();
            this.lblSaveImageSubFolderPatternWindow = new System.Windows.Forms.Label();
            this.txtSaveImageSubFolderPatternWindow = new System.Windows.Forms.TextBox();
            this.tpIntegration = new System.Windows.Forms.TabPage();
            this.gbWindows = new System.Windows.Forms.GroupBox();
            this.cbShellContextMenu = new System.Windows.Forms.CheckBox();
            this.cbSendToMenu = new System.Windows.Forms.CheckBox();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.cbEditWithShareX = new System.Windows.Forms.CheckBox();
            this.gbChrome = new System.Windows.Forms.GroupBox();
            this.btnChromeOpenExtensionPage = new System.Windows.Forms.Button();
            this.cbChromeExtensionSupport = new System.Windows.Forms.CheckBox();
            this.gbSteam = new System.Windows.Forms.GroupBox();
            this.cbSteamShowInApp = new System.Windows.Forms.CheckBox();
            this.gbFirefox = new System.Windows.Forms.GroupBox();
            this.btnFirefoxOpenAddonPage = new System.Windows.Forms.Button();
            this.cbFirefoxAddonSupport = new System.Windows.Forms.CheckBox();
            this.tpTheme = new System.Windows.Forms.TabPage();
            this.eiTheme = new ShareX.HelpersLib.ExportImportControl();
            this.pgTheme = new System.Windows.Forms.PropertyGrid();
            this.cbThemes = new System.Windows.Forms.ComboBox();
            this.btnThemeAdd = new System.Windows.Forms.Button();
            this.btnThemeRemove = new System.Windows.Forms.Button();
            this.btnThemeReset = new System.Windows.Forms.Button();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cbRememberMainFormSize = new System.Windows.Forms.CheckBox();
            this.cbTaskbarProgressEnabled = new System.Windows.Forms.CheckBox();
            this.cbSilentRun = new System.Windows.Forms.CheckBox();
            this.cbRememberMainFormPosition = new System.Windows.Forms.CheckBox();
            this.btnLanguages = new ShareX.HelpersLib.MenuButton();
            this.cbTrayIconProgressEnabled = new System.Windows.Forms.CheckBox();
            this.cbShowTray = new System.Windows.Forms.CheckBox();
            this.cbUseWhiteShareXIcon = new System.Windows.Forms.CheckBox();
            this.tcSettings = new System.Windows.Forms.TabControl();
            this.tpMainWindow.SuspendLayout();
            this.gbThumbnailView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThumbnailViewThumbnailSizeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThumbnailViewThumbnailSizeHeight)).BeginInit();
            this.gbListView.SuspendLayout();
            this.tpPaths.SuspendLayout();
            this.tpIntegration.SuspendLayout();
            this.gbWindows.SuspendLayout();
            this.gbChrome.SuspendLayout();
            this.gbSteam.SuspendLayout();
            this.gbFirefox.SuspendLayout();
            this.tpTheme.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tcSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsLanguages
            // 
            this.cmsLanguages.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsLanguages.Name = "cmsLanguages";
            resources.ApplyResources(this.cmsLanguages, "cmsLanguages");
            // 
            // tttvMain
            // 
            resources.ApplyResources(this.tttvMain, "tttvMain");
            this.tttvMain.ImageList = null;
            this.tttvMain.LeftPanelBackColor = System.Drawing.SystemColors.Window;
            this.tttvMain.MainTabControl = null;
            this.tttvMain.Name = "tttvMain";
            this.tttvMain.SeparatorColor = System.Drawing.SystemColors.ControlDark;
            this.tttvMain.TreeViewFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tttvMain.TreeViewSize = 175;
            this.tttvMain.TabChanged += new ShareX.HelpersLib.TabToTreeView.TabChangedEventHandler(this.tttvMain_TabChanged);
            // 
            // tpMainWindow
            // 
            this.tpMainWindow.Controls.Add(this.gbListView);
            this.tpMainWindow.Controls.Add(this.gbThumbnailView);
            this.tpMainWindow.Controls.Add(this.cbMainWindowShowMenu);
            this.tpMainWindow.Controls.Add(this.cbMainWindowTaskViewMode);
            this.tpMainWindow.Controls.Add(this.lblMainWindowTaskViewMode);
            resources.ApplyResources(this.tpMainWindow, "tpMainWindow");
            this.tpMainWindow.Name = "tpMainWindow";
            this.tpMainWindow.UseVisualStyleBackColor = true;
            // 
            // lblMainWindowTaskViewMode
            // 
            resources.ApplyResources(this.lblMainWindowTaskViewMode, "lblMainWindowTaskViewMode");
            this.lblMainWindowTaskViewMode.Name = "lblMainWindowTaskViewMode";
            // 
            // cbMainWindowTaskViewMode
            // 
            this.cbMainWindowTaskViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMainWindowTaskViewMode.FormattingEnabled = true;
            resources.ApplyResources(this.cbMainWindowTaskViewMode, "cbMainWindowTaskViewMode");
            this.cbMainWindowTaskViewMode.Name = "cbMainWindowTaskViewMode";
            this.cbMainWindowTaskViewMode.SelectedIndexChanged += new System.EventHandler(this.cbMainWindowTaskViewMode_SelectedIndexChanged);
            // 
            // cbMainWindowShowMenu
            // 
            resources.ApplyResources(this.cbMainWindowShowMenu, "cbMainWindowShowMenu");
            this.cbMainWindowShowMenu.Name = "cbMainWindowShowMenu";
            this.cbMainWindowShowMenu.UseVisualStyleBackColor = true;
            this.cbMainWindowShowMenu.CheckedChanged += new System.EventHandler(this.cbMainWindowShowMenu_CheckedChanged);
            // 
            // gbThumbnailView
            // 
            this.gbThumbnailView.Controls.Add(this.btnThumbnailViewThumbnailSizeReset);
            this.gbThumbnailView.Controls.Add(this.lblThumbnailViewThumbnailSizeX);
            this.gbThumbnailView.Controls.Add(this.nudThumbnailViewThumbnailSizeHeight);
            this.gbThumbnailView.Controls.Add(this.nudThumbnailViewThumbnailSizeWidth);
            this.gbThumbnailView.Controls.Add(this.cbThumbnailViewThumbnailClickAction);
            this.gbThumbnailView.Controls.Add(this.lblThumbnailViewThumbnailClickAction);
            this.gbThumbnailView.Controls.Add(this.lblThumbnailViewThumbnailSize);
            this.gbThumbnailView.Controls.Add(this.cbThumbnailViewTitleLocation);
            this.gbThumbnailView.Controls.Add(this.lblThumbnailViewTitleLocation);
            this.gbThumbnailView.Controls.Add(this.cbThumbnailViewShowTitle);
            resources.ApplyResources(this.gbThumbnailView, "gbThumbnailView");
            this.gbThumbnailView.Name = "gbThumbnailView";
            this.gbThumbnailView.TabStop = false;
            // 
            // cbThumbnailViewShowTitle
            // 
            resources.ApplyResources(this.cbThumbnailViewShowTitle, "cbThumbnailViewShowTitle");
            this.cbThumbnailViewShowTitle.Name = "cbThumbnailViewShowTitle";
            this.cbThumbnailViewShowTitle.UseVisualStyleBackColor = true;
            this.cbThumbnailViewShowTitle.CheckedChanged += new System.EventHandler(this.cbThumbnailViewShowTitle_CheckedChanged);
            // 
            // lblThumbnailViewTitleLocation
            // 
            resources.ApplyResources(this.lblThumbnailViewTitleLocation, "lblThumbnailViewTitleLocation");
            this.lblThumbnailViewTitleLocation.Name = "lblThumbnailViewTitleLocation";
            // 
            // cbThumbnailViewTitleLocation
            // 
            this.cbThumbnailViewTitleLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThumbnailViewTitleLocation.FormattingEnabled = true;
            resources.ApplyResources(this.cbThumbnailViewTitleLocation, "cbThumbnailViewTitleLocation");
            this.cbThumbnailViewTitleLocation.Name = "cbThumbnailViewTitleLocation";
            this.cbThumbnailViewTitleLocation.SelectedIndexChanged += new System.EventHandler(this.cbThumbnailViewTitleLocation_SelectedIndexChanged);
            // 
            // lblThumbnailViewThumbnailSize
            // 
            resources.ApplyResources(this.lblThumbnailViewThumbnailSize, "lblThumbnailViewThumbnailSize");
            this.lblThumbnailViewThumbnailSize.Name = "lblThumbnailViewThumbnailSize";
            // 
            // lblThumbnailViewThumbnailClickAction
            // 
            resources.ApplyResources(this.lblThumbnailViewThumbnailClickAction, "lblThumbnailViewThumbnailClickAction");
            this.lblThumbnailViewThumbnailClickAction.Name = "lblThumbnailViewThumbnailClickAction";
            // 
            // cbThumbnailViewThumbnailClickAction
            // 
            this.cbThumbnailViewThumbnailClickAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThumbnailViewThumbnailClickAction.FormattingEnabled = true;
            resources.ApplyResources(this.cbThumbnailViewThumbnailClickAction, "cbThumbnailViewThumbnailClickAction");
            this.cbThumbnailViewThumbnailClickAction.Name = "cbThumbnailViewThumbnailClickAction";
            this.cbThumbnailViewThumbnailClickAction.SelectedIndexChanged += new System.EventHandler(this.cbThumbnailViewThumbnailClickAction_SelectedIndexChanged);
            // 
            // nudThumbnailViewThumbnailSizeWidth
            // 
            resources.ApplyResources(this.nudThumbnailViewThumbnailSizeWidth, "nudThumbnailViewThumbnailSizeWidth");
            this.nudThumbnailViewThumbnailSizeWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudThumbnailViewThumbnailSizeWidth.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudThumbnailViewThumbnailSizeWidth.Name = "nudThumbnailViewThumbnailSizeWidth";
            this.nudThumbnailViewThumbnailSizeWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudThumbnailViewThumbnailSizeWidth.ValueChanged += new System.EventHandler(this.nudThumbnailViewThumbnailSizeWidth_ValueChanged);
            // 
            // nudThumbnailViewThumbnailSizeHeight
            // 
            resources.ApplyResources(this.nudThumbnailViewThumbnailSizeHeight, "nudThumbnailViewThumbnailSizeHeight");
            this.nudThumbnailViewThumbnailSizeHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudThumbnailViewThumbnailSizeHeight.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudThumbnailViewThumbnailSizeHeight.Name = "nudThumbnailViewThumbnailSizeHeight";
            this.nudThumbnailViewThumbnailSizeHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudThumbnailViewThumbnailSizeHeight.ValueChanged += new System.EventHandler(this.nudThumbnailViewThumbnailSizeHeight_ValueChanged);
            // 
            // lblThumbnailViewThumbnailSizeX
            // 
            resources.ApplyResources(this.lblThumbnailViewThumbnailSizeX, "lblThumbnailViewThumbnailSizeX");
            this.lblThumbnailViewThumbnailSizeX.Name = "lblThumbnailViewThumbnailSizeX";
            // 
            // btnThumbnailViewThumbnailSizeReset
            // 
            resources.ApplyResources(this.btnThumbnailViewThumbnailSizeReset, "btnThumbnailViewThumbnailSizeReset");
            this.btnThumbnailViewThumbnailSizeReset.Name = "btnThumbnailViewThumbnailSizeReset";
            this.btnThumbnailViewThumbnailSizeReset.UseVisualStyleBackColor = true;
            this.btnThumbnailViewThumbnailSizeReset.Click += new System.EventHandler(this.btnThumbnailViewThumbnailSizeReset_Click);
            // 
            // gbListView
            // 
            this.gbListView.Controls.Add(this.cbListViewImagePreviewLocation);
            this.gbListView.Controls.Add(this.lblListViewImagePreviewLocation);
            this.gbListView.Controls.Add(this.cbListViewImagePreviewVisibility);
            this.gbListView.Controls.Add(this.lblListViewImagePreviewVisibility);
            this.gbListView.Controls.Add(this.cbListViewShowColumns);
            resources.ApplyResources(this.gbListView, "gbListView");
            this.gbListView.Name = "gbListView";
            this.gbListView.TabStop = false;
            // 
            // cbListViewShowColumns
            // 
            resources.ApplyResources(this.cbListViewShowColumns, "cbListViewShowColumns");
            this.cbListViewShowColumns.Name = "cbListViewShowColumns";
            this.cbListViewShowColumns.UseVisualStyleBackColor = true;
            this.cbListViewShowColumns.CheckedChanged += new System.EventHandler(this.cbListViewShowColumns_CheckedChanged);
            // 
            // lblListViewImagePreviewVisibility
            // 
            resources.ApplyResources(this.lblListViewImagePreviewVisibility, "lblListViewImagePreviewVisibility");
            this.lblListViewImagePreviewVisibility.Name = "lblListViewImagePreviewVisibility";
            // 
            // cbListViewImagePreviewVisibility
            // 
            this.cbListViewImagePreviewVisibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListViewImagePreviewVisibility.FormattingEnabled = true;
            resources.ApplyResources(this.cbListViewImagePreviewVisibility, "cbListViewImagePreviewVisibility");
            this.cbListViewImagePreviewVisibility.Name = "cbListViewImagePreviewVisibility";
            this.cbListViewImagePreviewVisibility.SelectedIndexChanged += new System.EventHandler(this.cbListViewImagePreviewVisibility_SelectedIndexChanged);
            // 
            // lblListViewImagePreviewLocation
            // 
            resources.ApplyResources(this.lblListViewImagePreviewLocation, "lblListViewImagePreviewLocation");
            this.lblListViewImagePreviewLocation.Name = "lblListViewImagePreviewLocation";
            // 
            // cbListViewImagePreviewLocation
            // 
            this.cbListViewImagePreviewLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListViewImagePreviewLocation.FormattingEnabled = true;
            resources.ApplyResources(this.cbListViewImagePreviewLocation, "cbListViewImagePreviewLocation");
            this.cbListViewImagePreviewLocation.Name = "cbListViewImagePreviewLocation";
            this.cbListViewImagePreviewLocation.SelectedIndexChanged += new System.EventHandler(this.cbListViewImagePreviewLocation_SelectedIndexChanged);
            // 
            // tpPaths
            // 
            this.tpPaths.BackColor = System.Drawing.SystemColors.Window;
            this.tpPaths.Controls.Add(this.txtSaveImageSubFolderPatternWindow);
            this.tpPaths.Controls.Add(this.txtPersonalFolderPath);
            this.tpPaths.Controls.Add(this.txtCustomScreenshotsPath);
            this.tpPaths.Controls.Add(this.txtSaveImageSubFolderPattern);
            this.tpPaths.Controls.Add(this.lblSaveImageSubFolderPatternWindow);
            this.tpPaths.Controls.Add(this.btnPersonalFolderPathApply);
            this.tpPaths.Controls.Add(this.btnOpenScreenshotsFolder);
            this.tpPaths.Controls.Add(this.lblPreviewPersonalFolderPath);
            this.tpPaths.Controls.Add(this.btnBrowsePersonalFolderPath);
            this.tpPaths.Controls.Add(this.lblPersonalFolderPath);
            this.tpPaths.Controls.Add(this.btnBrowseCustomScreenshotsPath);
            this.tpPaths.Controls.Add(this.btnOpenPersonalFolderPath);
            this.tpPaths.Controls.Add(this.cbUseCustomScreenshotsPath);
            this.tpPaths.Controls.Add(this.lblSaveImageSubFolderPattern);
            this.tpPaths.Controls.Add(this.lblSaveImageSubFolderPatternPreview);
            resources.ApplyResources(this.tpPaths, "tpPaths");
            this.tpPaths.Name = "tpPaths";
            // 
            // txtSaveImageSubFolderPattern
            // 
            resources.ApplyResources(this.txtSaveImageSubFolderPattern, "txtSaveImageSubFolderPattern");
            this.txtSaveImageSubFolderPattern.Name = "txtSaveImageSubFolderPattern";
            this.txtSaveImageSubFolderPattern.TextChanged += new System.EventHandler(this.txtSaveImageSubFolderPattern_TextChanged);
            // 
            // lblSaveImageSubFolderPatternPreview
            // 
            resources.ApplyResources(this.lblSaveImageSubFolderPatternPreview, "lblSaveImageSubFolderPatternPreview");
            this.lblSaveImageSubFolderPatternPreview.Name = "lblSaveImageSubFolderPatternPreview";
            // 
            // lblSaveImageSubFolderPattern
            // 
            resources.ApplyResources(this.lblSaveImageSubFolderPattern, "lblSaveImageSubFolderPattern");
            this.lblSaveImageSubFolderPattern.Name = "lblSaveImageSubFolderPattern";
            // 
            // cbUseCustomScreenshotsPath
            // 
            resources.ApplyResources(this.cbUseCustomScreenshotsPath, "cbUseCustomScreenshotsPath");
            this.cbUseCustomScreenshotsPath.Name = "cbUseCustomScreenshotsPath";
            this.cbUseCustomScreenshotsPath.UseVisualStyleBackColor = true;
            this.cbUseCustomScreenshotsPath.CheckedChanged += new System.EventHandler(this.cbUseCustomScreenshotsPath_CheckedChanged);
            // 
            // txtCustomScreenshotsPath
            // 
            resources.ApplyResources(this.txtCustomScreenshotsPath, "txtCustomScreenshotsPath");
            this.txtCustomScreenshotsPath.Name = "txtCustomScreenshotsPath";
            this.txtCustomScreenshotsPath.TextChanged += new System.EventHandler(this.txtCustomScreenshotsPath_TextChanged);
            // 
            // btnOpenPersonalFolderPath
            // 
            resources.ApplyResources(this.btnOpenPersonalFolderPath, "btnOpenPersonalFolderPath");
            this.btnOpenPersonalFolderPath.Name = "btnOpenPersonalFolderPath";
            this.btnOpenPersonalFolderPath.UseVisualStyleBackColor = true;
            this.btnOpenPersonalFolderPath.Click += new System.EventHandler(this.btnOpenPersonalFolder_Click);
            // 
            // btnBrowseCustomScreenshotsPath
            // 
            resources.ApplyResources(this.btnBrowseCustomScreenshotsPath, "btnBrowseCustomScreenshotsPath");
            this.btnBrowseCustomScreenshotsPath.Name = "btnBrowseCustomScreenshotsPath";
            this.btnBrowseCustomScreenshotsPath.UseVisualStyleBackColor = true;
            this.btnBrowseCustomScreenshotsPath.Click += new System.EventHandler(this.btnBrowseCustomScreenshotsPath_Click);
            // 
            // txtPersonalFolderPath
            // 
            resources.ApplyResources(this.txtPersonalFolderPath, "txtPersonalFolderPath");
            this.txtPersonalFolderPath.Name = "txtPersonalFolderPath";
            this.txtPersonalFolderPath.TextChanged += new System.EventHandler(this.txtPersonalFolderPath_TextChanged);
            // 
            // lblPersonalFolderPath
            // 
            resources.ApplyResources(this.lblPersonalFolderPath, "lblPersonalFolderPath");
            this.lblPersonalFolderPath.Name = "lblPersonalFolderPath";
            // 
            // btnBrowsePersonalFolderPath
            // 
            resources.ApplyResources(this.btnBrowsePersonalFolderPath, "btnBrowsePersonalFolderPath");
            this.btnBrowsePersonalFolderPath.Name = "btnBrowsePersonalFolderPath";
            this.btnBrowsePersonalFolderPath.UseVisualStyleBackColor = true;
            this.btnBrowsePersonalFolderPath.Click += new System.EventHandler(this.btnBrowsePersonalFolderPath_Click);
            // 
            // lblPreviewPersonalFolderPath
            // 
            resources.ApplyResources(this.lblPreviewPersonalFolderPath, "lblPreviewPersonalFolderPath");
            this.lblPreviewPersonalFolderPath.Name = "lblPreviewPersonalFolderPath";
            // 
            // btnOpenScreenshotsFolder
            // 
            resources.ApplyResources(this.btnOpenScreenshotsFolder, "btnOpenScreenshotsFolder");
            this.btnOpenScreenshotsFolder.Name = "btnOpenScreenshotsFolder";
            this.btnOpenScreenshotsFolder.UseVisualStyleBackColor = true;
            this.btnOpenScreenshotsFolder.Click += new System.EventHandler(this.btnOpenScreenshotsFolder_Click);
            // 
            // btnPersonalFolderPathApply
            // 
            resources.ApplyResources(this.btnPersonalFolderPathApply, "btnPersonalFolderPathApply");
            this.btnPersonalFolderPathApply.Name = "btnPersonalFolderPathApply";
            this.btnPersonalFolderPathApply.UseVisualStyleBackColor = true;
            this.btnPersonalFolderPathApply.Click += new System.EventHandler(this.btnPersonalFolderPathApply_Click);
            // 
            // lblSaveImageSubFolderPatternWindow
            // 
            resources.ApplyResources(this.lblSaveImageSubFolderPatternWindow, "lblSaveImageSubFolderPatternWindow");
            this.lblSaveImageSubFolderPatternWindow.Name = "lblSaveImageSubFolderPatternWindow";
            // 
            // txtSaveImageSubFolderPatternWindow
            // 
            resources.ApplyResources(this.txtSaveImageSubFolderPatternWindow, "txtSaveImageSubFolderPatternWindow");
            this.txtSaveImageSubFolderPatternWindow.Name = "txtSaveImageSubFolderPatternWindow";
            this.txtSaveImageSubFolderPatternWindow.TextChanged += new System.EventHandler(this.txtSaveImageSubFolderPatternWindow_TextChanged);
            // 
            // tpIntegration
            // 
            this.tpIntegration.BackColor = System.Drawing.SystemColors.Window;
            this.tpIntegration.Controls.Add(this.gbFirefox);
            this.tpIntegration.Controls.Add(this.gbSteam);
            this.tpIntegration.Controls.Add(this.gbChrome);
            this.tpIntegration.Controls.Add(this.gbWindows);
            resources.ApplyResources(this.tpIntegration, "tpIntegration");
            this.tpIntegration.Name = "tpIntegration";
            // 
            // gbWindows
            // 
            this.gbWindows.Controls.Add(this.cbEditWithShareX);
            this.gbWindows.Controls.Add(this.cbStartWithWindows);
            this.gbWindows.Controls.Add(this.cbSendToMenu);
            this.gbWindows.Controls.Add(this.cbShellContextMenu);
            resources.ApplyResources(this.gbWindows, "gbWindows");
            this.gbWindows.Name = "gbWindows";
            this.gbWindows.TabStop = false;
            // 
            // cbShellContextMenu
            // 
            resources.ApplyResources(this.cbShellContextMenu, "cbShellContextMenu");
            this.cbShellContextMenu.Name = "cbShellContextMenu";
            this.cbShellContextMenu.UseVisualStyleBackColor = true;
            this.cbShellContextMenu.CheckedChanged += new System.EventHandler(this.cbShellContextMenu_CheckedChanged);
            // 
            // cbSendToMenu
            // 
            resources.ApplyResources(this.cbSendToMenu, "cbSendToMenu");
            this.cbSendToMenu.Name = "cbSendToMenu";
            this.cbSendToMenu.UseVisualStyleBackColor = true;
            this.cbSendToMenu.CheckedChanged += new System.EventHandler(this.cbSendToMenu_CheckedChanged);
            // 
            // cbStartWithWindows
            // 
            resources.ApplyResources(this.cbStartWithWindows, "cbStartWithWindows");
            this.cbStartWithWindows.Name = "cbStartWithWindows";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            this.cbStartWithWindows.CheckedChanged += new System.EventHandler(this.cbStartWithWindows_CheckedChanged);
            // 
            // cbEditWithShareX
            // 
            resources.ApplyResources(this.cbEditWithShareX, "cbEditWithShareX");
            this.cbEditWithShareX.Name = "cbEditWithShareX";
            this.cbEditWithShareX.UseVisualStyleBackColor = true;
            this.cbEditWithShareX.CheckedChanged += new System.EventHandler(this.cbEditWithShareX_CheckedChanged);
            // 
            // gbChrome
            // 
            this.gbChrome.Controls.Add(this.cbChromeExtensionSupport);
            this.gbChrome.Controls.Add(this.btnChromeOpenExtensionPage);
            resources.ApplyResources(this.gbChrome, "gbChrome");
            this.gbChrome.Name = "gbChrome";
            this.gbChrome.TabStop = false;
            // 
            // btnChromeOpenExtensionPage
            // 
            resources.ApplyResources(this.btnChromeOpenExtensionPage, "btnChromeOpenExtensionPage");
            this.btnChromeOpenExtensionPage.Name = "btnChromeOpenExtensionPage";
            this.btnChromeOpenExtensionPage.UseVisualStyleBackColor = true;
            this.btnChromeOpenExtensionPage.Click += new System.EventHandler(this.btnChromeOpenExtensionPage_Click);
            // 
            // cbChromeExtensionSupport
            // 
            resources.ApplyResources(this.cbChromeExtensionSupport, "cbChromeExtensionSupport");
            this.cbChromeExtensionSupport.Name = "cbChromeExtensionSupport";
            this.cbChromeExtensionSupport.UseVisualStyleBackColor = true;
            this.cbChromeExtensionSupport.CheckedChanged += new System.EventHandler(this.cbChromeExtensionSupport_CheckedChanged);
            // 
            // gbSteam
            // 
            this.gbSteam.Controls.Add(this.cbSteamShowInApp);
            resources.ApplyResources(this.gbSteam, "gbSteam");
            this.gbSteam.Name = "gbSteam";
            this.gbSteam.TabStop = false;
            // 
            // cbSteamShowInApp
            // 
            resources.ApplyResources(this.cbSteamShowInApp, "cbSteamShowInApp");
            this.cbSteamShowInApp.Name = "cbSteamShowInApp";
            this.cbSteamShowInApp.UseVisualStyleBackColor = true;
            this.cbSteamShowInApp.CheckedChanged += new System.EventHandler(this.cbSteamShowInApp_CheckedChanged);
            // 
            // gbFirefox
            // 
            this.gbFirefox.Controls.Add(this.cbFirefoxAddonSupport);
            this.gbFirefox.Controls.Add(this.btnFirefoxOpenAddonPage);
            resources.ApplyResources(this.gbFirefox, "gbFirefox");
            this.gbFirefox.Name = "gbFirefox";
            this.gbFirefox.TabStop = false;
            // 
            // btnFirefoxOpenAddonPage
            // 
            resources.ApplyResources(this.btnFirefoxOpenAddonPage, "btnFirefoxOpenAddonPage");
            this.btnFirefoxOpenAddonPage.Name = "btnFirefoxOpenAddonPage";
            this.btnFirefoxOpenAddonPage.UseVisualStyleBackColor = true;
            this.btnFirefoxOpenAddonPage.Click += new System.EventHandler(this.btnFirefoxOpenAddonPage_Click);
            // 
            // cbFirefoxAddonSupport
            // 
            resources.ApplyResources(this.cbFirefoxAddonSupport, "cbFirefoxAddonSupport");
            this.cbFirefoxAddonSupport.Name = "cbFirefoxAddonSupport";
            this.cbFirefoxAddonSupport.UseVisualStyleBackColor = true;
            this.cbFirefoxAddonSupport.CheckedChanged += new System.EventHandler(this.cbFirefoxAddonSupport_CheckedChanged);
            // 
            // tpTheme
            // 
            this.tpTheme.Controls.Add(this.btnThemeReset);
            this.tpTheme.Controls.Add(this.btnThemeRemove);
            this.tpTheme.Controls.Add(this.btnThemeAdd);
            this.tpTheme.Controls.Add(this.cbThemes);
            this.tpTheme.Controls.Add(this.pgTheme);
            this.tpTheme.Controls.Add(this.eiTheme);
            resources.ApplyResources(this.tpTheme, "tpTheme");
            this.tpTheme.Name = "tpTheme";
            this.tpTheme.UseVisualStyleBackColor = true;
            // 
            // eiTheme
            // 
            this.eiTheme.DefaultFileName = null;
            resources.ApplyResources(this.eiTheme, "eiTheme");
            this.eiTheme.Name = "eiTheme";
            this.eiTheme.ObjectType = null;
            this.eiTheme.SerializationBinder = null;
            this.eiTheme.ExportRequested += new ShareX.HelpersLib.ExportImportControl.ExportEventHandler(this.EiTheme_ExportRequested);
            this.eiTheme.ImportRequested += new ShareX.HelpersLib.ExportImportControl.ImportEventHandler(this.EiTheme_ImportRequested);
            // 
            // pgTheme
            // 
            resources.ApplyResources(this.pgTheme, "pgTheme");
            this.pgTheme.Name = "pgTheme";
            this.pgTheme.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgTheme.ToolbarVisible = false;
            this.pgTheme.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgTheme_PropertyValueChanged);
            // 
            // cbThemes
            // 
            this.cbThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThemes.FormattingEnabled = true;
            resources.ApplyResources(this.cbThemes, "cbThemes");
            this.cbThemes.Name = "cbThemes";
            this.cbThemes.SelectedIndexChanged += new System.EventHandler(this.CbThemes_SelectedIndexChanged);
            // 
            // btnThemeAdd
            // 
            resources.ApplyResources(this.btnThemeAdd, "btnThemeAdd");
            this.btnThemeAdd.Name = "btnThemeAdd";
            this.btnThemeAdd.UseVisualStyleBackColor = true;
            this.btnThemeAdd.Click += new System.EventHandler(this.BtnThemeAdd_Click);
            // 
            // btnThemeRemove
            // 
            resources.ApplyResources(this.btnThemeRemove, "btnThemeRemove");
            this.btnThemeRemove.Name = "btnThemeRemove";
            this.btnThemeRemove.UseVisualStyleBackColor = true;
            this.btnThemeRemove.Click += new System.EventHandler(this.BtnThemeRemove_Click);
            // 
            // btnThemeReset
            // 
            resources.ApplyResources(this.btnThemeReset, "btnThemeReset");
            this.btnThemeReset.Name = "btnThemeReset";
            this.btnThemeReset.UseVisualStyleBackColor = true;
            this.btnThemeReset.Click += new System.EventHandler(this.BtnThemeReset_Click);
            // 
            // tpGeneral
            // 
            this.tpGeneral.BackColor = System.Drawing.SystemColors.Window;
            this.tpGeneral.Controls.Add(this.cbUseWhiteShareXIcon);
            this.tpGeneral.Controls.Add(this.cbShowTray);
            this.tpGeneral.Controls.Add(this.cbTrayIconProgressEnabled);
            this.tpGeneral.Controls.Add(this.btnLanguages);
            this.tpGeneral.Controls.Add(this.cbRememberMainFormPosition);
            this.tpGeneral.Controls.Add(this.cbSilentRun);
            this.tpGeneral.Controls.Add(this.cbTaskbarProgressEnabled);
            this.tpGeneral.Controls.Add(this.cbRememberMainFormSize);
            this.tpGeneral.Controls.Add(this.lblLanguage);
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Name = "tpGeneral";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // cbRememberMainFormSize
            // 
            resources.ApplyResources(this.cbRememberMainFormSize, "cbRememberMainFormSize");
            this.cbRememberMainFormSize.Name = "cbRememberMainFormSize";
            this.cbRememberMainFormSize.UseVisualStyleBackColor = true;
            this.cbRememberMainFormSize.CheckedChanged += new System.EventHandler(this.cbRememberMainFormSize_CheckedChanged);
            // 
            // cbTaskbarProgressEnabled
            // 
            resources.ApplyResources(this.cbTaskbarProgressEnabled, "cbTaskbarProgressEnabled");
            this.cbTaskbarProgressEnabled.Name = "cbTaskbarProgressEnabled";
            this.cbTaskbarProgressEnabled.UseVisualStyleBackColor = true;
            this.cbTaskbarProgressEnabled.CheckedChanged += new System.EventHandler(this.cbTaskbarProgressEnabled_CheckedChanged);
            // 
            // cbSilentRun
            // 
            resources.ApplyResources(this.cbSilentRun, "cbSilentRun");
            this.cbSilentRun.Name = "cbSilentRun";
            this.cbSilentRun.UseVisualStyleBackColor = true;
            this.cbSilentRun.CheckedChanged += new System.EventHandler(this.cbSilentRun_CheckedChanged);
            // 
            // cbRememberMainFormPosition
            // 
            resources.ApplyResources(this.cbRememberMainFormPosition, "cbRememberMainFormPosition");
            this.cbRememberMainFormPosition.Name = "cbRememberMainFormPosition";
            this.cbRememberMainFormPosition.UseVisualStyleBackColor = true;
            this.cbRememberMainFormPosition.CheckedChanged += new System.EventHandler(this.cbRememberMainFormPosition_CheckedChanged);
            // 
            // btnLanguages
            // 
            resources.ApplyResources(this.btnLanguages, "btnLanguages");
            this.btnLanguages.Menu = this.cmsLanguages;
            this.btnLanguages.Name = "btnLanguages";
            this.btnLanguages.UseVisualStyleBackColor = true;
            // 
            // cbTrayIconProgressEnabled
            // 
            resources.ApplyResources(this.cbTrayIconProgressEnabled, "cbTrayIconProgressEnabled");
            this.cbTrayIconProgressEnabled.Name = "cbTrayIconProgressEnabled";
            this.cbTrayIconProgressEnabled.UseVisualStyleBackColor = true;
            this.cbTrayIconProgressEnabled.CheckedChanged += new System.EventHandler(this.cbTrayIconProgressEnabled_CheckedChanged);
            // 
            // cbShowTray
            // 
            resources.ApplyResources(this.cbShowTray, "cbShowTray");
            this.cbShowTray.Name = "cbShowTray";
            this.cbShowTray.UseVisualStyleBackColor = true;
            this.cbShowTray.CheckedChanged += new System.EventHandler(this.cbShowTray_CheckedChanged);
            // 
            // cbUseWhiteShareXIcon
            // 
            resources.ApplyResources(this.cbUseWhiteShareXIcon, "cbUseWhiteShareXIcon");
            this.cbUseWhiteShareXIcon.Name = "cbUseWhiteShareXIcon";
            this.cbUseWhiteShareXIcon.UseVisualStyleBackColor = true;
            this.cbUseWhiteShareXIcon.CheckedChanged += new System.EventHandler(this.CbUseWhiteShareXIcon_CheckedChanged);
            // 
            // tcSettings
            // 
            resources.ApplyResources(this.tcSettings, "tcSettings");
            this.tcSettings.Controls.Add(this.tpGeneral);
            this.tcSettings.Controls.Add(this.tpTheme);
            this.tcSettings.Controls.Add(this.tpIntegration);
            this.tcSettings.Controls.Add(this.tpPaths);
            this.tcSettings.Controls.Add(this.tpMainWindow);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            // 
            // ApplicationSettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tcSettings);
            this.Controls.Add(this.tttvMain);
            this.Name = "ApplicationSettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.Resize += new System.EventHandler(this.SettingsForm_Resize);
            this.tpMainWindow.ResumeLayout(false);
            this.tpMainWindow.PerformLayout();
            this.gbThumbnailView.ResumeLayout(false);
            this.gbThumbnailView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThumbnailViewThumbnailSizeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThumbnailViewThumbnailSizeHeight)).EndInit();
            this.gbListView.ResumeLayout(false);
            this.gbListView.PerformLayout();
            this.tpPaths.ResumeLayout(false);
            this.tpPaths.PerformLayout();
            this.tpIntegration.ResumeLayout(false);
            this.gbWindows.ResumeLayout(false);
            this.gbWindows.PerformLayout();
            this.gbChrome.ResumeLayout(false);
            this.gbChrome.PerformLayout();
            this.gbSteam.ResumeLayout(false);
            this.gbSteam.PerformLayout();
            this.gbFirefox.ResumeLayout(false);
            this.gbFirefox.PerformLayout();
            this.tpTheme.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tcSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

   

        #endregion Windows Form Designer generated code
        private TabToTreeView tttvMain;
        private System.Windows.Forms.ContextMenuStrip cmsLanguages;
        private System.Windows.Forms.TabPage tpMainWindow;
        private System.Windows.Forms.GroupBox gbListView;
        private System.Windows.Forms.ComboBox cbListViewImagePreviewLocation;
        private System.Windows.Forms.Label lblListViewImagePreviewLocation;
        private System.Windows.Forms.ComboBox cbListViewImagePreviewVisibility;
        private System.Windows.Forms.Label lblListViewImagePreviewVisibility;
        private System.Windows.Forms.CheckBox cbListViewShowColumns;
        private System.Windows.Forms.GroupBox gbThumbnailView;
        private System.Windows.Forms.Button btnThumbnailViewThumbnailSizeReset;
        private System.Windows.Forms.Label lblThumbnailViewThumbnailSizeX;
        private System.Windows.Forms.NumericUpDown nudThumbnailViewThumbnailSizeHeight;
        private System.Windows.Forms.NumericUpDown nudThumbnailViewThumbnailSizeWidth;
        private System.Windows.Forms.ComboBox cbThumbnailViewThumbnailClickAction;
        private System.Windows.Forms.Label lblThumbnailViewThumbnailClickAction;
        private System.Windows.Forms.Label lblThumbnailViewThumbnailSize;
        private System.Windows.Forms.ComboBox cbThumbnailViewTitleLocation;
        private System.Windows.Forms.Label lblThumbnailViewTitleLocation;
        private System.Windows.Forms.CheckBox cbThumbnailViewShowTitle;
        private System.Windows.Forms.CheckBox cbMainWindowShowMenu;
        private System.Windows.Forms.ComboBox cbMainWindowTaskViewMode;
        private System.Windows.Forms.Label lblMainWindowTaskViewMode;
        private System.Windows.Forms.TabPage tpPaths;
        private System.Windows.Forms.TextBox txtSaveImageSubFolderPatternWindow;
        private System.Windows.Forms.TextBox txtPersonalFolderPath;
        private System.Windows.Forms.TextBox txtCustomScreenshotsPath;
        private System.Windows.Forms.TextBox txtSaveImageSubFolderPattern;
        private System.Windows.Forms.Label lblSaveImageSubFolderPatternWindow;
        private System.Windows.Forms.Button btnPersonalFolderPathApply;
        private System.Windows.Forms.Button btnOpenScreenshotsFolder;
        private System.Windows.Forms.Label lblPreviewPersonalFolderPath;
        private System.Windows.Forms.Button btnBrowsePersonalFolderPath;
        private System.Windows.Forms.Label lblPersonalFolderPath;
        private System.Windows.Forms.Button btnBrowseCustomScreenshotsPath;
        private System.Windows.Forms.Button btnOpenPersonalFolderPath;
        private System.Windows.Forms.CheckBox cbUseCustomScreenshotsPath;
        private System.Windows.Forms.Label lblSaveImageSubFolderPattern;
        private System.Windows.Forms.Label lblSaveImageSubFolderPatternPreview;
        private System.Windows.Forms.TabPage tpIntegration;
        private System.Windows.Forms.GroupBox gbFirefox;
        private System.Windows.Forms.CheckBox cbFirefoxAddonSupport;
        private System.Windows.Forms.Button btnFirefoxOpenAddonPage;
        private System.Windows.Forms.GroupBox gbSteam;
        private System.Windows.Forms.CheckBox cbSteamShowInApp;
        private System.Windows.Forms.GroupBox gbChrome;
        private System.Windows.Forms.CheckBox cbChromeExtensionSupport;
        private System.Windows.Forms.Button btnChromeOpenExtensionPage;
        private System.Windows.Forms.GroupBox gbWindows;
        private System.Windows.Forms.CheckBox cbEditWithShareX;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.CheckBox cbSendToMenu;
        private System.Windows.Forms.CheckBox cbShellContextMenu;
        private System.Windows.Forms.TabPage tpTheme;
        private System.Windows.Forms.Button btnThemeReset;
        private System.Windows.Forms.Button btnThemeRemove;
        private System.Windows.Forms.Button btnThemeAdd;
        private System.Windows.Forms.ComboBox cbThemes;
        private System.Windows.Forms.PropertyGrid pgTheme;
        private ExportImportControl eiTheme;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.CheckBox cbUseWhiteShareXIcon;
        private System.Windows.Forms.CheckBox cbShowTray;
        private System.Windows.Forms.CheckBox cbTrayIconProgressEnabled;
        private MenuButton btnLanguages;
        private System.Windows.Forms.CheckBox cbRememberMainFormPosition;
        private System.Windows.Forms.CheckBox cbSilentRun;
        private System.Windows.Forms.CheckBox cbTaskbarProgressEnabled;
        private System.Windows.Forms.CheckBox cbRememberMainFormSize;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.TabControl tcSettings;
    }
}