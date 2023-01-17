using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaseR.Ctrls;
using BaseR.Properties;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition;
using FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode;

namespace BaseR
{
    public partial class FBaseForm : XtraForm
    {
        private BindingSource BsLista;

        public DataLayoutControl DLControl;
        public bool EnEdicion;
        public FBaseFormEdicion FFormEdicion;
        public Control FirstControl;
        public string IdOpcion;

        public List<Control> LC_Default = new List<Control>();
        public List<Control> LC_Validar = new List<Control>();
        public string Parametros;
        public string Parametros2;

        private bool SeCargo;
        public bool SeGrabo;
        private XtraTabControl TCLista;
        public EnumEdicion TipoEdicion;

        public string TipoInterno;

        public FBaseForm()
        {
            InitializeComponent();
        }

        //Ivan
        public GridView GridACopiar { get; set; }

        public object EntidadForm { get; set; }

        private void FBaseForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode) FnLoad();
            FnLoadForm();
        }

        public void FnLoad()
        {
            if (SeCargo) return;
            DLControl = (DataLayoutControl)Controls.Find("dlcData", true).FirstOrDefault();
            TCLista = (XtraTabControl)Controls.Find("tpListaEdicion", true).FirstOrDefault();
            BsLista = (BindingSource)DLControl.DataSource;
            TCLista.ShowTabHeader = DefaultBoolean.False;
            FFormEdicion = new FBaseFormEdicion(DLControl, Text);
            FFormEdicion.Event_LuegoEdicion += Event_LuegoEdicion;
            GrupoFiltros.Visible = GrupoFiltros.ItemLinks.Count != 0;
            GrupoDatos.Visible = GrupoDatos.ItemLinks.Count != 0;
            FnControl();
            SeCargo = true;
            EnEdicion = false;
        }

        public virtual void FnLoadForm()
        {
        }

        private void btnButtonRibbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tipo = e.Item.Name == "wbtnNuevo" ? EnumEdicion.Nuevo :
                e.Item.Name == "wbtnEditar" ? EnumEdicion.Editar :
                e.Item.Name == "wbtnBorrar" ? EnumEdicion.Borrar : EnumEdicion.Visualizar;
            FnMostrar(tipo);
        }

        public void FnMostrar(EnumEdicion tipoEdicion)
        {
            if (tipoEdicion != EnumEdicion.Nuevo)
            {
                if ((tipoEdicion == EnumEdicion.Borrar || tipoEdicion == EnumEdicion.Editar ||
                 tipoEdicion == EnumEdicion.Visualizar) & (BsLista.Current == null))
                {
                    XtraMessageBox.Show("Seleccione alguna fila.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            EnEdicion = tipoEdicion == EnumEdicion.Visualizar || tipoEdicion == EnumEdicion.Borrar ? false : true;
            TipoEdicion = tipoEdicion;
            if (!FnEdicion())
            {
                EnEdicion = false;
                TipoEdicion = EnumEdicion.Visualizar;
                return;
            }

            //FirstControl = null;
            //FnGetFirstControl(DLControl);
            //if (FirstControl != null)
            //{
            //    string name = FirstControl.Name;
            //}
            FnPreview();
            FFormEdicion.FnEdicion(TipoEdicion, FirstControl);
        }

        private void FnGetFirstControl(Control ctrl)
        {
            var name = ctrl.Name;
            if (FirstControl == null)
                if ((ctrl is TextEdit || ctrl is GridLookUpEdit || ctrl is DateEdit) && ctrl.Enabled && ctrl.Visible)
                    FirstControl = ctrl;
                else
                    foreach (Control item in ctrl.Controls)
                        FnGetFirstControl(item);
        }

        public void Event_LuegoEdicion(EnumOperacion operacion)
        {
            FnLuego(operacion);
        }

        public void FnLuego(EnumOperacion operacion)
        {
            EntidadForm = null;
            if (operacion == EnumOperacion.Grabar)
            {
                if (TipoEdicion != EnumEdicion.Borrar && !FnValidar()) return;
                var msg = "Los datos son conformes.?";
                if (TipoEdicion == EnumEdicion.Borrar) msg = "Seguro que desea borrar el registro.?";
                var result = XtraMessageBox.Show(msg, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes && FnGrabar())
                {
                    SeGrabo = true;
                    FFormEdicion.Close();
                    EntidadForm = BsLista.Current;
                    TipoEdicion = EnumEdicion.Visualizar;
                    EnEdicion = false;
                }
            }
            else if (operacion == EnumOperacion.Carcelar)
            {
                SeGrabo = false;
                FFormEdicion.Close();
                FnCancelar();
                TipoEdicion = EnumEdicion.Visualizar;
                EnEdicion = false;
            }
            else if (operacion == EnumOperacion.Otro)
            {
                FnOtro();
            }

            FnClearValidator();
        }

        public void FnLuegoAux(EnumOperacion operacion)
        {
            EntidadForm = null;
            if (operacion == EnumOperacion.Grabar)
            {
                if (TipoEdicion != EnumEdicion.Borrar && !FnValidar()) return;
                SeGrabo = true;
                FFormEdicion.Close();
                EntidadForm = BsLista.Current;
                TipoEdicion = EnumEdicion.Visualizar;
                EnEdicion = false;
            }
            else if (operacion == EnumOperacion.Carcelar)
            {
                SeGrabo = false;
                FFormEdicion.Close();
                FnCancelar();
                TipoEdicion = EnumEdicion.Visualizar;
                EnEdicion = false;
            }
            else if (operacion == EnumOperacion.Otro)
            {
                FnOtro();
            }

            FnClearValidator();
        }

        public virtual void FnLuegoModal(object sender, string TipoInterno)
        {
        }

        public virtual bool FnEdicion()
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

        public virtual void FnOtro()
        {
        }

        public virtual void FnImprimir()
        {
        }

        public virtual void FnPreview()
        {
        }

        private bool FnValidar()
        {
            FnValidarRunTime();
            foreach (var item in LC_Default) DxValidacion.SetValidationRule(item, new ValidationRuleControl(item));
            foreach (var item in LC_Validar) DxValidacion.SetValidationRule(item, new ValidationRuleControl(item));
            return DxValidacion.Validate();
        }

        private void FnClearValidator()
        {
            LC_Validar = new List<Control>();
            DxValidacion = new DXValidationProvider();
        }

        private void rbtnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            FnImprimir();
        }

        private void rbtnCerrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        public void MostrarMenuEnGrid(object sender, GridMenuEventArgs e, PopupMenu popup)
        {
            var view = sender as GridView;
            GridACopiar = view;
            var hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRowCell)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                popup.ShowPopup(MousePosition);
            }
        }

        private void rbtnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FnActualizar();
        }

        public virtual void FnActualizar()
        {
        }

        //VIRTUAL LANZAR EVENTOS
        public virtual void FnInvoke(object sender, string e)
        {
        }

        #region Datos por defecto y validaciones

        private DXValidationProvider DxValidacion = new DXValidationProvider();

        public void FnControl()
        {
            var grids = ExtControls.FnGetControls<GridControl>(TCLista);
            foreach (var item in grids)
            {
                if (item.Tag != null)
                    if (item.Tag.ToString() == "N")
                        continue;
                foreach (var viewItem in item.Views)
                {
                    var view = viewItem as GridView;
                    view.OptionsBehavior.Editable = false;
                    view.OptionsBehavior.AutoExpandAllGroups = true;
                    view.OptionsNavigation.EnterMoveNextColumn = true;
                    view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;
                    view.OptionsView.ShowAutoFilterRow = true;
                    view.OptionsView.RowAutoHeight = true;
                    view.OptionsPrint.PrintDetails = true;
                    view.OptionsDetail.ShowDetailTabs = false;

                    if (Settings.Default.SkinName == "VS2010")
                    {
                        view.Appearance.FocusedRow.ForeColor = Color.White;
                        view.Appearance.HideSelectionRow.ForeColor = Color.White;
                        view.Appearance.FocusedRow.BackColor = Color.FromArgb(69, 89, 124);
                        view.Appearance.FocusedRow.BackColor2 = Color.FromArgb(188, 199, 216);
                        view.Appearance.HideSelectionRow.BackColor = Color.FromArgb(69, 89, 124);
                        view.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(188, 199, 216);
                    }
                    else
                    {
                        view.Appearance.FocusedRow.Reset();
                        view.Appearance.HideSelectionRow.Reset();
                    }

                    foreach (var column in view.Columns)
                    {
                        var columnItem = (GridColumn)column;
                        columnItem.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                        columnItem.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
                        columnItem.FilterMode = ColumnFilterMode.DisplayText;
                        if (columnItem.FieldName != null && columnItem.FieldName == "Numero") columnItem.Width = 90;
                    }
                }

                if (item.Tag == null)
                {
                    item.UseEmbeddedNavigator = true;
                    item.EmbeddedNavigator.Buttons.Append.Visible = false;
                    item.EmbeddedNavigator.Buttons.Edit.Visible = false;
                    item.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                    item.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                    item.EmbeddedNavigator.Buttons.Remove.Visible = false;
                }
            }

            var grids2 = ExtControls.FnGetControls<GridControl>(DLControl);
            foreach (var item in grids2)
            {
                if (item.Tag == null)
                {
                    item.EmbeddedNavigator.Buttons.Append.Visible = false;
                    item.EmbeddedNavigator.Buttons.Edit.Visible = false;
                    item.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                    item.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                    item.EmbeddedNavigator.Buttons.Remove.Visible = false;
                }

                foreach (var rpi in item.RepositoryItems)
                    if (rpi.GetType().Name == "RepositoryItemGridLookUpEdit")
                        Glue.FnGlueBase(rpi);

                foreach (var viewItem in item.Views)
                {
                    var view = viewItem as GridView;
                    view.OptionsFilter.AllowAutoFilterConditionChange = DefaultBoolean.False;
                    view.OptionsNavigation.EnterMoveNextColumn = true;
                }
            }

            var trees = ExtControls.FnGetControls<TreeList>(TCLista);
            foreach (var item in trees)
            {
                item.OptionsFilter.AllowAutoFilterConditionChange = DefaultBoolean.False;
                item.OptionsBehavior.Editable = false;
                item.OptionsBehavior.EnableFiltering = true;
                item.OptionsView.ShowAutoFilterRow = true;
                item.OptionsFilter.ShowAllValuesInFilterPopup = true;
                item.OptionsSelection.EnableAppearanceFocusedCell = false;
                if (Settings.Default.SkinName == "VS2010")
                {
                    item.Appearance.FocusedRow.ForeColor = Color.White;
                    item.Appearance.HideSelectionRow.ForeColor = Color.White;
                    item.Appearance.FocusedRow.BackColor = Color.FromArgb(69, 89, 124);
                    item.Appearance.FocusedRow.BackColor2 = Color.FromArgb(188, 199, 216);
                    item.Appearance.HideSelectionRow.BackColor = Color.FromArgb(69, 89, 124);
                    item.Appearance.HideSelectionRow.BackColor2 = Color.FromArgb(188, 199, 216);
                }
                else
                {
                    item.Appearance.FocusedRow.Reset();
                    item.Appearance.HideSelectionRow.Reset();
                }

                foreach (var column in item.Columns)
                {
                    var columnItem = (TreeListColumn)column;
                    columnItem.OptionsFilter.AllowFilter = true;
                    columnItem.FilterMode = ColumnFilterMode.DisplayText;
                }

                item.ExpandAll();
            }

            var glues = ExtControls.FnGetControls<GridLookUpEdit>(DLControl);
            foreach (var item in glues)
            {
                item.Properties.AppearanceDisabled.ForeColor = Color.Black;
                item.Properties.AppearanceDisabled.Options.UseForeColor = true;
                Glue.FnGlueBase(item);
                if (item.Tag != null) LC_Default.Add(item);
            }

            var dates = ExtControls.FnGetControls<DateEdit>(DLControl);
            foreach (var item in dates)
            {
                item.Properties.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                item.Properties.TextEditStyle = TextEditStyles.Standard;
                item.Properties.ValidateOnEnterKey = true;
                item.Properties.AppearanceDisabled.ForeColor = Color.Black;
                item.Properties.AppearanceDisabled.Options.UseForeColor = true;
            }

            var txts = ExtControls.FnGetControls<TextEdit>(DLControl);
            foreach (var item in txts)
            {
                if (item.Tag != null) LC_Default.Add(item);
                item.EnterMoveNextControl = true;
                item.Properties.ValidateOnEnterKey = true;
                item.Properties.AppearanceDisabled.ForeColor = Color.Black;
                item.Properties.AppearanceDisabled.Options.UseForeColor = true;
            }
        }

        #endregion
    }
}