using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraDataLayout;
using DevExpress.XtraTab;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace Base.UI
{
    public partial class FBaseEdicion : DevExpress.XtraEditors.XtraForm
    {
        DataLayoutControl DLControl { get; set; }
        string Title { get; set; }
        public event Event_LuegoEdicionEventHandler Event_LuegoEdicion;
        public delegate void Event_LuegoEdicionEventHandler(EnumOperacion operacion);

        public FBaseEdicion(DataLayoutControl dlControl, string titulo)
        {
            InitializeComponent();
            DLControl = dlControl;
            this.Size = new Size(DLControl.Width + 30, DLControl.Height + 140);
            Title = titulo;
            DLControl.Dock = DockStyle.Fill;
            pcEdicion.Controls.Add(DLControl);
        }

        public FBaseEdicion()
        {
            InitializeComponent();
        }

        public void FnEdicion(EnumEdicion tipo, bool maximizado=false)
        {
            this.Text = Title + " [ " + (tipo == EnumEdicion.Borrar ? "Borrar" : tipo == EnumEdicion.Editar ? "Editar" : tipo == EnumEdicion.Nuevo ? "Nuevo" : "Visualizar") + " ]";
            this.StartPosition = FormStartPosition.CenterScreen;
            GrupoDatos.Visible = tipo != EnumEdicion.Visualizar;
            GrupoOpcion.Visible = tipo == EnumEdicion.Visualizar;
            DLControl.OptionsView.IsReadOnly = tipo == EnumEdicion.Visualizar || tipo == EnumEdicion.Borrar ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            if (maximizado)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            this.ShowDialog();
        }

        private void btnGrabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { Event_LuegoEdicion(EnumOperacion.Grabar); }
        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { Event_LuegoEdicion(EnumOperacion.Carcelar); }
        private void FBaseEdicion_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Escape) Event_LuegoEdicion(EnumOperacion.Carcelar); }
        private void btnCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { this.Close(); }        

    }
}