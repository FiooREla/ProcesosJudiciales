using AutoMapper;
using Sistema.Services.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{
    public class TipoContenidoServices
    {
        private Sistema.Model.ContextoModelo CtxModelo;
        public TipoContenido BuscarTipoContenido(string sPc)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    Sistema.Model.TipoContenido tipoContenido = CtxModelo.TipoContenido.Where(t => t.Abreviado == sPc).FirstOrDefault();
                    TipoContenido tipoContenidoBuscar = Mapper.Map<Sistema.Model.TipoContenido, TipoContenido>(tipoContenido);
                    return tipoContenidoBuscar;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TipoContenido ReemplazarNombre()
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    Sistema.Model.TipoContenido tipoContenido = CtxModelo.TipoContenido.Where(t => t.Abreviado == "ESCANER").FirstOrDefault();
                    TipoContenido tipoContenidoReemplazar = Mapper.Map<Sistema.Model.TipoContenido, TipoContenido>(tipoContenido);
                    return tipoContenidoReemplazar;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
