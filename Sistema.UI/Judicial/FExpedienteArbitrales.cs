using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base.UI;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraRichEdit.Commands;
using Ext;
using Sistema.Query;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraScheduler;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Sistema.Model.Classes;
using DevExpress.XtraGrid.Views.Base;
using System.Net;
using Sistema.GestionDeArchivos;
using Sistema.Services;
using Sistema.Services.Modelo;

namespace Sistema.UI.Judicial
{
    public partial class FExpedienteArbitrales : FBaseForm
    {


        private ExpedienteService ExpedienteService = new ExpedienteService();
        private ExpedienteInstanciaService ExpedienteInstanciaService = new ExpedienteInstanciaService();
        private DocumentoService DocumentoService = new DocumentoService();
        private PersonaService PersonaService = new PersonaService();
        private OrganoJudicialService OrganoJudicialService = new OrganoJudicialService();
        private Expediente EntidadExpediente;
        private ArchivoHerlper ArchivoHerlper = new ArchivoHerlper();
        private List<ExpedienteInstancia> lInstanciass = new List<ExpedienteInstancia>();
        private DocumentoService documentoService = new DocumentoService();
        private ModelosGeneralServices modelosService = new ModelosGeneralServices();
        private ViewExpedienteServices viewEntidadService = new ViewExpedienteServices();
        private ActoProcesalService actoProcesalService = new ActoProcesalService();
        private TipoContenidoServices tipoContenidoService = new TipoContenidoServices();
        private ActoProcesal actoProcesalModelo = new ActoProcesal();
        private PersonaEmpresa personaEmpresaModelo = new PersonaEmpresa();


        public FExpedienteArbitrales()
        {
            InitializeComponent();
            rbtnFechaInicio.EditValue = Convert.ToDateTime("01/01/" + DateTime.Now.Year);
            rbtnFechaFin.EditValue = DateTime.Now.ToShortDateString();
            this.Maximizado = true;
            DataLoad();
        }

        private void DataLoad()
        {
            DateTime ddFechaInicio = Convert.ToDateTime(Convert.ToDateTime(rbtnFechaInicio.EditValue).ToShortDateString());
            DateTime ddFechaFin = Convert.ToDateTime(Convert.ToDateTime(rbtnFechaFin.EditValue).ToShortDateString());
            bsLista.DataSource = viewEntidadService.BuscarFechaExpediente(ddFechaInicio, ddFechaFin);

            //Ctrls.Glue.FnGlueDemandanteEdit(IdDemandanteGridLookUpEdit, null);
            //Ctrls.Glue.FnGlueDemandadoEdit(IdDemandadoGridLookUpEdit, null);

            Ctrls.Glue.FnRpiGlueDemandanteEdit(rpiglueDemandante, null);
            Ctrls.Glue.FnRpiGlueDemandadoEdit(rpiglueDemandado, null);

            Ctrls.Glue.FnRpiGluePersonaAbogadosEdit(rpiEstudioAbogados, "OASESORJURIDOCO");

            Ctrls.Glue.FnGlueAbogadoEdit(IdAbogadoGridLookUpEdit, null, "OASESORJURIDOCO");
            Ctrls.Glue.FnGlueSupervisorInternoEdit(GLueIdSupervisor, null, "SUPERVISORINTERNO");


            //
            Ctrls.Glue.FnGlueArbitrosEdit(DescripcionTextEdit, null, "OASESORJURIDOCO");
            Ctrls.Glue.FnGlueArbitrosEdit(ObservacionTextEdit, null, "OASESORJURIDOCO");
            Ctrls.Glue.FnGlueArbitrosEdit(txtTercerArbitroAsignado, null, "OASESORJURIDOCO");

            Ctrls.Glue.FnGlueArbitrosEdit(glueSecretarioArbitral, null, "OASESORJURIDOCO");



            // Ctrls.Glue.FnGlueNotificacion(IdNotificacionGgridLookUpEdit, null);

            Ctrls.Glue.FnGlueSINO(glueArchivadoGridLookUpEdit1, null);

            Ctrls.Glue.FnGlueSedeJudicialDescripcion(LugarGridLookUpEdit, null);

            Ctrls.Glue.FnGlueTipoContingencia(glueTipoContingenciaGridLookUpEdit1, null);
            Ctrls.Glue.FnGlueCentroArbitral(glueCentroArbitral, null);

            Ctrls.Glue.FnGlueSedeArbitral(glueIdSedeArbitral);
            //Ctrls.Glue.FnRpiGlueTipoEstadoActual(EstadoActualgridLookUpEdit1);


            //Ctrls.Glue.FnGlueContratosEdit(glueContrato, null, "CONTRATOS"); //ix

            //Ctrls.Glue.FnGlueEstadoActualEdit(EstadoActualgridLookUpEdit1,null,null);//ix


            //////   Ctrls.Glue.FnRpiGlueTrabajadorJudicialEdit(rpiDemoPer, null);
            //glueUbicacion
            Ctrls.Glue.FnGlueTipoArbitraje(IdTipoProcesoGridLookUpEdit, null);

            Ctrls.Glue.FnGlueModalidad(glueModalidad, null);
            Ctrls.Glue.FnGlueUbicacion(glueUbicacion, null);

            //glueLaudoFavor
            Ctrls.Glue.FnGlueLaudoAFavor(glueLaudoFavor, null);


            //glueTipoMonedaCOntrovercia
            Ctrls.Glue.FnGlueTipoMoneda(glueTipoMonedaCOntrovercia, null);
            Ctrls.Glue.FnGlueTipoMoneda(glueTipoMonedaReconvencion, null);
            Ctrls.Glue.FnGlueTipoMoneda(glueTipoMonedaLaudado, null);


            Ctrls.Glue.FnGlueTipoContenidoEdit(IdClaseProcesoGridLookUpEdit, null, "MATERIAEXARBITRAL");


            ////Ctrls.Glue.FnGlueClaseProceso(GLueIdSupervisor, null);
            //Ctrls.Glue.FnRpiGlueInstancia(riglueInstancia);
            //Ctrls.Glue.FnRpiGlueSedeJudicial(riglueSalaJudiacial);
            //Ctrls.Glue.FnRpiGlueContratos(rpiContratos);//
            bsOrganoJudicialEdit.DataSource = OrganoJudicialService.ObtenerOrganoJudicial();
            //bsOrganoJudicialEdit.DataSource = ctxModelo().OrganoJudicial();
            bsTipoDoc.DataSource = Model.TipoDocumentoAdd.GLista();
            //Ctrls.Glue.FnRpiGlueOrganoJudicial(riglueOrganoJudiacial);
            //Ctrls.Glue.FnRpiGlueSalaJudicial(riglueSalaJudicialCC);
            lcgTabsEdicion.SelectedTabPage = lcgEstadoArbitral;


            Ctrls.Glue.FnRpiGluePersonaAbogados(rpiAbogadoPorEstudio, "ABOGADOS");
        }

