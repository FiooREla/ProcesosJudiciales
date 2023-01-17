using AutoMapper;
using Sistema.Services.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{

    public class PersonaService
    {
        private Sistema.Model.ContextoModelo CtxModelo;

        public PersonaEmpresa BuscarPersona(int idPersona)
        {
            try
            {
                using (CtxModelo = new Sistema.Model.ContextoModelo())
                {
                    Sistema.Model.PersonaEmpresa personaEmpresa = CtxModelo.PersonaEmpresa.Where(c => c.IdPersonaEmpresa == idPersona).FirstOrDefault();
                    //PersonaEmpresa personaEmpresaConvertido = Mapper.Map<Sistema.Model.PersonaEmpresa, PersonaEmpresa>(personaEmpresa);
                    PersonaEmpresa personaEmpresaConvertido = Mapper.Map<Sistema.Model.PersonaEmpresa, PersonaEmpresa>(personaEmpresa);
                    return personaEmpresaConvertido;
                }
                
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
