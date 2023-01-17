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
    public partial class FRListadosExpedientes : FBaseForm
    {
        ContextoModelo CtxModelo = new ContextoModelo();
        public FRListadosExpedientes()
        {
            InitializeComponent();
            wbtnBorrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            wbtnEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            wbtnNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            rbtnVisualizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            deInicio.EditValue = DateTime.Now;
            deFin.EditValue = DateTime.Now.AddDays(7);
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
           
            dInicio =(DateTime) deInicio.EditValue;
            dFin = (DateTime)deFin.EditValue;
            List<viewExpedienteReport> lviewReports;
            lviewReports =
                CtxModelo.viewExpedienteReport.Where(x => x.FechaInicio >= dInicio && x.FechaInicio <= dFin && x.TipoExpediente== "EXPEDIENTE").ToList();

            bsLista.DataSource = lviewReports;

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            GenerarDiasSemana();
        }


    }
}
