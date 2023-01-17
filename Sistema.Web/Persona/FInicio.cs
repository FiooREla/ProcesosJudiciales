using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Sistema.UI.Persona
{
    public partial class FInicio : DevExpress.XtraEditors.XtraForm
    {
        public FInicio()
        {
            InitializeComponent();
        }

        private void FInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   e.Cancel = true;
        }
    }
}