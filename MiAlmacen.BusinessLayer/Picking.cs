using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Picking
    {
        DataLayer.Picking dPicking = new DataLayer.Picking();

        public List<EntityLayer.Picking> Listar()
        {
            return dPicking.Listar();
        }

        public int Registrar(EntityLayer.Picking obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (obj.oTipoMovimiento.IdTipoMovimiento == 0)
                Mensaje = "Debe seleccionar un tipo de movimiento";
            else if (string.IsNullOrEmpty(obj.NroOrden) || string.IsNullOrWhiteSpace(obj.NroOrden))
                Mensaje = "El número de orden no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Fecha) || string.IsNullOrWhiteSpace(obj.Fecha))
                Mensaje = "La fecha no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPicking.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Picking obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (obj.oTipoMovimiento.IdTipoMovimiento == 0)
                Mensaje = "Debe seleccionar un tipo de movimiento";
            else if (string.IsNullOrEmpty(obj.NroOrden) || string.IsNullOrWhiteSpace(obj.NroOrden))
                Mensaje = "El número de orden no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Fecha) || string.IsNullOrWhiteSpace(obj.Fecha))
                Mensaje = "La fecha no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPicking.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dPicking.Eliminar(id, out Mensaje);
        }
    }
}
