using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BaseR;
using BaseR.Ctrls;
using BaseR.DB;
using BaseR;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;

namespace BaseR
{
    public partial class FConfiguracion : FBaseForm
    {
        private ContextoReporte CtxReporte = new ContextoReporte();

        private Reporte EntidadActual;

        public FConfiguracion()
        {
            InitializeComponent();
        }

        public override void FnLoadForm()
        {
            PivotGridFieldBase.DefaultDecimalFormat.FormatType = FormatType.Numeric;
            PivotGridFieldBase.DefaultDecimalFormat.FormatString = "n2";
            FnActualizar();
            Glue.FnGlueSiNo(new object[] {glueFiltro, glueFecha, gluePivot});
            FFormEdicion.WindowState = FormWindowState.Maximized;
        }

        public override void FnActualizar()
        {
            CtxReporte = new ContextoReporte();
            bsLista.DataSource = CtxReporte.Reporte.ToList();
        }

        #region EDICION

        public override bool FnEdicion()
        {
            if (TipoEdicion == EnumEdicion.Nuevo)
            {
                if (!string.IsNullOrEmpty(vLista.ActiveFilterString))
                    vLista.FocusedRowHandle = GridControl.AutoFilterRowHandle;
                EntidadActual = new Reporte();
                EntidadActual.Query = null;
                EntidadActual.Filtro = false;
                EntidadActual.MostrarPivot = false;
                EntidadActual.FiltroFecha = false;
                bsLista.Add(EntidadActual);
                bsLista.MoveLast();
            }

            EntidadActual = (Reporte) bsLista.Current;
            sbRestaurar_Click(null, null);
            FnConfiguracion();
            FnDetalles();
            if (EntidadActual.ConfXml1 != null)
                vPreview.RestoreLayoutFromStream(new MemoryStream(EntidadActual.ConfXml1));
            if (EntidadActual.ConfXml2 != null)
                pgPreview.RestoreLayoutFromStream(new MemoryStream(EntidadActual.ConfXml2));
            vPreview.OptionsView.ShowFooter = true;
            vPreview.OptionsBehavior.Editable = false;
            return true;
        }

        private void FnDetalles()
        {
            bsDetalle1.DataSource = EntidadActual.ReporteDetalle.Where(x => x.TipoInterno == "COLUMN").ToList();
            bsDetalle2.DataSource = EntidadActual.ReporteDetalle.Where(x => x.TipoInterno == "BAND").ToList();
        }

        #endregion

        #region GRABAR, CANCELAR

        public override bool FnGrabar()
        {
            if (TipoEdicion == EnumEdicion.Borrar)
            {
                bsLista.RemoveCurrent();
                CtxReporte.DeleteObject(EntidadActual);
            }
            else if (TipoEdicion == EnumEdicion.Nuevo)
            {
                CtxReporte.AddToReporte(EntidadActual);
            }

            var stream1 = new MemoryStream();
            vPreview.SaveLayoutToStream(stream1);
            EntidadActual.ConfXml1 = stream1.ToArray();
            //var uri = Path.GetTempPath() + EntidadActual.Codigo + ".layout.xml";
            //vPreview.SaveLayoutToXml(uri);
            //EntidadActual.ConfXml1 = System.IO.File.ReadAllBytes(uri);
            //'
            var stream2 = new MemoryStream();
            pgPreview.SaveLayoutToStream(stream2);
            EntidadActual.ConfXml2 = stream2.ToArray();
            bsLista.EndEdit();
            CtxReporte.SaveChanges();
            //FnMenu.FnActualizarMenu()
            vLista.RefreshData();
            vPreview.HideCustomization();
            return true;
        }

        public override void FnCancelar()
        {
            if (TipoEdicion == EnumEdicion.Nuevo) bsLista.RemoveCurrent();
            Contexto.FnCancelarCambios(CtxReporte);
            bsLista.CancelEdit();
            vPreview.HideCustomization();
        }

        #endregion

        #region CONFIGURACION

        private void sbGenerar_Click(object sender, EventArgs e)
        {
            var sql = new FnSQL();
            var dt = sql.FnQueryData(EntidadActual.Query);
            bsReporte.DataSource = dt;
            foreach (DataColumn item in dt.Columns)
            {
                var fieldName = item.ColumnName;
                var column = EntidadActual.ReporteDetalle.FirstOrDefault(x => x.FieldName == fieldName);
                if (column == null)
                {
                    column = new ReporteDetalle();
                    column.Numero = 0;
                    column.FieldName = item.ColumnName;
                    column.Caption = item.ColumnName;
                    column.Name = "col_" + column.FieldName;
                    column.TipoInterno = "COLUMN";
                    EntidadActual.ReporteDetalle.Add(column);
                    Grid.FnBandedGridColumn(column.FieldName, column.Caption, vPreview);
                    Grid.FnPivotGridField(column.FieldName, column.Caption, pgPreview);
                }
            }

            FnDetalles();
        }

