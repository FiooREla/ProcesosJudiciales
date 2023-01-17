using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseR;
using BaseR.Ctrls;
using BaseR.Fns;
using BaseR;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraCharts.Wizard;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using Utils = BaseR.Ctrls.Utils;

namespace BaseR
{
    public partial class FReporte : FBaseReporte
    {
        private FnFiltro ClsFiltro;

        private ContextoReporte CtxReporte = new ContextoReporte();
        private Reporte EntidadActual;
        private FBaseModal FrmFiltro;
        private bool SeCargo;

        public FReporte()
        {            
            InitializeComponent();
        }

        public override void FnLoadForm()
        {
            PivotGridFieldBase.DefaultDecimalFormat.FormatType = FormatType.Numeric;
            PivotGridFieldBase.DefaultDecimalFormat.FormatString = "n2";
            rbtnImprimir.Visibility = BarItemVisibility.Never;
            if (Parametros2 != null)
            {
                EntidadActual = CtxReporte.Reporte.FirstOrDefault(x => x.Codigo == Parametros2);
            }
            else
            {
                var id = Convert.ToInt32(Parametros);
                EntidadActual = CtxReporte.Reporte.FirstOrDefault(x => x.ID == id);
            }

            ClsFiltro = new FnFiltro(BaseSession.SQLConnection, EntidadActual.Query);
            if (!EntidadActual.MostrarPivot) tcgVistas.ShowTabHeader = DefaultBoolean.False;
            if (EntidadActual.FiltroFecha)
                if (Parametros2 != "E.7.6")
                {
                    Utils.FnFiltroFechaInicioMes(bbiFInicio, bbiFFin);
                }
                else
                {
                    Utils.FnFiltroFechaInicioMes(bbiFInicio, bbiFFin, -6);
                    bbiFInicio.Enabled = false;
                }
            else GrupoFiltros.Visible = false;

            if (EntidadActual.MostrarPivot) tcgVistas.SelectedTabPage = lcgEstadistico;

            SeCargo = true;
            if (EntidadActual.Filtro)
            {
                FrmFiltro = (FBaseModal)Activator.CreateInstance(Type.GetType(EntidadActual.FormFiltro));
                FrmFiltro.FnLoadForm();
                FrmFiltro.FnLoadBasic();
                FnFiltro(true);
            }
            else
            {
                rbbiFiltros.Visibility = BarItemVisibility.Never;
                rbbiVerFiltro.Visibility = BarItemVisibility.Never;
                GrupoEdicion.Visible = false;
            }

            FnConfiguracion();
            FnLoadLayout();
            //FnActualizar();
            //vReporte.OptionsView.ShowGroupPanel = false;
            //vReporte.OptionsView.ShowFooter = true;
            //vReporte.OptionsBehavior.Editable = false;
        }

        #region DATOS

        private void bbiFechaFin_EditValueChanged(object sender, EventArgs e)
        {
            if (!SeCargo) return;
            if (Parametros2 == "E.7.6")
            {
                var fFin = Convert.ToDateTime(bbiFFin.EditValue);
                bbiFInicio.EditValue = fFin.AddMonths(-6);
                var fIni = Convert.ToDateTime(bbiFInicio.EditValue);
                bbiFInicio.EditValue = fIni.AddDays(1);
                bbiFInicio.Enabled = false;
            }

            FnActualizar();
        }

        private void bbiFechaInicio_EditValueChanged(object sender, EventArgs e)
        {
            //if (!SeCargo) return; FnActualizar();
        }

        public override void FnActualizar()
        {
            if (EntidadActual.Filtro & (ClsFiltro.LF_Ctrls.Count == 0))
            {
                Msg.FnMessage("E", "Los filtros no se definieron.");
                FnFiltro(true);
                return;
            }

            var vInicio1 = "";
            var vFin1 = "";
            var vInicio1SinMinutos = "";
            var vFin1SinMinutos = "";
            if (EntidadActual.FiltroFecha)
            {
                ClsFiltro.FnClearDates();
                var fInicio = Convert.ToDateTime(bbiFInicio.EditValue).AddDays(-1);
                var fFin = Convert.ToDateTime(bbiFFin.EditValue).AddDays(1);
                var fInicioSinMinutos = Convert.ToDateTime(bbiFInicio.EditValue);
                var fFinSinMinutos = Convert.ToDateTime(bbiFFin.EditValue);
                var vInicio = fInicio.Year + "-" + fInicio.Month + "-" + fInicio.Day + " 23:59:59";
                var vFin = fFin.Year + "-" + fFin.Month + "-" + fFin.Day + " 0:0:0";
                ClsFiltro.FnSetFilter(EntidadActual.ColumnFecha, ">'", "bbiFInicio", vInicio, "' and ", "D");
                ClsFiltro.FnSetFilter(EntidadActual.ColumnFecha, "<'", "bbiFFin", vFin, "' ", "D");
                var fInicio1 = Convert.ToDateTime(bbiFInicio.EditValue).AddDays(0);
                var fFin1 = Convert.ToDateTime(bbiFFin.EditValue).AddDays(1);
                vInicio1 = fInicio1.Year + "-" + fInicio1.Month + "-" + fInicio1.Day + " 0:0:0";
                vFin1 = fFin1.Year + "-" + fFin1.Month + "-" + fFin1.Day + " 0:0:0";
                vInicio1SinMinutos =
                    fInicioSinMinutos.Year + "-" + fInicioSinMinutos.Month + "-" + fInicioSinMinutos.Day;
                vFin1SinMinutos = fFinSinMinutos.Year + "-" + fFinSinMinutos.Month + "-" + fFinSinMinutos.Day;
            }
            else
            {
                vInicio1 = "1999" + "-" + "01" + "-" + "01" + " 0:0:0";
                vFin1 = "2099" + "-" + "12" + "-" + "31" + " 0:0:0";
            }

            CtxReporte = new ContextoReporte();
            bsReporte.DataSource = ClsFiltro.FnExecQuery(vInicio1, vFin1, vInicio1SinMinutos, vFin1SinMinutos);
            vReporte.OptionsView.ShowGroupPanel = false;
            vReporte.OptionsView.ShowFooter = true;
            vReporte.OptionsBehavior.Editable = false;
            //pgReporte.BestFit();
            //pgReporte.BestFitColumnArea();
            //pgReporte.BestFitRowArea();
            //vReporte.BestFitColumns();
        }

