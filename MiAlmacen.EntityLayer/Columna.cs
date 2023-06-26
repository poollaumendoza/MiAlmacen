using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Columna
    {
        public int IdColumna { get; set; }
        public string NombreColumna { get; set; }
        public Estado oEstado { get; set; }
    }
}