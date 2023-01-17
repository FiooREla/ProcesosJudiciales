using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace BaseR
{
    public class ExtGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName => "ExtGridView";

        public override BaseView CreateView(GridControl grid)
        {
            return new ExtGridView(grid);
        }
    }
}