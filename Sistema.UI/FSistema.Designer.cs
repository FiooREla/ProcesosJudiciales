namespace Sistema.UI
{
    partial class FSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSistema));
            this.bbiCerrarSesion = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpMenu = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.vbcMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.G1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbLocalidad = new DevExpress.XtraNavBar.NavBarItem();
            this.nbDemandantesDemandados = new DevExpress.XtraNavBar.NavBarItem();
            this.nbAsesoresJuridicos = new DevExpress.XtraNavBar.NavBarItem();
            this.nbTrabajadoresJudiciales = new DevExpress.XtraNavBar.NavBarItem();
            this.nbTipoContenido = new DevExpress.XtraNavBar.NavBarItem();
            this.nbSupervisorInterno = new DevExpress.XtraNavBar.NavBarItem();
            this.nbContratos = new DevExpress.XtraNavBar.NavBarItem();
            this.nbVariablesDeSistema = new DevExpress.XtraNavBar.NavBarItem();
            this.nbEstadoActual = new DevExpress.XtraNavBar.NavBarItem();
            this.G2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.bnTipoProceso = new DevExpress.XtraNavBar.NavBarItem();
            this.nbClaseProceso = new DevExpress.XtraNavBar.NavBarItem();
            this.nbInstanciaJudicial = new DevExpress.XtraNavBar.NavBarItem();
            this.nbNotificaciones = new DevExpress.XtraNavBar.NavBarItem();
            this.G5 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbSedeJudicial = new DevExpress.XtraNavBar.NavBarItem();
            this.nbJuzgados = new DevExpress.XtraNavBar.NavBarItem();
            this.G3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbExpedientes = new DevExpress.XtraNavBar.NavBarItem();
            this.nbListadosExpedientes = new DevExpress.XtraNavBar.NavBarItem();
            this.nbListadoAgendasJudiciales = new DevExpress.XtraNavBar.NavBarItem();
            this.nbInformesTrimestrales = new DevExpress.XtraNavBar.NavBarItem();
            this.G7 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbExpedientesArbitrales = new DevExpress.XtraNavBar.NavBarItem();
            this.nbMateriaControvertida = new DevExpress.XtraNavBar.NavBarItem();
            this.nbSedeArbitral = new DevExpress.XtraNavBar.NavBarItem();
            this.nbEstadoActualActoProcesal = new DevExpress.XtraNavBar.NavBarItem();
            this.nbListadoArbitrajes = new DevExpress.XtraNavBar.NavBarItem();
            this.G4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbUsuarios = new DevExpress.XtraNavBar.NavBarItem();
            this.nbOpciones = new DevExpress.XtraNavBar.NavBarItem();
            this.G6 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbConfigurarReporte = new DevExpress.XtraNavBar.NavBarItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dpMenu.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vbcMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // GrupoSistema
            // 
            this.GrupoSistema.ItemLinks.Add(this.barButtonItem2);
            this.GrupoSistema.ItemLinks.Add(this.barButtonItem3);
            this.GrupoSistema.ItemLinks.Add(this.barButtonItem1);
            this.GrupoSistema.ItemLinks.Add(this.bbiCerrarSesion);
            // 
            // RibbonPrincipal
            // 
            this.RibbonPrincipal.ExpandCollapseItem.Id = 0;
            this.RibbonPrincipal.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiCerrarSesion,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem1});
            this.RibbonPrincipal.MaxItemId = 206;
            // 
            // 
            // 
            this.RibbonPrincipal.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.RibbonPrincipal.SearchEditItem.EditWidth = 150;
            this.RibbonPrincipal.SearchEditItem.Id = -5000;
            this.RibbonPrincipal.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.RibbonPrincipal.Size = new System.Drawing.Size(745, 142);
            // 
            // StatusBarPrincipal
            // 
            this.StatusBarPrincipal.Location = new System.Drawing.Point(0, 741);
            this.StatusBarPrincipal.Size = new System.Drawing.Size(745, 33);
            // 
            // bbiCerrarSesion
            // 
            this.bbiCerrarSesion.Caption = "Cerrar Sistema";
            this.bbiCerrarSesion.Id = 201;
            this.bbiCerrarSesion.ImageOptions.LargeImageIndex = 0;
            this.bbiCerrarSesion.Name = "bbiCerrarSesion";
            this.bbiCerrarSesion.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiCerrarSesion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCerrarSesion_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Servidor";
            this.barButtonItem2.Id = 202;
            this.barButtonItem2.ImageOptions.LargeImageIndex = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Ajustes";
            this.barButtonItem3.Id = 203;
            this.barButtonItem3.ImageOptions.LargeImageIndex = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpMenu});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dpMenu
            // 
            this.dpMenu.Controls.Add(this.dockPanel1_Container);
            this.dpMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpMenu.ID = new System.Guid("274a6322-6501-454c-8cc2-bba71e39b7ef");
            this.dpMenu.Location = new System.Drawing.Point(0, 142);
            this.dpMenu.Name = "dpMenu";
            this.dpMenu.Options.ShowCloseButton = false;
            this.dpMenu.OriginalSize = new System.Drawing.Size(352, 200);
            this.dpMenu.Size = new System.Drawing.Size(352, 599);
            this.dpMenu.Text = "Menú del Sistema";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.vbcMenu);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 24);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(345, 572);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // vbcMenu
            // 
            this.vbcMenu.ActiveGroup = this.G1;
            this.vbcMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vbcMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.G1,
            this.G2,
            this.G5,
            this.G3,
            this.G7,
            this.G4,
            this.G6});
            this.vbcMenu.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbLocalidad,
            this.nbDemandantesDemandados,
            this.nbTipoContenido,
            this.bnTipoProceso,
            this.nbClaseProceso,
            this.nbInstanciaJudicial,
            this.nbSedeJudicial,
            this.nbJuzgados,
            this.nbExpedientes,
            this.nbUsuarios,
            this.nbOpciones,
            this.nbListadosExpedientes,
            this.nbListadoAgendasJudiciales,
            this.nbInformesTrimestrales,
            this.nbAsesoresJuridicos,
            this.nbTrabajadoresJudiciales,
            this.nbSupervisorInterno,
            this.nbContratos,
            this.nbNotificaciones,
            this.nbVariablesDeSistema,
            this.nbConfigurarReporte,
            this.nbEstadoActual,
            this.nbExpedientesArbitrales,
            this.nbMateriaControvertida,
            this.nbSedeArbitral,
            this.nbListadoArbitrajes,
            this.nbEstadoActualActoProcesal});
            this.vbcMenu.Location = new System.Drawing.Point(0, 0);
            this.vbcMenu.Name = "vbcMenu";
            this.vbcMenu.OptionsNavPane.ExpandedWidth = 345;
            this.vbcMenu.Size = new System.Drawing.Size(345, 572);
            this.vbcMenu.TabIndex = 0;
            this.vbcMenu.Text = "navBarControl1";
            this.vbcMenu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.vbcMenu_LinkClicked);
            this.vbcMenu.Click += new System.EventHandler(this.vbcMenu_Click);
            // 
            // G1
            // 
            this.G1.Caption = "Información General";
            this.G1.Expanded = true;
            this.G1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbLocalidad),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbDemandantesDemandados),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbAsesoresJuridicos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbTrabajadoresJudiciales),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbTipoContenido),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbSupervisorInterno),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbContratos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbVariablesDeSistema),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbEstadoActual)});
            this.G1.Name = "G1";
            this.G1.Visible = false;
            // 
            // nbLocalidad
            // 
            this.nbLocalidad.Caption = "Localidades";
            this.nbLocalidad.ImageOptions.LargeImage = global::Sistema.UI.Properties.Resources.place32x32;
            this.nbLocalidad.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.place32x32;
            this.nbLocalidad.Name = "nbLocalidad";
            this.nbLocalidad.Visible = false;
            this.nbLocalidad.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbLocalidad_LinkClicked);
            // 
            // nbDemandantesDemandados
            // 
            this.nbDemandantesDemandados.Caption = "Demandantes / Demandados";
            this.nbDemandantesDemandados.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.personas32x32;
            this.nbDemandantesDemandados.Name = "nbDemandantesDemandados";
            this.nbDemandantesDemandados.Visible = false;
            this.nbDemandantesDemandados.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbEntidad_LinkClicked);
            // 
            // nbAsesoresJuridicos
            // 
            this.nbAsesoresJuridicos.Caption = "Asesores Juridicos";
            this.nbAsesoresJuridicos.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.AsesoresJuridicos32x32;
            this.nbAsesoresJuridicos.Name = "nbAsesoresJuridicos";
            this.nbAsesoresJuridicos.Visible = false;
            this.nbAsesoresJuridicos.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbAsesoresJuridicos_LinkClicked);
            // 
            // nbTrabajadoresJudiciales
            // 
            this.nbTrabajadoresJudiciales.Caption = "Especialista Judicial";
            this.nbTrabajadoresJudiciales.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.TrabajadoresJudiciales32x32;
            this.nbTrabajadoresJudiciales.Name = "nbTrabajadoresJudiciales";
            this.nbTrabajadoresJudiciales.Visible = false;
            this.nbTrabajadoresJudiciales.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbTrabajadoresJudiciales_LinkClicked);
            // 
            // nbTipoContenido
            // 
            this.nbTipoContenido.Caption = "Tipos de Contenido (Tags)";
            this.nbTipoContenido.ImageOptions.LargeImage = global::Sistema.UI.Properties.Resources.Tag32x32;
            this.nbTipoContenido.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.Tag32x32;
            this.nbTipoContenido.Name = "nbTipoContenido";
            this.nbTipoContenido.Visible = false;
            this.nbTipoContenido.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbTipoContenido_LinkClicked);
            // 
            // nbSupervisorInterno
            // 
            this.nbSupervisorInterno.Caption = "Supervisor Interno";
            this.nbSupervisorInterno.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nbSupervisorInterno.ImageOptions.SvgImage")));
            this.nbSupervisorInterno.Name = "nbSupervisorInterno";
            this.nbSupervisorInterno.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbSupervisorInterno_LinkClicked);
            // 
            // nbContratos
            // 
            this.nbContratos.Caption = "Contratos";
            this.nbContratos.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nbContratos.ImageOptions.SvgImage")));
            this.nbContratos.Name = "nbContratos";
            this.nbContratos.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbContratos_LinkClicked);
            // 
            // nbVariablesDeSistema
            // 
            this.nbVariablesDeSistema.Caption = "Variables de Sistema";
            this.nbVariablesDeSistema.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nbVariablesDeSistema.ImageOptions.SvgImage")));
            this.nbVariablesDeSistema.Name = "nbVariablesDeSistema";
            this.nbVariablesDeSistema.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbVariablesDeSistema_LinkClicked);
            // 
            // nbEstadoActual
            // 
            this.nbEstadoActual.Caption = "Estados Actuales";
            this.nbEstadoActual.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nbEstadoActual.ImageOptions.SvgImage")));
            this.nbEstadoActual.Name = "nbEstadoActual";
            this.nbEstadoActual.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbEstadoActual_LinkClicked);
            // 
            // G2
            // 
            this.G2.Caption = "Información Judicial";
            this.G2.Expanded = true;
            this.G2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bnTipoProceso),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbClaseProceso),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbInstanciaJudicial),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbNotificaciones)});
            this.G2.Name = "G2";
            this.G2.Visible = false;
            // 
            // bnTipoProceso
            // 
            this.bnTipoProceso.Caption = "Tipos de Proceso";
            this.bnTipoProceso.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.Procesos32x32;
            this.bnTipoProceso.Name = "bnTipoProceso";
            this.bnTipoProceso.Visible = false;
            this.bnTipoProceso.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bnTipoProceso_LinkClicked);
            // 
            // nbClaseProceso
            // 
            this.nbClaseProceso.Caption = "Materias de Proceso";
            this.nbClaseProceso.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.Claseroceso32x32;
            this.nbClaseProceso.Name = "nbClaseProceso";
            this.nbClaseProceso.Visible = false;
            this.nbClaseProceso.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbClaseProceso_LinkClicked);
            // 
            // nbInstanciaJudicial
            // 
            this.nbInstanciaJudicial.Caption = "Instancias Judiciales";
            this.nbInstanciaJudicial.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.InstaciasJudiciales;
            this.nbInstanciaJudicial.Name = "nbInstanciaJudicial";
            this.nbInstanciaJudicial.Visible = false;
            this.nbInstanciaJudicial.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbInstanciaJudicial_LinkClicked);
            // 
            // nbNotificaciones
            // 
            this.nbNotificaciones.Caption = "Tipos de Notificacion";
            this.nbNotificaciones.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("nbNotificaciones.ImageOptions.SvgImage")));
            this.nbNotificaciones.Name = "nbNotificaciones";
            this.nbNotificaciones.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbNOtificaciones_LinkClicked);
            // 
            // G5
            // 
            this.G5.Caption = "Entidades Judiciales";
            this.G5.Expanded = true;
            this.G5.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbSedeJudicial),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbJuzgados)});
            this.G5.Name = "G5";
            this.G5.Visible = false;
            // 
            // nbSedeJudicial
            // 
            this.nbSedeJudicial.Caption = "Sedes Judiciales";
            this.nbSedeJudicial.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.Salajudiacila32x32;
            this.nbSedeJudicial.Name = "nbSedeJudicial";
            this.nbSedeJudicial.Visible = false;
            this.nbSedeJudicial.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbSalaJudicial_LinkClicked);
            // 
            // nbJuzgados
            // 
            this.nbJuzgados.Caption = "Organos Judiciales";
            this.nbJuzgados.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.Juzgados32x32;
            this.nbJuzgados.Name = "nbJuzgados";
            this.nbJuzgados.Visible = false;
            this.nbJuzgados.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbJuzgados_LinkClicked);
            // 
            // G3
            // 
            this.G3.Caption = "Procesos Judiciales";
            this.G3.Expanded = true;
            this.G3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbExpedientes),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbListadosExpedientes),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbListadoAgendasJudiciales),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbInformesTrimestrales)});
            this.G3.Name = "G3";
            this.G3.Visible = false;
            // 
            // nbExpedientes
            // 
            this.nbExpedientes.Caption = "Expedientes";
            this.nbExpedientes.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.Documents32x32;
            this.nbExpedientes.Name = "nbExpedientes";
            this.nbExpedientes.Visible = false;
            this.nbExpedientes.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbExpedientes_LinkClicked);
            // 
            // nbListadosExpedientes
            // 
            this.nbListadosExpedientes.Caption = "Listado - Expedientes";
            this.nbListadosExpedientes.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.ReportList32x32;
            this.nbListadosExpedientes.Name = "nbListadosExpedientes";
            this.nbListadosExpedientes.Visible = false;
            this.nbListadosExpedientes.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbListadosExpedientes_LinkClicked);
            // 
            // nbListadoAgendasJudiciales
            // 
            this.nbListadoAgendasJudiciales.Caption = "Listado - Agendas Judiciales";
            this.nbListadoAgendasJudiciales.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.Calendar32x32;
            this.nbListadoAgendasJudiciales.Name = "nbListadoAgendasJudiciales";
            this.nbListadoAgendasJudiciales.Visible = false;
            this.nbListadoAgendasJudiciales.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbListadoAgendasJudiciales_LinkClicked);
            // 
            // nbInformesTrimestrales
            // 
            this.nbInformesTrimestrales.Caption = "Informes Trimestrales";
            this.nbInformesTrimestrales.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.Import_Files_32x32;
            this.nbInformesTrimestrales.Name = "nbInformesTrimestrales";
            this.nbInformesTrimestrales.Visible = false;
            this.nbInformesTrimestrales.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbInformesTrimestrales_LinkClicked);
            // 
            // G7
            // 
            this.G7.Caption = "Arbitrajes";
            this.G7.Expanded = true;
            this.G7.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbExpedientesArbitrales),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbMateriaControvertida),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbSedeArbitral),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbEstadoActualActoProcesal),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbListadoArbitrajes)});
            this.G7.Name = "G7";
            // 
            // nbExpedientesArbitrales
            // 
            this.nbExpedientesArbitrales.Caption = "Expedientes Arbitrales";
            this.nbExpedientesArbitrales.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbExpedientesArbitrales.ImageOptions.SmallImage")));
            this.nbExpedientesArbitrales.Name = "nbExpedientesArbitrales";
            this.nbExpedientesArbitrales.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbExpedientesArbitrales_LinkClicked);
            this.nbExpedientesArbitrales.ItemChanged += new System.EventHandler(this.nbExpedientesArbitrales_ItemChanged);
            // 
            // nbMateriaControvertida
            // 
            this.nbMateriaControvertida.Caption = "Materias Arbitrales";
            this.nbMateriaControvertida.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbMateriaControvertida.ImageOptions.SmallImage")));
            this.nbMateriaControvertida.Name = "nbMateriaControvertida";
            this.nbMateriaControvertida.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbMateriaControvertida_LinkClicked);
            // 
            // nbSedeArbitral
            // 
            this.nbSedeArbitral.Caption = "Sedes Arbitrales";
            this.nbSedeArbitral.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbSedeArbitral.ImageOptions.SmallImage")));
            this.nbSedeArbitral.Name = "nbSedeArbitral";
            this.nbSedeArbitral.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbSedeArbitral_LinkClicked);
            // 
            // nbEstadoActualActoProcesal
            // 
            this.nbEstadoActualActoProcesal.Caption = "Actos Procesales - Estado Actual";
            this.nbEstadoActualActoProcesal.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbEstadoActualActoProcesal.ImageOptions.SmallImage")));
            this.nbEstadoActualActoProcesal.Name = "nbEstadoActualActoProcesal";
            this.nbEstadoActualActoProcesal.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbEstadoActualActoProcesal_LinkClicked);
            // 
            // nbListadoArbitrajes
            // 
            this.nbListadoArbitrajes.Caption = "Listado Expedientes Arbitrales";
            this.nbListadoArbitrajes.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbListadoArbitrajes.ImageOptions.SmallImage")));
            this.nbListadoArbitrajes.Name = "nbListadoArbitrajes";
            this.nbListadoArbitrajes.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbListadoArbitrajes_LinkClicked);
            // 
            // G4
            // 
            this.G4.Caption = "Seguridad";
            this.G4.Expanded = true;
            this.G4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbUsuarios),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbOpciones)});
            this.G4.Name = "G4";
            this.G4.Visible = false;
            // 
            // nbUsuarios
            // 
            this.nbUsuarios.Caption = "Usuarios - Derechos";
            this.nbUsuarios.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.User32x32;
            this.nbUsuarios.Name = "nbUsuarios";
            this.nbUsuarios.Visible = false;
            this.nbUsuarios.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            // 
            // nbOpciones
            // 
            this.nbOpciones.Caption = "Opciones";
            this.nbOpciones.ImageOptions.SmallImage = global::Sistema.UI.Properties.Resources.Options32x32;
            this.nbOpciones.Name = "nbOpciones";
            this.nbOpciones.Visible = false;
            this.nbOpciones.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem2_LinkClicked);
            // 
            // G6
            // 
            this.G6.Caption = "Reportes";
            this.G6.Expanded = true;
            this.G6.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbConfigurarReporte)});
            this.G6.Name = "G6";
            this.G6.Visible = false;
            // 
            // nbConfigurarReporte
            // 
            this.nbConfigurarReporte.Caption = "Configuración Reportes";
            this.nbConfigurarReporte.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbConfigurarReporte.ImageOptions.LargeImage")));
            this.nbConfigurarReporte.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbConfigurarReporte.ImageOptions.SmallImage")));
            this.nbConfigurarReporte.Name = "nbConfigurarReporte";
            this.nbConfigurarReporte.Visible = false;
            this.nbConfigurarReporte.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked_1);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Principal";
            this.barButtonItem1.Id = 205;
            this.barButtonItem1.ImageOptions.LargeImageIndex = 4;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // FSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 774);
            this.Controls.Add(this.dpMenu);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FSistema.IconOptions.Icon")));
            this.Name = "FSistema";
            this.Text = "PROCESOS JUDICIALES ELECTROPERU";
            this.Load += new System.EventHandler(this.FSistema_Load);
            this.Controls.SetChildIndex(this.RibbonPrincipal, 0);
            this.Controls.SetChildIndex(this.StatusBarPrincipal, 0);
            this.Controls.SetChildIndex(this.dpMenu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dpMenu.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vbcMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem bbiCerrarSesion;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dpMenu;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraNavBar.NavBarControl vbcMenu;
        private DevExpress.XtraNavBar.NavBarGroup G1;
        private DevExpress.XtraNavBar.NavBarGroup G2;
        private DevExpress.XtraNavBar.NavBarGroup G3;
        private DevExpress.XtraNavBar.NavBarGroup G4;
        private DevExpress.XtraNavBar.NavBarItem nbLocalidad;
        private DevExpress.XtraNavBar.NavBarItem nbDemandantesDemandados;
        private DevExpress.XtraNavBar.NavBarItem nbTipoContenido;
        private DevExpress.XtraNavBar.NavBarItem bnTipoProceso;
        private DevExpress.XtraNavBar.NavBarItem nbClaseProceso;
        private DevExpress.XtraNavBar.NavBarItem nbInstanciaJudicial;
        private DevExpress.XtraNavBar.NavBarItem nbSedeJudicial;
        private DevExpress.XtraNavBar.NavBarItem nbJuzgados;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraNavBar.NavBarItem nbExpedientes;
        private DevExpress.XtraNavBar.NavBarItem nbUsuarios;
        private DevExpress.XtraNavBar.NavBarItem nbOpciones;
        private DevExpress.XtraNavBar.NavBarGroup G5;
        private DevExpress.XtraNavBar.NavBarItem nbListadosExpedientes;
        private DevExpress.XtraNavBar.NavBarItem nbListadoAgendasJudiciales;
        private DevExpress.XtraNavBar.NavBarItem nbInformesTrimestrales;
        private DevExpress.XtraNavBar.NavBarItem nbAsesoresJuridicos;
        private DevExpress.XtraNavBar.NavBarItem nbTrabajadoresJudiciales;
        private DevExpress.XtraNavBar.NavBarItem nbSupervisorInterno;
        private DevExpress.XtraNavBar.NavBarItem nbContratos;
        private DevExpress.XtraNavBar.NavBarItem nbNotificaciones;
        private DevExpress.XtraNavBar.NavBarItem nbVariablesDeSistema;
        private DevExpress.XtraNavBar.NavBarGroup G6;
        private DevExpress.XtraNavBar.NavBarItem nbConfigurarReporte;
        private DevExpress.XtraNavBar.NavBarItem nbEstadoActual;
        private DevExpress.XtraNavBar.NavBarItem nbExpedientesArbitrales;
        private DevExpress.XtraNavBar.NavBarGroup G7;
        private DevExpress.XtraNavBar.NavBarItem nbMateriaControvertida;
        private DevExpress.XtraNavBar.NavBarItem nbSedeArbitral;
        private DevExpress.XtraNavBar.NavBarItem nbListadoArbitrajes;
        private DevExpress.XtraNavBar.NavBarItem nbEstadoActualActoProcesal;
    }
}