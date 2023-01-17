using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;

namespace BaseR
{
    public partial class FBaseFormEdicion : XtraForm
    {
        public delegate void Event_LuegoEdicionEventHandler(EnumOperacion operacion);

        public FBaseFormEdicion()
        {
            InitializeComponent();
        }

        public FBaseFormEdicion(DataLayoutControl dlControl, string titulo)
        {
            InitializeComponent();
            DLControl = dlControl;
            Size = new Size(DLControl.Width + 30, DLControl.Height + 140);
            Title = titulo;
            DLControl.Dock = DockStyle.Fill;
            pcEdicion.Controls.Add(DLControl);
            SeMostroFormulario = false;
        }

        private string Title { get; }
        private DataLayoutControl DLControl { get; }
        private Control FirstControl { get; set; }
        private bool SeMostroFormulario { get; set; }
        public event Event_LuegoEdicionEventHandler Event_LuegoEdicion;

        public void FnEdicion(EnumEdicion tipo, Control ctrl = null)
        {
            SeMostroFormulario = false;
            FirstControl = ctrl;
            if (btnOtro.Tag == null) btnOtro.Visibility = BarItemVisibility.Never;
            Text = Title + " [ " + (tipo == EnumEdicion.Borrar ? "Borrar" :
                       tipo == EnumEdicion.Editar ? "Editar" :
                       tipo == EnumEdicion.Nuevo ? "Nuevo" : "Visualizar") + " ]";
            StartPosition = FormStartPosition.CenterScreen;
            GrupoDatos.Visible = tipo != EnumEdicion.Visualizar;
            if (GrupoOtros.Tag != null) GrupoOtros.Visible = tipo != EnumEdicion.Visualizar;
            else GrupoOtros.Visible = false;
            GrupoOpcion.Visible = tipo == EnumEdicion.Visualizar;
            DLControl.OptionsView.IsReadOnly = tipo == EnumEdicion.Visualizar || tipo == EnumEdicion.Borrar
                ? DefaultBoolean.True
                : DefaultBoolean.False;
            ShowDialog();
        }

        private void btnGrabar_ItemClick(object sender, ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}");
            Event_LuegoEdicion(EnumOperacion.Grabar);
        }

        private void btnCancelar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Event_LuegoEdicion(EnumOperacion.Carcelar);
        }

        private void btnOtro_ItemClick(object sender, ItemClickEventArgs e)
        {
            Event_LuegoEdicion(EnumOperacion.Otro);
        }

        private void FBaseEdicion_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Escape) Event_LuegoEdicion(EnumOperacion.Carcelar);*/
        }

        private void btnCerrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void FBaseFormEdicion_Activated(object sender, EventArgs e)
        {
            if (!SeMostroFormulario && FirstControl != null) FirstControl.Select();
            SeMostroFormulario = true;
        }
    }
}