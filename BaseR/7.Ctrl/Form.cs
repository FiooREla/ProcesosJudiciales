using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BaseR.Lists;
using BaseR.Properties;
using BaseR;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace BaseR.Ctrls
{
    public class Form
    {
        public static C_Glue FnGlueEdicionBasic(object ctrls)
        {
            var cls = Glue.FnGlueCtrls(ctrls);
            foreach (var glue in cls.Glues)
                if (glue.Properties.Buttons.Count == 1)
                    FnCreate_GlueButton("Agregar", glue, null);
            foreach (var glue in cls.RpiGlues)
                if (glue.Buttons.Count == 1)
                    FnCreate_GlueButton("Agregar", null, glue);
            return cls;
        }

        private static EditorButton FnCreate_GlueButton(string caption, GridLookUpEdit glue,
            RepositoryItemGridLookUpEdit rpiGlue)
        {
            Bitmap img = null;
            switch (caption)
            {
                case "Agregar":
                    img = Resources.addx16;
                    break;
                case "Editar":
                    img = Resources.editx16;
                    break;
                case "Visualizar":
                    img = Resources.zoomx16;
                    break;
                case "Actualizar":
                    img = Resources.refreshx16;
                    break;
            }

            var btn = new EditorButton(ButtonPredefines.Glyph, img, null);
            btn.Caption = caption;
            btn.ToolTip = caption;
            if (glue != null) glue.Properties.Buttons.Add(btn);
            if (rpiGlue != null) rpiGlue.Buttons.Add(btn);
            return btn;
        }

        public static void FnGlueEdicion(object ctrls, string tipo, string name, string tipoInterno, string args,
            bool permiteEdicion = false, string typeEdicion = null)
        {
            var cls = Glue.FnGlueCtrls(ctrls);
            var dic = new Dictionary<string, object>();
            dic.Add("Name", name);
            dic.Add("Type", tipo);
            dic.Add("TipoInterno", tipoInterno);
            dic.Add("Args", args);
            dic.Add("TypeEdicion", typeEdicion);
            foreach (var glue in cls.Glues)
                if (glue.Properties.Buttons.Count == 1)
                {
                    glue.ButtonClick += FnGlue_ButtonClick;
                    glue.Properties.Tag = dic;

                    var btn0 = new EditorButton(ButtonPredefines.Glyph, Resources.addx16, null);
                    btn0.Caption = "Agregar";
                    btn0.ToolTip = "Agregar";
                    glue.Properties.Buttons.Add(btn0);
                    if (permiteEdicion)
                    {
                        var btn1 = new EditorButton(ButtonPredefines.Glyph, Resources.editx16, null);
                        btn1.Caption = "Editar";
                        btn1.ToolTip = "Editar";
                        var btn2 = new EditorButton(ButtonPredefines.Glyph, Resources.zoomx16, null);
                        btn2.Caption = "Visualizar";
                        btn2.ToolTip = "Visualizar";
                        glue.Properties.Buttons.Add(btn1);
                        glue.Properties.Buttons.Add(btn2);
                    }

                    var btn3 = new EditorButton(ButtonPredefines.Glyph, Resources.refreshx16, null);
                    btn3.Caption = "Actualizar";
                    btn0.ToolTip = "Actualizar";
                    glue.Properties.Buttons.Add(btn3);
                }

            foreach (var glue in cls.RpiGlues)
                if (glue.Buttons.Count == 1)
                {
                    glue.ButtonClick += FnGlue_ButtonClick;
                    glue.Tag = dic;
                    var btn0 = new EditorButton(ButtonPredefines.Glyph, Resources.addx16, null);
                    btn0.Caption = "Agregar";
                    btn0.ToolTip = "Agregar";
                    glue.Buttons.Add(btn0);
                    if (permiteEdicion)
                    {
                        var btn1 = new EditorButton(ButtonPredefines.Glyph, Resources.editx16, null);
                        btn1.Caption = "Editar";
                        btn1.ToolTip = "Editar";
                        var btn2 = new EditorButton(ButtonPredefines.Glyph, Resources.zoomx16, null);
                        btn2.Caption = "Visualizar";
                        btn2.ToolTip = "Visualizar";
                        glue.Buttons.Add(btn1);
                        glue.Buttons.Add(btn2);
                    }

                    var btn3 = new EditorButton(ButtonPredefines.Glyph, Resources.refreshx16, null);
                    btn3.Caption = "Actualizar";
                    btn0.ToolTip = "Actualizar";
                    glue.Buttons.Add(btn3);
                }
        }

        private static void FnGlue_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            
        }
    }
}