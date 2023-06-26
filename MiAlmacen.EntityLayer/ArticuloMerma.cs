using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class ArticuloMerma
    {
        public int IdArticuloMerma { get; set; }
        public Articulo oArticulo { get; set; }
        public int Merma { get; set; }
        public Estado oEstado { get; set; }
    }
}