namespace Test_Browser
{
    partial class fWebBrowser
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fWebBrowser));
            this.m_Menu = new System.Windows.Forms.MenuStrip();
            this.m_File = new System.Windows.Forms.ToolStripMenuItem();
            this.m_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.m_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.m_Preview = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_View = new System.Windows.Forms.ToolStripMenuItem();
            this.m_Toolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.m_StatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_Goto = new System.Windows.Forms.ToolStripMenuItem();
            this.m_PreviousPage = new System.Windows.Forms.ToolStripMenuItem();
            this.m_NextPage = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_HomePage = new System.Windows.Forms.ToolStripMenuItem();
            this.m_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.m_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.m_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ViewMode = new System.Windows.Forms.ToolStripMenuItem();
            this.m_System = new System.Windows.Forms.ToolStripMenuItem();
            this.m_Professional = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_Toolbar = new System.Windows.Forms.ToolStrip();
            this.tb_PreviousPage = new System.Windows.Forms.ToolStripSplitButton();
            this.tb_NextPage = new System.Windows.Forms.ToolStripSplitButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tb_Stop = new System.Windows.Forms.ToolStripButton();
            this.tb_Refresh = new System.Windows.Forms.ToolStripButton();
            this.tb_Home = new System.Windows.Forms.ToolStripButton();
            this.tb_Favourite = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tl_Address = new System.Windows.Forms.ToolStripLabel();
            this.txtUrl = new System.Windows.Forms.ToolStripTextBox();
            this.tb_Goto = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.wb_Browser = new System.Windows.Forms.WebBrowser();
            this.ss_Status = new System.Windows.Forms.StatusStrip();
            this.webToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.webToolStripStatusBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.m_Menu.SuspendLayout();
            this.tb_Toolbar.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.ss_Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_Menu
            // 
            this.m_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_File,
            this.m_View,
            this.m_Options});
            this.m_Menu.Location = new System.Drawing.Point(0, 0);
            this.m_Menu.Name = "m_Menu";
            this.m_Menu.Size = new System.Drawing.Size(792, 24);
            this.m_Menu.TabIndex = 2;
            this.m_Menu.Text = "m_Menu";
            // 
            // m_File
            // 
            this.m_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_Open,
            this.ToolStripSeparator7,
            this.m_Print,
            this.m_Preview,
            this.ToolStripSeparator4,
            this.m_Quit});
            this.m_File.Name = "m_File";
            this.m_File.Size = new System.Drawing.Size(50, 20);
            this.m_File.Text = "Fichier";
            // 
            // m_Open
            // 
            this.m_Open.Name = "m_Open";
            this.m_Open.Size = new System.Drawing.Size(207, 22);
            this.m_Open.Text = "Ouvrir";
            this.m_Open.Click += new System.EventHandler(this.m_Open_Click);
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(204, 6);
            // 
            // m_Print
            // 
            this.m_Print.Name = "m_Print";
            this.m_Print.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.m_Print.Size = new System.Drawing.Size(207, 22);
            this.m_Print.Text = "Imprimer ...";
            this.m_Print.Click += new System.EventHandler(this.m_Print_Click);
            // 
            // m_Preview
            // 
            this.m_Preview.Name = "m_Preview";
            this.m_Preview.Size = new System.Drawing.Size(207, 22);
            this.m_Preview.Text = "Aperçu avant impression ...";
            this.m_Preview.Click += new System.EventHandler(this.m_Preview_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(204, 6);
            // 
            // m_Quit
            // 
            this.m_Quit.Name = "m_Quit";
            this.m_Quit.Size = new System.Drawing.Size(207, 22);
            this.m_Quit.Text = "Quitter";
            this.m_Quit.Click += new System.EventHandler(this.m_Quit_Click);
            // 
            // m_View
            // 
            this.m_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_Toolbar,
            this.m_StatusBar,
            this.ToolStripSeparator6,
            this.m_Goto,
            this.m_Stop,
            this.m_Refresh});
            this.m_View.Name = "m_View";
            this.m_View.Size = new System.Drawing.Size(65, 20);
            this.m_View.Text = "Affichage";
            // 
            // m_Toolbar
            // 
            this.m_Toolbar.Checked = true;
            this.m_Toolbar.CheckOnClick = true;
            this.m_Toolbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_Toolbar.Name = "m_Toolbar";
            this.m_Toolbar.Size = new System.Drawing.Size(205, 22);
            this.m_Toolbar.Text = "Barre boutons  et addresse";
            this.m_Toolbar.Click += new System.EventHandler(this.m_Toolbar_Click);
            // 
            // m_StatusBar
            // 
            this.m_StatusBar.Checked = true;
            this.m_StatusBar.CheckOnClick = true;
            this.m_StatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_StatusBar.Name = "m_StatusBar";
            this.m_StatusBar.Size = new System.Drawing.Size(205, 22);
            this.m_StatusBar.Text = "Barre d\'état";
            this.m_StatusBar.Click += new System.EventHandler(this.m_StatusBar_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(202, 6);
            // 
            // m_Goto
            // 
            this.m_Goto.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_PreviousPage,
            this.m_NextPage,
            this.ToolStripSeparator5,
            this.m_HomePage});
            this.m_Goto.Name = "m_Goto";
            this.m_Goto.Size = new System.Drawing.Size(205, 22);
            this.m_Goto.Text = "Atteindre";
            // 
            // m_PreviousPage
            // 
            this.m_PreviousPage.Name = "m_PreviousPage";
            this.m_PreviousPage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left)));
            this.m_PreviousPage.Size = new System.Drawing.Size(223, 22);
            this.m_PreviousPage.Text = "page précédente";
            this.m_PreviousPage.Click += new System.EventHandler(this.m_PreviousPage_Click);
            // 
            // m_NextPage
            // 
            this.m_NextPage.Name = "m_NextPage";
            this.m_NextPage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right)));
            this.m_NextPage.Size = new System.Drawing.Size(223, 22);
            this.m_NextPage.Text = "page suivante";
            this.m_NextPage.Click += new System.EventHandler(this.m_NextPage_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(220, 6);
            // 
            // m_HomePage
            // 
            this.m_HomePage.Name = "m_HomePage";
            this.m_HomePage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.m_HomePage.Size = new System.Drawing.Size(223, 22);
            this.m_HomePage.Text = "Page de démarrage";
            this.m_HomePage.Click += new System.EventHandler(this.m_HomePage_Click);
            // 
            // m_Stop
            // 
            this.m_Stop.Name = "m_Stop";
            this.m_Stop.Size = new System.Drawing.Size(205, 22);
            this.m_Stop.Text = "Arrêter";
            this.m_Stop.Click += new System.EventHandler(this.m_Stop_Click);
            // 
            // m_Refresh
            // 
            this.m_Refresh.Name = "m_Refresh";
            this.m_Refresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.m_Refresh.Size = new System.Drawing.Size(205, 22);
            this.m_Refresh.Text = "Actualiser";
            this.m_Refresh.Click += new System.EventHandler(this.m_Refresh_Click);
            // 
            // m_Options
            // 
            this.m_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ViewMode});
            this.m_Options.Name = "m_Options";
            this.m_Options.Size = new System.Drawing.Size(56, 20);
            this.m_Options.Text = "Options";
            // 
            // m_ViewMode
            // 
            this.m_ViewMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_System,
            this.m_Professional});
            this.m_ViewMode.Name = "m_ViewMode";
            this.m_ViewMode.Size = new System.Drawing.Size(156, 22);
            this.m_ViewMode.Text = "Mode d\'affichage";
            // 
            // m_System
            // 
            this.m_System.Name = "m_System";
            this.m_System.Size = new System.Drawing.Size(138, 22);
            this.m_System.Text = "Systême";
            this.m_System.Click += new System.EventHandler(this.m_System_Click);
            // 
            // m_Professional
            // 
            this.m_Professional.Name = "m_Professional";
            this.m_Professional.Size = new System.Drawing.Size(138, 22);
            this.m_Professional.Text = "Professionnel";
            this.m_Professional.Click += new System.EventHandler(this.m_Professional_Click);
            // 
            // tb_Toolbar
            // 
            this.tb_Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_PreviousPage,
            this.tb_NextPage,
            this.ToolStripSeparator1,
            this.tb_Stop,
            this.tb_Refresh,
            this.tb_Home,
            this.tb_Favourite,
            this.ToolStripSeparator3,
            this.tl_Address,
            this.txtUrl,
            this.tb_Goto,
            this.ToolStripSeparator2});
            this.tb_Toolbar.Location = new System.Drawing.Point(0, 24);
            this.tb_Toolbar.Name = "tb_Toolbar";
            this.tb_Toolbar.Size = new System.Drawing.Size(792, 25);
            this.tb_Toolbar.TabIndex = 3;
            this.tb_Toolbar.Text = "tb_Toolbar";
            // 
            // tb_PreviousPage
            // 
            this.tb_PreviousPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tb_PreviousPage.Image = ((System.Drawing.Image)(resources.GetObject("tb_PreviousPage.Image")));
            this.tb_PreviousPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_PreviousPage.Name = "tb_PreviousPage";
            this.tb_PreviousPage.Size = new System.Drawing.Size(32, 22);
            this.tb_PreviousPage.Text = "Précédent";
            this.tb_PreviousPage.ButtonClick += new System.EventHandler(this.tb_PreviousPage_ButtonClick);
            // 
            // tb_NextPage
            // 
            this.tb_NextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tb_NextPage.Image = ((System.Drawing.Image)(resources.GetObject("tb_NextPage.Image")));
            this.tb_NextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_NextPage.Name = "tb_NextPage";
            this.tb_NextPage.Size = new System.Drawing.Size(32, 22);
            this.tb_NextPage.Text = "Suivant";
            this.tb_NextPage.ButtonClick += new System.EventHandler(this.tb_NextPage_ButtonClick);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tb_Stop
            // 
            this.tb_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tb_Stop.Image = ((System.Drawing.Image)(resources.GetObject("tb_Stop.Image")));
            this.tb_Stop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tb_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_Stop.Name = "tb_Stop";
            this.tb_Stop.Size = new System.Drawing.Size(23, 22);
            this.tb_Stop.Text = "Stop";
            this.tb_Stop.Click += new System.EventHandler(this.tb_Stop_Click);
            // 
            // tb_Refresh
            // 
            this.tb_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tb_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("tb_Refresh.Image")));
            this.tb_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_Refresh.Name = "tb_Refresh";
            this.tb_Refresh.Size = new System.Drawing.Size(23, 22);
            this.tb_Refresh.Text = "Actualiser";
            this.tb_Refresh.Click += new System.EventHandler(this.tb_Refresh_Click);
            // 
            // tb_Home
            // 
            this.tb_Home.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tb_Home.Image = ((System.Drawing.Image)(resources.GetObject("tb_Home.Image")));
            this.tb_Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_Home.Name = "tb_Home";
            this.tb_Home.Size = new System.Drawing.Size(23, 22);
            this.tb_Home.Text = "Page d\'accueil";
            this.tb_Home.Click += new System.EventHandler(this.tb_Home_Click);
            // 
            // tb_Favourite
            // 
            this.tb_Favourite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tb_Favourite.Image = ((System.Drawing.Image)(resources.GetObject("tb_Favourite.Image")));
            this.tb_Favourite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_Favourite.Name = "tb_Favourite";
            this.tb_Favourite.Size = new System.Drawing.Size(23, 22);
            this.tb_Favourite.Text = "Favoris";
            this.tb_Favourite.Click += new System.EventHandler(this.tb_Favourite_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tl_Address
            // 
            this.tl_Address.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.tl_Address.Name = "tl_Address";
            this.tl_Address.Size = new System.Drawing.Size(46, 22);
            this.tl_Address.Text = "Adresse";
            // 
            // txtUrl
            // 
            this.txtUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.txtUrl.AutoSize = false;
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrl.Margin = new System.Windows.Forms.Padding(1);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(300, 21);
            this.txtUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrl_KeyDown);
            // 
            // tb_Goto
            // 
            this.tb_Goto.Image = ((System.Drawing.Image)(resources.GetObject("tb_Goto.Image")));
            this.tb_Goto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_Goto.Name = "tb_Goto";
            this.tb_Goto.Size = new System.Drawing.Size(40, 22);
            this.tb_Goto.Text = "Go";
            this.tb_Goto.Click += new System.EventHandler(this.tb_Goto_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.SplitContainer1);
            this.Panel2.Controls.Add(this.ss_Status);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(0, 49);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(792, 517);
            this.Panel2.TabIndex = 5;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Panel1MinSize = 0;
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.wb_Browser);
            this.SplitContainer1.Size = new System.Drawing.Size(792, 492);
            this.SplitContainer1.SplitterDistance = 254;
            this.SplitContainer1.TabIndex = 1;
            // 
            // wb_Browser
            // 
            this.wb_Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb_Browser.Location = new System.Drawing.Point(0, 0);
            this.wb_Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_Browser.Name = "wb_Browser";
            this.wb_Browser.Size = new System.Drawing.Size(534, 492);
            this.wb_Browser.TabIndex = 0;
            this.wb_Browser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wb_Browser_Navigated);
            this.wb_Browser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.wb_Browser_ProgressChanged);
            this.wb_Browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb_Browser_Navigating);
            // 
            // ss_Status
            // 
            this.ss_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.webToolStripStatusLabel,
            this.webToolStripStatusBar,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel9});
            this.ss_Status.Location = new System.Drawing.Point(0, 492);
            this.ss_Status.Name = "ss_Status";
            this.ss_Status.Size = new System.Drawing.Size(792, 25);
            this.ss_Status.TabIndex = 0;
            this.ss_Status.Text = "Statut";
            // 
            // webToolStripStatusLabel
            // 
            this.webToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.webToolStripStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.webToolStripStatusLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.webToolStripStatusLabel.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.webToolStripStatusLabel.Name = "webToolStripStatusLabel";
            this.webToolStripStatusLabel.Size = new System.Drawing.Size(501, 20);
            this.webToolStripStatusLabel.Spring = true;
            this.webToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // webToolStripStatusBar
            // 
            this.webToolStripStatusBar.Name = "webToolStripStatusBar";
            this.webToolStripStatusBar.Size = new System.Drawing.Size(100, 19);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel5.Text = "   ";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel6.Text = "   ";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel7.Text = "   ";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel8.Text = "   ";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel9.Image")));
            this.toolStripStatusLabel9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel9.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripStatusLabel9.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(60, 20);
            this.toolStripStatusLabel9.Text = "Internet";
            // 
            // dlg_OpenFile
            // 
            this.dlg_OpenFile.FileName = "OpenFileDialog1";
            // 
            // fWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.tb_Toolbar);
            this.Controls.Add(this.m_Menu);
            this.MainMenuStrip = this.m_Menu;
            this.Name = "fWebBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "oOOOoo WebBrowser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClosed_FormClosed);
            this.Load += new System.EventHandler(this.fWebBrowser_Load);
            this.m_Menu.ResumeLayout(false);
            this.m_Menu.PerformLayout();
            this.tb_Toolbar.ResumeLayout(false);
            this.tb_Toolbar.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.ResumeLayout(false);
            this.ss_Status.ResumeLayout(false);
            this.ss_Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip m_Menu;
        internal System.Windows.Forms.ToolStripMenuItem m_File;
        internal System.Windows.Forms.ToolStripMenuItem m_Open;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
        internal System.Windows.Forms.ToolStripMenuItem m_Print;
        internal System.Windows.Forms.ToolStripMenuItem m_Preview;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        internal System.Windows.Forms.ToolStripMenuItem m_Quit;
        internal System.Windows.Forms.ToolStripMenuItem m_View;
        internal System.Windows.Forms.ToolStripMenuItem m_Toolbar;
        internal System.Windows.Forms.ToolStripMenuItem m_StatusBar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
        internal System.Windows.Forms.ToolStripMenuItem m_Goto;
        internal System.Windows.Forms.ToolStripMenuItem m_PreviousPage;
        internal System.Windows.Forms.ToolStripMenuItem m_NextPage;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        internal System.Windows.Forms.ToolStripMenuItem m_HomePage;
        internal System.Windows.Forms.ToolStripMenuItem m_Stop;
        internal System.Windows.Forms.ToolStripMenuItem m_Refresh;
        internal System.Windows.Forms.ToolStripMenuItem m_Options;
        internal System.Windows.Forms.ToolStripMenuItem m_ViewMode;
        internal System.Windows.Forms.ToolStripMenuItem m_System;
        internal System.Windows.Forms.ToolStripMenuItem m_Professional;
        internal System.Windows.Forms.ToolStrip tb_Toolbar;
        internal System.Windows.Forms.ToolStripSplitButton tb_PreviousPage;
        internal System.Windows.Forms.ToolStripSplitButton tb_NextPage;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton tb_Stop;
        internal System.Windows.Forms.ToolStripButton tb_Refresh;
        internal System.Windows.Forms.ToolStripButton tb_Home;
        internal System.Windows.Forms.ToolStripButton tb_Favourite;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripLabel tl_Address;
        internal System.Windows.Forms.ToolStripTextBox txtUrl;
        internal System.Windows.Forms.ToolStripButton tb_Goto;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.WebBrowser wb_Browser;
        internal System.Windows.Forms.StatusStrip ss_Status;
        internal System.Windows.Forms.ToolStripStatusLabel webToolStripStatusLabel;
        internal System.Windows.Forms.ToolStripProgressBar webToolStripStatusBar;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        internal System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        internal System.Windows.Forms.OpenFileDialog dlg_OpenFile;

    }
}

