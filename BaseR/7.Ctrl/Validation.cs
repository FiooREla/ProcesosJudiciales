using System;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;

namespace BaseR.Ctrls
{
    public class Validation
    {
        public static bool FnNull(TextEdit control)
        {
            var valido = false;
            if (control.EditValue == null || control.EditValue == DBNull.Value ||
                control.EditValue.ToString() == "") valido = true;
            return valido;
        }

        public static bool FnValid(object value)
        {
            var valido = true;
            if (value == null || value == DBNull.Value || value.ToString() == "") valido = false;
            return valido;
        }

        public static bool FnIsNumber(object value)
        {
            if (value == null) return false;
            return Information.IsNumeric(value);
        }

        public static bool FnIsInt(object value)
        {
            if (value == null) return false;
            var x = value.ToString();
            int valueInt;
            return int.TryParse(x, out valueInt);
        }

        public static bool FnIsDecimal(object value)
        {
            if (value == null) return false;
            var x = value.ToString();
            decimal valueInt;
            return decimal.TryParse(x, out valueInt);
        }
    }
}