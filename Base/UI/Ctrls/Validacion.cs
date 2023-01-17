using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars;
using System.Linq;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Base.UI;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Base.UI.Ext
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

    public class ValidationRuleControl : ValidationRule
    {
        public ValidationRuleControl(Control ctrl)
        {
            if (ctrl == null) return;
            if (ctrl.Tag == null) return;
            var tag = ctrl.Tag.ToString();
            var error = "";
            if (tag == "N")
            {
                error = "El campo no acepta valores nulos.";
            }
            else if (tag.StartsWith("N"))
            {
                if (tag.EndsWith("N-N")) error = "Solo numeros y no vacios.";
                else if (tag.EndsWith("N-S")) error = "Solo numeros.";
                else if (tag.StartsWith("N-N<"))
                    error = "Solo numeros, no vacios y asta " + tag.Replace("N-N<", "") + " caracteres.";
                else if (tag.StartsWith("N-S<"))
                    error = "Solo numeros y asta " + tag.Replace("N-S<", "") + " caracteres.";
                else if (tag.StartsWith("N-N="))
                    error = "Solo numeros, no vacios y " + tag.Replace("N-N=", "") + " caracteres.";
                else if (tag.StartsWith("N-S=")) error = "Solo numeros y " + tag.Replace("N-S=", "") + " caracteres.";
            }
            else if (tag.StartsWith("D"))
            {
                if (tag.EndsWith("D-N")) error = "Solo importes y no vacios.";
                else if (tag.EndsWith("D-S")) error = "Solo importes.";
                else if (tag.StartsWith("D-N=8"))
                    error = "Solo importes, no vacios y " + tag.Replace("D-N=", "") + " decimales.";
                else if (tag.StartsWith("D-S=8")) error = "Solo importes y " + tag.Replace("D-S=", "") + " decimales.";
            }
            else if (tag.StartsWith("S"))
            {
                if (tag.EndsWith("S-N")) error = "Letras y no vacios.";
                else if (tag.EndsWith("S-S")) error = "Letras.";
                else if (tag.StartsWith("S-N<")) error = "Letras, no vacios y asta " + tag.Replace("S-N<", "") + ".";
                else if (tag.StartsWith("S-S<")) error = "Letras y asta " + tag.Replace("S-S<", "") + ".";
                else if (tag.StartsWith("S-N="))
                    error = "Letras, no vacios y " + tag.Replace("S-N=", "") + "caracteres.";
                else if (tag.StartsWith("S-S=")) error = "Letras y " + tag.Replace("S-S=", "") + "caracteres.";
            }

            ErrorText = error;
            ErrorType = ErrorType.Critical;
        }

        public override bool Validate(Control control, object valueCtrl)
        {
            if (!control.Visible || !control.Enabled || control.Tag == null) return true;
            var tag = control.Tag.ToString();
            var value = valueCtrl;
            var valido = true;
            if (control is GridLookUpEdit)
            {
                var glue = control as GridLookUpEdit;
                if (glue.Properties.GetDisplayText(valueCtrl) == null ||
                    string.IsNullOrEmpty(glue.Properties.GetDisplayText(valueCtrl))) value = null;
            }
            else
            {
                value = valueCtrl;
            }

            if (tag == "N")
            {
                valido = Validation.FnValid(value);
            }
            else
            {
                if (tag.StartsWith("N"))
                {
                    int nro, len = value.ToString().Length;
                    var isNumber = int.TryParse(value.ToString(), out nro);

                    if (tag.Contains("-N")) valido = isNumber && Validation.FnValid(value);
                    if (valido)
                        if (tag.StartsWith("N-S<"))
                        {
                            var nroStr = Convert.ToInt32(tag.Replace("N-S<", ""));
                            if (len != 0) valido = isNumber && len < nroStr;
                        }
                        else if (tag.StartsWith("N-N<"))
                        {
                            var nroStr = Convert.ToInt32(tag.Replace("N-N<", ""));
                            valido = isNumber && Validation.FnValid(value) && len < nroStr;
                        }
                        else if (tag.StartsWith("N-S="))
                        {
                            var nroStr = Convert.ToInt32(tag.Replace("N-S=", ""));
                            if (len != 0) valido = isNumber && len == nroStr;
                        }
                        else if (tag.StartsWith("N-N="))
                        {
                            var nroStr = Convert.ToInt32(tag.Replace("N-N=", ""));
                            valido = isNumber && Validation.FnValid(value) && len == nroStr;
                        }
                }

                //else if (tag.StartsWith("D"))
                //{
                //    if (tag.EndsWith("D-N")) error = "Solo importes y no vacios.";
                //    else if (tag.EndsWith("D-S")) error = "Solo importes.";
                //    else if (tag.StartsWith("D-N=8")) error = "Solo importes, no vacios y " + tag.Replace("D-N=", "") + "decimales.";
                //    else if (tag.StartsWith("D-S=8")) error = "Solo importes y " + tag.Replace("D-S=", "") + " decimales.";
                //}
                //else if (tag.StartsWith("S"))
                //{
                //    if (tag.EndsWith("S-N")) error = "Letras y no vacios.";
                //    else if (tag.EndsWith("S-S")) error = "Letras.";
                //    else if (tag.StartsWith("S-N<")) error = "Letras, no vacios y asta " + tag.Replace("S-N<", "") + ".";
                //    else if (tag.StartsWith("S-S<")) error = "Letras y asta " + tag.Replace("S-S<", "") + ".";
                //    else if (tag.StartsWith("S-N=")) error = "Letras, no vacios y " + tag.Replace("S-N=", "") + "caracteres.";
                //    else if (tag.StartsWith("S-S=")) error = "Letras y " + tag.Replace("S-S=", "") + "caracteres.";
                //}
            }

            return valido;
        }
    }

    public class ValidationRuleNotNull : ValidationRule
    {
        public ValidationRuleNotNull(string errorText, ErrorType errorType)
        {
            this.ErrorText = errorText;
            this.ErrorType = errorType;
        }
        public override bool Validate(Control control, object value)
        {
            if (value == null) return false;
            if (value.ToString().Length == 0) return false;
            if (value.ToString() == "0") return false;
            if (control is TextEdit) { if (value == null || value.ToString() == "") return false; }
            else if ((control as DevExpress.XtraEditors.LookUpEditBase).Properties.GetDisplayText(value) == null || string.IsNullOrEmpty((control as DevExpress.XtraEditors.LookUpEditBase).Properties.GetDisplayText(value))) return false;
            return true;
        }
    }

    public class ExtControls
    {
        public static IList<T> FnGetControls<T>(Control control) where T : Control
        {
            var rtn = new List<T>();
            if (control == null)
            {
                return rtn;
            }
            foreach (Control item in control.Controls)
            {
                var ctr = item as T;
                if (ctr != null)
                {
                    rtn.Add(ctr);
                }
                else
                {
                    rtn.AddRange(FnGetControls<T>(item));
                }
            }
            return rtn;
        }

        public static List<T> FnGetControlsRpi<T>(Control control) where T : RepositoryItemGridLookUpEditBase
        {
            var rtn = new List<T>();
            if (control == null) return rtn;
            foreach (Control item in control.Controls)
            {
                var ctr = item as T;
                if (ctr != null) rtn.Add(ctr);
                else rtn.AddRange(FnGetControlsRpi<T>(item));
            }

            return rtn;
        }
    }
}