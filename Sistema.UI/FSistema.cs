using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Internal;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using Base.UI;
using Sistema.Model;
using Sistema.Model.Classes;
using Sistema.UI.Judicial;
using Sistema.UI.Usuario;
using Caudalosa.View.MUsuario;
using Sistema.UI.Persona;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.EntityClient;


namespace Sistema.UI
{
    public partial class FSistema : FPrincipal
    {
      

        public FSistema()
        {
            InitializeComponent();
            lbmHora.Caption = DateTime.Now.ToLongDateString() + " : " + DateTime.Now.ToLongTimeString();

            barButtonItem2.Caption = DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToLongTimeString();
            this.StatusBarPrincipal.Visible = false;

        }

        private void FSistema_Load(object sender, EventArgs e)
        {


            ConnectionStringSettings genusSettings = ConfigurationManager.ConnectionStrings["ContextoModelo"];
            if (genusSettings == null || string.IsNullOrEmpty(genusSettings.ConnectionString))
            {
                throw new Exception("Fatal error: Missing connection string 'Genus_Connection_String' in App.config file");
            }
            string genusConnectionString = genusSettings.ConnectionString;
            EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder(genusConnectionString);
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(entityConnectionStringBuilder.ProviderConnectionString);
            string genusSqlServerName = sqlConnectionStringBuilder.DataSource;
            string genusDatabaseName = sqlConnectionStringBuilder.InitialCatalog;
            string genusUser = sqlConnectionStringBuilder.UserID;
            string genusPwd = sqlConnectionStringBuilder.Password;

            //MessageBox.Show(genusUser);


            BaseR.BaseSession.FnInit_BaseSession(genusSqlServerName, genusUser, genusPwd);
            string sNombrePC = Environment.UserDomainName;
            fnGenerateMenuReports();
            if (sNombrePC != "eMe7")
            {
                FInicio form = new FInicio();
                form.MdiParent = this;
                form.Show();
            }
            GenerarMenu();
            lbmUsuario.Caption = "USUARIO : " + SesionActual.Usuario.Codigo.ToString();
            bbiCerrarSesion.Caption = "Cerrar sesión: " + SesionActual.Usuario.Codigo.ToString();

            //FMensajeProximaA fP = new FMensajeProximaA();
            //fP.ShowDialog();


            //FMensaje f = new FMensaje();
            //f.ShowDialog();

            ContextoModelo contexto = new ContextoModelo();
            var expedientes = contexto.Expediente.Where(x => x.FechaProximaAudiencia != null);
            if (expedientes.Count() > 0)
            {
               
                Control.clsMail.fnSendMail(expedientes.ToList());
               
            }



        }

        private void GenerarMenu()
        {
            List<Derecho> lDerechos = SesionActual.ListDerechos;
            List<Derecho> lDerecchoAll= new List<Derecho>();
            Derecho oD = lDerechos.Where(v => v.IdOpcion == 100).FirstOrDefault();
            if (oD != null)
            {
                ContextoModelo contexto = new ContextoModelo();
                var lOpAll = contexto.Opcion.Where(v => v.IdOpcion != 100);
                foreach (var item in lOpAll)
                {
                    var oDerec = new Derecho();
                    oDerec.IdUsuario = oD.IdUsuario;
                    oDerec.IdOpcion = item.IdOpcion;
                    oDerec.Derecho1 = oD.Derecho1;
                    oDerec.Opcion = item;
                    lDerecchoAll.Add(oDerec);

                }
                lDerechos = lDerecchoAll;
                SesionActual.ListDerechos = lDerecchoAll;
            }


            int indexE = 1;
            foreach (DevExpress.XtraNavBar.NavBarGroup gItem in vbcMenu.Groups)
            {
                Derecho ogDerecho = lDerechos.Where(x => x.Opcion.NroGrupo == gItem.Name.ToString()).FirstOrDefault();
                if (ogDerecho != null)
                {
                    gItem.Visible = true;
                    //if (indexE == 1)
                    //{
                    //    gItem.Expanded = true;
                    //    indexE = indexE + 1;
                    //}
                    if (gItem.Name.ToString() == "G3")
                    {
                        gItem.Expanded = true;
                        indexE = indexE + 1;
                    }
                    else
                    {
                        gItem.Expanded = false;
                    }
                }

                foreach (DevExpress.XtraNavBar.NavBarItemLink iItemLink in gItem.ItemLinks)
                {
                    DevExpress.XtraNavBar.NavBarItem oItem = iItemLink.Item;
                    string os = iItemLink.ItemName.ToString();
                    Derecho oDerecho = lDerechos.Where(x => x.Opcion.Nombre == oItem.Name).FirstOrDefault();
                    if (oDerecho != null)
                    {
                        iItemLink.Visible = true;
                        oItem.Visible = true;
                    }
                }
            }
        }

