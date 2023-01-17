namespace Sistema.UI.Judicial
{
    partial class FRAgendaJudicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRAgendaJudicial));
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.bsLista = new System.Windows.Forms.BindingSource(this.components);
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.Calendario = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnMostrar = new DevExpress.XtraEditors.SimpleButton();
            this.deFin = new DevExpress.XtraEditors.DateEdit();
            this.deInicio = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calendario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInicio.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonForm
            // 
            this.RibbonForm.ExpandCollapseItem.Id = 0;
            this.RibbonForm.ExpandCollapseItem.Name = "";
            this.RibbonForm.Size = new System.Drawing.Size(758, 117);
            // 
            // bsLista
            // 
            this.bsLista.DataSource = typeof(Sistema.Model.ClaseProceso);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.Calendario;
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A3;
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // Calendario
            // 
            this.Calendario.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.Calendario.LimitInterval.Duration = System.TimeSpan.Parse("310.23:59:00");
            this.Calendario.LimitInterval.Start = new System.DateTime(2014, 12, 25, 0, 0, 0, 0);
            this.Calendario.Location = new System.Drawing.Point(12, 38);
            this.Calendario.MenuManager = this.RibbonForm;
            this.Calendario.Name = "Calendario";
            this.Calendario.Size = new System.Drawing.Size(734, 229);
            this.Calendario.Start = new System.DateTime(2015, 1, 12, 0, 0, 0, 0);
            this.Calendario.Storage = this.schedulerStorage1;
            this.Calendario.TabIndex = 7;
            this.Calendario.Text = "schedulerControl1";
            
            
            
            timeRuler1.TimeZoneId = "Hora est. Pacífico, Sudamérica";
            
            timeRuler1.UseClientTimeZone = false;
            this.Calendario.Views.DayView.TimeRulers.Add(timeRuler1);
            this.Calendario.Views.GanttView.Enabled = false;
            this.Calendario.Views.WeekView.Enabled = false;
            this.Calendario.Views.WorkWeekView.ShowWorkTimeOnly = true;
            
            
            
            timeRuler2.TimeZoneId = "Hora est. Pacífico, Sudamérica";
            
            timeRuler2.UseClientTimeZone = false;
            this.Calendario.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Calendario);
            this.layoutControl1.Controls.Add(this.btnMostrar);
            this.layoutControl1.Controls.Add(this.deFin);
            this.layoutControl1.Controls.Add(this.deInicio);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 117);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(758, 279);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnMostrar
            // 
            this.btnMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrar.Image = global::Sistema.UI.Properties.Resources.Search216x16;
            this.btnMostrar.Location = new System.Drawing.Point(565, 12);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(181, 22);
            this.btnMostrar.StyleController = this.layoutControl1;
            this.btnMostrar.TabIndex = 6;
            this.btnMostrar.Text = "Actualizar Listado";
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // deFin
            // 
            this.deFin.EditValue = null;
            this.deFin.Location = new System.Drawing.Point(358, 12);
            this.deFin.MenuManager = this.RibbonForm;
            this.deFin.Name = "deFin";
            this.deFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFin.Size = new System.Drawing.Size(203, 20);
            this.deFin.StyleController = this.layoutControl1;
            this.deFin.TabIndex = 5;
            // 
            // deInicio
            // 
            this.deInicio.EditValue = null;
            this.deInicio.Location = new System.Drawing.Point(70, 12);
            this.deInicio.MenuManager = this.RibbonForm;
            this.deInicio.Name = "deInicio";
            this.deInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deInicio.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deInicio.Size = new System.Drawing.Size(226, 20);
            this.deInicio.StyleController = this.layoutControl1;
            this.deInicio.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(758, 279);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deInicio;
            this.layoutControlItem1.CustomizationFormText = "Fecha Incio";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(288, 26);
            this.layoutControlItem1.Text = "Fecha Incio";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deFin;
            this.layoutControlItem2.CustomizationFormText = "Fecha Fin";
            this.layoutControlItem2.Location = new System.Drawing.Point(288, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(265, 26);
            this.layoutControlItem2.Text = "Fecha Fin";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnMostrar;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(553, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(185, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Calendario;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(738, 233);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // FRAgendaJudicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 423);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FRAgendaJudicial";
            this.Tag = "LISTA";
            this.Text = "Listado - Agendas Judiciales";
            this.Controls.SetChildIndex(this.RibbonForm, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calendario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deFin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInicio.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsLista;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraScheduler.SchedulerControl Calendario;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraEditors.SimpleButton btnMostrar;
        private DevExpress.XtraEditors.DateEdit deFin;
        private DevExpress.XtraEditors.DateEdit deInicio;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}