using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BaseR.Properties;
using BaseR;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace BaseR.Ctrls
{
    public class Form2
    {
        public static void FnGlueEdicion(object ctrls, string tipo, string name, string tipoInterno, string args,
            bool permiteEdicion = false)
        {
            var cls = Glue.FnGlueCtrls(ctrls);
            var dic = new Dictionary<string, object>();
            dic.Add("Name", name);
            dic.Add("Type", tipo);
            dic.Add("TipoInterno", tipoInterno);
            dic.Add("Args", args);
            foreach (var glue in cls.Glues)
                if (glue.Properties.Buttons.Count == 1)
                {
                    glue.ButtonClick += FnGlue_ButtonClick;
                    glue.Properties.Tag = dic;
                    FnCreate_GlueButton("Agregar", glue, null);
                    if (permiteEdicion)
                    {
                        FnCreate_GlueButton("Editar", glue, null);
                        FnCreate_GlueButton("Visualizar", glue, null);
                    }

                    FnCreate_GlueButton("Actualizar", glue, null);
                }

            foreach (var glue in cls.RpiGlues)
                if (glue.Buttons.Count == 1)
                {
                    glue.ButtonClick += FnGlue_ButtonClick;
                    glue.Tag = dic;
                    FnCreate_GlueButton("Agregar", null, glue);
                    if (permiteEdicion)
                    {
                        FnCreate_GlueButton("Editar", null, glue);
                        FnCreate_GlueButton("Visualizar", null, glue);
                    }

                    FnCreate_GlueButton("Actualizar", null, glue);
                }
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

        private static void FnGlue_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var glue = sender as GridLookUpEdit;
            var dic = glue.Properties.Tag as Dictionary<string, object>;
            string name = dic["Name"] as string,
                form = dic["Type"] as string,
                tipoInterno = dic["TipoInterno"] as string,
                args = dic["Args"] as string;

            if (e.Button.Caption == "Actualizar")
            {
                var item = Cache.FnGet(name, tipoInterno, args);
                if (item != null)
                {
                    item.Entidad.FnData();
                    glue.Properties.DataSource = item.Entidad.Lista;
                }
            }
            else if (e.Button.Kind != ButtonPredefines.Combo)
            {
                var tEdicion = e.Button.Caption == "Agregar" ? EnumEdicion.Nuevo :
                    e.Button.Caption == "Editar" ? EnumEdicion.Editar : EnumEdicion.Visualizar;
                FBaseModal fModal = null;
                if (glue.Properties.View.Tag == null)
                {
                    fModal = Activator.CreateInstance(
                        Type.GetType("Clinica.UI." + form + ", Clinica.UI")) as FBaseModal;
                    fModal.TipoInterno = tipoInterno;
                    glue.Properties.View.Tag = fModal;
                }
                else
                {
                    fModal = glue.Properties.View.Tag as FBaseModal;
                }

                int? ID = null;
                if (tEdicion != EnumEdicion.Nuevo)
                {
                    if (!Validation.FnValid(glue.EditValue)) return;
                    ID = Convert.ToInt32(glue.EditValue);
                    if (ID < 0) return;
                }

                fModal.FnMostrar(ID, tEdicion);
                fModal.FnDialog(tEdicion);
                if (fModal.SeGrabo)
                {
                    var objetos = new List<object>();
                    var bs = new BindingSource();
                    bs.DataSource = glue.Properties.DataSource;
                    if (tEdicion == EnumEdicion.Nuevo) objetos.Add(fModal.EntidadActual);
                    for (var i = 0; i < bs.Count; i++)
                    {
                        var entidad = bs[i];
                        var myType = entidad.GetType();
                        IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                        var itemID = Convert.ToInt32(myType.GetProperty("ID").GetValue(entidad, null));
                        if (itemID == ID) objetos.Add(fModal.EntidadActual);
                        else objetos.Add(entidad);
                    }

                    if (tEdicion == EnumEdicion.Nuevo)
                    {
                        var myType = fModal.EntidadActual.GetType();
                        IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                        ID = Convert.ToInt32(myType.GetProperty("ID").GetValue(fModal.EntidadActual, null));
                    }

                    glue.Properties.DataSource = objetos;
                    glue.EditValue = ID;
                }
            }
        }
    }
}