using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaseR.Ctrls;
using BaseR.Properties;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BaseR
{
    public partial class FBaseFormV2 : XtraForm
    {
        private BindingSource BsLista;
        public string IdOpcion;
        public string Parametros;
        public string Parametros2;

        public string TipoInterno;

        public FBaseFormV2()
        {
            InitializeComponent();
        }

        private void FBaseForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            FnLoad();
            FnLoadForm();
        }

        public void FnLoad()
        {
            GrupoFiltros.Visible = GrupoFiltros.ItemLinks.Count != 0;
            var grid = (GridControl) Controls.Find("gridLista", true).FirstOrDefault();
            if (grid != null) BsLista = (BindingSource) grid.DataSource;
            FnControl();
        }

        public virtual void FnLoadForm()
        {
        }

        #region Datos por defecto y validaciones

        public void FnControl()
        {
            WindowsFormsSettings.AllowAutoFilterConditionChange = DefaultBoolean.False;
            var grids = ExtControls.FnGetControls<GridControl>(this);
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
                    view.OptionsFilter.AllowAutoFilterConditionChange = DefaultBoolean.False;
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
                        var columnItem = (GridColumn) column;
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
        }

        #endregion

        private void rbtnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            FnImprimir();
        }

        private void rbtnCerrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void rbtnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FnActualizar();
        }

        private void btnButtonRibbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tipo = e.Item.Name == "wbtnNuevo" ? EnumEdicion.Nuevo :
                e.Item.Name == "wbtnEditar" ? EnumEdicion.Editar :
                e.Item.Name == "wbtnBorrar" ? EnumEdicion.Borrar : EnumEdicion.Visualizar;
            if (BsLista != null &&
                (tipo == EnumEdicion.Borrar || tipo == EnumEdicion.Editar || tipo == EnumEdicion.Visualizar) &
                (BsLista.Current == null))
            {
                XtraMessageBox.Show("Seleccione alguna fila.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FnMostrarEdicion(tipo);
        }

        public virtual void FnMostrarEdicion(EnumEdicion tipoEdicion)
        {
        }

        public virtual void FnLuegoEdicion(EnumEdicion tipoEdicion, int ID)
        {
        }

        public virtual void FnActualizar()
        {
        }

        public virtual void FnImprimir()
        {
        }
    }
}