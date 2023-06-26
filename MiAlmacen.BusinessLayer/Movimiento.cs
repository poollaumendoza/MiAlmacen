using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
   public class Movimiento
    {
        DataLayer.Movimiento dMovimiento = new DataLayer.Movimiento();

        public List<EntityLayer.Movimiento> Listar()
        {
            return dMovimiento.Listar();
        }

        public int Registrar(EntityLayer.Movimiento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoMovimiento.IdTipoMovimiento == 0)
                Mensaje = "Debe seleccionar un tipo de movimiento";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un artículo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (string.IsNullOrEmpty(obj.FechaMovimiento) || string.IsNullOrWhiteSpace(obj.FechaMovimiento))
                Mensaje = "La fecha de movimiento no puede ser vacía";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dMovimiento.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Movimiento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoMovimiento.IdTipoMovimiento == 0)
                Mensaje = "Debe seleccionar un tipo de movimiento";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un artículo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (string.IsNullOrEmpty(obj.FechaMovimiento) || string.IsNullOrWhiteSpace(obj.FechaMovimiento))
                Mensaje = "La fecha de movimiento no puede ser vacía";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dMovimiento.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dMovimiento.Eliminar(id, out Mensaje);
        }
    }
}