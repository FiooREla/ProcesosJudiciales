using DevExpress.Utils;
using DevExpress.XtraLayout;

namespace BaseR.Ctrls
{
    public class Layout
    {
        public static void FnLayoutControlEdicion(EnumEdicion tipoEdicion, LayoutControl lControl)
        {
            if (tipoEdicion == EnumEdicion.Nuevo || tipoEdicion == EnumEdicion.Editar)
                lControl.OptionsView.IsReadOnly = DefaultBoolean.False;
            else
                lControl.OptionsView.IsReadOnly = DefaultBoolean.True;
        }
    }
}