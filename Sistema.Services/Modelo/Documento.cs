using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services.Modelo
{
    public class Documento
    {
        public int idDocumento { get; set; }
        public int IdDocumento2 { get; set; }
        public string Nombre { get; set; }
        public string Nombre2 { get; set; }
        public string Extension { get; set; }
        public string Extension2 { get; set; }
        public string IdNEWID { get; set; }
        public string IdNEWID2 { get; set; }
        public byte[] Documento1 { get; set; }
        public byte[] Documento12 { get; set; }
        public string RutaPc { get; set; }
        public string RutaPc2 { get; set; }
        public string Tipo { get; set; }
        public string Tipo2 { get; set; }
        public string TipoInterno { get; set; }
    }
}
