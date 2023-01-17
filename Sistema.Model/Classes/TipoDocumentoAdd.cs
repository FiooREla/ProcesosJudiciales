


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{

    public class TipoDocumentoAdd
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoDocumentoAdd> GLista()
        {
            List<TipoDocumentoAdd> lista = new List<TipoDocumentoAdd>();
            lista.Add(new TipoDocumentoAdd() { ID = 1, Descripcion = "Expediente" });
            lista.Add(new TipoDocumentoAdd() { ID = 2, Descripcion = "Comprobante" });
            lista.Add(new TipoDocumentoAdd() { ID = 3, Descripcion = "Administrativo" });

            return lista;
        }
    }
}
