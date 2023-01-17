using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using BaseR.Properties;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraScheduler;
using DevExpress.XtraTreeList;

namespace BaseR
{
    internal enum TipoImpresion
    {
    }

    public class Print
    {
        public static void FnPrint(string Orientacion, string titulo, string subTitulo, Control ctrl,
            bool print = false, bool header = true, PageHeaderArea pageHeader = null, bool esDesarrollo = false,
            bool A5 = false, bool oldPrint = false)
        {
            //if (ctrl is PivotGridControl)
            //{
            //    var ctrl2 = ctrl as PivotGridControl;
            //    ctrl2.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False;
            //    ctrl2.OptionsPrint.PrintDataHeaders = DefaultBoolean.False;
            //    ctrl2.OptionsPrint.PrintUnusedFilterFields = false;
            //    ctrl2.ShowPrintPreview();
            //}
            //return;
            var pSystem = new PrintingSystem();
            var pComponentLink = new PrintableComponentLink();
            var pPreview = new PrintPreviewFormEx();
            //pComponentLink.ImageCollection.ImageStream = CType(resources.GetObject("PrintableComponentLink1.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
            if (Orientacion.StartsWith("Horizontal")) pComponentLink.Landscape = true;
            if (Orientacion.StartsWith("Vertical")) pComponentLink.Landscape = false;
            if (pageHeader == null) pComponentLink.Margins = new Margins(39, 39, 100, 59);
            else pComponentLink.Margins = new Margins(39, 39, 115, 59);
            if (A5)
            {
                pComponentLink.PaperName = "A5";
                pComponentLink.PaperKind = PaperKind.A5;
                //pComponentLink.Images.Add(Resources.LogoOrtegaSmall);
                pComponentLink.Margins = new Margins(39, 39, 70, 59);
            }
            else
            {
                pComponentLink.PaperName = "A4";
                //pComponentLink.Images.Add(Resources.LogoOrtega);
            }

            pComponentLink.PrintingSystem = pSystem;
            pComponentLink.PrintingSystemBase = pSystem;
            //pComponentLink.CreateDocument();

            PageHeaderArea pHeader;
            if (pageHeader == null)
                pHeader =
                    new PageHeaderArea(
                        new[]
                        {
                            "[Image 0]",
                            esDesarrollo
                                ? "ELECTRO PERU"
                                : "ELECTRO PERU" + Environment.NewLine + titulo + Environment.NewLine +
                                  subTitulo,
                            "[Date Printed]"
                        },
                        new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, Convert.ToByte(0)),
                        BrickAlignment.Center
                    );
            else pHeader = pageHeader;

            var pFooter = new PageFooterArea(new[] { "", "", "[Page # of Pages #]" },
                new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
                BrickAlignment.Near
            );
            if (header) pComponentLink.PageHeaderFooter = new PageHeaderFooter(pHeader, pFooter);
            pPreview.PrintingSystem = pSystem;

            if (ctrl is GridControl)
            {
                pComponentLink.Component = ctrl as GridControl;
            }
            else if (ctrl is SchedulerControl)
            {
                pComponentLink.Component = ctrl as SchedulerControl;
            }
            else if (ctrl is TreeList)
            {
                pComponentLink.Component = ctrl as TreeList;
            }
            else if (ctrl is LayoutControl)
            {
                if (oldPrint) (ctrl as LayoutControl).OptionsPrint.OldPrinting = true;
                pComponentLink.Component = ctrl as LayoutControl;
            }
            else if (ctrl is PivotGridControl)
            {
                var ctrl2 = ctrl as PivotGridControl;
                ctrl2.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False;
                ctrl2.OptionsPrint.PrintDataHeaders = DefaultBoolean.False;
                ctrl2.OptionsPrint.PrintUnusedFilterFields = false;
                pComponentLink.Component = ctrl2;
            }
            else if (ctrl is ChartControl)
            {
                pComponentLink.Component = ctrl as ChartControl;
            }

