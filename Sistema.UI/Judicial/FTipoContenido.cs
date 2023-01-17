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
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using Sistema.Model;
using Sistema.Query;

namespace Sistema.UI.Judicial
{
    public partial class FTipoContenido : FBaseForm
    {
        ContextoModelo CtxModelo = new ContextoModelo();
        TipoFiltro oTipoFiltro;
        TipoInternoContenido TipoInternoForm;
        List<TipoFiltro> lFiltros;
        public FTipoContenido()
        {
            InitializeComponent();
           
        }

        public override void FnEdicion()
        {
            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                TipoContenido tipoContenido = new TipoContenido();
                tipoContenido.TipoInterno = this.TipoInterno;
                bsLista.Add(tipoContenido);
                bsLista.MoveLast();
            }
        }

        public override bool FnGrabar()
        {
            if (TipoEdicion == EnumEdicion.Borrar) bsLista.RemoveCurrent();
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
        public override void FnLoadForm()
        {
            TipoInternoForm = TipoInternoContenido.GLista().Where(x => x.TipoInterno == TipoInterno.ToString()).FirstOrDefault();
            this.Text = TipoInternoForm.TipoMostrar;


            bsLista.DataSource = CtxModelo.TipoContenido.Where(x => x.TipoInterno == this.TipoInterno);

            if (this.TipoInterno == "NOTIFICACION")
            {
                ItemForAbreviado.Text = "Codigo";
                itemforTitulo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                itemforNrodias.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ItemForDescripcion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                colAbreviado.Caption = "Codigo";
                colTitulo.Visible = true;
                colNroDias.Visible = true;
                colDescripcion.Visible = false;
            }
            if (this.TipoInterno == "VARIABLES")
            {
                ItemForAbreviado.Text = "Clave";
                ItemForDescripcion.Text = "Valor";

                colAbreviado.Caption = "Clave";
                
                colDescripcion.Caption = "Valor";
            }

            

                 if (this.TipoInterno == "ESTADOSACTUALES")
            {
                ItemForAbreviado.Text = "ID";
                ItemForDescripcion.Text = "Descripciòn";

                colAbreviado.Caption = "ID";

                colDescripcion.Caption = "Descripciòn";
            }

        }

        private void FTipoContenido_Load(object sender, EventArgs e)
        {
            FnLoadForm();
        }
    }
}
