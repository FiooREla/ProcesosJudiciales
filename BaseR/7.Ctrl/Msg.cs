using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BaseR.Ctrls
{
    public class Msg
    {
        public static DialogResult FnMessage(string tipo, string message)
        {
            var res = DialogResult.OK;
            if (tipo == "E") res = XtraMessageBox.Show(message, "Error.!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tipo == "Q")
                res = XtraMessageBox.Show(message, "Pregunta.!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else if (tipo == "I")
                res = XtraMessageBox.Show(message, "Información.!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
            else if (tipo == "W")
                res = XtraMessageBox.Show(message, "Advertencia.!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
            else if (tipo == "R")
                res = XtraMessageBox.Show(message, "OK.!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return res;
        }
    }
}