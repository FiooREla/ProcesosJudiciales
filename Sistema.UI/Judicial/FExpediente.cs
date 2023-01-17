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
using Sistema.Model;
using Sistema.Query;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraScheduler;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sistema.UI.Judicial
{
    public partial class FExpediente : FBaseForm
    {
        private ContextoModelo CtxModelo = new ContextoModelo();
        private ContextoModelo Ctx = new ContextoModelo();
        private ContextoModelo ctxModeloDOC = new ContextoModelo();

        private Expediente EntidadExpediente;

        private EntityCollection<ExpedienteInstancia> lInstanciass = new EntityCollection<ExpedienteInstancia>();

        public FExpediente()
        {
            InitializeComponent();
            rbtnFechaInicio.EditValue = Convert.ToDateTime("01/01/" + DateTime.Now.Year);
            rbtnFechaFin.EditValue = DateTime.Now.ToShortDateString();

            DataLoad();
        }

        private void DataLoad()
        {
            DateTime ddFechaInicio =
                Convert.ToDateTime(Convert.ToDateTime(rbtnFechaInicio.EditValue).ToShortDateString());
            DateTime ddFechaFin = Convert.ToDateTime(Convert.ToDateTime(rbtnFechaFin.EditValue).ToShortDateString());

            bsLista.DataSource =
                CtxModelo.viewExpediente.Where(x => x.FechaInicio >= ddFechaInicio && x.FechaInicio <= ddFechaFin && x.TipoExpediente=="EXPEDIENTE");

            //Ctrls.Glue.FnGlueDemandanteEdit(IdDemandanteGridLookUpEdit, null);
            //Ctrls.Glue.FnGlueDemandadoEdit(IdDemandadoGridLookUpEdit, null);

            Ctrls.Glue.FnRpiGlueDemandanteEdit(rpiglueDemandante, null);
            Ctrls.Glue.FnRpiGlueDemandadoEdit(rpiglueDemandado, null);

            Ctrls.Glue.FnRpiGluePersonaAbogados(rpiEstudioAbogados, "OASESORJURIDOCO");
            Ctrls.Glue.FnRpiGluePersonaAbogados(rpiAbogadoPorEstudio, "ABOGADOS");
            Ctrls.Glue.FnGlueAbogadoEdit(IdAbogadoGridLookUpEdit, null, "OASESORJURIDOCO");
            Ctrls.Glue.FnGlueSupervisorInternoEdit(GLueIdSupervisor, null, "SUPERVISORINTERNO");

           

            
            Ctrls.Glue.FnGlueNotificacion(IdNotificacionGgridLookUpEdit, null);

            Ctrls.Glue.FnGlueSINO(glueArchivadoGridLookUpEdit1, null);

            Ctrls.Glue.FnGlueSedeJudicialDescripcion(LugarGridLookUpEdit, null);

            Ctrls.Glue.FnGlueTipoContingencia(glueTipoContingenciaGridLookUpEdit1, null);


            //Ctrls.Glue.FnRpiGlueTipoEstadoActual(EstadoActualgridLookUpEdit1);


            Ctrls.Glue.FnGlueContratosEdit(glueContrato, null, "CONTRATOS");

            Ctrls.Glue.FnGlueEstadoActualEdit(EstadoActualgridLookUpEdit1,null,null);


            //////   Ctrls.Glue.FnRpiGlueTrabajadorJudicialEdit(rpiDemoPer, null);

            Ctrls.Glue.FnGlueTipoProceso(IdTipoProcesoGridLookUpEdit, null);
            Ctrls.Glue.FnGlueClaseProceso(IdClaseProcesoGridLookUpEdit, null);
            Ctrls.Glue.FnGlueClaseProceso(IdClaseProcesoGridLookUpEdit, null);

            ////Ctrls.Glue.FnGlueClaseProceso(GLueIdSupervisor, null);
            //Ctrls.Glue.FnRpiGlueInstancia(riglueInstancia);
            //Ctrls.Glue.FnRpiGlueSedeJudicial(riglueSalaJudiacial);
            //Ctrls.Glue.FnRpiGlueContratos(rpiContratos);//////////
            bsOrganoJudicialEdit.DataSource = CtxModelo.OrganoJudicial;
            //Ctrls.Glue.FnRpiGlueOrganoJudicial(riglueOrganoJudiacial);
            //Ctrls.Glue.FnRpiGlueSalaJudicial(riglueSalaJudicialCC);

            bsDocumentos = new BindingSource();
        }

        private void bsLista_CurrentChanged(object sender, EventArgs e)
        {
            if (bsLista.Current == null) return;
            viewExpediente oViewExpediente = (viewExpediente)bsLista.Current;
            EntidadExpediente = QExpediente.GlExpediente(CtxModelo, oViewExpediente.IdExpediente);
            bsEdicion.DataSource = EntidadExpediente;
            bsInstanciaConsulta.DataSource = QExpediente.GlExpedienteInstancias(CtxModelo,
                EntidadExpediente.IdExpediente);
            List<ActoProcesalContenido> items = new List<ActoProcesalContenido>();
            foreach (var item in EntidadExpediente.ActoProcesal)
                items.AddRange(item.ActoProcesalContenido);

            bsActos.DataSource = items;
            List<ExpedienteInstancia> itemsInsta = new List<ExpedienteInstancia>();
            List<ExpedienteInstancia> itemsInstaT = new List<ExpedienteInstancia>();
            foreach (var item in EntidadExpediente.ExpedienteInstancia)
            {
                itemsInsta.Add(item);
            }

            bsInstanciasExpediente.DataSource = itemsInsta;
            lInstanciass = EntidadExpediente.ExpedienteInstancia;
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

        public override void FnEdicion()
        {
            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                bsInstanciasExpediente.DataSource = null;
                EntidadExpediente = new Expediente();
                EntidadExpediente.TipoExpediente = "EXPEDIENTE";
                bsEdicion.DataSource = EntidadExpediente;
            }
            else
            {
                viewExpediente oViewExpediente = (viewExpediente)bsLista.Current;
                EntidadExpediente = QExpediente.GlExpediente(CtxModelo, oViewExpediente.IdExpediente);
                bsEdicion.DataSource = EntidadExpediente;
            }

            if (EntidadExpediente.IdNEWID == null)
                EntidadExpediente.IdNEWID = Guid.NewGuid().ToString().ToUpper();

            bsDocumentos.DataSource = ctxModeloDOC.Documento.Where(x => x.IdNEWID == EntidadExpediente.IdNEWID);
        }

        public override bool FnGrabar()
        {
            if (TipoEdicion == EnumEdicion.Borrar)
            {
                CtxModelo.DeleteObject(EntidadExpediente);
            }

            bsEdicion.EndEdit();
            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                CtxModelo.AddToExpediente(EntidadExpediente);
            }

            if (TipoEdicion == EnumEdicion.Nuevo || TipoEdicion == EnumEdicion.Editar)
            {

                Expediente oExpediente = (Expediente)bsEdicion.Current;

                bool bError = false;

                if (oExpediente.IdSupervisorInterno != null)
                {
                    int IdSupervisor = (int)oExpediente.IdSupervisorInterno;
                    foreach (var item in oExpediente.ExpedienteAsesorLegal)
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

                if (oExpediente.OrganoExpedienteDemandante.Count > 0)
                {
                    oExpediente.IdDemandante = oExpediente.OrganoExpedienteDemandante.FirstOrDefault().IdDemandante;
                    string sNombres = "";
                    int iNroRows = oExpediente.OrganoExpedienteDemandante.Count();
                    int iIndex = 1;

                    foreach (OrganoExpedientePersona item in oExpediente.OrganoExpedienteDemandante)
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
                    oExpediente.IdDemandante = null;
                    oExpediente.NDemandantes = "";
                }


                if (oExpediente.OrganoExpedienteDemandado.Count > 0)
                {
                    oExpediente.IdDemandado = oExpediente.OrganoExpedienteDemandado.FirstOrDefault().IdDemandado;

                    string sNombres = "";
                    int iNroRows = oExpediente.OrganoExpedienteDemandado.Count();
                    int iIndex = 1;

                    foreach (OrganoExpedientePersona item in oExpediente.OrganoExpedienteDemandado)
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
                    oExpediente.IdDemandado = null;
                    oExpediente.NDemandados = "";
                }

                var lExpedienteExis = CtxModelo.Expediente.Where(x => x.IdDemandante == oExpediente.IdDemandante && oExpediente.IdDemandante != 289).ToList();
                if (lExpedienteExis.Count > 0 && TipoEdicion == EnumEdicion.Nuevo)
                {
                    var oMail = new Control.clsMail();
                    oMail.FnMail_DemandasExistentes(oExpediente.NDemandantes, lExpedienteExis);
                }

            }

            //if (TipoEdicion == EnumEdicion.Nuevo)
            //{
            //    foreach (var item in EntidadExpediente.ExpedienteInstancia)
            //    {
            //        var it0 = item;
            //    }
            //}

                if (bsDocumentos.Count > 0)
            {
                ctxModeloDOC.SaveChanges();
                DeleteFiles();
            }

            CtxModelo.SaveChanges();
            ContextoModelo ctxModelo = new ContextoModelo();
            DateTime ddFechaInicio =
               Convert.ToDateTime(Convert.ToDateTime(rbtnFechaInicio.EditValue).ToShortDateString());
            DateTime ddFechaFin = Convert.ToDateTime(Convert.ToDateTime(rbtnFechaFin.EditValue).ToShortDateString());
            bsLista.DataSource = ctxModelo.viewExpediente.Where(x => x.FechaInicio >= ddFechaInicio && x.FechaInicio <= ddFechaFin && x.TipoExpediente=="EXPEDIENTE");

            return true;
        }

        private void DeleteFiles()
        {
            List<Documento> documentos = (bsDocumentos.DataSource as ObjectQuery<Documento>).ToList();

            foreach (var item in documentos)
            {
                if (item.RutaPc == null) continue;
                if (File.Exists(item.RutaPc))
                {
                    try
                    {
                        File.Delete(item.RutaPc);
                    }
                    catch (Exception ex)
                    {
                        //Do something
                    }
                }
            }

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
            ActoProcesal oProcesal =
                CtxModelo.ActoProcesal.Where(x => x.IdExpediente == EntidadExpediente.IdExpediente)
                    .OrderByDescending(x => x.IdActoPro)
                    .FirstOrDefault();

            if (oProcesal != null)
                sContenido = oProcesal.Contenido;


            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                if (EntidadExpediente.ExpedienteInstancia.Count < 1)
                {
                    XtraMessageBox.Show("Debe ingresar como mínimo una instancia. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ;
                }
            }

            ActoProcesal oActoProcesal = new ActoProcesal();

            ExpedienteInstancia oExpedienteInstancia =
    EntidadExpediente.ExpedienteInstancia.OrderByDescending(x => x.IdExpedienteInstancia).FirstOrDefault();
            if (oExpedienteInstancia != null)
                oActoProcesal.IdExpedienteInstancia = oExpedienteInstancia.IdExpedienteInstancia;

            InstanciaJudicial instanciaJudicial = CtxModelo.InstanciaJudicial.FirstOrDefault(x => x.IdInstancia == oExpedienteInstancia.IdInstancia);

            EntidadExpediente.ActoProcesal.Add(oActoProcesal);
            int xx = 0;
            //foreach (var item in EntidadExpediente.ExpedienteInstancia)
            //{
            //    lInstanciass.ElementAt(xx).InstanciaJudicial = CtxModelo.InstanciaJudicial.FirstOrDefault(x => x.IdInstancia == item.IdInstancia);
            //}

            FActoProcesalE fActoProcesalE = new FActoProcesalE(oActoProcesal, CtxModelo,
                instanciaJudicial.Descripcion, sContenido, lInstanciass);
            fActoProcesalE.ShowDialog();

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
            ActoProcesal oActoProcesal = ((ActoProcesalContenido)bsActos.Current).ActoProcesal;
            EntidadExpediente.ActoProcesal.Add(oActoProcesal);
            ExpedienteInstancia oExpedienteInstancia =
                EntidadExpediente.ExpedienteInstancia.OrderByDescending(x => x.IdExpedienteInstancia).FirstOrDefault();

            FActoProcesalE fActoProcesalE = new FActoProcesalE(oActoProcesal, CtxModelo,
                oExpedienteInstancia.InstanciaJudicial.Descripcion, "E", lInstanciass);
            fActoProcesalE.ShowDialog();
            List<ActoProcesalContenido> items = new List<ActoProcesalContenido>();
            foreach (var item in EntidadExpediente.ActoProcesal)
                items.AddRange(item.ActoProcesalContenido);
            bsActos.DataSource = items;
        }
        private void btnMostrarArchivo_Click(object sender, EventArgs e)
        {
            ActoProcesal oActoProcesal = ((ActoProcesalContenido)bsActos.Current).ActoProcesal;
            MostrarArchivoGlobal(oActoProcesal.IdNEWID);
        }

        private void MostrarArchivoGlobal(string idNEWID)
        {
            Documento oFile = CtxModelo.Documento.Where(x => x.IdNEWID == idNEWID).FirstOrDefault();
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
            ActoProcesal oActoProcesal = ((ActoProcesalContenido)bsActos.Current).ActoProcesal;
            Documento oFile = CtxModelo.Documento.Where(x => x.IdNEWID == oActoProcesal.IdNEWID).FirstOrDefault();

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
                CtxModelo.AddToDocumento(oDocumento);
            }

            else
            {
                oDocumento = CtxModelo.Documento.Where(x => x.IdNEWID == EntidadExpediente.IdNEWID).FirstOrDefault();
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
            string sPc = System.Net.Dns.GetHostName();

            TipoContenido tipoContenido = CtxModelo.TipoContenido.Where(t => t.Abreviado == sPc).FirstOrDefault();
            if (tipoContenido == null) tipoContenido = CtxModelo.TipoContenido.Where(t => t.Abreviado == "ESCANER").FirstOrDefault();
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
            bsLista.DataSource =
                CtxModelo.viewExpediente.Where(x => x.FechaInicio >= ddFechaInicio && x.FechaInicio <= ddFechaFin && x.TipoExpediente=="EXPEDIENTE");
        }

        private void rbtnFechaFin_EditValueChanged(object sender, EventArgs e)
        {
            CargarDatosFecha();
        }

        private void btnReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bsLista.Current == null) return;
            viewExpediente oViewExpediente = (viewExpediente)bsLista.Current;
            EntidadExpediente = QExpediente.GlExpediente(CtxModelo, oViewExpediente.IdExpediente);

            RExpedienteDetalle rpDetalle = new RExpedienteDetalle(EntidadExpediente);
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
            TipoContenido tipoContenido = CtxModelo.TipoContenido.Where(t => t.Abreviado == sPc).FirstOrDefault();
            if (tipoContenido == null) tipoContenido = CtxModelo.TipoContenido.Where(t => t.Abreviado == "ESCANER").FirstOrDefault();
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
            EntidadExpediente.ExpedienteInstancia.Add(oActoProcesal);

            FExpedienteInstancia fActoProcesalE = new FExpedienteInstancia(oActoProcesal, CtxModelo);
            fActoProcesalE.ShowDialog();

            //foreach (var item in EntidadExpediente.ExpedienteInstancia)
            //{
            //    var od = item.InstanciaJudicial.Descripcion;
            //    var of = item.OrganoJudicial.Descripcion;
            //}

            bsInstanciasExpediente.DataSource = EntidadExpediente.ExpedienteInstancia;
            lInstanciass = EntidadExpediente.ExpedienteInstancia;

            //

        }

        private void btnEditInstancia_Click(object sender, EventArgs e)
        {
            ExpedienteInstancia oExpedienteInstancia = ((ExpedienteInstancia)bsInstanciasExpediente.Current);
            EntidadExpediente.ExpedienteInstancia.Add(oExpedienteInstancia);

            FExpedienteInstancia fActoProcesalE = new FExpedienteInstancia(oExpedienteInstancia, CtxModelo);
            fActoProcesalE.ShowDialog();

            bsInstanciasExpediente.DataSource = EntidadExpediente.ExpedienteInstancia;
            lInstanciass = EntidadExpediente.ExpedienteInstancia;
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
            if (IdNotificacionGgridLookUpEdit.EditValue == null) return;
            if (IdNotificacionGgridLookUpEdit.EditValue.ToString() == "") return;
            var f = IdNotificacionGgridLookUpEdit.EditValue.ToString();
            int iID = (int)IdNotificacionGgridLookUpEdit.EditValue;

            var tipoC = CtxModelo.TipoContenido.Where(d => d.IdTipoContenido == iID).FirstOrDefault();
            if (tipoC.Titulo == "CASILLA ELECTRONICA") lycNrocasilla.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else lycNrocasilla.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }

        private void rpiglueDemandante_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit oEdit = sender as GridLookUpEdit;
            int iID = 0;
            if (oEdit.EditValue != null) iID = (int)oEdit.EditValue;
            if (iID != 0)
            {
                ContextoModelo contextoModelo = new ContextoModelo();
                PersonaEmpresa personaEmpresa = contextoModelo.PersonaEmpresa.Where(c => c.IdPersonaEmpresa == iID).FirstOrDefault();
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
                ContextoModelo contextoModelo = new ContextoModelo();
                PersonaEmpresa personaEmpresa = contextoModelo.PersonaEmpresa.Where(c => c.IdPersonaEmpresa == iID).FirstOrDefault();
                (rpiglueDemandado.DataSource as List<PersonaEmpresa>).Add(personaEmpresa);
            }
        }
    }
}
