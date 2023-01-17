using Caudalosa.View.MUsuario;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Sistema.UI;

namespace Sistema.Main
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FLogin flogin = new FLogin();
            flogin.ShowDialog();
            if (flogin.EsValido)
            {
                Application.Run(new FSistema());
            }
        }
    }
}
