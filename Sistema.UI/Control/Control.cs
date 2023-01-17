using Base.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Sistema.Model;
using Sistema.UI.Persona;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base.Data;
using Sistema.UI.Judicial;

namespace Sistema.UI.Ctrls
{
    public class Glue
    {
        public static void FnGlueLocalidad(GridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().Localidad;
            Ext.Glue.GridLookUpEdit(glue, data, "IdLocalidad", "Descripcion", new string[] { "Descripcion" });
            Ext.Form.FnEdicionGlue(glue, typeof(FLocalidad));
        }


        public static void FnGlueSINO(GridLookUpEdit glue, object data)
        {
            if (data == null) data = SiNo.Lista();
            Ext.Glue.GridLookUpEdit(glue, data, "ID", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnGlueTipoContingencia(GridLookUpEdit glue, object data)
        {
            if (data == null) data = TipoContingencia.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnGlueCentroArbitral(GridLookUpEdit glue, object data)
        {
            if (data == null) data = TipoCentroArbitral.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnGlueTipoArbitraje(GridLookUpEdit glue, object data)
        {
            if (data == null) data = TipoArbitraje.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }


        public static void FnGlueModalidad(GridLookUpEdit glue, object data)
        {
            if (data == null) data = TipoModalidad.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnGlueUbicacion(GridLookUpEdit glue, object data)
        {
            if (data == null) data = TipoUbicacion.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnGlueEtapaProceso(GridLookUpEdit glue, object data)
        {
            if (data == null) data = TipoEtapaProceso.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }
        public static void FnGlueLaudoAFavor(GridLookUpEdit glue, object data)
        {
            if (data == null) data = TipoLaudoFavor.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }


        public static void FnGlueTipoMoneda(GridLookUpEdit glue, object data)
        {
            if (data == null) data = TipoMoneda.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }
        public static void FnGlueSedeJudicialDescripcion(GridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().SedeJudicial;
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnGlueTipoNotificacionEX(GridLookUpEdit glue, object data)
        {
            if (data == null) data = TipoNotificacionEx.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnGlueLocalidadConsulta(GridLookUpEdit glue, object data)
        {
            ContextoModelo ctxModelo = new ContextoModelo();
            //var lData = (from ta in ctxModelo.Localidad
            //             select ta.IdLocalidadPadre).Distinct();
            if (data == null)
                //data = (from ele in ctxModelo.Localidad.Include("Localidad2") where !(lData).Contains(ele.IdLocalidad) select ele);
                data = (from ele in ctxModelo.VLocalidad select ele).ToList();
            Ext.Glue.GridLookUpEdit(glue, data, "IdLocalidad", "DescripcionLugar", new string[] { "DescripcionLugar" });
            Ext.Form.FnEdicionGlue(glue, typeof(FLocalidad));
        }
        public static void FnGluePersona(GridLookUpEdit glue, string tipoInterno){
            object data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno);
            Ext.Glue.GridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
        }


        public static void FnGluePersonaTipoInterTipoFiltro(GridLookUpEdit glue, string tipoInterno, string tipoFiltro)
        {
            object data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno && x.TipoFiltro == tipoFiltro);
            Ext.Glue.GridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
        }



        public static void FnGlueRpiPersonaTipoInterTipoFiltro(RepositoryItemGridLookUpEdit glue, string tipoInterno, string tipoFiltro)
        {
            object data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno && x.TipoFiltro == tipoFiltro);
            Ext.Glue.RpiGridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
        }

        public static void FnGluePersonaAll(GridLookUpEdit glue)
        {
            object data = new ContextoModelo().PersonaEmpresa;
            Ext.Glue.GridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
        }

        public static void FnRpiGluePersona(RepositoryItemGridLookUpEdit rpiGlue, string tipoInterno)
        {
            object data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno);
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
        }

        public static void FnGlueTipoOrganoJudicial(GridLookUpEdit glue)
        {
            object data = TipoOrganoJudicial.GLista();
            Ext.Glue.GridLookUpEdit(glue, data, "Descripcion", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnGlueSedeJudicial(GridLookUpEdit glue)
        {
            object data = new ContextoModelo().SedeJudicial;
            Ext.Glue.GridLookUpEdit(glue, data, "IdSede", "Descripcion", new string[] { "Descripcion" });
        }


        public static void FnGlueSedeArbitral(GridLookUpEdit glue)
        {
            object data = new ContextoModelo().SedeJudicial.Where(x=>x.TipoInterno== "SEDEARBITRAL").ToList();
            Ext.Glue.GridLookUpEdit(glue, data, "IdSede", "Descripcion", new string[] { "Descripcion" });
        }
        //
        public static void FnGlueTipoProceso(GridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().TipoProceso;
            Ext.Glue.GridLookUpEdit(glue, data, "IdTipoProceso", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnGlueClaseProceso(GridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().ClaseProceso;
            Ext.Glue.GridLookUpEdit(glue, data, "IdClaseProceso", "Descripcion", new string[] { "Descripcion" });
        }


        public static void FnGlueNotificacion(GridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().TipoContenido.Where(x=>x.TipoInterno=="NOTIFICACION");
            Ext.Glue.GridLookUpEdit(glue, data, "IdTipoContenido", "Titulo", new string[] { "Titulo" });
        }



        public static void FnRpiGlueTipoCntenido(RepositoryItemGridLookUpEdit rpiGlue)
        {
            object data = new ContextoModelo().TipoContenido.Where(y=>y.TipoInterno!="NOTIFICACION");
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdTipoContenido", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnRpiGlueTipoEstadoActual(GridLookUpEdit rpiGlue)
        {
            object data = new ContextoModelo().TipoContenido.Where(y => y.TipoInterno == "ESTADOSACTUALES");
            Ext.Glue.GridLookUpEdit(rpiGlue, data, "IdTipoContenido", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnRpiGlueNotificacion(RepositoryItemGridLookUpEdit rpiGlue)
        {
            object data = new ContextoModelo().TipoContenido.Where(y => y.TipoInterno == "NOTIFICACION");
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdTipoContenido", "Titulo", new string[] { "Titulo" });
        }

        public static void FnRpiGlueInstancia(RepositoryItemGridLookUpEdit rpiGlue)
        {
            object data = new ContextoModelo().InstanciaJudicial;
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdInstancia", "Descripcion", new string[] { "Descripcion" });
        }


        public static void FnGlueInstancia(GridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().InstanciaJudicial;
            Ext.Glue.GridLookUpEdit(glue, data, "IdInstancia", "Descripcion", new string[] { "Descripcion" });
        }


        public static void FnRpiGlueSedeJudicial(RepositoryItemGridLookUpEdit rpiGlue)
        {
            object data = new ContextoModelo().SedeJudicial;
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdSede", "Descripcion", new string[] { "Descripcion" });
        }


        public static void FnRpiGlueContratos(RepositoryItemGridLookUpEdit rpiGlue)
        {
            object data = new ContextoModelo().PersonaEmpresa.Where(y=>y.TipoInterno== "CONTRATOS");
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
        }

        public static void FnRpiGlueOrganoJudicial(RepositoryItemGridLookUpEdit rpiGlue)
        {
            object data = new ContextoModelo().OrganoJudicial;
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdOrgano", "Descripcion", new string[] { "SedeJudicial.Descripcion", "Descripcion" });
        }


        public static void FnGlueOrganoJudicial(GridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().OrganoJudicial;
            Ext.Glue.GridLookUpEdit(glue, data, "IdOrgano", "Descripcion", new string[] { "Tipo", "Descripcion" });
        }

        public static void FnRpiGlueOpcione(RepositoryItemGridLookUpEdit rpiGlue)
        {
            object data = new ContextoModelo().Opcion;
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdOpcion", "Descripcion", new string[] { "Descripcion" });
        }

        public static void FnRpiGlueTipoDerecho(RepositoryItemGridLookUpEdit rpiGlue)
        {
            object data = TipoDerecho.GLista();
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "ID", "Descripcion", new string[] { "Descripcion" });
        }


        //
        public static void FnGlueDemandanteEdit(GridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == "ODEMANDA").ToList();
            Ext.Glue.GridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
            Ext.Form.FnEdicionGlue(glue, typeof(FPersona), "ODEMANDA");
        }


        public static void FnRpiGlueDemandanteEdit(RepositoryItemGridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == "ODEMANDA").ToList();
            Ext.Glue.RpiGridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
            Ext.Form.FnEdicionRpiGlue(glue, typeof(FPersona), "ODEMANDA");
        }

        public static void FnRpiGlueTrabajadorJudicialEdit(RepositoryItemGridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == "ABOGADOS").ToList();
            Ext.Glue.RpiGridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
            Ext.Form.FnEdicionRpiGlue(glue, typeof(FPersona), "ABOGADOS");
        }


        public static void FnRpiGluePersonaAbogados(RepositoryItemGridLookUpEdit rpiGlue, string tipoInterno)
        {
            object data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno);
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
        }

        public static void FnRpiGluePersonaAbogadosPorEstudio(RepositoryItemGridLookUpEdit rpiGlue, string tipoInterno, int idEstudio)
        {
            object data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno && x.IdPersonaEmpresa==idEstudio);
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
        }

        public static void FnRpiGluePersonaAbogadosEdit(RepositoryItemGridLookUpEdit rpiGlue, string tipoInterno)
        {
            object data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno);
            Ext.Glue.RpiGridLookUpEdit(rpiGlue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
            Ext.Form.FnEdicionRpiGlue(rpiGlue, typeof(FPersona), "OASESORJURIDOCO");
        }

        public static void FnGlueDemandadoEdit(GridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == "ODEMANDA").ToList();
            Ext.Glue.GridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
            Ext.Form.FnEdicionGlue(glue, typeof(FPersona), "ODEMANDA");
        }
        

        public static void FnRpiGlueDemandadoEdit(RepositoryItemGridLookUpEdit glue, object data)
        {
            if (data == null) data = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == "ODEMANDA").ToList();
            Ext.Glue.RpiGridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
            Ext.Form.FnEdicionRpiGlue(glue, typeof(FPersona), "ODEMANDA");
        }

        public static void FnGlueAbogadoEdit(GridLookUpEdit glue, object data, string tipoInterno)
        {
            object dataa = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno);
            Ext.Glue.GridLookUpEdit(glue, dataa, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
            Ext.Form.FnEdicionGlue(glue, typeof(FPersona), "OASESORJURIDOCO");
        }

        public static void FnGlueArbitrosEdit(GridLookUpEdit glue, object data, string tipoInterno)
        {
            object dataa = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno);
            Ext.Glue.GridLookUpEdit(glue, dataa, "Nombre", "Nombre", new string[] { "Documento", "Nombre" });
            Ext.Form.FnEdicionGlue(glue, typeof(FPersona), "OASESORJURIDOCO");
        }

        public static void FnGlueSupervisorInternoEdit(GridLookUpEdit glue, object data, string tipoInterno)
        {
            object dataa = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno);
            Ext.Glue.GridLookUpEdit(glue, dataa, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
            Ext.Form.FnEdicionGlue(glue, typeof(FPersona), "SUPERVISORINTERNO");
        }

        public static void FnGlueContratosEdit(GridLookUpEdit glue, object data, string tipoInterno)
        {
            object dataa = new ContextoModelo().PersonaEmpresa.Where(x => x.TipoInterno == tipoInterno);
            Ext.Glue.GridLookUpEdit(glue, dataa, "IdPersonaEmpresa", "Nombre", new string[] { "Documento>Nro. Contrato", "Nombre>Descripción" });
            Ext.Form.FnEdicionGlue(glue, typeof(FPersona), "CONTRATOS");
        }



        public static void FnGlueEstadoActualEdit(GridLookUpEdit glue, object data, string tipoInterno)
        {

            object dataa = new ContextoModelo().TipoContenido.Where(y => y.TipoInterno == "ESTADOSACTUALES");
            Ext.Glue.GridLookUpEdit(glue, dataa, "IdTipoContenido", "Descripcion", new string[] { "Descripcion" });
            Ext.Form.FnEdicionGlue(glue, typeof(FTipoContenido), "ESTADOSACTUALES");
        }

        public static void FnGlueTipoContenidoEdit(GridLookUpEdit glue, object data, string tipoInterno)
        {

            object dataa = new ContextoModelo().TipoContenido.Where(y => y.TipoInterno ==tipoInterno);
            Ext.Glue.GridLookUpEdit(glue, dataa, "IdTipoContenido", "Descripcion", new string[] { "Descripcion" });
            Ext.Form.FnEdicionGlue(glue, typeof(FTipoContenido), tipoInterno);
        }


        public static void FnGluePersonasByIDEmpresa(GridLookUpEdit glue, object data,int IdEmpresa )
        {
            if (data == null) data = new ContextoModelo().PersonaEmpresa.Where(x => x.IdEmpresa == IdEmpresa);
            Ext.Glue.GridLookUpEdit(glue, data, "IdPersonaEmpresa", "Nombre", new string[] { "Documento", "Nombre" });
        }


    }
}
