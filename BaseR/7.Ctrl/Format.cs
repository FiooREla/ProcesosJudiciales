using BaseR.Properties;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList.Columns;

namespace BaseR.Ctrls
{
    public class Format
    {
        public static ImageCollection Imgs = new ImageCollection();
        public static int IDIndex;

        public static void FnImgs()
        {
            Imgs.InsertImage(Resources.e_amarillo, "e_amarillo", typeof(Resources), 0);
            Imgs.Images.SetKeyName(0, "e_amarillo");
            Imgs.InsertImage(Resources.e_azul, "e_azul", typeof(Resources), 1);
            Imgs.Images.SetKeyName(1, "e_azul");
            Imgs.InsertImage(Resources.e_marron, "e_marron", typeof(Resources), 2);
            Imgs.Images.SetKeyName(2, "e_marron");
            Imgs.InsertImage(Resources.e_morado, "e_morado", typeof(Resources), 3);
            Imgs.Images.SetKeyName(3, "e_morado");
            Imgs.InsertImage(Resources.e_naranja, "e_naranja", typeof(Resources), 4);
            Imgs.Images.SetKeyName(4, "e_naranja");
            Imgs.InsertImage(Resources.e_rojo, "e_rojo", typeof(Resources), 5);
            Imgs.Images.SetKeyName(5, "e_rojo");
            Imgs.InsertImage(Resources.e_verde, "e_verde", typeof(Resources), 6);
            Imgs.Images.SetKeyName(6, "e_verde");
            Imgs.InsertImage(Resources.e_blanco, "e_blanco", typeof(Resources), 7);
            Imgs.Images.SetKeyName(7, "e_blanco");
        }

        public static void FnColumn(GridColumn column, string config, bool esBoolean = false)
        {
            if (Imgs.Images.Count == 0) FnImgs();
            var rpi = new RepositoryItemImageComboBox();
            rpi.AutoHeight = false;
            rpi.Buttons.Clear();
            rpi.Name = "BaseRepositoryItemImageComboBox" + IDIndex;
            var conf = config.Split(';');
            foreach (var item in conf)
            {
                var arg = item.Split('=');
                var index = 0;
                switch (arg[1])
                {
                    case "amarillo":
                        index = 0;
                        break;
                    case "azul":
                        index = 1;
                        break;
                    case "marron":
                        index = 2;
                        break;
                    case "morado":
                        index = 3;
                        break;
                    case "naranja":
                        index = 4;
                        break;
                    case "rojo":
                        index = 5;
                        break;
                    case "verde":
                        index = 6;
                        break;
                    case "blanco":
                        index = 7;
                        break;
                }

                object value = arg[0];
                if (esBoolean) value = arg[0] == "1" ? true : false;
                if (arg.Length == 3)
                    rpi.Items.Add(new ImageComboBoxItem(arg[2], value, index));
                else
                    rpi.Items.Add(new ImageComboBoxItem(value, index));
            }

            rpi.LargeImages = Imgs;
            column.Caption = "...";
            column.ColumnEdit = rpi;
            column.OptionsColumn.AllowFocus = false;
            column.OptionsColumn.FixedWidth = true;
            column.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            column.Width = 25;
            IDIndex = IDIndex + 1;
        }

        public static void FnColumn2(GridColumn column, string config)
        {
            if (Imgs.Images.Count == 0) FnImgs();
            var rpi = new RepositoryItemImageComboBox();
            rpi.AutoHeight = false;
            rpi.Buttons.Clear();
            rpi.Name = "BaseRepositoryItemImageComboBox" + IDIndex;
            var conf = config.Split(';');
            foreach (var item in conf)
            {
                var arg = item.Split('=');
                var index = 0;
                switch (arg[1])
                {
                    case "amarillo":
                        index = 0;
                        break;
                    case "azul":
                        index = 1;
                        break;
                    case "marron":
                        index = 2;
                        break;
                    case "morado":
                        index = 3;
                        break;
                    case "naranja":
                        index = 4;
                        break;
                    case "rojo":
                        index = 5;
                        break;
                    case "verde":
                        index = 6;
                        break;
                    case "blanco":
                        index = 7;
                        break;
                }

                object value = arg[0];
                if (arg.Length == 3)
                    rpi.Items.Add(new ImageComboBoxItem(arg[2], value, index));
                else
                    rpi.Items.Add(new ImageComboBoxItem(value, index));
            }

            rpi.LargeImages = Imgs;
            column.ColumnEdit = rpi;
            column.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            IDIndex = IDIndex + 1;
        }

        public static void FnColumn(TreeListColumn column, string config, bool esBoolean = false)
        {
            if (Imgs.Images.Count == 0) FnImgs();
            var rpi = new RepositoryItemImageComboBox();
            rpi.AutoHeight = false;
            rpi.Buttons.Clear();
            rpi.Name = "BaseRepositoryItemImageComboBox" + IDIndex;
            var conf = config.Split(';');
            foreach (var item in conf)
            {
                var arg = item.Split('=');
                var index = 0;
                switch (arg[1])
                {
                    case "amarillo":
                        index = 0;
                        break;
                    case "azul":
                        index = 1;
                        break;
                    case "marron":
                        index = 2;
                        break;
                    case "morado":
                        index = 3;
                        break;
                    case "naranja":
                        index = 4;
                        break;
                    case "rojo":
                        index = 5;
                        break;
                    case "verde":
                        index = 6;
                        break;
                    case "blanco":
                        index = 7;
                        break;
                }

                object value = arg[0];
                if (esBoolean) value = arg[0] == "1" ? true : false;
                if (arg.Length == 3) rpi.Items.Add(new ImageComboBoxItem(arg[2], value, index));
                else rpi.Items.Add(new ImageComboBoxItem(value, index));
            }

            rpi.LargeImages = Imgs;
            column.Caption = "*";
            column.ColumnEdit = rpi;
            column.OptionsColumn.AllowFocus = false;
            column.OptionsColumn.FixedWidth = true;
            column.Width = 25;
            IDIndex = IDIndex + 1;
        }
    }
}