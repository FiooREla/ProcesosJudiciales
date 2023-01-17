using AutoMapper;
using Sistema.Services.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{
    public class ExpedienteService
    {

        private Sistema.Model.ContextoModelo CtxModelo;


        public ExpedienteService()
        {
            CtxModelo = new Sistema.Model.ContextoModelo() ;
        }

        public bool Grabar(Expediente expediente , List<Documento> listaDeDocumento) {

            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    Sistema.Model.Expediente documentoConvertido = Mapper.Map<Sistema.Model.Expediente, Expediente>(expediente);
                    Expediente documentoConvertido = Mapper.Map<Sistema.Model.Expediente, Expediente>(expediente);

                    foreach (Documento documento in listaDeDocumento)
                    {
                        CtxModelo.Documento.AddObject(documento);

                    }
                    CtxModelo.SaveChanges();

                    return true;
                }             
            }
            catch (Exception)
            {
                return false;
            }          
        }

        public bool Editar(Expediente expediente ,  List<Documento> listaDeDocumento)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    foreach (Documento documento in listaDeDocumento)
                    {
                        CtxModelo.Documento.AddObject(documento);

                    }
                    CtxModelo.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Expediente> ListarPorDemandante(int codigoDemandante)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    List<Sistema.Model.Expediente> lExpedienteExis = CtxModelo.Expediente.Where(x => x.IdDemandante == codigoDemandante && codigoDemandante != 289).ToList();

                    List<Expediente> listaEntidad = Mapper.Map<List<Sistema.Model.Expediente>, List<Expediente>>(lExpedienteExis);
                    return listaEntidad;

                }
            }
            catch (Exception)
            {
               
                    List<Expediente> lExpedienteExis = null;
                    return lExpedienteExis;
                
            }

        }
        public Expediente BuscarPorExpediente(int IdExpediente)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    Sistema.Model.Expediente expediente = CtxModelo.Expediente.Where(x => x.IdExpediente == IdExpediente).FirstOrDefault();
                    Expediente documentoConvertido = Mapper.Map<Sistema.Model.Expediente, Expediente>(expediente);
                    return documentoConvertido;
                }
            }
            catch (Exception)
            {
                Expediente expediente = null;
                return expediente;
            }
        }

        public bool BorrarExpediente(Expediente codigoexpediente)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    CtxModelo.DeleteObject(codigoexpediente);
                    CtxModelo.SaveChanges();
                    return true;
                }

            }
            catch (Exception)
            {
                return false; 
            }
        }

        public void AgregarExpediente(Expediente contenidoExpediente)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    Sistema.Model.Expediente documentoConvertido = Mapper.Map<Expediente , Sistema.Model.Expediente >(contenidoExpediente);
                    CtxModelo.AddToExpediente(documentoConvertido);
                }                           
            }
            catch (Exception)
            {

            }
        }
    }
}
