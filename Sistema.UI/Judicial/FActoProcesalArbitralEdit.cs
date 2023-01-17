using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;
using Sistema.Services.Modelo;
using  Ext;
using System.Data.Objects.DataClasses;
using Sistema.Services;

namespace Sistema.UI.Judicial
{
    public partial class FActoProcesalArbitralEdit : DevExpress.XtraEditors.XtraForm
    {

        public bool Estado = false;
        //private ContextoModelo ctxContextoModelo;
        //private ContextoModelo ctxModeloDOC= new ContextoModelo();
        public ActoProcesal OActoProcesal;
        private DocumentoService DocumentoService = new DocumentoService();

        public FActoProcesalArbitralEdit(ActoProcesal oActoProcesal,string sContenido)
        //fio va borrar ctxmodelo
        {
            InitializeComponent();

            //bsInstanciasExpediente.DataSource = lInstanciass;
            OActoProcesal = oActoProcesal;
            bsEdicion.DataSource = oActoProcesal;
            if (sContenido=="E")
            {
                richEditControl1.Text = oActoProcesal.Contenido;
            }
            else
            {
                if (sContenido!="" && sContenido!= null )
                {
                  richEditControl1.Text = sContenido + "\n";

                DocumentRange[] dr = richEditControl1.Document.FindAll(sContenido, SearchOptions.WholeWord);
                CharacterProperties cp = richEditControl1.Document.BeginUpdateCharacters(dr[0]);
                cp.BackColor = Color.Yellow;
                richEditControl1.Document.EndUpdateCharacters(cp);   
                }
               
            }
            
            
            Ctrls.Glue.FnRpiGlueTipoCntenido(riglueTipoContenidoVal);
            Ctrls.Glue.FnGlueTipoContenidoEdit(glueIDInstancia, null, "TIPOACTOPROCESALARB");

            Ctrls.Glue.FnGlueNotificacion(idNotificacionGlue, null);
            //glueEtapaProceso
            Ctrls.Glue.FnGlueEtapaProceso(glueEtapaProceso, null);
            
            //fio
            //ctxContextoModelo = ctxModelo;
            if (OActoProcesal.IdNEWID == null)
                OActoProcesal.IdNEWID = Guid.NewGuid().ToString().ToUpper();
            // var valu=ctxModeloDOC.Documento.Select(v=> new Documento{IdDocumento = v.IdDocumento,Nombre = v.Nombre,Extension = v.Extension,IdNEWID = v.IdNEWID}).ToList();
            //fio
            //bsDocumentos.DataSource = ctxModeloDOC.Documento.Where(x=>x.IdNEWID==OActoProcesal.IdNEWID);
            bsDocumentos.DataSource = DocumentoService.BuscarPorEntidadExpediente(OActoProcesal.IdNEWID);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bsEdicion.EndEdit();
            Estado = true;

            ActoProcesal oActoProcesal = (ActoProcesal) bsEdicion.Current;

            oActoProcesal.Contenido = richEditControl1.Text;

            if(oActoProcesal.EtapaProceso==null || oActoProcesal.EtapaProceso == "")
            {
                MessageBox.Show("Error: Ingrese algún valor para [Etapa de Proceso].");
                return;
            }

            if (oActoProcesal.IdExpedienteInstancia == null || oActoProcesal.IdExpedienteInstancia == 0)
            {
                MessageBox.Show("Error: Ingrese algún valor para [Estado Actual].");
                return;
            }

            if (bsDocumentos.Count > 0)
            {
                //fio
                //ctxModeloDOC.SaveChanges();
                DocumentoService.Guardar();
            }

            DocumentoService.Guardar();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bsEdicion.CancelEdit();
            Estado = false;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.ofdAll.ShowDialog() == DialogResult.Cancel)
                return;
            string sRuta = ofdAll.FileName;
          
            Documento oDocumento;

            if (OActoProcesal.IdNEWID == null)
            {
                oDocumento = new Documento();
                oDocumento.IdNEWID = Guid.NewGuid().ToString().ToUpper();
                OActoProcesal.IdNEWID = oDocumento.IdNEWID;
                DocumentoService.AgregarDocumento(oDocumento);
            }
            else
            {
                //oDocumento = ctxContextoModelo.Documento.Where(x => x.IdNEWID == OActoProcesal.IdNEWID).FirstOrDefault();
                oDocumento = DocumentoService.BuscarPorEntidadExpediente(OActoProcesal.IdNEWID);
            }

            oDocumento.Nombre = Path.GetFileNameWithoutExtension(sRuta);
            oDocumento.Documento1 = ExtFile.FileToBits(sRuta);
            oDocumento.Extension = Path.GetExtension(sRuta);
        }

        private void rpiBtnCargarDoc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.ofdAll.ShowDialog() == DialogResult.Cancel)
                return;
            string sRuta = ofdAll.FileName;

            if (OActoProcesal.IdNEWID == null)
            {
                OActoProcesal.IdNEWID = Guid.NewGuid().ToString().ToUpper();
            }

            //    txtRutaFile.Text = sRuta;
            if (gridView4.FocusedRowHandle < 0)
            {
                bsDocumentos.Add(new Documento());
            bsDocumentos.MoveLast();
        }

            ((Documento)bsDocumentos.Current).IdNEWID = OActoProcesal.IdNEWID;
            ((Documento)bsDocumentos.Current).Nombre = Path.GetFileNameWithoutExtension(sRuta);
            ((Documento)bsDocumentos.Current).Documento1 = ExtFile.FileToBits(sRuta);
            ((Documento)bsDocumentos.Current).Extension = Path.GetExtension(sRuta);
        }

        private void rpiBtnShowDOC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
    }
}