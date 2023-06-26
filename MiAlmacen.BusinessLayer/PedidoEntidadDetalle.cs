using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class PedidoEntidadDetalle
    {
        DataLayer.PedidoEntidadDetalle dPedidoEntidadDetalle = new DataLayer.PedidoEntidadDetalle();

        public List<EntityLayer.PedidoEntidadDetalle> Listar()
        {
            return dPedidoEntidadDetalle.Listar();
        }

        public int Registrar(EntityLayer.PedidoEntidadDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPedidoEntidad.IdPedidoEntidad == 0)
                Mensaje = "Debe seleccionar un pedido de cliente";
            if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad del artículo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPedidoEntidadDetalle.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.PedidoEntidadDetalle obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPedidoEntidad.IdPedidoEntidad == 0)
                Mensaje = "Debe seleccionar un pedido de cliente";
            if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad del artículo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPedidoEntidadDetalle.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dPedidoEntidadDetalle.Eliminar(id, out Mensaje);
        }
    }
}