        #endregion

        #region FILTRO PERSONALIZADO

        private void rbbiFiltros_ItemClick(object sender, ItemClickEventArgs e)
        {
            FnFiltro(true);
        }

        private void rbbiVerFiltro_ItemClick(object sender, ItemClickEventArgs e)
        {
            FnFiltro(false);
        }

        public void FnFiltro(bool edicion)
        {
            FrmFiltro.FnMostrar(ClsFiltro);
            FrmFiltro.FnDialog(edicion ? EnumEdicion.Editar : EnumEdicion.Visualizar);
            if (FrmFiltro.SeGrabo)
            {
                ClsFiltro.LF_Ctrls = FrmFiltro.ClsFiltro.LF_Ctrls;
                FnActualizar();
            }
        }

        #endregion

        #region LAYOUT

        public void FnConfiguracion()
        {
            var columns = EntidadActual.ReporteDetalle.Where(x => x.TipoInterno == "COLUMN").ToList();
            var bans = EntidadActual.ReporteDetalle.Where(x => x.TipoInterno == "BAND").ToList();
            foreach (var item in columns)
            {
                Grid.FnBandedGridColumn_Basic(item.FieldName, item.Caption, vReporte);
                Grid.FnPivotGridField_Basic(item.FieldName, item.Caption, pgReporte);
            }

            foreach (var item in bans) Grid.FnGridBand_Basic(item.Name, item.Caption, vReporte);
        }

        public void FnLoadLayout()
        {
            bsReporte.DataSource = null;
            if (EntidadActual.ConfXml1 != null)
                vReporte.RestoreLayoutFromStream(new MemoryStream(EntidadActual.ConfXml1));
            if (EntidadActual.ConfXml2 != null)
                pgReporte.RestoreLayoutFromStream(new MemoryStream(EntidadActual.ConfXml2));
            vReporte.BestFitColumns();
        }

        #endregion

        #region IMPRECION

        private void FnVistaPrevia(string tipo)
        {
            DateTime fInicio = new DateTime(), fFin = new DateTime();
            Utils.FnFiltroFecha(ref fInicio, bbiFInicio, ref fFin, bbiFFin);
            Control ctrl = null;
            if (tipo == "GRID") ctrl = gReporte;
            else if (tipo == "PIVOT") ctrl = pgReporte;
            else if (tipo == "CHART") ctrl = ccReporte;
            Print.FnPrint("Horizontal", Text.ToUpper(), fInicio.ToShortDateString() + " - " + fFin.ToShortDateString(),
                ctrl);
        }

        private void FnExportXls(string tipo)
        {
            sfdReporte.Filter = "Excel files (*.xlsx)|*.xlsx";
            sfdReporte.FilterIndex = 0;
            sfdReporte.Title = "Exporte el formato a: ";
            if (tipo == "GRID-CSV") sfdReporte.Filter = "Excel files (*.csv)|*.csv";
            if (sfdReporte.ShowDialog() != DialogResult.OK) return;
            if (tipo == "GRID") vReporte.ExportToXlsx(sfdReporte.FileName);
            else if (tipo == "GRID-CSV")
                vReporte.ExportToCsv(sfdReporte.FileName, new CsvExportOptions(";", Encoding.ASCII));
            else if (tipo == "PIVOT") pgReporte.ExportToXls(sfdReporte.FileName);
            else if (tipo == "CHART") ccReporte.ExportToXls(sfdReporte.FileName);
        }

        //IMPRIMIR
        private void sbPrintGrid_Click(object sender, EventArgs e)
        {
            FnVistaPrevia("GRID");
        }

        private void sbPrintPivot_Click(object sender, EventArgs e)
        {
            FnVistaPrevia("PIVOT");
        }

        private void sbPrintGrafico_Click(object sender, EventArgs e)
        {
            FnVistaPrevia("CHART");
        }

        //EXCEL
        private void sbXlsGrid_Click(object sender, EventArgs e)
        {
            FnExportXls("GRID");
        }

        private void sbXlsPivot_Click(object sender, EventArgs e)
        {
            FnExportXls("PIVOT");
        }

        private void sbXlsGrafico_Click(object sender, EventArgs e)
        {
            FnExportXls("CHART");
        }

        private void sbCsvGrid_Click(object sender, EventArgs e)
        {
            FnExportXls("GRID-CSV");
        }

        private void sbConfGrafico_Click(object sender, EventArgs e)
        {
            new ChartWizard(ccReporte).ShowDialog();
        }

        #endregion
    }
}