            pComponentLink.CreateDocument();
            if (Orientacion.Contains("HISTORIA"))
            {
                pSystem.SetCommandVisibility(PrintingSystemCommand.PrintSelection, CommandVisibility.None);
                pSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
            }

            //pSystem.Links.Add(pComponentLink);
            //((Link)pSystem.Links[0]).Images.Add(BaseR.Properties.Resources.LogoOrtega);
            if (print) pSystem.Print();
            else pPreview.ShowDialog();

        }

        public static void FnPrint_SinLogo(string Orientacion, string titulo, string subTitulo, Control ctrl,
           bool print = false, bool header = true, PageHeaderArea pageHeader = null, bool esDesarrollo = false,
           bool A5 = false, bool oldPrint = false)
        {
            //if (ctrl is PivotGridControl)
            //{
            //    var ctrl2 = ctrl as PivotGridControl;
            //    ctrl2.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False;
            //    ctrl2.OptionsPrint.PrintDataHeaders = DefaultBoolean.False;
            //    ctrl2.OptionsPrint.PrintUnusedFilterFields = false;
            //    ctrl2.ShowPrintPreview();
            //}
            //return;
            var pSystem = new PrintingSystem();
            var pComponentLink = new PrintableComponentLink();
            var pPreview = new PrintPreviewFormEx();
            //pComponentLink.ImageCollection.ImageStream = CType(resources.GetObject("PrintableComponentLink1.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
            if (Orientacion.StartsWith("Horizontal")) pComponentLink.Landscape = true;
            if (Orientacion.StartsWith("Vertical")) pComponentLink.Landscape = false;
            if (pageHeader == null) pComponentLink.Margins = new Margins(39, 39, 100, 59);
            else pComponentLink.Margins = new Margins(39, 39, 115, 59);
            if (A5)
            {
                pComponentLink.PaperName = "A5";
                pComponentLink.PaperKind = PaperKind.A5;
                //pComponentLink.Images.Add(Resources.LogoOrtegaSmall);
                pComponentLink.Margins = new Margins(39, 39, 70, 59);
            }
            else
            {
                pComponentLink.PaperName = "A4";
                //pComponentLink.Images.Add(Resources.LogoOrtega);
            }

            pComponentLink.PrintingSystem = pSystem;
            pComponentLink.PrintingSystemBase = pSystem;
            //pComponentLink.CreateDocument();

            PageHeaderArea pHeader;
            if (pageHeader == null)
                pHeader =
                    new PageHeaderArea(
                        new[]
                        {
                            null,
                            esDesarrollo
                                ? ""
                                : "" + Environment.NewLine + titulo + Environment.NewLine +
                                  subTitulo,
                            "[Date Printed]"
                        },
                        new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, Convert.ToByte(0)),
                        BrickAlignment.Center
                    );
            else pHeader = pageHeader;

            var pFooter = new PageFooterArea(new[] { "", "", "[Page # of Pages #]" },
                new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
                BrickAlignment.Near
            );
            if (header) pComponentLink.PageHeaderFooter = new PageHeaderFooter(pHeader, pFooter);
            pPreview.PrintingSystem = pSystem;

            if (ctrl is GridControl)
            {
                pComponentLink.Component = ctrl as GridControl;
            }
            else if (ctrl is SchedulerControl)
            {
                pComponentLink.Component = ctrl as SchedulerControl;
            }
            else if (ctrl is TreeList)
            {
                pComponentLink.Component = ctrl as TreeList;
            }
            else if (ctrl is LayoutControl)
            {
                if (oldPrint) (ctrl as LayoutControl).OptionsPrint.OldPrinting = true;
                pComponentLink.Component = ctrl as LayoutControl;
            }
            else if (ctrl is PivotGridControl)
            {
                var ctrl2 = ctrl as PivotGridControl;
                ctrl2.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False;
                ctrl2.OptionsPrint.PrintDataHeaders = DefaultBoolean.False;
                ctrl2.OptionsPrint.PrintUnusedFilterFields = false;
                pComponentLink.Component = ctrl2;
            }
            else if (ctrl is ChartControl)
            {
                pComponentLink.Component = ctrl as ChartControl;
            }

