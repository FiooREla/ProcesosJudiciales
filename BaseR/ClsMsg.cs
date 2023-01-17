using System.Windows.Forms;
using DevExpress.XtraEditors;

public class ClsMsg
{
    public static DialogResult FnMessage(MessageBoxIcon tipoMsg, string message)
    {
        var res = DialogResult.OK;
        if (tipoMsg == MessageBoxIcon.Question)
            res = XtraMessageBox.Show(message, "Pregunta.!", MessageBoxButtons.YesNo, tipoMsg);
        else if (tipoMsg == MessageBoxIcon.Error)
            res = XtraMessageBox.Show(message, "Error.!", MessageBoxButtons.OK, tipoMsg);
        else if (tipoMsg == MessageBoxIcon.Warning)
            res = XtraMessageBox.Show(message, "Advertencia.!", MessageBoxButtons.YesNo, tipoMsg);
        else if (tipoMsg == MessageBoxIcon.Exclamation)
            res = XtraMessageBox.Show(message, "Exclamación.!", MessageBoxButtons.OK, tipoMsg);
        else if (tipoMsg == MessageBoxIcon.Information)
            res = XtraMessageBox.Show(message, "OK.!", MessageBoxButtons.OK, tipoMsg);
        else res = XtraMessageBox.Show(message, "Mensaje.", MessageBoxButtons.OK, tipoMsg);
        return res;
    }
}