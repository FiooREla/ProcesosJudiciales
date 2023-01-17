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
using Ext;

namespace Sistema.UI.Judicial
{
    public partial class FExpedienteInstancia : DevExpress.XtraEditors.XtraForm
    {
        public bool Estado = false;
        private ContextoModelo ctxContextoModelo;
        private ContextoModelo ctxModeloDOC = new ContextoModelo();
        public ExpedienteInstancia OExpedienteInstancia;

        public FExpedienteInstancia(ExpedienteInstancia oExpedienteInstancia, ContextoModelo ctxModelo)

        {
            InitializeComponent();


            Ctrls.Glue.FnGlueOrganoJudicial(IdOrganoJudicialgridLookUpEdit1, null);
            Ctrls.Glue.FnGlueInstancia(IdInstanciaGlue, null);

            OExpedienteInstancia = oExpedienteInstancia;
            bsEdicion.DataSource = oExpedienteInstancia;

            ctxContextoModelo = ctxModelo;

            if (OExpedienteInstancia.IdNEWID == null)
                OExpedienteInstancia.IdNEWID = Guid.NewGuid().ToString().ToUpper();
            // var valu=ctxModeloDOC.Documento.Select(v=> new Documento{IdDocumento = v.IdDocumento,Nombre = v.Nombre,Extension = v.Extension,IdNEWID = v.IdNEWID}).ToList();
            bsDocumentos.DataSource = ctxModeloDOC.Documento.Where(x => x.IdNEWID == OExpedienteInstancia.IdNEWID);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bsEdicion.EndEdit();
            Estado = true;

            ExpedienteInstancia oActoProcesal = (ExpedienteInstancia)bsEdicion.Current;
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

            if (OExpedienteInstancia.IdNEWID == null)
            {
                oDocumento = new Documento();
                oDocumento.IdNEWID = Guid.NewGuid().ToString().ToUpper();
                OExpedienteInstancia.IdNEWID = oDocumento.IdNEWID;
                ctxContextoModelo.AddToDocumento(oDocumento);
            }
            else
            {
                oDocumento = ctxContextoModelo.Documento.Where(x => x.IdNEWID == OExpedienteInstancia.IdNEWID).FirstOrDefault();
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

            if (OExpedienteInstancia.IdNEWID == null)
            {
                OExpedienteInstancia.IdNEWID = Guid.NewGuid().ToString().ToUpper();
            }

            //    txtRutaFile.Text = sRuta;
            if (gridView4.FocusedRowHandle < 0)
            {
                bsDocumentos.Add(new Documento());
                bsDocumentos.MoveLast();
            }

            ((Documento)bsDocumentos.Current).IdNEWID = OExpedienteInstancia.IdNEWID;
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

        private void IdInstanciaGlue_EditValueChanged(object sender, EventArgs e)
        {
            ExpedienteInstancia oEI = (ExpedienteInstancia)bsEdicion.Current;
            if (oEI == null) return;
            if (oEI.IdExpedienteInstancia == 0)
            {
                InstanciaJudicial OIJ;
                OIJ = (InstanciaJudicial)IdInstanciaGlue.Properties.View.GetRow(IdInstanciaGlue.Properties.View.FocusedRowHandle);
                if (OIJ == null) return;

                oEI.InstanciaTexto = ctxContextoModelo.InstanciaJudicial.First(x => x.IdInstancia == OIJ.IdInstancia).Descripcion;
                
            }
        }

        private void IdOrganoJudicialgridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            OrganoJudicial oOJ;
            oOJ = (OrganoJudicial)IdOrganoJudicialgridLookUpEdit1.Properties.View.GetRow(IdOrganoJudicialgridLookUpEdit1.Properties.View.FocusedRowHandle);
            if (oOJ == null) return;
            ExpedienteInstancia oEI = (ExpedienteInstancia)bsEdicion.Current;
            if (oEI == null) return;
            oEI.OrganoTexto = ctxContextoModelo.OrganoJudicial.First(x => x.IdOrgano == oOJ.IdOrgano).Descripcion;
           
        }
    }
}