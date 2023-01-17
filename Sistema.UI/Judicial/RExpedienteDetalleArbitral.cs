using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Schedule;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraReports.UI;
//using Sistema.Model;
using Sistema.Services.Modelo;

namespace Sistema.UI.Judicial
{
    public partial class RExpedienteDetalleArbitral : DevExpress.XtraReports.UI.XtraReport
    {
        public RExpedienteDetalleArbitral(Expediente oExpediente)
        {
            InitializeComponent();

            ContextoModelo ctxModelo = new ContextoModelo();

            Expediente oExpedienteTemp = ctxModelo.Expediente.Where(x => x.IdExpediente == oExpediente.IdExpediente).FirstOrDefault();


            bsLista.DataSource = oExpediente;

            System.Drawing.Font fFont1 = xr1.Font;
           


            List<ActoProcesalContenido> items = new List<ActoProcesalContenido>();
            foreach (var item in oExpedienteTemp.ActoProcesal)
                items.AddRange(item.ActoProcesalContenido);

            bsDetalle.DataSource = items;

            bsVista.DataSource = ctxModelo.viewExpedienteReport.Where(x => x.IdExpediente == oExpediente.IdExpediente);

            ExpedienteAsesorLegal expedienteAsesorLegal = oExpediente.ExpedienteAsesorLegal.LastOrDefault();

            if (expedienteAsesorLegal != null)
            {
                xrPatrocinante.Text = expedienteAsesorLegal.PersonaEmpresa1.Nombre;
                xrOrdenServicio.Text = expedienteAsesorLegal.NroOS_RA_C;
            }

            foreach (OrganoExpedientePersona item in oExpediente.OrganoExpedienteDemandado)
            {
                XRTableRow row = new XRTableRow();
                XRTableCell parCell= new XRTableCell();
                XRTableCell TipoCell = new XRTableCell();
                XRTableCell nombreCellCell = new XRTableCell();
               
                parCell.Text = "DEMANDADO";
                parCell.Width = xr1.Width;
                TipoCell.Text = item.DemandadoExpediente.TipoFiltro.ToUpper();
                TipoCell.Width = xr2.Width; 
                nombreCellCell.Text = item.DemandadoExpediente.Nombre.ToUpper();
                nombreCellCell.Width = xr3.Width; 
                
                row.Cells.Add(parCell);
                row.Cells.Add(TipoCell);
                row.Cells.Add(nombreCellCell);
                row.Font = fFont1;
                xrTablePartes.Rows.Add(row);
            }

            foreach (OrganoExpedientePersona item in oExpediente.OrganoExpedienteDemandante)
            {
                XRTableRow row = new XRTableRow();
                XRTableCell parCell = new XRTableCell();
                XRTableCell TipoCell = new XRTableCell();
                XRTableCell nombreCellCell = new XRTableCell();

                parCell.Text = "DEMANDANTE";
                parCell.Width = xr1.Width;
                TipoCell.Text = item.DemandanteExpediente.TipoFiltro.ToUpper();
                TipoCell.Width = xr2.Width; 
                nombreCellCell.Text = item.DemandanteExpediente.Nombre.ToUpper();
                nombreCellCell.Width = xr3.Width; 
                row.Cells.Add(parCell);
                row.Cells.Add(TipoCell);
                row.Cells.Add(nombreCellCell);
                row.Font = fFont1;
                xrTablePartes.Rows.Add(row);
            }

            xrFechaImpresion.Text = DateTime.Now.ToShortDateString();
        //    For Each item In lvSuper
        //    If Nro <> 1 Then
        //        Dim row As New XRTableRow()
        //        Dim cell0 As New XRTableCell()
        //        cell0.Text = item.NombreCompleto
        //        cell0.Font = fontt
        //        row.Font = fontt
        //        row.Cells.Add(cell0)
        //        XrTableSuper.Rows.Add(row)
        //    End If
        //    Nro += 1
        //Next

          
            
        }

        
    }
}
                   