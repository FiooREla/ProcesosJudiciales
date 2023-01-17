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
using Sistema.Model;
using  Ext;
using System.Data.Objects.DataClasses;

namespace Sistema.UI.Judicial
{
    public partial class FActoProcesalE : DevExpress.XtraEditors.XtraForm
    {
        public bool Estado = false;
        private ContextoModelo ctxContextoModelo;
        private ContextoModelo ctxModeloDOC= new ContextoModelo();
        public ActoProcesal OActoProcesal;

        public FActoProcesalE(ActoProcesal oActoProcesal, ContextoModelo ctxModelo, string TextoInstancia,string sContenido, EntityCollection<ExpedienteInstancia> lInstanciass)

        {
            InitializeComponent();

            bsInstanciasExpediente.DataSource = lInstanciass;
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
            
            lblTexto.Text = TextoInstancia;
            Ctrls.Glue.FnRpiGlueTipoCntenido(riglueTipoContenidoVal);

            Ctrls.Glue.FnGlueNotificacion(idNotificacionGlue, null);

            ctxContextoModelo = ctxModelo;
            if (OActoProcesal.IdNEWID == null)
                OActoProcesal.IdNEWID = Guid.NewGuid().ToString().ToUpper();
           // var valu=ctxModeloDOC.Documento.Select(v=> new Documento{IdDocumento = v.IdDocumento,Nombre = v.Nombre,Extension = v.Extension,IdNEWID = v.IdNEWID}).ToList();
            bsDocumentos.DataSource = ctxModeloDOC.Documento.Where(x=>x.IdNEWID==OActoProcesal.IdNEWID);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bsEdicion.EndEdit();
            Estado = true;

            ActoProcesal oActoProcesal = (ActoProcesal) bsEdicion.Current;
            oActoProcesal.Contenido = richEditControl1.Text;
            if (bsDocumentos.Count > 0)
            {
                ctxModeloDOC.SaveChanges();
            }

            ctxContextoModelo.SaveChanges();
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
                ctxContextoModelo.AddToDocumento(oDocumento);
            }
            else
            {
                oDocumento = ctxContextoModelo.Documento.Where(x => x.IdNEWID == OActoProcesal.IdNEWID).FirstOrDefault();
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