        private void bsLista_CurrentChanged(object sender, EventArgs e)
        {
            if (bsLista.Current == null) return;
            viewExpediente oViewExpediente = (viewExpediente)bsLista.Current;
            bsEdicion.DataSource = ExpedienteService.BuscarPorExpediente(oViewExpediente.IdExpediente);
            //bsEdicion.DataSource = EntidadExpediente;

            bsInstanciaConsulta.DataSource = ExpedienteInstanciaService.BuscarInstancias(EntidadExpediente.IdExpediente);
            List<ActoProcesalContenido> items = new List<ActoProcesalContenido>();
            foreach (var item in EntidadExpediente.ActoProcesal)
                items.AddRange(item.ActoProcesalContenido);

            bsActos.DataSource = items;
            List<ExpedienteInstancia> itemsInsta = new List<ExpedienteInstancia>();
            List<ExpedienteInstancia> itemsInstaT = new List<ExpedienteInstancia>();
            foreach (var item in EntidadExpediente.ListaExpedienteInstancia)
            {
                itemsInsta.Add(item);
            }

            bsInstanciasExpediente.DataSource = itemsInsta;
            lInstanciass = EntidadExpediente.ListaExpedienteInstancia;

        }

        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
        //IX 

        public override void FnActionsBefreSave()
        {
            lcgTabsEdicion.SelectedTabPage = lcgDatosArbitrajes;
        }
        public override bool FnInicioValidar()
        {
            bool swValido = true;
            if (TipoEdicion == EnumEdicion.Nuevo)
            {

            }
            else
            {
                if (TipoEdicion == EnumEdicion.Editar || TipoEdicion == EnumEdicion.Borrar)
                {
                    viewExpediente oViewExpediente = (viewExpediente)bsLista.Current;
                    //if(oViewExpediente.UsuarioCrea!=null)
                    if (oViewExpediente.UsuarioCrea != SesionActual.Usuario.Codigo.ToString())
                    {
                        XtraMessageBox.Show("Solo puede editar el registro la persona que lo creó.\n Utilice la opc" +
                            "ión [Visualizar] ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        swValido = false;
                    }
                }
                else
                {
                    swValido = true;
                }
            }
            return swValido;
        }
        public override void FnEdicion()
        {

            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                bsInstanciasExpediente.DataSource = null;
                EntidadExpediente = new Expediente();
                EntidadExpediente.TipoExpediente = "EXPEDIENTEARBITRAL";
                EntidadExpediente.UsuarioCrea = SesionActual.Usuario.Codigo.ToString();
                bsEdicion.DataSource = EntidadExpediente;
            }
            else
            {

                viewExpediente oViewExpediente = (viewExpediente)bsLista.Current;

                EntidadExpediente = ExpedienteService.BuscarPorExpediente(oViewExpediente.IdExpediente);
                //EntidadExpediente = QExpediente.GlExpediente(DocumentoService.ctxModelo(), oViewExpediente.IdExpediente);
                EntidadExpediente.UsuarioModifica = SesionActual.Usuario.Codigo.ToString();
                bsEdicion.DataSource = EntidadExpediente;
            }

            if (EntidadExpediente.IdNEWID == null)
                EntidadExpediente.IdNEWID = Guid.NewGuid().ToString().ToUpper();

            bsDocumentos.DataSource = DocumentoService.BuscarPorEntidadExpediente(EntidadExpediente.IdNEWID);
            //bsDocumentos.DataSource = DocumentoService.ctxModelo().Documento.Where(x => x.IdNEWID == EntidadExpediente.IdNEWID);
            lcgTabsEdicion.SelectedTabPage = lcgDatosArbitrajes;
            System.Threading.Thread.Sleep(10);
            lcgTabsEdicion.SelectedTabPage = lcgDatosGenerales;
        }
        public bool Nuevo()
        {

            lcgTabsEdicion.SelectedTabPage = lcgDatosArbitrajes;
            try
            {
                EntidadExpediente.FechaEdicion = DateTime.Now;
                ExpedienteService.AgregarExpediente(EntidadExpediente);
                if (bsDocumentos.Count > 0)
                {


                    List<Documento> documentos = (bsDocumentos.DataSource as ObjectQuery<Documento>).ToList();

                    foreach (Documento documento in documentos)
                    {

                        string nombreRuta = ArchivoHerlper.CrearRutaArchivo(documento.Nombre, documento.IdNEWID, Archivo.TipoDeArchivo.ExpedientesArbitrales);
                        documento.RutaPc = nombreRuta;
                        // guarda bd
                        DocumentoService.AgregarDocumento(documento);
                         // crea archivo 
                        ArchivoHerlper.CrearArchivo(nombreRuta);
                         
                    }

                    // se guardo la todo bd
                    DocumentoService.Guardar();
                  
                }

                DocumentoService.Guardar();


                return true;
            }
            catch (Exception ex)
            {


                return false;
            }
        }

