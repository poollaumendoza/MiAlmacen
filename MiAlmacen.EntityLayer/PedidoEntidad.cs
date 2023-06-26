using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class PedidoEntidad
    {
        public int IdPedidoEntidad { get; set; }
        public Entidad oEntidad { get; set; }
        public string NroPedido { get; set; }
        public string FechaPedido { get; set; }
        public Estado oEstado { get; set; }
    }
}