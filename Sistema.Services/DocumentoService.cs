using AutoMapper;
using Sistema.Services.Modelo;
using System;
using System.Linq;


namespace Sistema.Services
{
    public class DocumentoService
    {
            
        private Sistema.Model.ContextoModelo CtxModelo;
      
        public DocumentoService()
        {
            CtxModelo = new Sistema.Model.ContextoModelo();
         
        }

        public bool Guardar()
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    CtxModelo.SaveChanges();

                    return true;

                }
                //CtxModelo.Documento.AddObject(documento);


            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Eliminar(Sistema.Model.Documento documento)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    CtxModelo.Documento.DeleteObject(documento);
                    CtxModelo.SaveChanges();
                }


                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Modificar(Sistema.Model.Documento documento)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    CtxModelo.Documento.AddObject(documento);
                    CtxModelo.SaveChanges();
                    Documento convertirDocumento = Mapper.Map<Sistema.Model.Documento, Documento>(documento);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Documento BuscarDocumentoPorExpediente(string codigoExpediente)
        
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    Sistema.Model.Documento oFile = CtxModelo.Documento.Where(x => x.IdNEWID == codigoExpediente).FirstOrDefault();
                    Documento documentoConvertido = Mapper.Map<Sistema.Model.Documento , Documento>(oFile);
                    return documentoConvertido;
                }
            }
            catch (Exception ex)
            {
                Documento oFile = null;
                return oFile;
            }          
        }

        public bool AgregarDocumento(Sistema.Model.Documento oDocumento)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    CtxModelo.AddToDocumento(oDocumento);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Documento BuscarPorEntidadExpediente(string IdNEWID)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    Sistema.Model.Documento oDocumento = CtxModelo.Documento.Where(x => x.IdNEWID == IdNEWID).FirstOrDefault();
                    Documento documentoConvertido = Mapper.Map<Sistema.Model.Documento, Documento>(oDocumento);
                    return documentoConvertido;
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }

    }
}