        public bool Editar()
        {

            try
            {
                EntidadExpediente.FechaEdicion = DateTime.Now;

                ExpedienteService.AgregarExpediente(EntidadExpediente);
                List<Documento> documentos = (bsDocumentos.DataSource as ObjectQuery<Documento>).ToList();

                foreach (Documento documento in documentos)
                {

                    string nombreRuta = ArchivoHerlper.CrearRutaArchivo(documento.Nombre, documento.IdNEWID, Archivo.TipoDeArchivo.ExpedientesArbitrales);
                    documento.RutaPc = nombreRuta;
                    // guarda bd
                    DocumentoService.AgregarDocumento(documento);
                    // crea archivo 
                    ArchivoHerlper.CrearArchivo(nombreRuta);

                }

                // se guardo la todo bd
                DocumentoService.Guardar();


                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public bool Borrar()
        {
           
            try
            {
                ExpedienteService.BorrarExpediente(EntidadExpediente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    
        public override void FnLimpiar() {

            DateTime ddFechaInicio =
               Convert.ToDateTime(Convert.ToDateTime(rbtnFechaInicio.EditValue).ToShortDateString());
            DateTime ddFechaFin = Convert.ToDateTime(Convert.ToDateTime(rbtnFechaFin.EditValue).ToShortDateString());
            bsLista.DataSource = viewEntidadService.BuscarFechaExpediente(ddFechaInicio, ddFechaFin);
        }
        public override bool FnGrabar()
        {
            bool resultado = false;
            lcgTabsEdicion.SelectedTabPage = lcgDatosArbitrajes;
            if (TipoEdicion == EnumEdicion.Borrar)
            {
                resultado = Borrar();
            }

            bsEdicion.EndEdit();
           
            if (TipoEdicion == EnumEdicion.Nuevo || TipoEdicion == EnumEdicion.Editar)
            {

              
                Expediente oExpediente = (Expediente)bsEdicion.Current;
                oExpediente.FechaEdicion = DateTime.Now;
                bool bError = false;

                if (oExpediente.IdSupervisorInterno != null)
                {
                    int IdSupervisor = (int)oExpediente.IdSupervisorInterno;
                    foreach (var item in oExpediente.ListaExpedienteAsesorLegal)
                    {
                        if (IdSupervisor == item.IdAsesorLegalAbogado || IdSupervisor == item.IdAsesorLegalEstudio)
                        {
                            bError = true;
                            break;
                        }
                    }

                    if (bError)
                    {
                        XtraMessageBox.Show("No puede ser la misma persona el Asesor Legar y Supervisor Interno. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }

                if (oExpediente.ListaOrganoExpedienteDemandante.Count > 0)
                {
                    oExpediente.IdDemandante = oExpediente.ListaOrganoExpedienteDemandante.FirstOrDefault().IdDemandante;
                    string sNombres = "";
                    int iNroRows = oExpediente.ListaOrganoExpedienteDemandante.Count();
                    int iIndex = 1;

                    foreach (OrganoExpedientePersona item in oExpediente.ListaOrganoExpedienteDemandante)
                    {
                        sNombres = sNombres + item.DemandanteExpediente.Nombre.ToUpper();
                        if (iIndex < iNroRows)
                            sNombres = sNombres + ", ";
                        iIndex = iIndex + 1;
                    }
                    oExpediente.NDemandantes = sNombres;
                }

                else
                {
                    //cambio fio
                    oExpediente.IdDemandante = 0;
                    oExpediente.NDemandantes = "";
                }


                if (oExpediente.ListaOrganoExpedienteDemandado.Count > 0)
                {
                    oExpediente.IdDemandado = oExpediente.ListaOrganoExpedienteDemandado.FirstOrDefault().IdDemandado;

                    string sNombres = "";
                    int iNroRows = oExpediente.ListaOrganoExpedienteDemandado.Count();
                    int iIndex = 1;

                    foreach (OrganoExpedientePersona item in oExpediente.ListaOrganoExpedienteDemandado)
                    {
                        sNombres = sNombres + item.DemandadoExpediente.Nombre.ToUpper();
                        if (iIndex < iNroRows)
                            sNombres = sNombres + ", ";
                        iIndex = iIndex + 1;
                    }
                    oExpediente.NDemandados = sNombres;
                }

                else
                {
                    //cambio fio
                    oExpediente.IdDemandado = 0;
                    oExpediente.NDemandados = "";
                }

                List<Expediente> lExpedienteExis = ExpedienteService.ListarPorDemandante(oExpediente.IdDemandante);
                
                if (lExpedienteExis.Count > 0 && TipoEdicion == EnumEdicion.Nuevo)
                {
                    var oMail = new Control.clsMail();
                    oMail.FnMail_DemandasExistentes(oExpediente.NDemandantes, lExpedienteExis);
                }


                if (TipoEdicion == EnumEdicion.Nuevo)
                {
                    resultado = Nuevo();
                }
                else if (TipoEdicion == EnumEdicion.Editar)
                {
                    resultado = Editar();
                }

            }
            return resultado;

        }


        public override void FnCancelar()
        {
            if (TipoEdicion == EnumEdicion.Nuevo) bsEdicion.RemoveCurrent();
            bsEdicion.CancelEdit();
        }

        public override void FnImprimir()
        {
            PrintPreviewRibbonFormEx pViewEx = new PrintPreviewRibbonFormEx();
            pViewEx.PrintingSystem = printingSystem1;
            printableComponentLink1.CreateDocument();
            pViewEx.PrintingSystem.PageSettings.Landscape = true;
            pViewEx.Show();
        }

        private void btnAddActoProcesal_Click(object sender, EventArgs e)
        {
            AgregarActoProcesal();
        }

        private void AgregarActoProcesal()
        {
            string sContenido = "";
            ActoProcesal oProcesal = actoProcesalService.BuscarActoProcesalPorId(EntidadExpediente.IdExpediente);

            if (oProcesal != null)
                sContenido = oProcesal.Contenido;


            if (TipoEdicion == EnumEdicion.Nuevo)
            {
            }

            ActoProcesal oActoProcesal = new ActoProcesal();
            EntidadExpediente.ActoProcesal.Add(oActoProcesal);
            int xx = 0;
            //foreach (var item in EntidadExpediente.ExpedienteInstancia)
            //{
            //    lInstanciass.ElementAt(xx).InstanciaJudicial = siModelo.InstanciaJudicial.FirstOrDefault(x => x.IdInstancia == item.IdInstancia);
            //}ESTO NO

            FActoProcesalArbitralEdit fActoProcesalE = new FActoProcesalArbitralEdit(actoProcesalModelo ,sContenido);
            fActoProcesalE.ShowDialog();

            //FActoProcesalArbitralEdit fActoProcesalE = new FActoProcesalArbitralEdit(oActoProcesal, DocumentoService.ctxModelo(),
            //    "", sContenido, lInstanciass);
            //fActoProcesalE.ShowDialog();

            List<ActoProcesalContenido> items = new List<ActoProcesalContenido>();
            foreach (var item in EntidadExpediente.ActoProcesal)
                items.AddRange(item.ActoProcesalContenido);
            bsActos.DataSource = items;
        }

        private void btnAddE_Click(object sender, EventArgs e)
        {
            EditarActoProcesal();
        }

        private void EditarActoProcesal()
        {
            ActoProcesal oActoProcesal = ((ActoProcesalContenido)bsActos.Current).actoProcesal;
            EntidadExpediente.ActoProcesal.Add(oActoProcesal);


            //FActoProcesalArbitralEdit fActoProcesalE = new FActoProcesalArbitralEdit(oActoProcesal, DocumentoService.ctxModelo(),
             //   "", "E", lInstanciass);
           // fActoProcesalE.ShowDialog();
            List<ActoProcesalContenido> items = new List<ActoProcesalContenido>();
            foreach (var item in EntidadExpediente.ActoProcesal)
                items.AddRange(item.ActoProcesalContenido);
            bsActos.DataSource = items;
        }
        private void btnMostrarArchivo_Click(object sender, EventArgs e)
        {
            ActoProcesal oActoProcesal = ((ActoProcesalContenido)bsActos.Current).actoProcesal;
            MostrarArchivoGlobal(oActoProcesal.IdNEWID);
        }

        private void MostrarArchivoGlobal(string idNEWID)
        {
            
            Documento oFile = documentoService.BuscarDocumentoPorExpediente(idNEWID);
            if (oFile == null)
            {
                MessageBox.Show("Error: No contiene Ningun Archivo.");
                return;
            }

            if (oFile.Documento1 == null)
            {
                MessageBox.Show("Error: No contiene Ningun Archivo.");
                return;
            }
            Ext.ExtFile.MostrarDocumentoCreado(oFile.Documento1, oFile.Nombre + oFile.Extension);
        }

        private void ribtnShow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show("Error: No contiene Ningun Archivo.");
            ActoProcesal oActoProcesal = ((ActoProcesalContenido)bsActos.Current).actoProcesal;
            
            Documento oFile = documentoService.BuscarDocumentoPorExpediente(oActoProcesal.IdNEWID);

            if (oFile == null)
            {
                MessageBox.Show("Error: No contiene Ningun Archivo.");
                return;
            }

            if (oFile.Documento1 == null)
            {
                MessageBox.Show("Error: No contiene Ningun Archivo.");
                return;
            }

            Ext.ExtFile.MostrarDocumentoCreado(oFile.Documento1, oFile.Nombre + oFile.Extension);
        }

        private void ribtnShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error: No contiene Ningun Archivo.");
        }

        private void gridView1_PopupMenuShowing(object sender,
            DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.Point);
            if (hitInfo.InRowCell)
            {
                gridView1.FocusedRowHandle = hitInfo.RowHandle;
                popMenu.ShowPopup(MousePosition);
            }
        }

        private void rbtnAddActoProce_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnAddActoProcesal_Click(sender, e);
        }

        private void gridView2_PopupMenuShowing(object sender,
            DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.Point);
            if (hitInfo.InRowCell)
            {
                gridView1.FocusedRowHandle = hitInfo.RowHandle;
                popMenuActos.ShowPopup(MousePosition);
            }
        }

        private void rbtnEditarActo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnAddE_Click(sender, e);
        }

        private void rbtnVerAdjuntoActo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnMostrarArchivo_Click(sender, e);
        }

        private void rbtnMostrarDatosAdjuntosExp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            MostrarArchivoGlobal(EntidadExpediente.IdNEWID);
        }