        private void FnOpcion(Type tipo, object oSender, string sTipo)
        {
            foreach (var item in this.MdiChildren)
            {
                if (sTipo == item.Name)
                {
                    item.Activate();
                    return;
                }
                else
                {
                    if (tipo.Name == item.Name)
                    {
                        item.Activate();
                        return;
                    }
                }
            }

            FBaseForm fForm = Activator.CreateInstance(tipo) as FBaseForm;
            DevExpress.XtraNavBar.NavElement oElement = (DevExpress.XtraNavBar.NavElement)oSender;
            Derecho oDerecho =
                SesionActual.ListDerechos.Where(x => x.Opcion.Nombre == oElement.Name.ToString()).FirstOrDefault();

            if (oDerecho != null)
            {
                if (oDerecho.Derecho1 == false)
                {
                    fForm.wbtnBorrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    fForm.wbtnEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    fForm.wbtnNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }

            if (sTipo != "")
            {
                fForm.Name = sTipo;
                fForm.Tag = sTipo;
                fForm.TipoInterno = sTipo;
            }
            fForm.MdiParent = this;

            fForm.Show();
        }

        private void FnOpcionConfigReporte(Type tipo, object oSender, string sTipo)
        {
            foreach (var item in this.MdiChildren)
            {
                if (sTipo == item.Name)
                {
                    item.Activate();
                    return;
                }
                else
                {
                    if (tipo.Name == item.Name)
                    {
                        item.Activate();
                        return;
                    }
                }
            }

            BaseR.FBaseForm fForm = Activator.CreateInstance(tipo) as BaseR.FBaseForm;
            DevExpress.XtraNavBar.NavElement oElement = (DevExpress.XtraNavBar.NavElement)oSender;
            Derecho oDerecho =
                SesionActual.ListDerechos.Where(x => x.Opcion.Nombre == oElement.Name.ToString()).FirstOrDefault();

            if (oDerecho != null)
            {
                if (oDerecho.Derecho1 == false)
                {
                    fForm.wbtnBorrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    fForm.wbtnEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    fForm.wbtnNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }

            if (sTipo != "")
            {
                fForm.Name = sTipo;
                fForm.Tag = sTipo;
                fForm.TipoInterno = sTipo;
            }
            fForm.MdiParent = this;

            fForm.Show();
        }

        private void FnOpenReporte(Type tipo, object oSender, string codigo)
        {
            foreach (var item in this.MdiChildren)
            {
                BaseR.FBaseReporte fOpen = item as BaseR.FBaseReporte;
                if (fOpen != null && tipo.Name == fOpen.Name && codigo == fOpen.Parametros2)
                {
                    item.Activate();
                    return;
                }
            }

            BaseR.FReporte fForm = Activator.CreateInstance(tipo) as BaseR.FReporte;
            fForm.Parametros2 = codigo;
           // DevExpress.XtraNavBar.NavElement oElement = (DevExpress.XtraNavBar.NavElement)oSender;
            fForm.MdiParent = this;

            fForm.Show();
        }

        private void nbLocalidad_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FLocalidad), sender, "");
        }

