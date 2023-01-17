using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.Container;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BaseR
{
    [DesignerCategory("")]
    public class ExtGridView : GridView
    {
        public ExtGridView() : this(null)
        {
        }

        public ExtGridView(GridControl grid)
            : base(grid)
        {
            OptionsView.AllowCellMerge = true;
        }

        protected override string ViewName => "ExtGridView";

        protected override void ActivateEditor(GridCellInfo cell)
        {
            if (cell.MergedCell == null)
                base.ActivateEditor(cell);
            else
                ActivateMergedCellEditor(cell);
        }

        private void ActivateMergedCellEditor(GridCellInfo cell)
        {
            if (cell == null) return;
            cell = cell.MergedCell.MergedCells[0];
            fEditingCell = cell;
            var bounds = GetMergedEditorBounds(cell);
            if (bounds.IsEmpty) return;
            var cellEdit = RequestCellEditor(cell);
            ViewInfo.UpdateCellAppearance(cell);
            ViewInfo.RequestCellEditViewInfo(cell);
            var appearance = new AppearanceObject();
            AppearanceHelper.Combine(appearance,
                new[] {GetEditorAppearance(), ViewInfo.PaintAppearance.Row, cell.Appearance});
            if (cellEdit != cell.Editor && cellEdit.DefaultAlignment != HorzAlignment.Default)
                appearance.TextOptions.HAlignment = cellEdit.DefaultAlignment;
            UpdateEditor(cellEdit,
                new UpdateEditorInfoArgs(GetColumnReadOnly(cell.ColumnInfo.Column), bounds, appearance, cell.CellValue,
                    ElementsLookAndFeel, cell.ViewInfo.ErrorIconText, cell.ViewInfo.ErrorIcon));
            ViewInfo.UpdateCellAppearance(cell);
            if (cell != null)
                InvalidateRow(cell.RowHandle);
        }

        private Rectangle GetMergedEditorBounds(GridCellInfo cell)
        {
            var r = cell.CellValueRect;
            var bounds = ViewInfo.UpdateFixedRange(r, cell.ColumnInfo);
            if (bounds.Right > ViewInfo.ViewRects.Rows.Right)
                bounds.Width = ViewInfo.ViewRects.Rows.Right - bounds.Left;
            if (bounds.Bottom > ViewInfo.ViewRects.Rows.Bottom)
                bounds.Height = ViewInfo.ViewRects.Rows.Bottom - bounds.Top;
            if (bounds.Width < 1 || bounds.Height < 1) return Rectangle.Empty;
            ;

            for (var i = 1; i < cell.MergedCell.MergedCells.Count; i++)
                bounds.Height += cell.MergedCell.MergedCells[i].Bounds.Height;
            return bounds;
        }

        protected override bool PostEditor(bool causeValidation)
        {
            if (IsEditing)
                if (fEditingCell.MergedCell != null)
                {
                    var CurValue = ExtractEditingValue(fEditingCell.ColumnInfo.Column, EditingValue);
                    for (var i = 0; i < fEditingCell.MergedCell.MergedCells.Count; i++)
                        SetRowCellValue(fEditingCell.RowHandle + i, fEditingCell.Column, CurValue);
                }

            return base.PostEditor(causeValidation);
        }
    }
}