        private void btnAdjuntarArchivo_Click(object sender, EventArgs e)
        {
            if (this.ofdAll.ShowDialog() == DialogResult.Cancel)
                return;
            string sRuta = ofdAll.FileName;

            //    txtRutaFile.Text = sRuta;
            Documento oDocumento;

            if (EntidadExpediente.IdNEWID == null)
            {
                oDocumento = new Documento();
                oDocumento.IdNEWID = Guid.NewGuid().ToString().ToUpper();
                EntidadExpediente.IdNEWID = oDocumento.IdNEWID;
                DocumentoService.AgregarDocumento(oDocumento);
            }

            else
            {
                oDocumento = DocumentoService.BuscarPorEntidadExpediente(EntidadExpediente.IdNEWID);
            }

            oDocumento.Nombre = Path.GetFileNameWithoutExtension(sRuta);
            oDocumento.Documento1 = ExtFile.FileToBits(sRuta);
            oDocumento.Extension = Path.GetExtension(sRuta);
        }

        private void btnMortrarArchivoGrid_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MostrarArchivoGlobal(EntidadExpediente.IdNEWID);
        }

        private void btnMortrarArchivoGrid_Click(object sender, EventArgs e)
        {
            MostrarArchivoGlobal(EntidadExpediente.IdNEWID);
        }

