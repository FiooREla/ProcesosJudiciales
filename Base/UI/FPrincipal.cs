using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Tutorials.Controls;
using DevExpress.Utils;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars;

namespace Base.UI
{
    public partial class FPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FPrincipal()
        {
            InitializeComponent();
            DevExpress.UserSkins.BonusSkins.Register();
            SkinHelper.InitSkinGalleryDropDown(gddSkins);
            InitSkinGallery();
            InitEditors();
            InitSchemeCombo();
            string skinName = Base.Properties.Settings.Default.SkinName;
            UserLookAndFeel.Default.SetSkinStyle(skinName.Length > 0 ? skinName : "VS2010");
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            if (DesignMode) return;
            RibbonPrincipal.ForceInitialize();
            GalleryDropDown skins = new GalleryDropDown();
            skins.Ribbon = RibbonPrincipal;
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGalleryDropDown(skins);
        }

        private void InitSchemeCombo()
        {
            foreach (object obj in Enum.GetValues(typeof(RibbonControlColorScheme))) rpiStyles.Items.Add(obj);
            beScheme.EditValue = RibbonControlColorScheme.Yellow;
        }

        void InitEditors()
        {
            riicStyle.Items.Add(new ImageComboBoxItem("Office 2007", RibbonControlStyle.Office2007, -1));
            riicStyle.Items.Add(new ImageComboBoxItem("Office 2010", RibbonControlStyle.Office2010, -1));
            riicStyle.Items.Add(new ImageComboBoxItem("MacOffice", RibbonControlStyle.MacOffice, -1));
            biStyle.EditValue = RibbonPrincipal.RibbonStyle;
        }

        void InitSkinGallery()
        {
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private void ribbonControl1_ApplicationButtonDoubleClick(object sender, EventArgs e)
        {
            if (RibbonPrincipal.RibbonStyle == RibbonControlStyle.Office2007)
                this.Close();
        }

        private void barEditItem1_ItemPress(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.devexpress.com");
        }

        private void biStyle_EditValueChanged(object sender, EventArgs e)
        {
            RibbonControlStyle style = (RibbonControlStyle)biStyle.EditValue;
            RibbonPrincipal.RibbonStyle = style;
            UpdateSchemeCombo();
        }

        void UpdateSchemeCombo()
        {
            if (RibbonPrincipal.RibbonStyle == RibbonControlStyle.MacOffice || RibbonPrincipal.RibbonStyle == RibbonControlStyle.Office2010)
                beScheme.Visibility = UserLookAndFeel.Default.ActiveSkinName.Contains("Office 2010") ? BarItemVisibility.Always : BarItemVisibility.Never;
            else beScheme.Visibility = BarItemVisibility.Never;
        }

        private void beScheme_EditValueChanged(object sender, EventArgs e)
        {
            RibbonPrincipal.ColorScheme = ((RibbonControlColorScheme)beScheme.EditValue);
        }

        private void rgbiSkins_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption);
            Base.Properties.Settings.Default.SkinName = e.Item.Caption;
            Base.Properties.Settings.Default.Save();
            UpdateSchemeCombo();
        }
    }
}
