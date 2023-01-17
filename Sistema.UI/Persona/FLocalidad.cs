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

namespace Sistema.UI.Persona
{
    public partial class FLocalidad : FBaseForm
    {
        ContextoModelo CtxModelo = new ContextoModelo();
        public FLocalidad()
        {
            InitializeComponent();
            bsLista.DataSource = CtxModelo.Localidad;
            Ctrls.Glue.FnGlueLocalidad(IdLocalidadPadreGridLookUpEdit, bsLista);
            tlLista.ExpandAll();
        }

        public override void FnEdicion()
        {
            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                var entidad = new Localidad();
                bsLista.Add(entidad);
                bsLista.MoveLast();
            }
        }

        public override bool FnGrabar()
        {
            if (TipoEdicion == EnumEdicion.Borrar) bsLista.RemoveCurrent();
            bsLista.EndEdit();
            CtxModelo.SaveChanges();
            tlLista.ExpandAll();
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
    }
}