        private void nbEntidad_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FPersona), sender, "ODEMANDA");
        }

        private void nbTipoContenido_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FTipoContenido), sender, "TIPOCONTENIDO");
        }

        private void bnTipoProceso_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FTipoProceso), sender, "");
        }

        private void nbClaseProceso_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FClaseProceso), sender, "");
        }

        private void nbInstanciaJudicial_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FInstanciaJudicial), sender, "");
        }

        private void nbSalaJudicial_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FSedeJudicial), sender, "");
        }

        private void nbJuzgados_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FOrganoJudicial), sender, "");
        }

        private void nbExpedientes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FExpediente), sender, "");
        }

        private void bbiCerrarSesion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.ExitThread();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FOpciones), sender, "");
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FUsuarios), sender, "");
        }

        private void nbListadoAgendasJudiciales_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FRAgendaJudicial), sender, "");
        }

        private void nbListadosExpedientes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FRListadosExpedientes), sender, "");
        }

        private void nbInformesTrimestrales_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FRListadosTrimestrales), sender, "");
        }

        private void nbAsesoresJuridicos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FPersona), sender, "OASESORJURIDOCO");
        }

        private void nbTrabajadoresJudiciales_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FPersona), sender, "OTRABAJADORJURIDOCO");
        }

        private void nbSupervisorInterno_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FPersona), sender, "SUPERVISORINTERNO");
        }

        private void nbContratos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FPersona), sender, "CONTRATOS");

        }

        private void nbNOtificaciones_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FTipoContenido), sender, "NOTIFICACION");
        }

        private void nbVariablesDeSistema_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FTipoContenido), sender, "VARIABLES");
        }

        private void vbcMenu_Click(object sender, EventArgs e)
        {

        }

        private void navBarItem1_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcionConfigReporte(typeof(BaseR.FConfiguracion), sender, null);
        }

        private void navBarItem2_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpenReporte(typeof(BaseR.FReporte), sender, "01.01");
        }

        private void nbReporte2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpenReporte(typeof(BaseR.FReporte), sender, "02");
        }

        private void vbcMenu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DevExpress.XtraNavBar.NavBarLinkEventArgs nav = e;
            DevExpress.XtraNavBar.NavBarItem barItem = e.Link.Item;
            if(barItem.Name.Contains("nbReporte"))
            FnOpenReporte(typeof(BaseR.FReporte), sender, barItem.Tag.ToString());

        }

        private void fnGenerateMenuReports()
        {
            BaseR.ContextoReporte contextoR = new BaseR.ContextoReporte();
            List<BaseR.Reporte> reportes = contextoR.Reporte.ToList();

            foreach (var item in reportes)
            {
                DevExpress.XtraNavBar.NavBarItem nbRepor;
                nbRepor = new DevExpress.XtraNavBar.NavBarItem();
                //this.vbcMenu.Items.Add(this.nbReporte);
                nbRepor.Caption = item.Descripcion;
                //nbRepor.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbReporte.ImageOptions.SmallImage")));
                nbRepor.Name = "nbReporte_" + item.Codigo.ToString();
                nbRepor.ImageOptions.SmallImage= DevExpress.Images.ImageResourceCache.Default.GetImage("images/reports/report_32x32.png");
                nbRepor.Tag = item.Codigo;
                this.G6.ItemLinks.Add(nbRepor);
            }
            //this.G6.ItemLinks.add(new DevExpress.XtraNavBar.NavBarItemLink(this.nbReporte))
        }

        private void nbEstadoActual_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FTipoContenido), sender, "ESTADOSACTUALES");
        }

        private void nbExpedientesArbitrales_ItemChanged(object sender, EventArgs e)
        {
            FnOpcion(typeof(FExpedienteArbitrales), sender, "");
        }

        private void nbExpedientesArbitrales_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FExpedienteArbitrales), sender, "");
        }

        private void nbMateriaControvertida_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FTipoContenido), sender, "MATERIAEXARBITRAL");
        }

        private void nbSedeArbitral_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FSedeArbitral), sender, "");
        }

        private void nbListadoArbitrajes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FRListadosExpedientesArb), sender, "");
        }

        private void nbEstadoActualActoProcesal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FnOpcion(typeof(FTipoContenido), sender, "TIPOACTOPROCESALARB");
        }
    }
}