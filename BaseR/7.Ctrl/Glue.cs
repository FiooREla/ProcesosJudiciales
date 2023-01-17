using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaseR.Delegate;
using BaseR.Lists;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace BaseR.Ctrls
{
    public class Glue
    {
        public static void FnGlue(object ctrls, object data, string value, string display, string[] columns)
        {
            FnGlueBase(ctrls);
            var cls = FnGlueCtrls(ctrls);
            var gColumns = new List<GridColumn>();
            var index = 0;
            foreach (var fieldName in columns)
            {
                var ancho = 600;
                var items = fieldName.Split('>');
                var field = items[0];
                var caption = items[0];
                var visible = true;
                var groupIndex = -1;
                if (items.Count() == 2)
                {
                    var config = items[1].Replace("[", "").Replace("]", "").Split(';');
                    foreach (var item in config)
                        if (item.StartsWith("D="))
                        {
                            caption = item.Replace("D=", "");
                        }
                        else if (item.StartsWith("W="))
                        {
                            var width = ancho * (Convert.ToDecimal(item.Replace("W=", "")) / 100);
                            ancho = Convert.ToInt32(width);
                        }
                        else if (item.StartsWith("V="))
                        {
                            visible = item.Replace("V=", "") != "0";
                        }
                        else if (item.StartsWith("G="))
                        {
                            groupIndex = int.Parse(item.Replace("G=", ""));
                        }
                }

                var column = new GridColumn();
                column.Caption = caption;
                column.FieldName = field;
                column.Visible = visible;
                column.Width = ancho;
                column.GroupIndex = groupIndex;
                gColumns.Add(column);
            }

            foreach (var glue in cls.Glues)
            {
                if (glue.Properties.View.Columns.Count == 0)
                {
                    glue.Properties.DisplayMember = display;
                    glue.Properties.ValueMember = value;
                    glue.Properties.View.Columns.AddRange(gColumns.ToArray());
                }

                glue.Properties.DataSource = data;
                //glue.Properties.View.RefreshData();
            }

            foreach (var glue in cls.RpiGlues)
            {
                if (glue.View.Columns.Count == 0)
                {
                    glue.DisplayMember = display;
                    glue.ValueMember = value;
                    glue.View.Columns.AddRange(gColumns.ToArray());
                }

                glue.DataSource = data;
                //glue.View.RefreshData();
            }
        }

        public static void FnGlueBase(object ctrls)
        {
            var cls = FnGlueCtrls(ctrls);
            foreach (var item in cls.Glues)
            {
                item.EnterMoveNextControl = true;
                item.Properties.AllowNullInput = DefaultBoolean.True;
                item.Properties.NullText = "";
                item.Properties.ValidateOnEnterKey = true;
                item.Properties.ImmediatePopup = true;
                item.Properties.View.OptionsView.ShowAutoFilterRow = true;
                item.Properties.TextEditStyle = TextEditStyles.Standard;
                item.Properties.PopupFormSize = new Size(600, 300);
                item.Properties.PopupFilterMode = PopupFilterMode.Contains;
                item.Properties.View.OptionsBehavior.AutoExpandAllGroups = true;
                item.Properties.View.OptionsNavigation.EnterMoveNextColumn = true;
                item.Properties.View.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;
                item.Properties.View.OptionsView.ShowAutoFilterRow = true;
                item.KeyDown += FnGlue_KeyDown;
            }

            foreach (var rpiGlue in cls.RpiGlues)
            {
                rpiGlue.AllowNullInput = DefaultBoolean.True;
                rpiGlue.NullText = "";
                rpiGlue.TextEditStyle = TextEditStyles.Standard;
                rpiGlue.PopupFormSize = new Size(600, 300);
                rpiGlue.ImmediatePopup = true;
                rpiGlue.View.OptionsView.ShowAutoFilterRow = true;
                rpiGlue.PopupFilterMode = PopupFilterMode.Contains;
                rpiGlue.View.OptionsBehavior.AutoExpandAllGroups = true;
                rpiGlue.View.OptionsNavigation.EnterMoveNextColumn = true;
                rpiGlue.View.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;
                rpiGlue.View.OptionsView.ShowAutoFilterRow = true;
                rpiGlue.KeyDown += FnGlue_KeyDown;
            }
        }

        public static void FnGlueCache(object ctrls, string name, string tipoInterno, Event_FnData fn, string args)
        {
            var item = Cache.FnGet(name, tipoInterno, args);
            if (item == null) item = Cache.FnAdd(name, tipoInterno, args, fn, false);
            var cls = FnGlueCtrls(ctrls);
            foreach (var glue in cls.Glues)
            {
                glue.Properties.DataSource = item.Entidad.Lista;
                glue.QueryPopUp += FnGlue_QueryPopUp;
            }

            foreach (var glue in cls.RpiGlues)
            {
                glue.DataSource = item.Entidad.Lista;
                glue.QueryPopUp += FnGlue_QueryPopUp;
            }
        }

        private static void FnGlue_QueryPopUp(object sender, CancelEventArgs e)
        {
            var glue = sender as GridLookUpEdit;
            var rpiGlue = sender as RepositoryItemGridLookUpEdit;
            if (glue.Properties.Tag == null) return;
            var dic = glue.Properties.Tag as Dictionary<string, object>;
            var name = dic["Name"] as string;
            var tipo = dic["TipoInterno"] as string;
            string args = null;
            if (dic["Args"] != null) args = dic["Args"] as string;
            var item = Cache.FnGet(name, tipo, args);
            if (item != null) glue.Properties.DataSource = item.Entidad.Lista;
        }

        private static void FnGlue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40) ((GridLookUpEdit) sender).ShowPopup();
            }
            catch (Exception ex)
            {
            }
        }

        #region BASE

        public static C_Glue FnGlueCtrls(object ctrls)
        {
            var glues = new List<GridLookUpEdit>();
            var rpiGlues = new List<RepositoryItemGridLookUpEdit>();
            if (ctrls.GetType() == typeof(object[]))
                foreach (var item in ctrls as object[])
                {
                    if (item.GetType() == typeof(GridLookUpEdit)) glues.Add(item as GridLookUpEdit);
                    if (item.GetType() == typeof(RepositoryItemGridLookUpEdit))
                        rpiGlues.Add(item as RepositoryItemGridLookUpEdit);
                }
            else if (ctrls.GetType() == typeof(GridLookUpEdit))
                glues.Add(ctrls as GridLookUpEdit);
            else if (ctrls.GetType() == typeof(RepositoryItemGridLookUpEdit))
                rpiGlues.Add(ctrls as RepositoryItemGridLookUpEdit);
            else if (ctrls.GetType() == typeof(GridLookUpEdit[]))
                foreach (var item in ctrls as GridLookUpEdit[])
                    glues.Add(item);
            else if (ctrls.GetType() == typeof(RepositoryItemGridLookUpEdit[]))
                foreach (var item in ctrls as RepositoryItemGridLookUpEdit[])
                    rpiGlues.Add(item);

            var cls = new C_Glue {Glues = glues, RpiGlues = rpiGlues};
            return cls;
        }

        public static void FnGlueAño(object ctrls)
        {
            FnGlue(ctrls, Año.Lista(), "Numero", "Numero", new[] {"Numero"});
        }

        public static void FnGlueMes(object ctrls)
        {
            FnGlue(ctrls, Mes.Lista(), "Numero", "Nombre", new[] {"Nombre"});
        }

        public static void FnGlueSiNo(object ctrls, bool todos = false)
        {
            if (todos) FnGlue(ctrls, SiNo.ListaTodos(), "LogicoNull", "Descripcion", new[] {"Descripcion"});
            else FnGlue(ctrls, SiNo.Lista(), "Logico", "Descripcion", new[] {"Descripcion"});
            var cls = FnGlueCtrls(ctrls);
            foreach (var item in cls.Glues)
            {
                if (todos) item.Properties.NullText = "Todos";
                item.Properties.DisplayMember = "Descripcion";
                item.Properties.ValueMember = todos ? "LogicoNull" : "Logico";
                item.Properties.View.Columns.Clear();
                var column = new GridColumn();
                column.Caption = "Descripcion";
                column.FieldName = "Descripcion";
                column.Visible = true;
                item.Properties.View.Columns.Add(column);
                item.Properties.PopupFormSize = new Size(200, 200);
                item.Properties.View.RefreshData();
            }

            foreach (var item in cls.RpiGlues)
            {
                if (todos) item.NullText = "Todos";
                item.DisplayMember = "Descripcion";
                item.ValueMember = todos ? "LogicoNull" : "Logico";
                //GridColumn column = new GridColumn(); column.Caption = "Descripcion"; column.FieldName = "Descripcion"; column.Visible = true;
                item.PopupFormSize = new Size(200, 200);
                item.View.RefreshData();
            }
        }

        public static void FnGlueSiNo_Kardex(object ctrls, bool todos = false)
        {
            if (todos) FnGlue(ctrls, SiNo.ListaTodos_Kardex(), "LogicoNull", "Descripcion", new[] {"Descripcion"});
            else FnGlue(ctrls, SiNo.Lista_Kardex(), "Logico", "Descripcion", new[] {"Descripcion"});
            var cls = FnGlueCtrls(ctrls);
            foreach (var item in cls.Glues)
            {
                if (todos) item.Properties.NullText = "Todos";
                item.Properties.NullText = "Todos";
                item.Properties.DisplayMember = "Descripcion";
                item.Properties.ValueMember = todos ? "LogicoNull" : "Logico";
                item.Properties.View.Columns.Clear();
                var column = new GridColumn();
                column.Caption = "Descripcion";
                column.FieldName = "Descripcion";
                column.Visible = true;
                item.Properties.View.Columns.Add(column);
                item.Properties.PopupFormSize = new Size(200, 200);
                item.Properties.View.RefreshData();
            }

            foreach (var item in cls.RpiGlues)
            {
                if (todos) item.NullText = "Todos";                
                item.DisplayMember = "Descripcion";
                item.ValueMember = todos ? "LogicoNull" : "Logico";
                //GridColumn column = new GridColumn(); column.Caption = "Descripcion"; column.FieldName = "Descripcion"; column.Visible = true;
                item.PopupFormSize = new Size(200, 200);
                item.View.RefreshData();
            }
        }

        public static void FnGlueParcialTotal(object ctrls)
        {
            FnGlue(ctrls, SiNo.ListaParcialTotal(), "Logico", "Descripcion", new[] {"Descripcion"});
            var cls = FnGlueCtrls(ctrls);
            foreach (var item in cls.Glues) item.Properties.PopupFormSize = new Size(200, 200);
            foreach (var item in cls.RpiGlues) item.PopupFormSize = new Size(200, 200);
        }

        #endregion
    }
}