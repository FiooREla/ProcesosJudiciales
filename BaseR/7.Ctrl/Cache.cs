using System.Collections;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using BaseR.Delegate;

namespace BaseR.Ctrls
{
    public class ICache
    {
        public ICache(Event_FnData fn, string tipoInterno, string args, bool async)
        {
            Lista = new List<EntityObject>();
            Fn = fn;
            TipoInterno = tipoInterno;
            Args = args;
            if (!async) FnData();
        }

        private Event_FnData Fn { get; }
        private string TipoInterno { get; }
        private string Args { get; }
        public IList Lista { get; set; }

        public void FnEntidad(EntityObject entidad, EnumEdicion tipoEdicion)
        {
            if (tipoEdicion == EnumEdicion.Nuevo)
            {
                Lista.Add(entidad);
            }
            else
            {
                object item = null;
                for (var i = 0; i < Lista.Count; i++)
                {
                    var eo = Lista[i] as EntityObject;
                    if (entidad.EntityKey == eo.EntityKey) item = Lista[i];
                }

                if (item != null) Lista.Remove(item);
                if (tipoEdicion == EnumEdicion.Editar) Lista.Add(entidad);
            }
        }

        public void FnData()
        {
            Lista = Fn(TipoInterno, Args) as IList;
        }
    }

    public class Cache
    {
        public static List<Cache> Stores = new List<Cache>();
        public string Key { get; set; }
        public string TipoInterno { get; set; }
        public string Args { get; set; }
        public ICache Entidad { get; set; }

        public static Cache FnAdd(string name, string tipoInterno, string args, Event_FnData fn, bool async)
        {
            var item = new Cache
            {
                Key = name,
                TipoInterno = tipoInterno,
                Args = args,
                Entidad = new ICache(fn, tipoInterno, args, async)
            };
            Stores.Add(item);
            return item;
        }

        public static Cache FnGet(string name, string tipoInterno, string args)
        {
            var item = Stores.FirstOrDefault(x => x.Key == name && x.TipoInterno == tipoInterno && x.Args == args);
            return item;
        }

        public static void FnSet(string name, string tipoInterno, string args, EntityObject entidad,
            EnumEdicion tipoEdicion)
        {
            var item = FnGet(name, tipoInterno, args);
            if (item != null) item.Entidad.FnEntidad(entidad, tipoEdicion);
        }
    }
}