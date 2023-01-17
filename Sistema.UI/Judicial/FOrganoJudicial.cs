using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using Sistema.Model;
using Sistema.Query;
using Base.UI.Ext;

namespace Sistema.UI.Judicial
{    
    public partial class FOrganoJudicial : FBaseForm
    {
        ContextoModelo CtxModelo = new ContextoModelo();
        List<OrganoJudicial> lOjJudicials= new List<OrganoJudicial>(); 
        public FOrganoJudicial()
        {
            InitializeComponent();
            lOjJudicials = CtxModelo.OrganoJudicial.ToList();
            bsLista.DataSource = CtxModelo.OrganoJudicial;
            Ctrls.Glue.FnGlueLocalidadConsulta(IdLocalidadGridLookUpEdit, null);
            Ctrls.Glue.FnGlueSedeJudicial(IdSedeGridLookUpEdit);
            Ctrls.Glue.FnGlueTipoOrganoJudicial(TipoGridLookUpEdit);
           // Ctrls.Glue.FnGluePersonaTipoInterTipoFiltro(IdJuezGridLookUpEdit, "OTRABAJADORJURIDOCO", "Jueces");
            Ctrls.Glue.FnGlueRpiPersonaTipoInterTipoFiltro(rpiGlueJuez, "OTRABAJADORJURIDOCO", "Jueces");
           // Ctrls.Glue.FnGluePersonaTipoInterTipoFiltro(IdSecretarioGridLookUpEdit, "OTRABAJADORJURIDOCO", "Secretarios");
            Ctrls.Glue.FnGlueRpiPersonaTipoInterTipoFiltro(rpiGlueSecretario, "OTRABAJADORJURIDOCO", "Secretarios");
        }
        public override void FnEdicion()
        {           
            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                bsLista.Add(new OrganoJudicial());
                bsLista.MoveLast();
            }
        }

        public override bool FnGrabar()
        {
            if (TipoEdicion == EnumEdicion.Borrar) bsLista.RemoveCurrent();
            if (TipoEdicion==EnumEdicion.Nuevo)
            {
                OrganoJudicial oJudicial = (OrganoJudicial) bsLista.Current;
                if (lOjJudicials.Where(x=>x.Descripcion==oJudicial.Descripcion).ToList().Count>0)
                {
                    XtraMessageBox.Show("La descripción ya existe.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (oJudicial.OrganoJudicialJuez.Count>0)oJudicial.IdJuez = oJudicial.OrganoJudicialJuez.FirstOrDefault().IdJuez;
                if (oJudicial.OrganoJudicialSecretario.Count > 0) oJudicial.IdSecretario = oJudicial.OrganoJudicialSecretario.FirstOrDefault().IdSecretario;
                
            }

            bsLista.EndEdit();
            CtxModelo.SaveChanges();
            return true;
        }
        public override void FnCancelar()
        {
            if (TipoEdicion == EnumEdicion.Nuevo) bsLista.RemoveCurrent();
            bsLista.CancelEdit();            
        }

        public override void FnImprimir()
        {
            PrintPreviewRibbonFormEx pViewEx = new PrintPreviewRibbonFormEx();
            pViewEx.PrintingSystem = printingSystem1;
            printableComponentLink1.CreateDocument();
            pViewEx.Show();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}