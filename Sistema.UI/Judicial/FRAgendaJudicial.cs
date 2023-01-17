using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraScheduler;
using Sistema.Model;
using Sistema.Query;
using Sistema.UI.Persona;

namespace Sistema.UI.Judicial
{
    public partial class FRAgendaJudicial : FBaseForm
    {
        ContextoModelo CtxModelo = new ContextoModelo();
        public FRAgendaJudicial()
        {
            InitializeComponent();
            wbtnBorrar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            wbtnEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            wbtnNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            rbtnVisualizar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            deInicio.EditValue = DateTime.Now;
            deFin.EditValue = DateTime.Now.AddDays(7);

        }

        public override void FnImprimir()
        {
            PrintPreviewRibbonFormEx pViewEx = new PrintPreviewRibbonFormEx();
            pViewEx.PrintingSystem = printingSystem1;
            printableComponentLink1.CreateDocument();
            pViewEx.Show();
        }

        private void GenerarDiasSemana()
        {
             Calendario.Storage.Appointments.Clear();
            Calendario.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            
            DateTime dInicio;
            DateTime dFin;
            List<ActoProcesal> lActo;

            dInicio =(DateTime) deInicio.EditValue;
            dFin = (DateTime)deFin.EditValue;

            Calendario.LimitInterval.Start = dInicio;
            Calendario.LimitInterval.End = dFin;
            
            Calendario.Start = dInicio.AddDays(-1);

            lActo =CtxModelo.ActoProcesal.Where(x => x.FechaAvisoAlerta >= dInicio && x.FechaAvisoAlerta <= dFin).ToList();

            foreach (ActoProcesal item in  lActo)
            {
                DateTime dtValue = (DateTime)item.FechaAvisoAlerta;

                Appointment apt = Calendario.Storage.CreateAppointment(AppointmentType.Normal);
                apt.Start = (DateTime)item.FechaAvisoAlerta;
                apt.Duration = TimeSpan.FromHours(2);
                apt.Subject = item.Expediente.Codigo;//   apt.StatusId = AppointmentStatusType.Tentative;
                apt.StatusId = 1;
                apt.LabelId = 3;
                apt.Description = item.Contenido.ToString();
                Calendario.Storage.Appointments.Add(apt);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            GenerarDiasSemana();
        }


    }
}
