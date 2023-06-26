using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class PickingDetalle
    {
        public int IdPickingDetalle { get; set; }
        public Picking oPicking { get; set; }
        public Articulo oArticulo { get; set; }
        public int Cantidad { get; set; }
        public Estado oEstado { get; set; }
    }
}