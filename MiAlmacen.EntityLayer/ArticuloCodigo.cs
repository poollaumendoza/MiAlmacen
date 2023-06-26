using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class ArticuloCodigo
    {
        public int IdArticuloCodigo { get; set; }
        public Articulo oArticulo { get; set; }
        public string NombreCodigo { get; set; }
        public Estado oEstado { get; set; }
    }
}