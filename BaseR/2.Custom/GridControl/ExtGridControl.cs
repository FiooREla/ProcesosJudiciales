using System.ComponentModel;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace BaseR
{
    [DesignerCategory("")]
    public class ExtGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            return CreateView("ExtGridView");
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new ExtGridViewInfoRegistrator());
        }
    }
}