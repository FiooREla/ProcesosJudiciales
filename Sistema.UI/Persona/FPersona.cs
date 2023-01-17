using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Base.UI;
using Sistema.Model;
using System.Linq;
using DevExpress.XtraPrinting.Preview;
using System.Data.Objects.DataClasses;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Sistema.UI.Persona
{
    public partial class FPersona : FBaseForm
    {
        ContextoModelo CtxModelo = new ContextoModelo();
        TipoFiltro oTipoFiltro;
        TipoInternoPersona TipoInternoForm;
        List<TipoFiltro> lFiltros;
        public FPersona()
        {

            InitializeComponent();
        }

        private void CargarDatos()
        {
           CtxModelo = new ContextoModelo();
            bsLista.DataSource = CtxModelo.PersonaEmpresa.Where(x => x.TipoFiltro == oTipoFiltro.Descripcion);
          Ctrls.Glue.FnRpiGluePersona(rpiAbogados, "ABOGADOS");
        }

        private void bbiTipoInterno_EditValueChanged(object sender, EventArgs e)
        {
            oTipoFiltro = TipoFiltro.GLista().FirstOrDefault(x => x.Descripcion == bbiTipoInterno.EditValue.ToString());
            CargarDatos();
        }

        public override void FnEdicion()
        {
            this.Size = new Size(800, 800);
            dlcData.Size = new Size(730, 850);
            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                var entidad = new PersonaEmpresa();
                if (TipoInternoForm != null) entidad.TipoInterno = TipoInternoForm.TipoInterno;
                else entidad.TipoInterno = TipoInternoForm.TipoInterno;

                if (oTipoFiltro != null) entidad.TipoFiltro = oTipoFiltro.Descripcion;
                else entidad.TipoFiltro = oTipoFiltro.Descripcion;

                bsLista.Add(entidad);
                bsLista.MoveLast();
            }
        }

        public override bool FnGrabar()
        {

            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                dxValidationProvider1.Validate();
                var controls = dxValidationProvider1.GetInvalidControls().Where(cntrl => dxValidationProvider1.GetValidationRule(cntrl).ErrorType == ErrorType.Critical);
                if (controls.Count() > 0) return false;
            }

            if (TipoEdicion == EnumEdicion.Borrar) bsLista.RemoveCurrent();
            PersonaEmpresa entidad = (bsLista.Current as PersonaEmpresa);

            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                ContextoModelo contexto = new ContextoModelo();
                if (contexto.PersonaEmpresa.Count(x => x.Nombre == entidad.Nombre && x.TipoInterno==entidad.TipoInterno) > 0)
                {
                    XtraMessageBox.Show("Existe un registro con el mismo nombre  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (contexto.PersonaEmpresa.Count(x => x.Documento == entidad.Documento && x.TipoInterno == entidad.TipoInterno) > 0)
                {
                    XtraMessageBox.Show("Existe un registro con el mismo documento  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            if (this.TipoInterno == "OASESORJURIDOCO")
            {
                List<PersonaEmpresa> lPersonas = new List<PersonaEmpresa>();
                lPersonas = entidad.Personas.ToList();
                entidad.Personas.Clear();

                foreach (var item in lPersonas) entidad.Personas.Add(CtxModelo.PersonaEmpresa.Where(x => x.IdPersonaEmpresa == item.IdPersonaEmpresa).FirstOrDefault());
            }

            bsLista.EndEdit();
            CtxModelo.SaveChanges();
            CargarDatos();
            return true;
        }

        public override void FnCancelar()
        {
            if (TipoEdicion == EnumEdicion.Nuevo) bsLista.RemoveCurrent();
            bsLista.CancelEdit();
        }

        public override void FnImprimir()
        {
            PrintPreviewRibbonFormEx pView = new PrintPreviewRibbonFormEx();
            pView.PrintingSystem = printingSystem1;
            printableComponentLink1.CreateDocument();
            pView.Show();
        }

        public override void FnLoadForm()
        {
            TipoInternoForm = TipoInternoPersona.GLista().Where(x => x.TipoInterno == TipoInterno.ToString()).FirstOrDefault();
            lFiltros = TipoFiltro.GLista().Where(x => x.IDTipo == TipoInterno.ToString()).ToList();
            this.Text = TipoInternoForm.TipoMostrar;

            Ext.Glue.RpiGridLookUpEdit(rpiGlueTipoInterno, lFiltros, "Descripcion", "Descripcion", new string[] { "Descripcion" });

            Ctrls.Glue.FnRpiGlueTrabajadorJudicialEdit(rpiDemoPer, null);

            Ctrls.Glue.FnRpiGluePersona(rpiAbogados, "ABOGADOS");

            bbiTipoInterno.EditValue = lFiltros.FirstOrDefault().Descripcion;
            Ctrls.Glue.FnGlueLocalidadConsulta(IdLocalidadGridLookUpEdit, null);
            if (this.TipoInterno == "OASESORJURIDOCO")
            {
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lycAbogadosG.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                dlcData.Size = new Size(730, 850);

            }
            if (this.TipoInterno != "OASESORJURIDOCO")
            {
                dlcData.Size = new Size(730, 300);
            }

            if (this.TipoInterno == "ABOGADOS" || this.TipoInterno== "SUPERVISORINTERNO")
            {
                ItemForIdLocalidad.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForNombre.Text = "Nombre";
                //layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (this.TipoInterno == "CONTRATOS")
            {
                ItemForDireccion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForTelefono.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForEmail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                itemForFecha.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lycDetallesMemo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                colDescripcion.Visible = true;colNombre.Caption = "Descripcion";colDocumento.Caption = "Nro. Contrato";
                ItemForNombre.Text = "Descripcion"; ItemForDocumento.Text= "Nro. Contrato";
                colFechaIncio.Visible = true;
                colDireccion.Visible = false;

                //ItemForNombre.Text = "Nombre";
                //layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

        }

        private void FPersona_Load(object sender, EventArgs e)
        {
            FnLoadForm();
        }

        private void rpiDemoPer_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit oEdit = sender as GridLookUpEdit;
            int iID = 0;
            if (oEdit.EditValue != null) iID = (int)oEdit.EditValue;
            if (iID != 0)
            {
                ContextoModelo contextoModelo = new ContextoModelo();
                PersonaEmpresa personaEmpresa = contextoModelo.PersonaEmpresa.Where(c => c.IdPersonaEmpresa == iID).FirstOrDefault();
                (rpiDemoPer.DataSource as List<PersonaEmpresa>).Add(personaEmpresa);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void bsDetalle_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}