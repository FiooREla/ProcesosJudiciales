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
using DevExpress.XtraScheduler;
using Sistema.Model;
using Sistema.Query;
using Sistema.UI.Persona;

namespace Sistema.UI.Judicial
{
    public partial class FRListadosTrimestrales : FBaseForm
    {
        ContextoModelo CtxModelo = new ContextoModelo();
        public FRListadosTrimestrales()
        {
            InitializeComponent();
            wbtnBorrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            wbtnEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            wbtnNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            rbtnVisualizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            deInicio.EditValue = DateTime.Now;
            deFin.EditValue = DateTime.Now.AddDays(30);
            rgTipo.EditValue = 1;
            colDescripcion.Caption = "Tipo Proceso";
        }

        public override void FnImprimir()
        {
            PrintPreviewRibbonFormEx pViewEx = new PrintPreviewRibbonFormEx();
            pViewEx.PrintingSystem = printingSystem1;
            printableComponentLink1.CreateDocument();
            pViewEx.Show();
        }

        private void GenerarDiasSemana()
        {
            DateTime dInicio;
            DateTime dFin;

            bsLista.DataSource = null;
           
            dInicio =(DateTime) deInicio.EditValue;
            dFin = (DateTime)deFin.EditValue;
            List<viewEstructuraTotales> viewTotales=null;

            if ((int)rgTipo.EditValue == 1)
            {
                viewTotales = CtxModelo.uspExpedientesJudicialesTotales(dInicio, dFin).ToList();
                colDescripcion.Caption = "Tipo Proceso";
            }

            if ((int)rgTipo.EditValue == 2)
            {
                viewTotales = CtxModelo.uspExpedientesJudicialesClaseProcesoTotales(dInicio, dFin).ToList();
                colDescripcion.Caption = "Clase Proceso";
            }

            if ((int)rgTipo.EditValue == 3)
            {
                viewTotales = CtxModelo.uspExpedientesJudicialesSedeJudicialTotales(dInicio, dFin).ToList();
                colDescripcion.Caption = "Sede Judicial";
            }


            bsLista.DataSource = viewTotales;

          

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            GenerarDiasSemana();
        }


    }
}
