using DevExpress.XtraEditors;
namespace Base.UI
{
    partial class FBaseForm : XtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBaseForm));
            this.RibbonForm = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.wbtnNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.wbtnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.wbtnBorrar = new DevExpress.XtraBars.BarButtonItem();
            this.rbtnVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.rbtnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.rbtnCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonImageCollectionLarge = new DevExpress.Utils.ImageCollection();
            this.PageInicio = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.GrupoOpcion = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GrupoEdicion = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GrupoFiltros = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonForm
            // 
            this.RibbonForm.ExpandCollapseItem.Id = 0;
            this.RibbonForm.ExpandCollapseItem.Name = "";
            this.RibbonForm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.RibbonForm.ExpandCollapseItem,
            this.wbtnNuevo,
            this.wbtnEditar,
            this.wbtnBorrar,
            this.rbtnVisualizar,
            this.rbtnImprimir,
            this.rbtnCerrar});
            this.RibbonForm.LargeImages = this.ribbonImageCollectionLarge;
            this.RibbonForm.Location = new System.Drawing.Point(0, 0);
            this.RibbonForm.MaxItemId = 11;
            this.RibbonForm.Name = "RibbonForm";
            this.RibbonForm.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.PageInicio});
            this.RibbonForm.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.RibbonForm.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.RibbonForm.Size = new System.Drawing.Size(679, 117);
            this.RibbonForm.StatusBar = this.ribbonStatusBar;
            this.RibbonForm.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // wbtnNuevo
            // 
            this.wbtnNuevo.Caption = "Nuevo";
            this.wbtnNuevo.Hint = "Nuevo";
            this.wbtnNuevo.Id = 1;
            this.wbtnNuevo.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.wbtnNuevo.LargeImageIndex = 3;
            this.wbtnNuevo.Name = "wbtnNuevo";
            this.wbtnNuevo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.wbtnNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnButtonRibbon_ItemClick);
            // 
            // wbtnEditar
            // 
            this.wbtnEditar.Caption = "Editar";
            this.wbtnEditar.Hint = "Editar";
            this.wbtnEditar.Id = 2;
            this.wbtnEditar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.wbtnEditar.LargeImageIndex = 2;
            this.wbtnEditar.Name = "wbtnEditar";
            this.wbtnEditar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.wbtnEditar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnButtonRibbon_ItemClick);
            // 
            // wbtnBorrar
            // 
            this.wbtnBorrar.Caption = "Borrar";
            this.wbtnBorrar.Hint = "Borrar";
            this.wbtnBorrar.Id = 3;
            this.wbtnBorrar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B));
            this.wbtnBorrar.LargeImageIndex = 1;
            this.wbtnBorrar.Name = "wbtnBorrar";
            this.wbtnBorrar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.wbtnBorrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnButtonRibbon_ItemClick);
            // 
            // rbtnVisualizar
            // 
            this.rbtnVisualizar.Caption = "Visualizar";
            this.rbtnVisualizar.Hint = "Visualizar";
            this.rbtnVisualizar.Id = 4;
            this.rbtnVisualizar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W));
            this.rbtnVisualizar.LargeImageIndex = 5;
            this.rbtnVisualizar.Name = "rbtnVisualizar";
            this.rbtnVisualizar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.rbtnVisualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnButtonRibbon_ItemClick);
            // 
            // rbtnImprimir
            // 
            this.rbtnImprimir.Caption = "Imprimir";
            this.rbtnImprimir.Hint = "Imprimir";
            this.rbtnImprimir.Id = 5;
            this.rbtnImprimir.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.rbtnImprimir.LargeImageIndex = 4;
            this.rbtnImprimir.Name = "rbtnImprimir";
            this.rbtnImprimir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.rbtnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rbtnImprimir_ItemClick);
            // 
            // rbtnCerrar
            // 
            this.rbtnCerrar.Caption = "Cerrar";
            this.rbtnCerrar.Hint = "Cerrar";
            this.rbtnCerrar.Id = 8;
            this.rbtnCerrar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.rbtnCerrar.LargeImageIndex = 0;
            this.rbtnCerrar.Name = "rbtnCerrar";
            this.rbtnCerrar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.rbtnCerrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rbtnCerrar_ItemClick);
            // 
            // ribbonImageCollectionLarge
            // 
            this.ribbonImageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbonImageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollectionLarge.ImageStream")));
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.close, "close", typeof(global::Base.Properties.Resources), 0);
            this.ribbonImageCollectionLarge.Images.SetKeyName(0, "close");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.delete, "delete", typeof(global::Base.Properties.Resources), 1);
            this.ribbonImageCollectionLarge.Images.SetKeyName(1, "delete");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.edit, "edit", typeof(global::Base.Properties.Resources), 2);
            this.ribbonImageCollectionLarge.Images.SetKeyName(2, "edit");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources._new, "_new", typeof(global::Base.Properties.Resources), 3);
            this.ribbonImageCollectionLarge.Images.SetKeyName(3, "_new");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.print, "print", typeof(global::Base.Properties.Resources), 4);
            this.ribbonImageCollectionLarge.Images.SetKeyName(4, "print");
            this.ribbonImageCollectionLarge.InsertImage(global::Base.Properties.Resources.view, "view", typeof(global::Base.Properties.Resources), 5);
            this.ribbonImageCollectionLarge.Images.SetKeyName(5, "view");
            // 
            // PageInicio
            // 
            this.PageInicio.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.GrupoEdicion,
            this.GrupoFiltros,
            this.GrupoOpcion});
            this.PageInicio.Name = "PageInicio";
            this.PageInicio.Text = "Inicio";
            // 
            // GrupoOpcion
            // 
            this.GrupoOpcion.ItemLinks.Add(this.rbtnCerrar);
            this.GrupoOpcion.Name = "GrupoOpcion";
            this.GrupoOpcion.ShowCaptionButton = false;
            this.GrupoOpcion.Text = "Opción";
            // 
            // GrupoEdicion
            // 
            this.GrupoEdicion.ItemLinks.Add(this.wbtnNuevo);
            this.GrupoEdicion.ItemLinks.Add(this.wbtnEditar);
            this.GrupoEdicion.ItemLinks.Add(this.wbtnBorrar);
            this.GrupoEdicion.ItemLinks.Add(this.rbtnVisualizar);
            this.GrupoEdicion.ItemLinks.Add(this.rbtnImprimir);
            this.GrupoEdicion.Name = "GrupoEdicion";
            this.GrupoEdicion.ShowCaptionButton = false;
            this.GrupoEdicion.Text = "Edición";
            // 
            // GrupoFiltros
            // 
            this.GrupoFiltros.Name = "GrupoFiltros";
            this.GrupoFiltros.ShowCaptionButton = false;
            this.GrupoFiltros.Text = "Filtros";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 499);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.RibbonForm;
            this.ribbonStatusBar.Size = new System.Drawing.Size(679, 27);
            // 
            // FBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 526);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.RibbonForm);
            this.Name = "FBaseForm";
            this.Text = "FForm";
            this.Activated += new System.EventHandler(this.FBaseForm_Activated);
            this.Load += new System.EventHandler(this.FForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage PageInicio;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoEdicion;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem rbtnCerrar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoOpcion;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge;
        public DevExpress.XtraBars.Ribbon.RibbonControl RibbonForm;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoFiltros;
        public DevExpress.XtraBars.BarButtonItem wbtnNuevo;
        public DevExpress.XtraBars.BarButtonItem wbtnEditar;
        public DevExpress.XtraBars.BarButtonItem wbtnBorrar;
        public DevExpress.XtraBars.BarButtonItem rbtnVisualizar;
        public DevExpress.XtraBars.BarButtonItem rbtnImprimir;
    }
}