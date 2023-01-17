using DevExpress.XtraBars;
namespace Base.UI
{
    partial class FPrincipal {

        #region Designer generated code
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrincipal));
            this.RibbonPrincipal = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.rgbiSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.biStyle = new DevExpress.XtraBars.BarEditItem();
            this.riicStyle = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.beScheme = new DevExpress.XtraBars.BarEditItem();
            this.rpiStyles = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.lbmHora = new DevExpress.XtraBars.BarStaticItem();
            this.lbmUsuario = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonImageCollectionLarge = new DevExpress.Utils.ImageCollection();
            this.PageInicio = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.GrupoSistema = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageApariencia = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.GrupoSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.StatusBarPrincipal = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.TabMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            this.gddSkins = new DevExpress.XtraBars.Ribbon.GalleryDropDown();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiStyles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabMdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gddSkins)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonPrincipal
            // 
            this.RibbonPrincipal.ApplicationButtonText = null;
            this.RibbonPrincipal.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("File", new System.Guid("4b511317-d784-42ba-b4ed-0d2a746d6c1f")),
            new DevExpress.XtraBars.BarManagerCategory("Edit", new System.Guid("7c2486e1-92ea-4293-ad55-b819f61ff7f1")),
            new DevExpress.XtraBars.BarManagerCategory("Format", new System.Guid("d3052f28-4b3e-4bae-b581-b3bb1c432258")),
            new DevExpress.XtraBars.BarManagerCategory("Help", new System.Guid("e07a4c24-66ac-4de6-bbcb-c0b6cfa7798b")),
            new DevExpress.XtraBars.BarManagerCategory("Status", new System.Guid("77795bb7-9bc5-4dd2-a297-cc758682e23d"))});
            this.RibbonPrincipal.ExpandCollapseItem.Id = 0;
            this.RibbonPrincipal.ExpandCollapseItem.Name = "";
            this.RibbonPrincipal.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.RibbonPrincipal.ExpandCollapseItem,
            this.rgbiSkins,
            this.biStyle,
            this.beScheme,
            this.lbmHora,
            this.lbmUsuario});
            this.RibbonPrincipal.LargeImages = this.ribbonImageCollectionLarge;
            this.RibbonPrincipal.Location = new System.Drawing.Point(0, 0);
            this.RibbonPrincipal.MaxItemId = 205;
            this.RibbonPrincipal.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.RibbonPrincipal.Name = "RibbonPrincipal";
            this.RibbonPrincipal.PageHeaderItemLinks.Add(this.biStyle);
            this.RibbonPrincipal.PageHeaderItemLinks.Add(this.beScheme);
            this.RibbonPrincipal.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.PageInicio,
            this.PageApariencia});
            this.RibbonPrincipal.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riicStyle,
            this.rpiStyles});
            this.RibbonPrincipal.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.RibbonPrincipal.Size = new System.Drawing.Size(835, 144);
            this.RibbonPrincipal.StatusBar = this.StatusBarPrincipal;
            this.RibbonPrincipal.ApplicationButtonDoubleClick += new System.EventHandler(this.ribbonControl1_ApplicationButtonDoubleClick);
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Caption = "Skins";
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Pressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgbiSkins.Id = 13;
            this.rgbiSkins.Name = "rgbiSkins";
            this.rgbiSkins.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.rgbiSkins_GalleryItemClick);
            // 
            // biStyle
            // 
            this.biStyle.Edit = this.riicStyle;
            this.biStyle.Hint = "Ribbon Style";
            this.biStyle.Id = 106;
            this.biStyle.Name = "biStyle";
            this.biStyle.Width = 75;
            this.biStyle.EditValueChanged += new System.EventHandler(this.biStyle_EditValueChanged);
            // 
            // riicStyle
            // 
            this.riicStyle.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.riicStyle.Appearance.Options.UseFont = true;
            this.riicStyle.AutoHeight = false;
            this.riicStyle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riicStyle.Name = "riicStyle";
            // 
            // beScheme
            // 
            this.beScheme.Edit = this.rpiStyles;
            this.beScheme.Id = 188;
            this.beScheme.Name = "beScheme";
            this.beScheme.Width = 75;
            this.beScheme.EditValueChanged += new System.EventHandler(this.beScheme_EditValueChanged);
            // 
            // rpiStyles
            // 
            this.rpiStyles.AutoHeight = false;
            this.rpiStyles.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpiStyles.Name = "rpiStyles";
            this.rpiStyles.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // lbmHora
            // 
            this.lbmHora.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lbmHora.Id = 202;
            this.lbmHora.Name = "lbmHora";
            this.lbmHora.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lbmUsuario
            // 
            this.lbmUsuario.Id = 203;
            this.lbmUsuario.Name = "lbmUsuario";
            this.lbmUsuario.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonImageCollectionLarge
            // 
            this.ribbonImageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbonImageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollectionLarge.ImageStream")));
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.logout, "logout", typeof(global::Base.Properties.Resources), 0);
            this.ribbonImageCollectionLarge.Images.SetKeyName(0, "logout");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.office, "office", typeof(global::Base.Properties.Resources), 1);
            this.ribbonImageCollectionLarge.Images.SetKeyName(1, "office");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.server, "server", typeof(global::Base.Properties.Resources), 2);
            this.ribbonImageCollectionLarge.Images.SetKeyName(2, "server");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.setting, "setting", typeof(global::Base.Properties.Resources), 3);
            this.ribbonImageCollectionLarge.Images.SetKeyName(3, "setting");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.Home, "Home", typeof(global::Base.Properties.Resources), 4);
            this.ribbonImageCollectionLarge.Images.SetKeyName(4, "Home");
            // 
            // PageInicio
            // 
            this.PageInicio.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.GrupoSistema});
            this.PageInicio.Name = "PageInicio";
            this.PageInicio.Text = "Inicio";
            // 
            // GrupoSistema
            // 
            this.GrupoSistema.Name = "GrupoSistema";
            this.GrupoSistema.ShowCaptionButton = false;
            this.GrupoSistema.Text = "Sistema";
            // 
            // PageApariencia
            // 
            this.PageApariencia.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.GrupoSkins});
            this.PageApariencia.Name = "PageApariencia";
            this.PageApariencia.Text = "Apariencia";
            // 
            // GrupoSkins
            // 
            this.GrupoSkins.ItemLinks.Add(this.rgbiSkins);
            this.GrupoSkins.Name = "GrupoSkins";
            this.GrupoSkins.ShowCaptionButton = false;
            this.GrupoSkins.Text = "Skins";
            // 
            // StatusBarPrincipal
            // 
            this.StatusBarPrincipal.ItemLinks.Add(this.lbmHora);
            this.StatusBarPrincipal.ItemLinks.Add(this.lbmUsuario);
            this.StatusBarPrincipal.Location = new System.Drawing.Point(0, 589);
            this.StatusBarPrincipal.Name = "StatusBarPrincipal";
            this.StatusBarPrincipal.Ribbon = this.RibbonPrincipal;
            this.StatusBarPrincipal.Size = new System.Drawing.Size(835, 31);
            // 
            // TabMdiManager
            // 
            this.TabMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.TabMdiManager.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.TabMdiManager.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.TabMdiManager.MdiParent = this;
            // 
            // gddSkins
            // 
            this.gddSkins.Name = "gddSkins";
            this.gddSkins.Ribbon = this.RibbonPrincipal;
            // 
            // FPrincipal
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AllowMdiBar = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(835, 620);
            this.Controls.Add(this.StatusBarPrincipal);
            this.Controls.Add(this.RibbonPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FPrincipal";
            this.Ribbon = this.RibbonPrincipal;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.StatusBarPrincipal;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiStyles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabMdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gddSkins)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage PageInicio;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager TabMdiManager;
        private DevExpress.XtraBars.RibbonGalleryBarItem rgbiSkins;
        private DevExpress.XtraBars.Ribbon.RibbonPage PageApariencia;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoSkins;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge;
        private BarEditItem biStyle;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicStyle;
        private BarEditItem beScheme;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rpiStyles;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoSistema;
        public DevExpress.XtraBars.Ribbon.RibbonControl RibbonPrincipal;
        private System.ComponentModel.IContainer components;
        public BarStaticItem lbmHora;
        public BarStaticItem lbmUsuario;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown gddSkins;
        public DevExpress.XtraBars.Ribbon.RibbonStatusBar StatusBarPrincipal;
    }
}
