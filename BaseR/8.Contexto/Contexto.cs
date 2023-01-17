using System.Collections;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace BaseR
{
    public class Contexto
    {
        public static void FnCancelarCambios(ObjectContext contexto)
        {
            if (contexto == null) return;
            var deshaciendo = false;
            foreach (var entry in contexto.ObjectStateManager.GetObjectStateEntries(
                EntityState.Added | EntityState.Deleted | EntityState.Modified))
                if (entry.State != EntityState.Detached)
                    if (entry.Entity != null)
                        if (entry.State == EntityState.Added)
                        {
                            deshaciendo = true;
                            contexto.DeleteObject(entry.Entity);
                        }
                        else if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                        {
                            contexto.Refresh(RefreshMode.StoreWins, entry.Entity);
                            FnCancelarCambiosDetalles(contexto, entry.Entity as EntityObject);
                            deshaciendo = true;
                        }

            if (deshaciendo) contexto.AcceptAllChanges();
        }

        public static void FnCancelarCambiosDetalles(ObjectContext contexto, EntityObject entidad)
        {
            if (contexto == null || entidad == null) return;
            foreach (var prop in entidad.GetType().GetProperties())
            {
                var pValor = prop.GetValue(entidad, null);
                //si es una coleccion o referencia EntityCollection(uno a muchos) o EntityReference(uno a uno)
                if (prop.PropertyType.BaseType == typeof(RelatedEnd))
                {
                    var coleccion = pValor as IEnumerable;
                    var myEnumerator = coleccion.GetEnumerator();
                    while (myEnumerator.MoveNext())
                    {
                        var entidadHijo = myEnumerator.Current as EntityObject;
                        if (entidadHijo.EntityState == EntityState.Added)
                            contexto.DeleteObject(entidadHijo);
                        else if (entidadHijo.EntityState == EntityState.Modified ||
                                 entidadHijo.EntityState == EntityState.Deleted)
                            contexto.Refresh(RefreshMode.StoreWins, entidadHijo);
                    }
                }
                else if (prop.PropertyType.BaseType == typeof(EntityObject))
                {
                    var entidadHijo = pValor as EntityObject;
                    if (entidadHijo == null) return;
                    if (entidadHijo.EntityState == EntityState.Added)
                        contexto.DeleteObject(entidadHijo);
                    else if (entidadHijo.EntityState == EntityState.Modified ||
                             entidadHijo.EntityState == EntityState.Deleted)
                        contexto.Refresh(RefreshMode.StoreWins, entidadHijo);
                    foreach (var propHijo in pValor.GetType().GetProperties())
                    {
                        var pValorHijo = propHijo.GetValue(pValor, null);
                        if (propHijo.GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false).Count() != 1)
                        {
                            var coleccion = pValorHijo as IEnumerable;
                            if (coleccion != null)
                            {
                                var myEnumerator = coleccion.GetEnumerator();
                                while (myEnumerator.MoveNext())
                                {
                                    var entidadNieto = myEnumerator.Current as EntityObject;
                                    if (entidadNieto == null) return; //
                                    if (entidadNieto.EntityState == EntityState.Added)
                                        contexto.DeleteObject(entidadNieto);
                                    else if (entidadNieto.EntityState == EntityState.Modified ||
                                             entidadNieto.EntityState == EntityState.Deleted)
                                        contexto.Refresh(RefreshMode.StoreWins, entidadNieto);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}