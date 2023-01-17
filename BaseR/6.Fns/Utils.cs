using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace BaseR
{
    public class ClsUtils
    {
        public static int NewItemRow => GridControl.NewItemRowHandle;

        public static void FnSetTagControl(Control[] controles, string tag)
        {
            foreach (var item in controles) item.Tag = tag;
        }
    }
}