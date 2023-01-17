using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaseR.Ctrls;
using DevExpress.XtraBars;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BaseR
{
    public partial class FBaseReporte : XtraForm
    {
        public DataLayoutControl DLControl;
        public Control FirstControl;
        public string IdOpcion;
        public string Parametros;
        public string Parametros2;

        private bool SeCargo;
        public string TipoInterno;

        public FBaseReporte()
        {
            InitializeComponent();
        }

        private void FBaseForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode) FnLoad();
            FnLoadForm();
        }

        public void FnLoad()
        {
            if (SeCargo) return;
            DLControl = (DataLayoutControl) Controls.Find("dlcData", true).FirstOrDefault();
            GrupoFiltros.Visible = GrupoFiltros.ItemLinks.Count != 0;
            GrupoDatos.Visible = GrupoDatos.ItemLinks.Count != 0;
            FnControl();
            SeCargo = true;
        }

        public virtual void FnLoadForm()
        {
        }

        public virtual void FnImprimir()
        {
        }

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

        public virtual void FnActualizar()
        {
        }

        //VIRTUAL LANZAR EVENTOS
        public virtual void FnInvoke(object sender, string e)
        {
        }

        #region Datos por defecto y validaciones

        private readonly DXValidationProvider DxValidacion = new DXValidationProvider();

        public void FnControl()
        {
            var grids2 = ExtControls.FnGetControls<GridControl>(pcEdicion);
            foreach (var item in grids2)
            {
                if (item.Tag == null)
                {
                    item.EmbeddedNavigator.Buttons.Append.Visible = false;
                    item.EmbeddedNavigator.Buttons.Edit.Visible = false;
                    item.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                    item.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                    item.EmbeddedNavigator.Buttons.Remove.Visible = false;
                    //item.EmbeddedNavigator.Buttons.Remove.Visible = true;
                }

                foreach (var rpi in item.RepositoryItems)
                    if (rpi.GetType().Name == "RepositoryItemGridLookUpEdit")
                        Glue.FnGlueBase(rpi);

                foreach (var viewItem in item.Views)
                {
                    var view = viewItem as GridView;
                    view.OptionsNavigation.EnterMoveNextColumn = true;
                    foreach (var column in view.Columns)
                    {
                        var columnItem = (GridColumn) column;
                        columnItem.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                        columnItem.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
                        if (columnItem.FieldName != null && columnItem.FieldName == "Numero") columnItem.Width = 90;
                        else if (columnItem.FieldName != null && columnItem.FieldName == "Fecha") columnItem.Width = 80;
                    }
                }
            }

            var glues = ExtControls.FnGetControls<GridLookUpEdit>(DLControl);
            foreach (var item in glues)
            {
                item.Properties.AppearanceDisabled.ForeColor = Color.Black;
                item.Properties.AppearanceDisabled.Options.UseForeColor = true;
                Glue.FnGlueBase(item);
                if (item.Tag != null) DxValidacion.SetValidationRule(item, new ValidationRuleControl(item));
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
                if (item.Tag != null) DxValidacion.SetValidationRule(item, new ValidationRuleControl(item));
                item.EnterMoveNextControl = true;
                item.Properties.ValidateOnEnterKey = true;
                item.Properties.AppearanceDisabled.ForeColor = Color.Black;
                item.Properties.AppearanceDisabled.Options.UseForeColor = true;
            }
        }

        #endregion
    }
}