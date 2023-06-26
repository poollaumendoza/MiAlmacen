using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public TipoMovimiento oTipoMovimiento { get; set; }
        public Articulo oArticulo { get; set; }
        public int Cantidad { get; set; }
        public string FechaMovimiento { get; set; }
        public Estado oEstado { get; set; }
    }
}