            pComponentLink.CreateDocument();
            if (Orientacion.Contains("HISTORIA"))
            {
                pSystem.SetCommandVisibility(PrintingSystemCommand.PrintSelection, CommandVisibility.None);
                pSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
            }

            //pSystem.Links.Add(pComponentLink);
            //((Link)pSystem.Links[0]).Images.Add(BaseR.Properties.Resources.LogoOrtega);
            if (print) pSystem.Print();
            else pPreview.ShowDialog();

        }

        public static Stream FnExport_PDF(string Orientacion, string titulo, string subTitulo, Control ctrl)
        {
            var pSystem = new PrintingSystem();
            var pComponentLink = new PrintableComponentLink();
            var pPreview = new PrintPreviewFormEx();
            if (Orientacion.StartsWith("Horizontal")) pComponentLink.Landscape = true;
            if (Orientacion.StartsWith("Vertical")) pComponentLink.Landscape = false;
            pComponentLink.Margins = new Margins(39, 39, 100, 59);
            pComponentLink.PaperName = "A4";
            //pComponentLink.Images.Add(Resources.LogoOrtega);

            pComponentLink.PrintingSystem = pSystem;
            pComponentLink.PrintingSystemBase = pSystem;

            PageHeaderArea pHeader = new PageHeaderArea(
                        new[] { "[Image 0]", "ELECTRO PERU" + Environment.NewLine + titulo + Environment.NewLine + subTitulo, "[Date Printed]" },
                        new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, Convert.ToByte(0)),
                        BrickAlignment.Center);


            var pFooter = new PageFooterArea(new[] { "", "", "[Page # of Pages #]" },
                new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
                BrickAlignment.Near
            );
            pComponentLink.PageHeaderFooter = new PageHeaderFooter(pHeader, pFooter);
            pPreview.PrintingSystem = pSystem;

            if (ctrl is GridControl)
            {
                pComponentLink.Component = ctrl as GridControl;
            }
            else if (ctrl is SchedulerControl)
            {
                pComponentLink.Component = ctrl as SchedulerControl;
            }
            else if (ctrl is TreeList)
            {
                pComponentLink.Component = ctrl as TreeList;
            }
            else if (ctrl is LayoutControl)
            {
                pComponentLink.Component = ctrl as LayoutControl;
            }
            else if (ctrl is PivotGridControl)
            {
                var ctrl2 = ctrl as PivotGridControl;
                ctrl2.OptionsPrint.PrintFilterHeaders = DefaultBoolean.False;
                ctrl2.OptionsPrint.PrintDataHeaders = DefaultBoolean.False;
                ctrl2.OptionsPrint.PrintUnusedFilterFields = false;
                pComponentLink.Component = ctrl2;
            }
            else if (ctrl is ChartControl)
            {
                pComponentLink.Component = ctrl as ChartControl;
            }

            pComponentLink.CreateDocument();
            if (Orientacion.Contains("HISTORIA"))
            {
                pSystem.SetCommandVisibility(PrintingSystemCommand.PrintSelection, CommandVisibility.None);
                pSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
            }


            byte[] b = null;
            var tempName = Path.GetTempFileName() + ".pdf";
            pComponentLink.ExportToPdf(tempName);
            //using (Stream stream = File.Open(tempName, FileMode.Open))
            //{
            //    return stream;
            //}
            byte[] bytes = null;
            try
            {

                using (FileStream fsSource = new FileStream(tempName, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);                        
                        if (n == 0)                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }                                        
                }
            }
            catch (Exception) { }
            return new MemoryStream(bytes);
        }

    }
}