using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Sistema.Model
{    
    public partial class PersonaEmpresa
    {
        private EntityCollection<Empleado> empleados;
        public EntityCollection<Empleado> Empleados
        {
            get
            {
                EntityCollection<Empleado> lista = new EntityCollection<Empleado>();
                List<int> ids = this.Personas.Select(x => x.IdPersonaEmpresa).ToList();
                foreach (var item in ids) lista.Add(new Empleado() { ID = item });
                return lista;
            }
            set { empleados = value; }
        }
    }

    public class Empleado
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
