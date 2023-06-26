using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class PedidoEntidadDetalle
    {
        public int IdPedidoEntidadDetalle { get; set; }
        public PedidoEntidad oPedidoEntidad { get; set; }
        public Articulo oArticulo { get; set; }
        public int Cantidad { get; set; }
        public Estado oEstado { get; set; }
    }
}