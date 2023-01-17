using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaseR.Ctrls;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace BaseR
{
    public partial class FBaseModalV2 : XtraForm
    {
        public bool AutoTitle = true;
        public DataLayoutControl DLControl;
        public LayoutControl DLControl2;
        public List<Control> LC_Default = new List<Control>();
        public List<Control> LC_Validar = new List<Control>();
        private readonly bool SeCargo = false;
        private bool SeMostroFormulario;
        public EnumEdicion TipoEdicion;

        public FBaseModalV2()
        {
            InitializeComponent();
        }

        public bool SeGrabo { get; set; }
        public FBaseFormV2 FBase { get; set; }
        public Control FirstControl { get; set; }

        private void FBaseModal_Load(object sender, EventArgs e)
        {
            if (SeCargo) return;
            //FnLoadBasic();
            FnControl();
        }

        public void FnLoadBasic()
        {
            if (DLControl != null || DLControl2 != null) return;
            try
            {
                var ctrl = Controls.Find("dlcData", true).FirstOrDefault();
                if (ctrl is DataLayoutControl) DLControl = (DataLayoutControl)ctrl;
                if (DLControl == null && ctrl is LayoutControl) DLControl2 = (LayoutControl)ctrl;
            }
            catch (Exception)
            {
            }
        }

        public virtual void FnMostrar()
        {
        }

        public virtual void FnLoadForm()
        {
        }

        public void FnDialog(EnumEdicion tipo)
        {
            FnLoadBasic();
            SeMostroFormulario = false;
            TipoEdicion = tipo;
            if (tipo == EnumEdicion.Nuevo || tipo == EnumEdicion.Editar)
            {
                if (DLControl != null && DLControl.Tag == null) DLControl.OptionsView.IsReadOnly = DefaultBoolean.False;
                if (DLControl2 != null && DLControl2.Tag == null)
                    DLControl2.OptionsView.IsReadOnly = DefaultBoolean.False;
            }
            else
            {
                if (DLControl != null && DLControl.Tag == null) DLControl.OptionsView.IsReadOnly = DefaultBoolean.True;
                if (DLControl2 != null && DLControl2.Tag == null)
                    DLControl2.OptionsView.IsReadOnly = DefaultBoolean.True;
            }

            GrupoDatos.Visible = tipo != EnumEdicion.Visualizar;
            GrupoOpcion.Visible = tipo == EnumEdicion.Visualizar;
            if (AutoTitle && FBase != null)
            {
                var title = tipo == EnumEdicion.Nuevo
                    ? "Nuevo"
                    : (tipo == EnumEdicion.Editar ? "Editar" : tipo == EnumEdicion.Borrar ? "Borrar" : "Visualizar");
                Text = FBase.Text + " [ " + title + " ]";
            }

            SeGrabo = false;
            ShowDialog();
        }

        public void FnLuegoEdicion(EnumOperacion tipo)
        {
            if (tipo == EnumOperacion.Grabar)
            {
                if (Tag == null)
                {
                    if  (TipoEdicion == EnumEdicion.Visualizar){
                        return;
                    }

                    var msg = "Los datos son conformes.?";
                    if (TipoEdicion == EnumEdicion.Borrar) msg = "Seguro que desea borrar el registro.?";
                    var result = XtraMessageBox.Show(msg, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No || !FnGrabar()) return;
                    SeGrabo = true;
                }
                else
                {
                    if (!FnGrabar()) return;
                    SeGrabo = true;
                }
            }
            else if (tipo == EnumOperacion.Carcelar)
            {
                FnCancelar();
                SeGrabo = false;
            }

            Close();
        }

        public virtual bool FnMostrarForm()
        {
            return true;
        }

        public virtual bool FnGrabar()
        {
            return true;
        }

        public virtual void FnCancelar()
        {
        }

        public virtual void FnValidarRunTime()
        {
        }

        private bool FnValidar()
        {
            FnValidarRunTime();
            foreach (var item in LC_Default) DxValidacion.SetValidationRule(item, new ValidationRuleControl(item));
            foreach (var item in LC_Validar) DxValidacion.SetValidationRule(item, new ValidationRuleControl(item));
            return DxValidacion.Validate();
        }

        private void btnGrabar_ItemClick(object sender, ItemClickEventArgs e)
        {
            SendKeys.SendWait("{TAB}");
            var valido = true;
            if (TipoEdicion != EnumEdicion.Borrar) valido = FnValidar();
            if (!valido) return;
            FnLuegoEdicion(EnumOperacion.Grabar);
        }

        private void btnCancelar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FnLuegoEdicion(EnumOperacion.Carcelar);
        }

        private void btnCerrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void FBaseModal_Activated(object sender, EventArgs e)
        {
            if (!SeMostroFormulario && FirstControl != null) FirstControl.Focus();
            SeMostroFormulario = true;
        }

        //VIRTUAL LANZAR EVENTOS
        public virtual void FnInvoke(object sender, string e)
        {
        }

        #region Datos por defecto y validaciones

        private readonly DXValidationProvider DxValidacion = new DXValidationProvider();

        public void FnControl()
        {
            if (DLControl == null && DLControl2 == null) return;
            var grids2 = new List<GridControl>();
            if (DLControl != null) grids2 = ExtControls.FnGetControls<GridControl>(DLControl);
            if (DLControl2 != null) grids2 = ExtControls.FnGetControls<GridControl>(DLControl2);
            foreach (var item in grids2)
            {
                item.EmbeddedNavigator.Buttons.Append.Visible = false;
                item.EmbeddedNavigator.Buttons.Edit.Visible = false;
                item.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                item.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                item.EmbeddedNavigator.Buttons.Remove.Visible = false;
                foreach (var rpi in item.RepositoryItems)
                {
                    var name = rpi.GetType().Name;
                    if (rpi.GetType().Name == "RepositoryItemComboBox")
                    {
                        var rpiCB = rpi as RepositoryItemComboBox;
                        rpiCB.ValidateOnEnterKey = true;
                        rpiCB.AppearanceDisabled.ForeColor = Color.Black;
                        rpiCB.AppearanceDisabled.Options.UseForeColor = true;
                        rpiCB.NullText = "";
                        rpiCB.ImmediatePopup = true;
                        if (rpiCB.Tag == null) rpiCB.TextEditStyle = TextEditStyles.DisableTextEditor;
                    }

                    if (rpi.GetType().Name == "RepositoryItemGridLookUpEdit") Glue.FnGlueBase(rpi);
                }

                foreach (var viewItem in item.Views)
                {
                    var view = viewItem as GridView;
                    view.OptionsNavigation.EnterMoveNextColumn = true;
                }
            }

            var glues = new List<GridLookUpEdit>();
            if (DLControl != null) glues = ExtControls.FnGetControls<GridLookUpEdit>(DLControl);
            if (DLControl2 != null) glues = ExtControls.FnGetControls<GridLookUpEdit>(DLControl2);

            foreach (var item in glues)
            {
                item.Properties.AppearanceDisabled.ForeColor = Color.Black;
                item.Properties.AppearanceDisabled.Options.UseForeColor = true;
                Glue.FnGlueBase(item);
                if (item.Tag != null) LC_Default.Add(item);
            }

            var dates = new List<DateEdit>();
            if (DLControl != null) dates = ExtControls.FnGetControls<DateEdit>(DLControl);
            if (DLControl2 != null) dates = ExtControls.FnGetControls<DateEdit>(DLControl2);
            foreach (var item in dates)
            {
                item.Properties.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                item.Properties.TextEditStyle = TextEditStyles.Standard;
                item.Properties.ValidateOnEnterKey = true;
                item.Properties.AppearanceDisabled.ForeColor = Color.Black;
                item.Properties.AppearanceDisabled.Options.UseForeColor = true;
            }

            var txts = new List<TextEdit>();
            if (DLControl != null) txts = ExtControls.FnGetControls<TextEdit>(DLControl);
            if (DLControl2 != null) txts = ExtControls.FnGetControls<TextEdit>(DLControl2);
            foreach (var item in txts)
            {
                if (item.Tag != null) LC_Default.Add(item);
                item.EnterMoveNextControl = true;
                item.Properties.ValidateOnEnterKey = true;
                item.Properties.AppearanceDisabled.ForeColor = Color.Black;
                item.Properties.AppearanceDisabled.Options.UseForeColor = true;
            }

            var combos = new List<ComboBoxEdit>();
            if (DLControl != null) combos = ExtControls.FnGetControls<ComboBoxEdit>(DLControl);
            if (DLControl2 != null) combos = ExtControls.FnGetControls<ComboBoxEdit>(DLControl2);
            foreach (var item in combos)
            {
                if (item.Tag != null) LC_Default.Add(item);
                item.EnterMoveNextControl = true;
                item.Properties.ValidateOnEnterKey = true;
                item.Properties.AppearanceDisabled.ForeColor = Color.Black;
                item.Properties.AppearanceDisabled.Options.UseForeColor = true;
                item.Properties.NullText = "";
                item.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            }
        }

        #endregion
    }
}