        private void sbColumnsCustomization_Click(object sender, EventArgs e)
        {
            vPreview.ColumnsCustomization();
        }

        private void sbAjusteColumna_Click(object sender, EventArgs e)
        {
            vPreview.BestFitColumns();
        }

        public void FnConfiguracion()
        {
            var columns = EntidadActual.ReporteDetalle.Where(x => x.TipoInterno == "COLUMN").ToList();
            var bans = EntidadActual.ReporteDetalle.Where(x => x.TipoInterno == "BAND").ToList();
            foreach (var item in columns)
            {
                Grid.FnBandedGridColumn(item.FieldName, item.Caption, vPreview);
                Grid.FnPivotGridField(item.FieldName, item.Caption, pgPreview);
            }

            foreach (var item in bans) Grid.FnGridBand(item.Name, item.Caption, vPreview);
        }

        private void sbRestaurar_Click(object sender, EventArgs e)
        {
            vPreview.Columns.Clear();
            vPreview.Bands.Clear();
            pgPreview.Fields.Clear();
            bsReporte.DataSource = null;
        }

        #endregion

        #region ELIMINAR DETALLE

        private void rpiBtnEliminar1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (Msg.FnMessage("Q", "Eliminar Fila.?") == DialogResult.Yes)
            {
                var item = (ReporteDetalle) vColumna.GetRow(vColumna.FocusedRowHandle);
                var column = vPreview.Columns.FirstOrDefault(x => x.FieldName == item.FieldName);
                vPreview.Columns.Remove(column);
                CtxReporte.DeleteObject(item);
                vColumna.DeleteRow(vColumna.FocusedRowHandle);
            }
        }

        private void rpiBtnEliminar2_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (Msg.FnMessage("Q", "Eliminar Fila.?") == DialogResult.Yes)
            {
                var item = (ReporteDetalle) vBanda.GetRow(vBanda.FocusedRowHandle);
                var band = vPreview.Bands.FirstOrDefault(x => x.Name == item.Name);
                vPreview.Bands.Remove(band);
                CtxReporte.DeleteObject(item);
                vBanda.DeleteRow(vBanda.FocusedRowHandle);
            }
        }

        #endregion

        #region CellValueChanged, InitNewRow

        private void vBanda_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var item = (ReporteDetalle) vBanda.GetRow(e.RowHandle);
            var nro = EntidadActual.ReporteDetalle.Where(x => x.TipoInterno == "BAND").Count() + 1;
            item.Numero = nro;
            item.Name = "colBan_" + nro;
            item.TipoInterno = "BAND";
            EntidadActual.ReporteDetalle.Add(item);
            Grid.FnGridBand(item.Name, item.Caption, vPreview);
        }

        private void vColumna_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Caption")
            {
                var item = (ReporteDetalle) vColumna.GetRow(e.RowHandle);
                var column = vPreview.Columns.FirstOrDefault(x => x.FieldName == item.FieldName);
                var pgColumn = pgPreview.Fields[item.FieldName];
                column.Caption = item.Caption;
                pgColumn.Caption = item.Caption;
            }
        }

        private void vBanda_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Caption")
            {
                var item = (ReporteDetalle) vBanda.GetRow(e.RowHandle);
                var column = vPreview.Bands.FirstOrDefault(x => x.Name == item.Name);
                column.Caption = item.Caption;
            }
        }

        #endregion

        #region PROPIEDADES

        private bool Pivot;

        private void vColumna_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (Pivot)
            {
                var item = (ReporteDetalle) vColumna.GetRow(e.FocusedRowHandle);
                if (item == null) return;
                var column = pgPreview.Fields[item.FieldName];
                propertyGridControl1.SelectedObject = column;
            }
            else
            {
                var item = (ReporteDetalle) vColumna.GetRow(e.FocusedRowHandle);
                if (item == null) return;
                var column = vPreview.Columns.FirstOrDefault(x => x.FieldName == item.FieldName);
                propertyGridControl1.SelectedObject = column;
            }
        }

        private void vBanda_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var item = (ReporteDetalle) vBanda.GetRow(e.FocusedRowHandle);
            if (item == null) return;
            var column = vPreview.Bands.FirstOrDefault(x => x.Name == item.Name);
            propertyGridControl1.SelectedObject = column;
        }

        private void gPreview_DoubleClick(object sender, EventArgs e)
        {
            Pivot = false;
            propertyGridControl1.SelectedObject = vPreview;
        }

        private void pgPreview_DoubleClick(object sender, EventArgs e)
        {
            Pivot = true;
            propertyGridControl1.SelectedObject = pgPreview;
        }

        #endregion
    }
}