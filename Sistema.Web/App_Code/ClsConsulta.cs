using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ClsConsulta
{
    public static bool Login(string usuario, string password)
    {
        ContextoModelo ctxModelo = new ContextoModelo();
        Usuario entidad = (from ele in ctxModelo.Usuario
                           where ele.Codigo.ToUpper() == usuario.ToUpper() && ele.Clave == password
                           select ele).FirstOrDefault();
        return entidad != null;
    }

    public static List<viewExpediente> GlviewExpediente(DateTime fInicio, DateTime fFin)
    {
        ContextoModelo ctxModelo = new ContextoModelo();
        List<viewExpediente> lista = new List<viewExpediente>();
        lista = (from ele in ctxModelo.viewExpediente
                 where ele.FechaInicio >= fInicio && ele.FechaInicio <= fFin
                 select ele).ToList();
        return lista;
    }

    public static List<ActoProcesalContenido> GlActoProcesalContenido(int idExpediente)
    {
        ContextoModelo ctxModelo = new ContextoModelo();
        List<ActoProcesalContenido> lista = new List<ActoProcesalContenido>();
        lista = (from ele in ctxModelo.ActoProcesalContenido
                 where ele.ActoProcesal.IdExpediente == idExpediente
                 select ele).ToList();
        return lista;
    }

    public static List<viewExpedienteInstancia> GlviewExpedienteInstancia(int idExpediente)
    {
        ContextoModelo ctxModelo = new ContextoModelo();
        List<viewExpedienteInstancia> lista = new List<viewExpedienteInstancia>();
        lista = (from ele in ctxModelo.viewExpedienteInstancia
                 where ele.IdExpediente == idExpediente
                 select ele).ToList();
        return lista;
    }
}