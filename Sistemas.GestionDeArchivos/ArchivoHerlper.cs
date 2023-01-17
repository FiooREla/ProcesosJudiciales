using System;
using System.IO;
using static Sistema.GestionDeArchivos.Archivo;

namespace Sistema.GestionDeArchivos
{

    public class ArchivoHerlper {



        private static string RutaExpedienteArbitral = Path.Combine("127.0.0.1", "C", "DocumentosSIPJ", "ExpArbitrales");
        private static string RutaExpedienteJudiciales = Path.Combine("127.0.0.1", "C", "DocumentosSIPJ", "ExpJudiciales");

        public ArchivoHerlper() {


            if (!Directory.Exists(RutaExpedienteArbitral))
            {
                Directory.CreateDirectory(RutaExpedienteArbitral);
            }
            if (!Directory.Exists(RutaExpedienteJudiciales))
            {
                Directory.CreateDirectory(RutaExpedienteJudiciales);
            }

        }

        public string CrearRutaArchivo(string nombreArchivo , string idTramite , TipoDeArchivo tipoArchivo )

        {
            string rutaCarpeta = "";

            if (tipoArchivo == TipoDeArchivo.ExpedientesArbitrales)
            {

                 rutaCarpeta = Path.Combine(RutaExpedienteArbitral, idTramite);
            }
            else if (tipoArchivo == TipoDeArchivo.ExpedientesJudciales) {


                 rutaCarpeta = Path.Combine(RutaExpedienteArbitral, idTramite);
            }
         
            return Path.Combine(rutaCarpeta, nombreArchivo);

        }
        public void CrearArchivo(string nombreArchivo ) {


            string rutaCarpeta = Path.GetDirectoryName(nombreArchivo);
            if (Directory.Exists(rutaCarpeta)) { 
                
                Directory.CreateDirectory(rutaCarpeta); 
                     
            }
            if (File.Exists(nombreArchivo))
            {
                File.Delete(nombreArchivo);
            }
            
            File.Create(nombreArchivo);
        
        }

        public void EliminarArchivo(string archivoEliminar) {


            if (File.Exists(archivoEliminar))
            {
                File.Delete(archivoEliminar);

            }


        }
        public void Eliminar(string idTramite, TipoDeArchivo tipoArchivo)
        {
            string rutaFolder = "";

            if (tipoArchivo == TipoDeArchivo.ExpedientesArbitrales)
            {
                rutaFolder = Path.Combine(Path.Combine(RutaExpedienteArbitral, idTramite));


            }
            else if (tipoArchivo == TipoDeArchivo.ExpedientesJudciales)
            {
                rutaFolder = Path.Combine(Path.Combine(RutaExpedienteJudiciales, idTramite));
               
            }
            else
            {
                throw new ArgumentException("Archivo no permitido.");
            }

            string[] archivosEcontrados = Directory.GetFiles(rutaFolder);

            foreach (string archivoEcontrado in archivosEcontrados)
            {
                if (File.Exists(archivoEcontrado))
                {
                    File.Delete(archivoEcontrado);

                }
            }

        }


    }

}
