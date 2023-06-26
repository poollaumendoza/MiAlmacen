using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class PickingDetalle
    {
        DataLayer.PickingDetalle dPickingDetalle = new DataLayer.PickingDetalle();

        public List<EntityLayer.PickingDetalle> Listar()
        {
            return dPickingDetalle.Listar();
        }

        public int Registrar(EntityLayer.PickingDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPicking.IdPicking == 0)
                Mensaje = "Debe seleccionar un picking";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPickingDetalle.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.PickingDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPicking.IdPicking == 0)
                Mensaje = "Debe seleccionar un picking";
            else if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPickingDetalle.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dPickingDetalle.Eliminar(id, out Mensaje);
        }
    }
}