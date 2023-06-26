using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class EntidadUbicacion
    {
        DataLayer.EntidadUbicacion dEntidadUbicacion = new DataLayer.EntidadUbicacion();

        public List<EntityLayer.EntidadUbicacion> Listar()
        {
            return dEntidadUbicacion.Listar();
        }

        public int Registrar(EntityLayer.EntidadUbicacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (obj.oUbicacion.IdUbicacion == 0)
                Mensaje = "Debe seleccionar una ubicación";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dEntidadUbicacion.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.EntidadUbicacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (obj.oUbicacion.IdUbicacion == 0)
                Mensaje = "Debe seleccionar una ubicación";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dEntidadUbicacion.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dEntidadUbicacion.Eliminar(id, out Mensaje);
        }
    }
}