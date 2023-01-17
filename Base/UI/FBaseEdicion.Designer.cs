namespace Base.UI
{
    partial class FBaseEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBaseEdicion));
            this.RibbonEdicion = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGrabar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonImageCollectionLarge = new DevExpress.Utils.ImageCollection();
            this.PageInicio = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.GrupoOpcion = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GrupoDatos = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pcEdicion = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonEdicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcEdicion)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonEdicion
            // 
            this.RibbonEdicion.ExpandCollapseItem.Id = 0;
            this.RibbonEdicion.ExpandCollapseItem.Name = "";
            this.RibbonEdicion.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.RibbonEdicion.ExpandCollapseItem,
            this.btnGrabar,
            this.btnCancelar,
            this.btnCerrar});
            this.RibbonEdicion.LargeImages = this.ribbonImageCollectionLarge;
            this.RibbonEdicion.Location = new System.Drawing.Point(0, 0);
            this.RibbonEdicion.MaxItemId = 4;
            this.RibbonEdicion.Name = "RibbonEdicion";
            this.RibbonEdicion.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.PageInicio});
            this.RibbonEdicion.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.RibbonEdicion.Size = new System.Drawing.Size(511, 96);
            this.RibbonEdicion.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Caption = "Grabar";
            this.btnGrabar.Hint = "Grabar";
            this.btnGrabar.Id = 1;
            this.btnGrabar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G));
            this.btnGrabar.LargeImageIndex = 2;
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGrabar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGrabar_ItemClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Caption = "Cancelar";
            this.btnCancelar.Hint = "Cancelar";
            this.btnCancelar.Id = 2;
            this.btnCancelar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X));
            this.btnCancelar.LargeImageIndex = 1;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancelar_ItemClick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Caption = "Cerrar";
            this.btnCerrar.Hint = "Cerrar";
            this.btnCerrar.Id = 3;
            this.btnCerrar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnCerrar.LargeImageIndex = 0;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCerrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCerrar_ItemClick);
            // 
            // ribbonImageCollectionLarge
            // 
            this.ribbonImageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbonImageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollectionLarge.ImageStream")));
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.close, "close", typeof(global::Base.Properties.Resources), 0);
            this.ribbonImageCollectionLarge.Images.SetKeyName(0, "close");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.cancel, "cancel", typeof(global::Base.Properties.Resources), 1);
            this.ribbonImageCollectionLarge.Images.SetKeyName(1, "cancel");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.save, "save", typeof(global::Base.Properties.Resources), 2);
            this.ribbonImageCollectionLarge.Images.SetKeyName(2, "save");
            // 
            // PageInicio
            // 
            this.PageInicio.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.GrupoDatos,
            this.GrupoOpcion});
            this.PageInicio.Name = "PageInicio";
            this.PageInicio.Text = "ribbonPage1";
            // 
            // GrupoOpcion
            // 
            this.GrupoOpcion.ItemLinks.Add(this.btnCerrar);
            this.GrupoOpcion.Name = "GrupoOpcion";
            this.GrupoOpcion.ShowCaptionButton = false;
            this.GrupoOpcion.Text = "Opción";
            // 
            // GrupoDatos
            // 
            this.GrupoDatos.ItemLinks.Add(this.btnGrabar);
            this.GrupoDatos.ItemLinks.Add(this.btnCancelar);
            this.GrupoDatos.Name = "GrupoDatos";
            this.GrupoDatos.ShowCaptionButton = false;
            this.GrupoDatos.Text = "Datos";
            // 
            // pcEdicion
            // 
            this.pcEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcEdicion.Location = new System.Drawing.Point(0, 96);
            this.pcEdicion.Name = "pcEdicion";
            this.pcEdicion.Size = new System.Drawing.Size(511, 339);
            this.pcEdicion.TabIndex = 2;
            // 
            // FBaseEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 435);
            this.ControlBox = false;
            this.Controls.Add(this.pcEdicion);
            this.Controls.Add(this.RibbonEdicion);
            this.KeyPreview = true;
            this.Name = "FBaseEdicion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edición de Datos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FBaseEdicion_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonEdicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcEdicion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl RibbonEdicion;
        private DevExpress.XtraBars.BarButtonItem btnCerrar;
        private DevExpress.XtraBars.Ribbon.RibbonPage PageInicio;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoDatos;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoOpcion;
        private DevExpress.XtraEditors.PanelControl pcEdicion;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge;
        public DevExpress.XtraBars.BarButtonItem btnGrabar;
        public DevExpress.XtraBars.BarButtonItem btnCancelar;
    }
}
