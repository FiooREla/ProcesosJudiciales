using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraDataLayout;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTab;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using System.Linq;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;

namespace Base.UI
{
    public partial class FBaseForm : XtraForm
    {
        public string TipoInterno;
        public string IdOpcion;
        public string Parametros;
        public bool Maximizado = false;
        public EnumEdicion TipoEdicion;

        //Ivan
        public GridView GridACopiar { get; set; }

        FBaseEdicion FFormEdicion;
        public ExtLayoutControl DLControl;
        XtraTabControl TCLista;
        BindingSource BsLista;
        public FBaseForm()
        {
            InitializeComponent();
        }
        private void FForm_Load(object sender, EventArgs e) { if (DesignMode) return; FnLoad(); }

        public virtual void FnLoadForm() { }

        public void FnLoad()
        {
            if (this.Tag != "LISTA")
            {
                DLControl = (ExtLayoutControl)this.Controls.Find("dlcData", true).FirstOrDefault();
                TCLista = (XtraTabControl)this.Controls.Find("tpListaEdicion", true).FirstOrDefault();
                BsLista = (BindingSource)DLControl.DataSource;
                TCLista.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                FFormEdicion = new FBaseEdicion(DLControl, this.Text);
                FFormEdicion.Event_LuegoEdicion += Event_LuegoEdicion;
                GrupoFiltros.Visible = GrupoFiltros.ItemLinks.Count != 0;
            }

        }

        private void FBaseForm_Activated(object sender, EventArgs e) { FnControl(); }

        #region Datos por defecto y validaciones
        DXValidationProvider DxValidacion = new DXValidationProvider();
        public void FnControl()
        {
            var grids = Ext.ExtControls.FnGetControls<GridControl>(TCLista);
            foreach (var item in grids)
            {
                if (item.Tag != null)
                {
                    if (item.Tag.ToString() == "N")
                    {
                        continue;
                    }
                }

                foreach (var viewItem in item.Views)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = viewItem as DevExpress.XtraGrid.Views.Grid.GridView;
                    view.OptionsBehavior.Editable = false;
                    view.OptionsBehavior.AutoExpandAllGroups = true;
                    view.OptionsNavigation.EnterMoveNextColumn = true;
                    view.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
                    view.OptionsView.ShowAutoFilterRow = true;
                    view.OptionsView.RowAutoHeight = true;
                    view.OptionsPrint.PrintDetails = true;
                    view.OptionsDetail.ShowDetailTabs = false;
                    foreach (var column in view.Columns)
                    {
                        var columnItem = (DevExpress.XtraGrid.Columns.GridColumn)column;
                        columnItem.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                        columnItem.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                    }
                    if (view.Tag != "N")
                    {
                        view.OptionsView.ColumnAutoWidth = true;
                        view.BestFitColumns();
                    }
                }
            }

            var trees = Ext.ExtControls.FnGetControls<TreeList>(TCLista);
            foreach (var item in trees)
            {
                item.OptionsBehavior.Editable = false;
                item.OptionsBehavior.EnableFiltering = true;
                item.OptionsView.ShowAutoFilterRow = true;
                item.OptionsFilter.ShowAllValuesInFilterPopup = true;
                item.OptionsView.AutoWidth = true;
                foreach (var column in item.Columns)
                {
                    var columnItem = (DevExpress.XtraTreeList.Columns.TreeListColumn)column;
                    columnItem.OptionsFilter.AllowFilter = true;
                }
                item.BestFitColumns();
                item.ExpandAll();
            }

            var glues = Ext.ExtControls.FnGetControls<GridLookUpEdit>(DLControl);
            foreach (var item in glues)
            {
                item.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
                item.Properties.NullText = "";
                item.EnterMoveNextControl = true;
                item.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                item.Properties.PopupFormSize = new System.Drawing.Size(800, 400);
                item.Properties.ImmediatePopup = true;
                item.EnterMoveNextControl = true;
                item.Properties.View.OptionsBehavior.AutoExpandAllGroups = true;
                item.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
                item.Properties.View.OptionsNavigation.EnterMoveNextColumn = true;
                item.Properties.View.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
                item.Properties.View.OptionsView.ShowAutoFilterRow = true;
                item.KeyDown += Glue_KeyDown;
                if (item.Tag != null && item.Tag.ToString() == "N") DxValidacion.SetValidationRule(item, new Ext.ValidationRuleNotNull(" [ Selecione un valor... ]", ErrorType.Critical));
            }

            var txts = Ext.ExtControls.FnGetControls<TextEdit>(DLControl);
            foreach (var item in txts)
            {
                if (item.Tag != null && item.Tag.ToString() == "N") DxValidacion.SetValidationRule(item, new Ext.ValidationRuleNotNull(" [ Ingrese un valor... ]", ErrorType.Critical));
                item.EnterMoveNextControl = true;
            }
        }

        private void Glue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                ((GridLookUpEdit)sender).ShowPopup();
            }
        }

        #endregion

        private void btnButtonRibbon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TipoEdicion = e.Item.Caption == "Nuevo" ? EnumEdicion.Nuevo : e.Item.Caption == "Editar" ? EnumEdicion.Editar : e.Item.Caption == "Borrar" ? EnumEdicion.Borrar : EnumEdicion.Visualizar;
            if ((TipoEdicion == EnumEdicion.Borrar | TipoEdicion == EnumEdicion.Editar | TipoEdicion == EnumEdicion.Visualizar) & (BsLista.Current == null))
                XtraMessageBox.Show("Seleccione alguna fila.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else FnMostrar(TipoEdicion);
        }

        public void FnMostrar(EnumEdicion tipoEdicion)
        {
            if (FnInicioValidar() == false) return;

            FnEdicion();
            FFormEdicion.FnEdicion(TipoEdicion , Maximizado);
        }

        public virtual void FnLimpiar()
        {
          
        }

        public void MostrarMenuEnGrid(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e, DevExpress.XtraBars.PopupMenu popup)
        {
            GridView view = sender as GridView;
            GridACopiar = view;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRowCell)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                popup.ShowPopup(MousePosition);
            }
        }

        public void Event_LuegoEdicion(EnumOperacion operacion) { FnLuego(operacion); }

        public object EntidadActual { get; set; }
        public void FnLuego(EnumOperacion operacion)
        {
            EntidadActual = null;
            if (operacion == EnumOperacion.Grabar)
            {
                if (!FnValidar()) return;
                DialogResult result = XtraMessageBox.Show("Los datos son conformes.?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if ((result == DialogResult.Yes) )
                {

                    bool resultado =  FnGrabar();
                    if (resultado)
                    {

                        FnLimpiar();

                        TipoEdicion = EnumEdicion.Visualizar;
                        FFormEdicion.Close();
                        EntidadActual = BsLista.Current;
                    }

                  
                }
            }
            else
            {
                TipoEdicion = EnumEdicion.Visualizar;
                FFormEdicion.Close();
                FnCancelar();
            }            
        }

        public virtual void FnEdicion() { }
        public virtual bool FnInicioValidar() { return true; }

        public virtual void FnActionsBefreSave() { }
        public virtual bool FnGrabar() { return true; }
        public virtual void FnCancelar() { }
        public virtual void FnImprimir() { }
        private bool FnValidar() {
            FnActionsBefreSave();
            return DxValidacion.Validate();
        }
        private void rbtnImprimir_ItemClick(object sender, ItemClickEventArgs e) { FnImprimir(); }
        private void rbtnCerrar_ItemClick(object sender, ItemClickEventArgs e) { this.Close(); }
    }
}