using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class PedidoEntidad
    {
        DataLayer.PedidoEntidad dPedidoEntidad = new DataLayer.PedidoEntidad();

        public List<EntityLayer.PedidoEntidad> Listar()
        {
            return dPedidoEntidad.Listar();
        }

        public int Registrar(EntityLayer.PedidoEntidad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NroPedido) || string.IsNullOrWhiteSpace(obj.NroPedido))
                Mensaje = "El número de pedido no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.FechaPedido) || string.IsNullOrWhiteSpace(obj.FechaPedido))
                Mensaje = "La fecha de pedido no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPedidoEntidad.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.PedidoEntidad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NroPedido) || string.IsNullOrWhiteSpace(obj.NroPedido))
                Mensaje = "El número de pedido no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.FechaPedido) || string.IsNullOrWhiteSpace(obj.FechaPedido))
                Mensaje = "La fecha de pedido no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPedidoEntidad.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dPedidoEntidad.Eliminar(id, out Mensaje);
        }
    }
}