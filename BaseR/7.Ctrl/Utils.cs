using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace BaseR.Ctrls
{
    public class Utils
    {
        public static void FnEnabledControl(List<Control> ctrls, bool enabled)
        {
            foreach (var item in ctrls)
                item.Enabled = enabled;
            //if (item is TextEdit) item.Enabled = enabled;
            //else if (item is DateEdit) item.Enabled = enabled;
            //else if (item is DateEdit) item.Enabled = enabled;
        }

        public static void FnEnabledControl(List<BarItem> ctrls, bool enabled)
        {
            foreach (var item in ctrls)
                item.Enabled = enabled;
            //if (item is TextEdit) item.Enabled = enabled;
            //else if (item is DateEdit) item.Enabled = enabled;
            //else if (item is DateEdit) item.Enabled = enabled;
        }

        public static void FnFiltroFecha(ref DateTime fInicio, ref DateTime fFin)
        {
            fInicio = new DateTime(fInicio.Year, fInicio.Month, fInicio.Day, 0, 0, 0);
            fFin = new DateTime(fFin.Year, fFin.Month, fFin.Day, 23, 59, 59);
        }

        public static void FnFiltroFecha(ref DateTime fInicio, BarEditItem bbiFInicio, ref DateTime fFin,
            BarEditItem bbiFFin)
        {
            fInicio = Convert.ToDateTime(bbiFInicio.EditValue);
            fFin = Convert.ToDateTime(bbiFFin.EditValue);
            fInicio = new DateTime(fInicio.Year, fInicio.Month, fInicio.Day, 0, 0, 0);
            fFin = new DateTime(fFin.Year, fFin.Month, fFin.Day, 23, 59, 59);
        }

        public static void FnFiltroHora(ref DateTime fInicio, ref DateTime fFin, ref DateTime hInicio,
            ref DateTime hFin)
        {
            fInicio = new DateTime(fInicio.Year, fInicio.Month, fInicio.Day, hInicio.Hour, hInicio.Minute, 0);
            fFin = new DateTime(fFin.Year, fFin.Month, fFin.Day, hFin.Hour, hFin.Minute, 59);
        }

        public static void FnFiltroFecha(ref DateTime fInicio, DateEdit deInicio, ref DateTime fFin, DateEdit deFin)
        {
            fInicio = Convert.ToDateTime(deInicio.EditValue);
            fFin = Convert.ToDateTime(deFin.EditValue);
            fInicio = new DateTime(fInicio.Year, fInicio.Month, fInicio.Day, 0, 0, 0);
            fFin = new DateTime(fFin.Year, fFin.Month, fFin.Day, 23, 59, 59);
        }

        public static void FnFiltroFechaInicio(BarEditItem bbiFInicio, BarEditItem bbiFFin)
        {
            bbiFInicio.EditValue = DateTime.Now;
            bbiFFin.EditValue = DateTime.Now;
            //if (BaseSession.PCDev) bbiFInicio.EditValue = DateTime.Now.AddDays(-3);
        }

        public static void FnFiltroFechaInicioMes(BarEditItem bbiFInicio, BarEditItem bbiFFin)
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //if (Base.BaseSession.PCDev) date = date.AddMonths(-1);
            bbiFInicio.EditValue = date;
            bbiFFin.EditValue = DateTime.Now;
        }

        public static void FnFiltroFechaInicioMes(BarEditItem bbiFInicio, BarEditItem bbiFFin, int NroMesesAtras)
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            date = date.AddMonths(NroMesesAtras);
            bbiFInicio.EditValue = date.AddDays(1);
            bbiFFin.EditValue = DateTime.Now;
        }

        public static void FnFiltroHora(BarEditItem bbiFInicio, BarEditItem bbiFFin)
        {
            bbiFInicio.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 7, 0, 0);
            bbiFFin.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 14, 0, 0);
        }

        public static void FnFiltroFechaInicioYear(BarEditItem bbiFInicio, BarEditItem bbiFFin)
        {
            bbiFInicio.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            bbiFFin.EditValue = DateTime.Now;
        }

        public static void FnFiltroFecha(DateEdit deInicio, DateEdit deFin)
        {
            var fecha = DateTime.Now;
            deInicio.EditValue = new DateTime(fecha.Year, fecha.Month, 1, 0, 0, 0);
            deFin.EditValue = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
        }
    }
}