        private void btnMortrarArchivoGrid_ButtonPressed(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MostrarArchivoGlobal(EntidadExpediente.IdNEWID);
        }

        private void riglueBuscarArchivo_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //int iIndex = layoutView1.GetSelectedRows()[0];
            //ExpedienteInstancia oInstancia = (ExpedienteInstancia)layoutView1.GetRow(iIndex);
            //DevExpress.XtraEditors.ButtonEdit oButtonEdit =
            //    (DevExpress.XtraEditors.ButtonEdit)sender;

            if (this.ofdAll.ShowDialog() == DialogResult.Cancel)
                return;
            string sRuta = ofdAll.FileName;

            //oButtonEdit.Text = sRuta;
            //oButtonEdit.Text = sRuta;
            //Documento oDocumento;

            //if (oInstancia.IdNEWID == null)
            //{
            //    oDocumento = new Documento();
            //    oDocumento.IdNEWID = Guid.NewGuid().ToString().ToUpper();
            //    oInstancia.IdNEWID = oDocumento.IdNEWID;
            //    CtxModelo.AddToDocumento(oDocumento);
            //}
            //else
            //{
            //    oDocumento = CtxModelo.Documento.Where(x => x.IdNEWID == oInstancia.IdNEWID).FirstOrDefault();
            //}

