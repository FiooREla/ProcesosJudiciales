using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;

namespace BaseR.Ctrls
{
    public class Grid
    {
        #region BASICO

        public static GridBand FnGridBand_Basic(string name, string caption, AdvBandedGridView view = null)
        {
            var item = new GridBand();
            item.Name = name;
            item.Caption = caption;
            if (view != null) view.Bands.Add(item);
            return item;
        }

        public static BandedGridColumn FnBandedGridColumn_Basic(string fieldName, string caption,
            AdvBandedGridView view = null)
        {
            var item = new BandedGridColumn();
            item.Name = "col_" + fieldName;
            item.FieldName = fieldName;
            item.Caption = caption;
            item.AppearanceHeader.Options.UseTextOptions = true;
            item.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            item.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            item.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
            if (view != null) view.Columns.Add(item);
            return item;
        }

        public static PivotGridField FnPivotGridField_Basic(string fieldName, string caption,
            PivotGridControl view = null)
        {
            var item = new PivotGridField();
            item.Name = "colPivot_" + fieldName;
            item.FieldName = fieldName;
            item.Caption = caption;
            if (view != null) view.Fields.Add(item);
            return item;
        }

        #endregion

        #region FORMATO

        public static GridBand FnGridBand(string name, string caption, AdvBandedGridView view = null)
        {
            var item = new GridBand();
            item.Name = name;
            item.Caption = caption;
            item.Width = 207;
            if (view != null) view.Bands.Add(item);
            return item;
        }

        public static BandedGridColumn FnBandedGridColumn(string fieldName, string caption,
            AdvBandedGridView view = null)
        {
            var item = new BandedGridColumn();
            item.AppearanceHeader.Options.UseTextOptions = true;
            item.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            item.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            item.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
            item.Name = "col_" + fieldName;
            item.FieldName = fieldName;
            item.Caption = caption;
            item.Visible = false;
            item.Width = 75;
            if (view != null) view.Columns.Add(item);
            return item;
        }

        public static PivotGridField FnPivotGridField(string fieldName, string caption, PivotGridControl view = null)
        {
            var item = new PivotGridField();
            item.Name = "colPivot_" + fieldName;
            item.FieldName = fieldName;
            item.Caption = caption;
            if (view != null) view.Fields.Add(item);
            return item;
        }

        public static void FnGridViewEdicion(EnumEdicion tipoEdicion, GridView[] views, bool filtro = true)
        {
            foreach (var view in views)
            {
                view.OptionsView.ShowAutoFilterRow = false;
                if (tipoEdicion == EnumEdicion.Nuevo || tipoEdicion == EnumEdicion.Editar)
                {
                    view.OptionsBehavior.Editable = true;
                    view.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                    if (filtro) view.OptionsView.ShowAutoFilterRow = false;
                }
                else
                {
                    view.OptionsBehavior.Editable = false;
                    view.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    if (filtro) view.OptionsView.ShowAutoFilterRow = true;
                }
            }
        }

        #endregion
    }
}