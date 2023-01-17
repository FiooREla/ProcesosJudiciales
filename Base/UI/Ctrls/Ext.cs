using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars;
using System.Linq;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Base.UI;
using DevExpress.Utils;

namespace Ext
{
    public class Glue
    {
        public static void RpiGlueAño(RepositoryItemGridLookUpEdit rpiGlue, BarEditItem bbItem)
        {
            List<int> años = new List<int>();
            for (int año = System.DateTime.Now.Year - 2; año <= System.DateTime.Now.Year; año++) años.Add(año);
            rpiGlue.DataSource = años;
            if (bbItem != null) bbItem.EditValue = System.DateTime.Now.Year;
        }

        public static void RpiGlueMes(RepositoryItemGridLookUpEdit rpiGlue, BarEditItem bbItem)
        {
            rpiGlue.DisplayMember = "Nombre";
            rpiGlue.ValueMember = "Numero";
            rpiGlue.DataSource = Base.Data.Mes.Lista();
            if (bbItem != null) bbItem.EditValue = System.DateTime.Now.Month;
        }

        public static void GlueSiNo(GridLookUpEdit glue)
        {
            glue.Properties.DisplayMember = "Descripcion";
            glue.Properties.ValueMember = "Logico";
            glue.Properties.DataSource = Base.Data.SiNo.Lista();
            glue.Properties.View.PopulateColumns(glue.Properties.DataSource);
            for (int index = 0; index <= 2; index++) glue.Properties.View.Columns[index].Visible = index == 2;
        }

        public static void RpiGlueSiNo(RepositoryItemGridLookUpEdit rpiGlue)
        {
            rpiGlue.DisplayMember = "Descripcion";
            rpiGlue.ValueMember = "Logico";
            rpiGlue.DataSource = Base.Data.SiNo.Lista();
            rpiGlue.View.PopulateColumns(rpiGlue.DataSource);
            for (int index = 0; index <= 2; index++) rpiGlue.View.Columns[index].Visible = index == 2;
        }

        public static void GridLookUpEdit(GridLookUpEdit glue, object data, string value, string display, string[] columns)
        {
            glue.Properties.DisplayMember = display;
            glue.Properties.ValueMember = value;
            glue.Properties.DataSource = data;
            glue.Properties.View.PopulateColumns(glue.Properties.DataSource);
            Array.Reverse(columns);
            for (int index = 0; index <= glue.Properties.View.Columns.Count - 1; index++) glue.Properties.View.Columns[index].Visible = false;
            for (int index = 0; index <= columns.Length - 1; index++)
            {
                var items = columns[index].Split('>');
                glue.Properties.View.Columns[items[0]].Visible = true;
                if (items.Count() == 2) glue.Properties.View.Columns[items[0]].Caption = items[1];
            }
            glue.Properties.PopupFormSize = new Size(500, 300);
        }

        public static void RpiGridLookUpEdit(RepositoryItemGridLookUpEdit rpiGlue, object data, string value, string display, string[] columns)
        {
            rpiGlue.DisplayMember = display;
            rpiGlue.ValueMember = value;
            rpiGlue.DataSource = data;
            rpiGlue.View.PopulateColumns(rpiGlue.DataSource);
            Array.Reverse(columns);
            for (int index = 0; index <= rpiGlue.View.Columns.Count - 1; index++) rpiGlue.View.Columns[index].Visible = false;
            for (int index = 0; index <= columns.Length - 1; index++) rpiGlue.View.Columns[columns[index]].Visible = true;
            rpiGlue.PopupFormSize = new Size(500, 300);
        }
    }

    public class Form
    {
        public static void FnEdicionGlue(GridLookUpEdit glue, Type tipo, string tipoInterno)
        {
            EditorButton btn = new EditorButton();
            btn.Kind = ButtonPredefines.Plus;
            glue.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(Glue_ButtonClick);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Type", tipo);
            dic.Add("TipoInterno", tipoInterno);
            glue.Properties.Tag = dic;
            glue.Properties.Buttons.Add(btn);
        }

        public static void FnEdicionRpiGlue(RepositoryItemGridLookUpEdit glue, Type tipo, string tipoInterno)
        {
            EditorButton btn = new EditorButton();
            btn.Kind = ButtonPredefines.Plus;
            glue.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(Glue_ButtonClick);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Type", tipo);
            dic.Add("TipoInterno", tipoInterno);
            glue.Tag = dic;
            glue.Buttons.Add(btn);
        }

        public static void FnEdicionGlue(GridLookUpEdit glue, Type tipo)
        {
            EditorButton btn = new EditorButton();
            btn.Kind = ButtonPredefines.Plus;
            glue.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(Glue_ButtonClick);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Type", tipo);
            dic.Add("TipoInterno", null);
            glue.Properties.Tag = dic;
            glue.Properties.Buttons.Add(btn);
        }

        public static void FnEdicionRpiGlue(RepositoryItemGridLookUpEdit glue, Type tipo)
        {
            EditorButton btn = new EditorButton();
            btn.Kind = ButtonPredefines.Plus;
            glue.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(Glue_ButtonClick);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Type", tipo);
            dic.Add("TipoInterno", null);
            glue.Tag = dic;
            glue.Buttons.Add(btn);
        }

        private static void Glue_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit glue = sender as GridLookUpEdit;
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                Dictionary<string, object> dic = glue.Properties.Tag as Dictionary<string, object>;
                Type tipo = dic["Type"] as Type;
                string tipoInterno = dic["TipoInterno"] == null ? null : dic["TipoInterno"].ToString();                
                FBaseForm fForm = Activator.CreateInstance(tipo) as FBaseForm;
                fForm.TipoInterno = tipoInterno;
                fForm.FnLoad();
                fForm.FnLoadForm();
                fForm.FnMostrar(EnumEdicion.Nuevo);
                if (fForm.EntidadActual != null)
                {
                    List<object> objetos = new List<object>();
                    BindingSource bs = new BindingSource();
                    bs.DataSource = glue.Properties.DataSource;
                    objetos.Add(fForm.EntidadActual);
                    for (int i = 0; i < bs.Count; i++) objetos.Add(bs[i]);
                    glue.Properties.DataSource = objetos;
                    glue.EditValue = glue.Properties.GetKeyValue(0);
                }
            }
        }

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

            var cls = new C_Glue { Glues = glues, RpiGlues = rpiGlues };
            return cls;
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

        private static void FnGlue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40) ((GridLookUpEdit)sender).ShowPopup();
            }
            catch (Exception ex)
            {
            }
        }
    }

    public class C_Glue
    {
        public List<GridLookUpEdit> Glues { get; set; }
        public List<RepositoryItemGridLookUpEdit> RpiGlues { get; set; }
    }
}