            //oDocumento.Nombre = Path.GetFileNameWithoutExtension(sRuta);
            //oDocumento.Documento1 = ExtFile.FileToBits(sRuta);
            //oDocumento.Extension = Path.GetExtension(sRuta);
        }

        private void ribtnMostrarArchivoInstancia_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            //int iIndex = layoutView1.GetSelectedRows()[0];
            //ExpedienteInstancia oInstancia = (ExpedienteInstancia)layoutView1.GetRow(iIndex);
            //MostrarArchivoGlobal(oInstancia.IdNEWID);
        }
        private void ribtnCargarDOC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://");
            //request.Method = WebRequestMethods.Ftp.UploadFile;
            //request.Credentials = new NetworkCredential("", "");
            //using (FileStream fileStream = File.Open("testfile.txt", FileMode.Open, FileAccess.Read))
            //{
            //    using (Stream requestStream = request.GetRequestStream())
            //    {
            //        await fileStream.CopyToAsync(requestStream);
            //        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            //        {
            //            Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            //        }
            //    }
            //}
            string sPc = System.Net.Dns.GetHostName();

            TipoContenido tipoContenido = tipoContenidoService.BuscarTipoContenido(sPc);
            if (tipoContenido == null) tipoContenido = tipoContenidoService.ReemplazarNombre();
            if (tipoContenido != null)
            {
                this.ofdAll.InitialDirectory = tipoContenido.Descripcion.ToString();
            }

            if (this.ofdAll.ShowDialog() == DialogResult.Cancel)
                return;

            //string sRuta = ofdAll.FileName;

            string[] files = ofdAll.FileNames;
            if (files.Count() == 0) return;
            if (gridView3.FocusedRowHandle < 0)
            {
                Documento oFileInsert;
                if (gridView3.DataRowCount > 0)
                {
                     oFileInsert = (Documento)bsDocumentos.Current;
                }
                else {

                    oFileInsert =  new Documento();
                }

              

                foreach (var item in files)
                {

                    if (EntidadExpediente.IdNEWID == null)
                    {
                        EntidadExpediente.IdNEWID = Guid.NewGuid().ToString().ToUpper();
                    }


                    bsDocumentos.Add(new Documento());
                    bsDocumentos.MoveLast();

                    //    txtRutaFile.Text = sRuta;
                    ((Documento)bsDocumentos.Current).Tipo = oFileInsert.Tipo;
                    ((Documento)bsDocumentos.Current).IdNEWID = EntidadExpediente.IdNEWID;
                    ((Documento)bsDocumentos.Current).Nombre = Path.GetFileNameWithoutExtension(item);
                    ((Documento)bsDocumentos.Current).Documento1 = ExtFile.FileToBits(item);
                    ((Documento)bsDocumentos.Current).Extension = Path.GetExtension(item);
                    ((Documento)bsDocumentos.Current).RutaPc = item;
                    bsDocumentos.Remove(oFileInsert);
                }


            }
            else
            {
                XtraMessageBox.Show("Se actualizara un solo archivo. ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((Documento)bsDocumentos.Current).IdNEWID = EntidadExpediente.IdNEWID;
                ((Documento)bsDocumentos.Current).Nombre = Path.GetFileNameWithoutExtension(files[0]);
                ((Documento)bsDocumentos.Current).Documento1 = ExtFile.FileToBits(files[0]);
                ((Documento)bsDocumentos.Current).Extension = Path.GetExtension(files[0]);
                ((Documento)bsDocumentos.Current).RutaPc = files[0];

            }
            //    txtRutaFile.Text = sRuta;

            //if (gridView3.FocusedRowHandle > 0)
            //{
            //    XtraMessageBox.Show("Elija la opción de carga individual de archivos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }

        private void ribtnShowDOC_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void ribtnShowDOC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Documento oFile = (Documento)bsDocumentos.Current;
            if (oFile == null)
            {
                MessageBox.Show("Error: No contiene Ningun Archivo.");
                return;
            }

            if (oFile.Documento1 == null)
            {
                MessageBox.Show("Error: No contiene Ningun Archivo.");
                return;
            }
            Ext.ExtFile.MostrarDocumentoCreado(oFile.Documento1, oFile.Nombre + oFile.Extension);
        }

        private void rbtnFechaInicio_EditValueChanged(object sender, EventArgs e)
        {
            CargarDatosFecha();
        }

        private void CargarDatosFecha()
        {
            DateTime ddFechaInicio =
                Convert.ToDateTime(Convert.ToDateTime(rbtnFechaInicio.EditValue).ToShortDateString());
            DateTime ddFechaFin = Convert.ToDateTime(Convert.ToDateTime(rbtnFechaFin.EditValue).ToShortDateString());
            bsLista.DataSource = viewEntidadService.BuscarFechaExpediente(ddFechaInicio, ddFechaFin);
        }

        private void rbtnFechaFin_EditValueChanged(object sender, EventArgs e)
        {
            CargarDatosFecha();
        }

        private void btnReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bsLista.Current == null) return;
            viewExpediente oViewExpediente = (viewExpediente)bsLista.Current;
            EntidadExpediente = ExpedienteService.BuscarPorExpediente(oViewExpediente.IdExpediente);
            //EntidadExpediente = QExpediente.GlExpediente(DocumentoService.ctxModelo(), oViewExpediente.IdExpediente);

            RExpedienteDetalleArbitral rpDetalle = new RExpedienteDetalleArbitral(EntidadExpediente);
            rpDetalle.ShowPreview();

        }

        private void GLueIdSupervisor_EditValueChanged(object sender, EventArgs e)
        {
            if (glueTipoContingenciaGridLookUpEdit1.EditValue == null) return;
            if (glueTipoContingenciaGridLookUpEdit1.EditValue.ToString() == "") return;

            string sTipoConti = glueTipoContingenciaGridLookUpEdit1.EditValue.ToString();
            if (sTipoConti == "Probable") ItemForMontoDolares.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else ItemForMontoDolares.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void rbtnCargarFolder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string sPc = System.Net.Dns.GetHostName();
            TipoContenido tipoContenido = tipoContenidoService.BuscarTipoContenido(sPc);
            if (tipoContenido == null) tipoContenido = tipoContenidoService.ReemplazarNombre();
            if (tipoContenido != null)
            {
                this.folderDialog1.SelectedPath = tipoContenido.Descripcion.ToString();
            }

            if (this.folderDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string sRuta = folderDialog1.SelectedPath;

            string[] files = null;

            if (Directory.Exists(sRuta))
            {
                files = Directory.GetFiles(sRuta, @"*.*", SearchOption.TopDirectoryOnly);
            }

            if (files.Count() == 0) return;


            if (gridView3.FocusedRowHandle > 0)
            {
                XtraMessageBox.Show("Elija la opción de carga individual de archivos. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var item in files)
            {

                if (EntidadExpediente.IdNEWID == null)
                {
                    EntidadExpediente.IdNEWID = Guid.NewGuid().ToString().ToUpper();
                }
                bsDocumentos.Add(new Documento());
                bsDocumentos.MoveLast();

                //    txtRutaFile.Text = sRuta;

                ((Documento)bsDocumentos.Current).IdNEWID = EntidadExpediente.IdNEWID;
                ((Documento)bsDocumentos.Current).Nombre = Path.GetFileNameWithoutExtension(item);
                ((Documento)bsDocumentos.Current).Documento1 = ExtFile.FileToBits(item);
                ((Documento)bsDocumentos.Current).Extension = Path.GetExtension(item);
                ((Documento)bsDocumentos.Current).RutaPc = item;
            }
        }

        private void IdAbogadoGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            IdAbogadoPatrocinanteGgridLookUpEdit.Properties.DataSource = null;

            GridLookUpEdit oEdit = sender as GridLookUpEdit;
            int iID = 0;
            if (oEdit.EditValue != null)
            {
                if (int.TryParse(oEdit.EditValue.ToString(), out iID))
                {
                    iID = (int)oEdit.EditValue;
                }
            }

            if (iID != 0)
            {
                Ctrls.Glue.FnGluePersonasByIDEmpresa(IdAbogadoPatrocinanteGgridLookUpEdit, null, iID);

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            ExpedienteInstancia oActoProcesal = new ExpedienteInstancia();
            EntidadExpediente.ListaExpedienteInstancia.Add(oActoProcesal);

            //FExpedienteInstancia fActoProcesalE = new FExpedienteInstancia(oActoProcesal, DocumentoService.ctxModelo());
            //fActoProcesalE.ShowDialog();

            //foreach (var item in EntidadExpediente.ExpedienteInstancia)
            //{
            //    var od = item.InstanciaJudicial.Descripcion;
            //    var of = item.OrganoJudicial.Descripcion;
            //}esto no

            bsInstanciasExpediente.DataSource = EntidadExpediente.ListaExpedienteInstancia;
            lInstanciass = EntidadExpediente.ListaExpedienteInstancia;

            //

        }

        private void btnEditInstancia_Click(object sender, EventArgs e)
        {
            ExpedienteInstancia oExpedienteInstancia = ((ExpedienteInstancia)bsInstanciasExpediente.Current);
            EntidadExpediente.ListaExpedienteInstancia.Add(oExpedienteInstancia);

            //FExpedienteInstancia fActoProcesalE = new FExpedienteInstancia(oExpedienteInstancia, DocumentoService.ctxModelo());
            //fActoProcesalE.ShowDialog();

            bsInstanciasExpediente.DataSource = EntidadExpediente.ListaExpedienteInstancia;
            lInstanciass = EntidadExpediente.ListaExpedienteInstancia;
        }

        private void btnAddActo_Click(object sender, EventArgs e)
        {
            AgregarActoProcesal();
        }

        private void btnEditarActo_Click(object sender, EventArgs e)
        {
            EditarActoProcesal();
        }

        private void OrganoExpedienteDemandanteGridControl_Click(object sender, EventArgs e)
        {

        }
        private void IdNotificacionGgridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (IdNotificacionGgridLookUpEdit.EditValue == null) return;
            //if (IdNotificacionGgridLookUpEdit.EditValue.ToString() == "") return;
            //var f = IdNotificacionGgridLookUpEdit.EditValue.ToString();
            //int iID = (int)IdNotificacionGgridLookUpEdit.EditValue;

            //var tipoC = CtxModelo.TipoContenido.Where(d => d.IdTipoContenido == iID).FirstOrDefault();
            //if (tipoC.Titulo == "CASILLA ELECTRONICA") lycNrocasilla.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //else lycNrocasilla.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }

        private void rpiglueDemandante_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit oEdit = sender as GridLookUpEdit;
            int iID = 0;
            if (oEdit.EditValue != null) iID = (int)oEdit.EditValue;
            if (iID != 0)
            {               
                PersonaEmpresa personaEmpresa = PersonaService.BuscarPersona(iID);
                (rpiglueDemandante.DataSource as List<PersonaEmpresa>).Add(personaEmpresa);
            }
        }

        private void rpiglueDemandado_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit oEdit = sender as GridLookUpEdit;
            int iID = 0;
            if (oEdit.EditValue != null) iID = (int)oEdit.EditValue;
            if (iID != 0)
            {
                PersonaEmpresa personaEmpresa = PersonaService.BuscarPersona(iID);
                (rpiglueDemandado.DataSource as List<PersonaEmpresa>).Add(personaEmpresa);
            }
        }

        private void ribtnEliminarFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            Documento oFile = (Documento)bsDocumentos.Current;
            bsDocumentos.Remove(oFile);

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            TipoEdicion = EnumEdicion.Visualizar;
            FnMostrar(TipoEdicion);
        }

        private void rpiAbogadoPorEstudio_QueryPopUp(object sender, CancelEventArgs e)
        {
            //if (EntidadExpediente.ExpedienteAsesorLegal.LastOrDefault() == null) return;

            //ExpedienteAsesorLegal expedienteAsesorLegal = (ExpedienteAsesorLegal)EntidadExpediente.ExpedienteAsesorLegal.LastOrDefault();
            //Ctrls.Glue.FnRpiGluePersonaAbogadosPorEstudio(rpiAbogadoPorEstudio, "ABOGADOS", Convert.ToInt32(expedienteAsesorLegal.IdAsesorLegalEstudio));
        }

        private void gridView11_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.RowHandle < 0 && e.Column.Name == "colIdAsesorLegalEstudio")
            //{
            //    DevExpress.XtraGrid.Views.Grid.GridView dView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            //    GridLookUpEdit glueGrid = (GridLookUpEdit)dView.ActiveEditor;
            //    if (glueGrid.EditValue == null) return;

            //    ExpedienteAsesorLegal oDetalleN = (ExpedienteAsesorLegal)gridView11.GetRow(e.RowHandle);
            //    if (oDetalleN == null) return;

            //    // Ctrls.Glue.FnRpiGluePersonaAbogadosPorEstudio(rpiAbogadoPorEstudio, "ABOGADOS", Convert.ToInt32(expedienteAsesorLegal.IdAsesorLegalEstudio));


            //    //ActividadClaseCosto oActividadClaseCosto =
            //    //    (ActividadClaseCosto)rpiActividadE.GetRowByKeyValue(glueGrid.EditValue);
            //    //ActividadClaseDetalle oClaseDetalle = oActividadClaseCosto.ActividadClaseDetalle;
            //    //PartidaCosto oPartida = (PartidaCosto)bsLista.Current;
            //    //foreach (ActividadClaseCosto item in oClaseDetalle.ActividadClaseCosto)
            //    //{
            //    //    PartidaCostoDetalle oPartidaCostoDetalle = new PartidaCostoDetalle();
            //    //    oPartidaCostoDetalle.IdActividad = oClaseDetalle.IdActoActividad;
            //    //    oPartidaCostoDetalle.IdActividadClaseDetalle = oClaseDetalle.ID;
            //    //    oPartidaCostoDetalle.IdActividadClaseCosto = item.ID;
            //    //    oPartidaCostoDetalle.IdCatalogoTipoCosto = item.IdCatalogoTipoCosto;
            //    //    oPartidaCostoDetalle.IdTipoCosto = item.CatalogoTipoCosto.IdTipoCosto;
            //    //    oPartidaCostoDetalle.Costo = 0;
            //    //    oPartidaCostoDetalle.Cantidad = 1;
            //    //    oPartidaCostoDetalle.Total = 0;
            //    //    oPartidaCostoDetalle.Porcentaje = 0;
            //    //    oPartidaCostoDetalle.TasaIndicador = oPartida.Metrado / oPartidaCostoDetalle.Cantidad;
            //    //    oPartida.PartidaCostoDetalle.Add(oPartidaCostoDetalle);


            //}
            ////                SalidaMaterialDetalle oDetalle = (SalidaMaterialDetalle)gridViewDetalles.GetRow(e.RowHandle);
            //                oDetalle.Material = oMaterial;
            //                gridViewDetalles.SelectCell(e.RowHandle, colCantidadSolicitada);
            //                gridLookUpEdit1.Properties.GetRowByKeyValue(gridLookUpEdit1.EditValue)
            //                AsociacionGrupoMuestra oAsoTEM = (AsociacionGrupoMuestra)glueCodigo.GetSelectedDataRow();
            // gvDetalle.EndUpdate();
            //                oPartida.PartidaCostoDetalle.Remove(oDetalleN);
        }

        private void gridView11_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            //if (e.RowHandle < 0 && e.Column.Name == "colIdAsesorLegalAbogado")
            //{
            //    DevExpress.XtraGrid.Views.Grid.GridView dView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            //    GridLookUpEdit glueGrid = (GridLookUpEdit)dView.ActiveEditor;
            //    if (glueGrid == null) return;
            //    if (glueGrid.EditValue == null) return;
            //}
        }

        private void gridView11_ShownEditor(object sender, EventArgs e)
        {
            //var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            //if (view.FocusedColumn.FieldName == "IdAsesorLegalAbogado" && view.ActiveEditor is LookUpEdit)
            //{
            //    // GET SELECTED DATAROW OF LookupEdit City here  

            //    //DataRow row = view.GetDataRow(view.FocusedRowHandle);
            //    //var edit = (LookUpEdit)view.ActiveEditor;
            //    //this.stratenBindingSource.DataSource = GisServiceAgent.GetStraten();
            //    //edit.Properties.DataSource = this.stratenBindingSource;
            //}
        }

        private void rpiAbogadoPorEstudio_Popup(object sender, EventArgs e)
        {
            GridLookUpEditBase edit = sender as GridLookUpEditBase;
            ColumnView view = edit.Properties.View;
            int countryCode = Convert.ToInt32(gridView11.GetFocusedRowCellValue("IdAsesorLegalEstudio"));
            view.ActiveFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[IdEmpresa] == ?", countryCode)  ;
        }
    }
}
