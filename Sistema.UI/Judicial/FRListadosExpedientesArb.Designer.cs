namespace Sistema.UI.Judicial
{
    partial class FRListadosExpedientesArb
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
            this.bsLista = new System.Windows.Forms.BindingSource(this.components);
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaInicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreDemandante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreDemandado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroDocumentoDemandante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentoDemandado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMateriaArbitral = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupervisorInterno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstadoProceso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colubicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModalidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCorreoParaNotificacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContratoOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSedeArbitral = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaInstalacionTribText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroArbitral = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcionTipoArbitraje = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSecretarioArbitral = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArbitroUnicoPresidente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArbitroParteEntidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArbitroParteDemandante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaudoFavor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContingencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJustificacionContingencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoMonedaControversia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoControversia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoMonedaReconvencion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoReconvencion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoMonedaLaudado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoLaudado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnMostrar = new DevExpress.XtraEditors.SimpleButton();
            this.deFin = new DevExpress.XtraEditors.DateEdit();
            this.deInicio = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonForm
            // 
            this.RibbonForm.ExpandCollapseItem.Id = 0;
            this.RibbonForm.Margin = new System.Windows.Forms.Padding(4);
            this.RibbonForm.OptionsMenuMinWidth = 495;
            // 
            // 
            // 
            this.RibbonForm.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.RibbonForm.SearchEditItem.EditWidth = 150;
            this.RibbonForm.SearchEditItem.Id = -5000;
            this.RibbonForm.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.RibbonForm.Size = new System.Drawing.Size(1060, 112);
            // 
            // bsLista
            // 
            this.bsLista.DataSource = typeof(Sistema.Model.viewExpedienteReport);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gridControl1;
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bsLista;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.RibbonForm;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1036, 474);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigo,
            this.colFechaInicio,
            this.colNombreDemandante,
            this.colNombreDemandado,
            this.colNroDocumentoDemandante,
            this.colDocumentoDemandado,
            this.colTipoDocumento,
            this.colMateriaArbitral,
            this.colSupervisorInterno,
            this.colEstadoProceso,
            this.colubicacion,
            this.colModalidad,
            this.colCorreoParaNotificacion,
            this.colContratoOrigen,
            this.colSedeArbitral,
            this.colFechaInstalacionTribText,
            this.colCentroArbitral,
            this.colDescripcionTipoArbitraje,
            this.colSecretarioArbitral,
            this.colArbitroUnicoPresidente,
            this.colArbitroParteEntidad,
            this.colArbitroParteDemandante,
            this.colLaudoFavor,
            this.colContingencia,
            this.colJustificacionContingencia,
            this.colTipoMonedaControversia,
            this.colMontoControversia,
            this.colTipoMonedaReconvencion,
            this.colMontoReconvencion,
            this.colTipoMonedaLaudado,
            this.colMontoLaudado});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFechaInicio, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // colCodigo
            // 
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            this.colCodigo.Width = 64;
            // 
            // colFechaInicio
            // 
            this.colFechaInicio.Caption = "Fecha";
            this.colFechaInicio.FieldName = "FechaInicio";
            this.colFechaInicio.Name = "colFechaInicio";
            this.colFechaInicio.Visible = true;
            this.colFechaInicio.VisibleIndex = 1;
            this.colFechaInicio.Width = 53;
            // 
            // colNombreDemandante
            // 
            this.colNombreDemandante.Caption = "Demandante";
            this.colNombreDemandante.FieldName = "NombreDemandante";
            this.colNombreDemandante.Name = "colNombreDemandante";
            this.colNombreDemandante.Visible = true;
            this.colNombreDemandante.VisibleIndex = 3;
            this.colNombreDemandante.Width = 125;
            // 
            // colNombreDemandado
            // 
            this.colNombreDemandado.Caption = "Demandado";
            this.colNombreDemandado.FieldName = "NombreDemandado";
            this.colNombreDemandado.Name = "colNombreDemandado";
            this.colNombreDemandado.Visible = true;
            this.colNombreDemandado.VisibleIndex = 5;
            this.colNombreDemandado.Width = 110;
            // 
            // colNroDocumentoDemandante
            // 
            this.colNroDocumentoDemandante.Caption = "Documento";
            this.colNroDocumentoDemandante.FieldName = "NroDocumentoDemandante";
            this.colNroDocumentoDemandante.Name = "colNroDocumentoDemandante";
            this.colNroDocumentoDemandante.Visible = true;
            this.colNroDocumentoDemandante.VisibleIndex = 2;
            this.colNroDocumentoDemandante.Width = 76;
            // 
            // colDocumentoDemandado
            // 
            this.colDocumentoDemandado.Caption = "Documento.";
            this.colDocumentoDemandado.CustomizationCaption = "Documento";
            this.colDocumentoDemandado.FieldName = "DocumentoDemandado";
            this.colDocumentoDemandado.Name = "colDocumentoDemandado";
            this.colDocumentoDemandado.Visible = true;
            this.colDocumentoDemandado.VisibleIndex = 4;
            // 
            // colTipoDocumento
            // 
            this.colTipoDocumento.FieldName = "TipoDocumento";
            this.colTipoDocumento.Name = "colTipoDocumento";
            this.colTipoDocumento.Visible = true;
            this.colTipoDocumento.VisibleIndex = 6;
            this.colTipoDocumento.Width = 91;
            // 
            // colMateriaArbitral
            // 
            this.colMateriaArbitral.Caption = "Materia";
            this.colMateriaArbitral.FieldName = "MateriaArbitral";
            this.colMateriaArbitral.Name = "colMateriaArbitral";
            this.colMateriaArbitral.Visible = true;
            this.colMateriaArbitral.VisibleIndex = 7;
            this.colMateriaArbitral.Width = 87;
            // 
            // colSupervisorInterno
            // 
            this.colSupervisorInterno.FieldName = "SupervisorInterno";
            this.colSupervisorInterno.Name = "colSupervisorInterno";
            this.colSupervisorInterno.Visible = true;
            this.colSupervisorInterno.VisibleIndex = 8;
            this.colSupervisorInterno.Width = 144;
            // 
            // colEstadoProceso
            // 
            this.colEstadoProceso.Caption = "Estado del Proceso";
            this.colEstadoProceso.FieldName = "EstadoProceso";
            this.colEstadoProceso.Name = "colEstadoProceso";
            this.colEstadoProceso.Visible = true;
            this.colEstadoProceso.VisibleIndex = 9;
            this.colEstadoProceso.Width = 104;
            // 
            // colubicacion
            // 
            this.colubicacion.Caption = "Ubicación";
            this.colubicacion.FieldName = "ubicacion";
            this.colubicacion.Name = "colubicacion";
            this.colubicacion.Visible = true;
            this.colubicacion.VisibleIndex = 10;
            this.colubicacion.Width = 137;
            // 
            // colModalidad
            // 
            this.colModalidad.FieldName = "Modalidad";
            this.colModalidad.Name = "colModalidad";
            this.colModalidad.Visible = true;
            this.colModalidad.VisibleIndex = 11;
            this.colModalidad.Width = 121;
            // 
            // colCorreoParaNotificacion
            // 
            this.colCorreoParaNotificacion.FieldName = "CorreoParaNotificacion";
            this.colCorreoParaNotificacion.Name = "colCorreoParaNotificacion";
            this.colCorreoParaNotificacion.Visible = true;
            this.colCorreoParaNotificacion.VisibleIndex = 12;
            this.colCorreoParaNotificacion.Width = 124;
            // 
            // colContratoOrigen
            // 
            this.colContratoOrigen.FieldName = "ContratoOrigen";
            this.colContratoOrigen.Name = "colContratoOrigen";
            this.colContratoOrigen.Visible = true;
            this.colContratoOrigen.VisibleIndex = 13;
            this.colContratoOrigen.Width = 104;
            // 
            // colSedeArbitral
            // 
            this.colSedeArbitral.FieldName = "SedeArbitral";
            this.colSedeArbitral.Name = "colSedeArbitral";
            this.colSedeArbitral.Visible = true;
            this.colSedeArbitral.VisibleIndex = 14;
            this.colSedeArbitral.Width = 139;
            // 
            // colFechaInstalacionTribText
            // 
            this.colFechaInstalacionTribText.Caption = "Fecha Instalación Trib.";
            this.colFechaInstalacionTribText.FieldName = "FechaInstalacionTribText";
            this.colFechaInstalacionTribText.Name = "colFechaInstalacionTribText";
            this.colFechaInstalacionTribText.Visible = true;
            this.colFechaInstalacionTribText.VisibleIndex = 15;
            this.colFechaInstalacionTribText.Width = 119;
            // 
            // colCentroArbitral
            // 
            this.colCentroArbitral.FieldName = "CentroArbitral";
            this.colCentroArbitral.Name = "colCentroArbitral";
            this.colCentroArbitral.Visible = true;
            this.colCentroArbitral.VisibleIndex = 16;
            this.colCentroArbitral.Width = 111;
            // 
            // colDescripcionTipoArbitraje
            // 
            this.colDescripcionTipoArbitraje.Caption = "Tipo Arbitraje";
            this.colDescripcionTipoArbitraje.FieldName = "DescripcionTipoArbitraje";
            this.colDescripcionTipoArbitraje.Name = "colDescripcionTipoArbitraje";
            this.colDescripcionTipoArbitraje.Visible = true;
            this.colDescripcionTipoArbitraje.VisibleIndex = 17;
            this.colDescripcionTipoArbitraje.Width = 111;
            // 
            // colSecretarioArbitral
            // 
            this.colSecretarioArbitral.FieldName = "SecretarioArbitral";
            this.colSecretarioArbitral.Name = "colSecretarioArbitral";
            this.colSecretarioArbitral.Visible = true;
            this.colSecretarioArbitral.VisibleIndex = 18;
            this.colSecretarioArbitral.Width = 160;
            // 
            // colArbitroUnicoPresidente
            // 
            this.colArbitroUnicoPresidente.FieldName = "ArbitroUnicoPresidente";
            this.colArbitroUnicoPresidente.Name = "colArbitroUnicoPresidente";
            this.colArbitroUnicoPresidente.Visible = true;
            this.colArbitroUnicoPresidente.VisibleIndex = 19;
            this.colArbitroUnicoPresidente.Width = 151;
            // 
            // colArbitroParteEntidad
            // 
            this.colArbitroParteEntidad.FieldName = "ArbitroParteEntidad";
            this.colArbitroParteEntidad.Name = "colArbitroParteEntidad";
            this.colArbitroParteEntidad.Visible = true;
            this.colArbitroParteEntidad.VisibleIndex = 20;
            this.colArbitroParteEntidad.Width = 130;
            // 
            // colArbitroParteDemandante
            // 
            this.colArbitroParteDemandante.FieldName = "ArbitroParteDemandante";
            this.colArbitroParteDemandante.Name = "colArbitroParteDemandante";
            this.colArbitroParteDemandante.Visible = true;
            this.colArbitroParteDemandante.VisibleIndex = 21;
            this.colArbitroParteDemandante.Width = 143;
            // 
            // colLaudoFavor
            // 
            this.colLaudoFavor.Caption = "Laudo a favor";
            this.colLaudoFavor.FieldName = "LaudoFavor";
            this.colLaudoFavor.Name = "colLaudoFavor";
            this.colLaudoFavor.Visible = true;
            this.colLaudoFavor.VisibleIndex = 22;
            this.colLaudoFavor.Width = 151;
            // 
            // colContingencia
            // 
            this.colContingencia.FieldName = "Contingencia";
            this.colContingencia.Name = "colContingencia";
            this.colContingencia.Visible = true;
            this.colContingencia.VisibleIndex = 23;
            this.colContingencia.Width = 109;
            // 
            // colJustificacionContingencia
            // 
            this.colJustificacionContingencia.FieldName = "JustificacionContingencia";
            this.colJustificacionContingencia.Name = "colJustificacionContingencia";
            this.colJustificacionContingencia.Visible = true;
            this.colJustificacionContingencia.VisibleIndex = 24;
            this.colJustificacionContingencia.Width = 141;
            // 
            // colTipoMonedaControversia
            // 
            this.colTipoMonedaControversia.Caption = "T.M. Controversia";
            this.colTipoMonedaControversia.FieldName = "TipoMonedaControversia";
            this.colTipoMonedaControversia.Name = "colTipoMonedaControversia";
            this.colTipoMonedaControversia.Visible = true;
            this.colTipoMonedaControversia.VisibleIndex = 25;
            this.colTipoMonedaControversia.Width = 114;
            // 
            // colMontoControversia
            // 
            this.colMontoControversia.Caption = "Monto Controversia";
            this.colMontoControversia.FieldName = "MontoControversia";
            this.colMontoControversia.Name = "colMontoControversia";
            this.colMontoControversia.Visible = true;
            this.colMontoControversia.VisibleIndex = 26;
            this.colMontoControversia.Width = 113;
            // 
            // colTipoMonedaReconvencion
            // 
            this.colTipoMonedaReconvencion.Caption = "T.M. Reconvención";
            this.colTipoMonedaReconvencion.FieldName = "TipoMonedaReconvencion";
            this.colTipoMonedaReconvencion.Name = "colTipoMonedaReconvencion";
            this.colTipoMonedaReconvencion.Visible = true;
            this.colTipoMonedaReconvencion.VisibleIndex = 27;
            this.colTipoMonedaReconvencion.Width = 111;
            // 
            // colMontoReconvencion
            // 
            this.colMontoReconvencion.Caption = "Monto Reconvención";
            this.colMontoReconvencion.FieldName = "MontoReconvencion";
            this.colMontoReconvencion.Name = "colMontoReconvencion";
            this.colMontoReconvencion.Visible = true;
            this.colMontoReconvencion.VisibleIndex = 28;
            this.colMontoReconvencion.Width = 119;
            // 
            // colTipoMonedaLaudado
            // 
            this.colTipoMonedaLaudado.Caption = "T.M. Laudado";
            this.colTipoMonedaLaudado.FieldName = "TipoMonedaLaudado";
            this.colTipoMonedaLaudado.Name = "colTipoMonedaLaudado";
            this.colTipoMonedaLaudado.Visible = true;
            this.colTipoMonedaLaudado.VisibleIndex = 29;
            this.colTipoMonedaLaudado.Width = 103;
            // 
            // colMontoLaudado
            // 
            this.colMontoLaudado.FieldName = "MontoLaudado";
            this.colMontoLaudado.Name = "colMontoLaudado";
            this.colMontoLaudado.Visible = true;
            this.colMontoLaudado.VisibleIndex = 30;
            this.colMontoLaudado.Width = 94;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.btnMostrar);
            this.layoutControl1.Controls.Add(this.deFin);
            this.layoutControl1.Controls.Add(this.deInicio);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 112);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1060, 524);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnMostrar
            // 
            this.btnMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrar.ImageOptions.Image = global::Sistema.UI.Properties.Resources.Search216x16;
            this.btnMostrar.Location = new System.Drawing.Point(792, 12);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(256, 22);
            this.btnMostrar.StyleController = this.layoutControl1;
            this.btnMostrar.TabIndex = 6;
            this.btnMostrar.Text = "Actualizar Listado";
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // deFin
            // 
            this.deFin.EditValue = null;
            this.deFin.Location = new System.Drawing.Point(477, 12);
            this.deFin.MenuManager = this.RibbonForm;
            this.deFin.Name = "deFin";
            this.deFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFin.Size = new System.Drawing.Size(311, 20);
            this.deFin.StyleController = this.layoutControl1;
            this.deFin.TabIndex = 5;
            // 
            // deInicio
            // 
            this.deInicio.EditValue = null;
            this.deInicio.Location = new System.Drawing.Point(71, 12);
            this.deInicio.MenuManager = this.RibbonForm;
            this.deInicio.Name = "deInicio";
            this.deInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deInicio.Size = new System.Drawing.Size(343, 20);
            this.deInicio.StyleController = this.layoutControl1;
            this.deInicio.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1060, 524);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deInicio;
            this.layoutControlItem1.CustomizationFormText = "Fecha Incio";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(406, 26);
            this.layoutControlItem1.Text = "Fecha Incio";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deFin;
            this.layoutControlItem2.CustomizationFormText = "Fecha Fin";
            this.layoutControlItem2.Location = new System.Drawing.Point(406, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(374, 26);
            this.layoutControlItem2.Text = "Fecha Fin";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnMostrar;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(780, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(260, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1040, 478);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // FRListadosExpedientesArb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 664);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRListadosExpedientesArb";
            this.Tag = "LISTA";
            this.Text = "Listado - Expedientes Arbitrales ";
            this.Controls.SetChildIndex(this.RibbonForm, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsLista;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnMostrar;
        private DevExpress.XtraEditors.DateEdit deFin;
        private DevExpress.XtraEditors.DateEdit deInicio;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaInicio;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreDemandante;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreDemandado;
        private DevExpress.XtraGrid.Columns.GridColumn colNroDocumentoDemandante;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentoDemandado;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colMateriaArbitral;
        private DevExpress.XtraGrid.Columns.GridColumn colSupervisorInterno;
        private DevExpress.XtraGrid.Columns.GridColumn colEstadoProceso;
        private DevExpress.XtraGrid.Columns.GridColumn colubicacion;
        private DevExpress.XtraGrid.Columns.GridColumn colModalidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCorreoParaNotificacion;
        private DevExpress.XtraGrid.Columns.GridColumn colContratoOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn colSedeArbitral;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaInstalacionTribText;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroArbitral;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcionTipoArbitraje;
        private DevExpress.XtraGrid.Columns.GridColumn colSecretarioArbitral;
        private DevExpress.XtraGrid.Columns.GridColumn colArbitroUnicoPresidente;
        private DevExpress.XtraGrid.Columns.GridColumn colArbitroParteEntidad;
        private DevExpress.XtraGrid.Columns.GridColumn colArbitroParteDemandante;
        private DevExpress.XtraGrid.Columns.GridColumn colLaudoFavor;
        private DevExpress.XtraGrid.Columns.GridColumn colContingencia;
        private DevExpress.XtraGrid.Columns.GridColumn colJustificacionContingencia;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMonedaControversia;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoControversia;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMonedaReconvencion;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoReconvencion;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMonedaLaudado;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoLaudado;
    }
}