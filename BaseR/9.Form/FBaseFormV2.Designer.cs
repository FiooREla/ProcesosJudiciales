using DevExpress.XtraEditors;
namespace BaseR
{
    partial class FBaseFormV2 : XtraForm
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
            this.ribbonImageCollectionLarge = new DevExpress.Utils.ImageCollection();
            this.wbtnNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.wbtnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.wbtnBorrar = new DevExpress.XtraBars.BarButtonItem();
            this.rbtnVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.rbtnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.obtnCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.rbtnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.PageInicio = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.GrupoEdicion = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GrupoFiltros = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GrupoDatos = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GrupoOpcion = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonForm
            // 
            this.RibbonForm.ExpandCollapseItem.Id = 0;
            this.RibbonForm.Images = this.ribbonImageCollectionLarge;
            this.RibbonForm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.RibbonForm.ExpandCollapseItem,
            this.wbtnNuevo,
            this.wbtnEditar,
            this.wbtnBorrar,
            this.rbtnVisualizar,
            this.rbtnImprimir,
            this.obtnCerrar,
            this.rbtnActualizar});
            this.RibbonForm.LargeImages = this.ribbonImageCollectionLarge;
            this.RibbonForm.Location = new System.Drawing.Point(0, 0);
            this.RibbonForm.MaxItemId = 12;
            this.RibbonForm.Name = "RibbonForm";
            this.RibbonForm.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.PageInicio});
            this.RibbonForm.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.RibbonForm.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.RibbonForm.Size = new System.Drawing.Size(679, 112);
            this.RibbonForm.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // ribbonImageCollectionLarge
            // 
            this.ribbonImageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbonImageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollectionLarge.ImageStream")));
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.close, "close", typeof(global::BaseR.Properties.Resources), 0);
            this.ribbonImageCollectionLarge.Images.SetKeyName(0, "close");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.delete, "delete", typeof(global::BaseR.Properties.Resources), 1);
            this.ribbonImageCollectionLarge.Images.SetKeyName(1, "delete");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.edit, "edit", typeof(global::BaseR.Properties.Resources), 2);
            this.ribbonImageCollectionLarge.Images.SetKeyName(2, "edit");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources._new, "_new", typeof(global::BaseR.Properties.Resources), 3);
            this.ribbonImageCollectionLarge.Images.SetKeyName(3, "_new");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.print, "print", typeof(global::BaseR.Properties.Resources), 4);
            this.ribbonImageCollectionLarge.Images.SetKeyName(4, "print");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.view, "view", typeof(global::BaseR.Properties.Resources), 5);
            this.ribbonImageCollectionLarge.Images.SetKeyName(5, "view");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.acceso, "acceso", typeof(global::BaseR.Properties.Resources), 6);
            this.ribbonImageCollectionLarge.Images.SetKeyName(6, "acceso");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.consulta, "consulta", typeof(global::BaseR.Properties.Resources), 7);
            this.ribbonImageCollectionLarge.Images.SetKeyName(7, "consulta");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.money, "money", typeof(global::BaseR.Properties.Resources), 8);
            this.ribbonImageCollectionLarge.Images.SetKeyName(8, "money");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.aceptar, "aceptar", typeof(global::BaseR.Properties.Resources), 9);
            this.ribbonImageCollectionLarge.Images.SetKeyName(9, "aceptar");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.check, "check", typeof(global::BaseR.Properties.Resources), 10);
            this.ribbonImageCollectionLarge.Images.SetKeyName(10, "check");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.corazon, "corazon", typeof(global::BaseR.Properties.Resources), 11);
            this.ribbonImageCollectionLarge.Images.SetKeyName(11, "corazon");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.hospitalizar, "hospitalizar", typeof(global::BaseR.Properties.Resources), 12);
            this.ribbonImageCollectionLarge.Images.SetKeyName(12, "hospitalizar");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.clinica, "clinica", typeof(global::BaseR.Properties.Resources), 13);
            this.ribbonImageCollectionLarge.Images.SetKeyName(13, "clinica");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lista1, "lista1", typeof(global::BaseR.Properties.Resources), 14);
            this.ribbonImageCollectionLarge.Images.SetKeyName(14, "lista1");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lista2, "lista2", typeof(global::BaseR.Properties.Resources), 15);
            this.ribbonImageCollectionLarge.Images.SetKeyName(15, "lista2");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.refresh, "refresh", typeof(global::BaseR.Properties.Resources), 16);
            this.ribbonImageCollectionLarge.Images.SetKeyName(16, "refresh");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.analisas, "analisas", typeof(global::BaseR.Properties.Resources), 17);
            this.ribbonImageCollectionLarge.Images.SetKeyName(17, "analisas");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.descuento, "descuento", typeof(global::BaseR.Properties.Resources), 18);
            this.ribbonImageCollectionLarge.Images.SetKeyName(18, "descuento");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.cierrecaja, "cierrecaja", typeof(global::BaseR.Properties.Resources), 19);
            this.ribbonImageCollectionLarge.Images.SetKeyName(19, "cierrecaja");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.atender, "atender", typeof(global::BaseR.Properties.Resources), 20);
            this.ribbonImageCollectionLarge.Images.SetKeyName(20, "atender");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.print2, "print2", typeof(global::BaseR.Properties.Resources), 21);
            this.ribbonImageCollectionLarge.Images.SetKeyName(21, "print2");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.print3, "print3", typeof(global::BaseR.Properties.Resources), 22);
            this.ribbonImageCollectionLarge.Images.SetKeyName(22, "print3");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.anular, "anular", typeof(global::BaseR.Properties.Resources), 23);
            this.ribbonImageCollectionLarge.Images.SetKeyName(23, "anular");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.alta, "alta", typeof(global::BaseR.Properties.Resources), 24);
            this.ribbonImageCollectionLarge.Images.SetKeyName(24, "alta");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.detalle, "detalle", typeof(global::BaseR.Properties.Resources), 25);
            this.ribbonImageCollectionLarge.Images.SetKeyName(25, "detalle");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.cama, "cama", typeof(global::BaseR.Properties.Resources), 26);
            this.ribbonImageCollectionLarge.Images.SetKeyName(26, "cama");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.resultado, "resultado", typeof(global::BaseR.Properties.Resources), 27);
            this.ribbonImageCollectionLarge.Images.SetKeyName(27, "resultado");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.asignacion, "asignacion", typeof(global::BaseR.Properties.Resources), 28);
            this.ribbonImageCollectionLarge.Images.SetKeyName(28, "asignacion");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.uci, "uci", typeof(global::BaseR.Properties.Resources), 29);
            this.ribbonImageCollectionLarge.Images.SetKeyName(29, "uci");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.solicitud, "solicitud", typeof(global::BaseR.Properties.Resources), 30);
            this.ribbonImageCollectionLarge.Images.SetKeyName(30, "solicitud");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.reprogramar, "reprogramar", typeof(global::BaseR.Properties.Resources), 31);
            this.ribbonImageCollectionLarge.Images.SetKeyName(31, "reprogramar");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.adjuntarX32, "adjuntarX32", typeof(global::BaseR.Properties.Resources), 32);
            this.ribbonImageCollectionLarge.Images.SetKeyName(32, "adjuntarX32");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.viewX32, "viewX32", typeof(global::BaseR.Properties.Resources), 33);
            this.ribbonImageCollectionLarge.Images.SetKeyName(33, "viewX32");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.informeX32, "informeX32", typeof(global::BaseR.Properties.Resources), 34);
            this.ribbonImageCollectionLarge.Images.SetKeyName(34, "informeX32");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.filtro, "filtro", typeof(global::BaseR.Properties.Resources), 35);
            this.ribbonImageCollectionLarge.Images.SetKeyName(35, "filtro");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.verFiltro, "verFiltro", typeof(global::BaseR.Properties.Resources), 36);
            this.ribbonImageCollectionLarge.Images.SetKeyName(36, "verFiltro");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.baja, "baja", typeof(global::BaseR.Properties.Resources), 37);
            this.ribbonImageCollectionLarge.Images.SetKeyName(37, "baja");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.conciliacion, "conciliacion", typeof(global::BaseR.Properties.Resources), 38);
            this.ribbonImageCollectionLarge.Images.SetKeyName(38, "conciliacion");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.pagar, "pagar", typeof(global::BaseR.Properties.Resources), 39);
            this.ribbonImageCollectionLarge.Images.SetKeyName(39, "pagar");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.refacturar, "refacturar", typeof(global::BaseR.Properties.Resources), 40);
            this.ribbonImageCollectionLarge.Images.SetKeyName(40, "refacturar");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.tramite, "tramite", typeof(global::BaseR.Properties.Resources), 41);
            this.ribbonImageCollectionLarge.Images.SetKeyName(41, "tramite");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.judicial, "judicial", typeof(global::BaseR.Properties.Resources), 42);
            this.ribbonImageCollectionLarge.Images.SetKeyName(42, "judicial");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.consolidado, "consolidado", typeof(global::BaseR.Properties.Resources), 43);
            this.ribbonImageCollectionLarge.Images.SetKeyName(43, "consolidado");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.detallePago, "detallePago", typeof(global::BaseR.Properties.Resources), 44);
            this.ribbonImageCollectionLarge.Images.SetKeyName(44, "detallePago");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.distribuir, "distribuir", typeof(global::BaseR.Properties.Resources), 45);
            this.ribbonImageCollectionLarge.Images.SetKeyName(45, "distribuir");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.distribuirGlobal, "distribuirGlobal", typeof(global::BaseR.Properties.Resources), 46);
            this.ribbonImageCollectionLarge.Images.SetKeyName(46, "distribuirGlobal");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.relacionPaciente, "relacionPaciente", typeof(global::BaseR.Properties.Resources), 47);
            this.ribbonImageCollectionLarge.Images.SetKeyName(47, "relacionPaciente");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.cancel, "cancel", typeof(global::BaseR.Properties.Resources), 48);
            this.ribbonImageCollectionLarge.Images.SetKeyName(48, "cancel");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.save, "save", typeof(global::BaseR.Properties.Resources), 49);
            this.ribbonImageCollectionLarge.Images.SetKeyName(49, "save");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.sobre, "sobre", typeof(global::BaseR.Properties.Resources), 50);
            this.ribbonImageCollectionLarge.Images.SetKeyName(50, "sobre");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.print4, "print4", typeof(global::BaseR.Properties.Resources), 51);
            this.ribbonImageCollectionLarge.Images.SetKeyName(51, "print4");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.DefaultPrinter_16x16, "DefaultPrinter_16x16", typeof(global::BaseR.Properties.Resources), 52);
            this.ribbonImageCollectionLarge.Images.SetKeyName(52, "DefaultPrinter_16x16");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.Print_16x16, "Print_16x16", typeof(global::BaseR.Properties.Resources), 53);
            this.ribbonImageCollectionLarge.Images.SetKeyName(53, "Print_16x16");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.SavePageSetup_16x16, "SavePageSetup_16x16", typeof(global::BaseR.Properties.Resources), 54);
            this.ribbonImageCollectionLarge.Images.SetKeyName(54, "SavePageSetup_16x16");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lab_condiciones_16x16, "lab_condiciones_16x16", typeof(global::BaseR.Properties.Resources), 55);
            this.ribbonImageCollectionLarge.Images.SetKeyName(55, "lab_condiciones_16x16");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lab_lista_16x16, "lab_lista_16x16", typeof(global::BaseR.Properties.Resources), 56);
            this.ribbonImageCollectionLarge.Images.SetKeyName(56, "lab_lista_16x16");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lab_mail_16x16, "lab_mail_16x16", typeof(global::BaseR.Properties.Resources), 57);
            this.ribbonImageCollectionLarge.Images.SetKeyName(57, "lab_mail_16x16");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lab_sobre_32x32, "lab_sobre_32x32", typeof(global::BaseR.Properties.Resources), 58);
            this.ribbonImageCollectionLarge.Images.SetKeyName(58, "lab_sobre_32x32");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lab_informe_16x16, "lab_informe_16x16", typeof(global::BaseR.Properties.Resources), 59);
            this.ribbonImageCollectionLarge.Images.SetKeyName(59, "lab_informe_16x16");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lab_verinforme_16x16, "lab_verinforme_16x16", typeof(global::BaseR.Properties.Resources), 60);
            this.ribbonImageCollectionLarge.Images.SetKeyName(60, "lab_verinforme_16x16");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lab_print_32x32, "lab_print_32x32", typeof(global::BaseR.Properties.Resources), 61);
            this.ribbonImageCollectionLarge.Images.SetKeyName(61, "lab_print_32x32");
            this.ribbonImageCollectionLarge.InsertImage(global::BaseR.Properties.Resources.lab_print_seleccion_32x32, "lab_print_seleccion_32x32", typeof(global::BaseR.Properties.Resources), 62);
            this.ribbonImageCollectionLarge.Images.SetKeyName(62, "lab_print_seleccion_32x32");
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
            // obtnCerrar
            // 
            this.obtnCerrar.Caption = "Cerrar";
            this.obtnCerrar.Hint = "Cerrar";
            this.obtnCerrar.Id = 8;
            this.obtnCerrar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.obtnCerrar.LargeImageIndex = 0;
            this.obtnCerrar.Name = "obtnCerrar";
            this.obtnCerrar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.obtnCerrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rbtnCerrar_ItemClick);
            // 
            // rbtnActualizar
            // 
            this.rbtnActualizar.Caption = "Actualizar Listado";
            this.rbtnActualizar.Id = 11;
            this.rbtnActualizar.LargeImageIndex = 16;
            this.rbtnActualizar.Name = "rbtnActualizar";
            this.rbtnActualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rbtnActualizar_ItemClick);
            // 
            // PageInicio
            // 
            this.PageInicio.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.GrupoEdicion,
            this.GrupoFiltros,
            this.GrupoDatos,
            this.GrupoOpcion});
            this.PageInicio.Name = "PageInicio";
            this.PageInicio.Text = "Inicio";
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
            // GrupoDatos
            // 
            this.GrupoDatos.ItemLinks.Add(this.rbtnActualizar);
            this.GrupoDatos.Name = "GrupoDatos";
            this.GrupoDatos.ShowCaptionButton = false;
            this.GrupoDatos.Text = "Datos";
            // 
            // GrupoOpcion
            // 
            this.GrupoOpcion.ItemLinks.Add(this.obtnCerrar);
            this.GrupoOpcion.Name = "GrupoOpcion";
            this.GrupoOpcion.ShowCaptionButton = false;
            this.GrupoOpcion.Text = "Opción";
            // 
            // FBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 526);
            this.Controls.Add(this.RibbonForm);
            this.Name = "FBaseForm";
            this.Text = "FForm";
            this.Load += new System.EventHandler(this.FBaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarButtonItem obtnCerrar;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge;
        public DevExpress.XtraBars.Ribbon.RibbonControl RibbonForm;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoFiltros;
        public DevExpress.XtraBars.BarButtonItem wbtnNuevo;
        public DevExpress.XtraBars.BarButtonItem wbtnEditar;
        public DevExpress.XtraBars.BarButtonItem wbtnBorrar;
        public DevExpress.XtraBars.BarButtonItem rbtnVisualizar;
        public DevExpress.XtraBars.BarButtonItem rbtnImprimir;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoEdicion;
        public DevExpress.XtraBars.BarButtonItem rbtnActualizar;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoDatos;
        public DevExpress.XtraBars.Ribbon.RibbonPage PageInicio;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup GrupoOpcion;
    }
}