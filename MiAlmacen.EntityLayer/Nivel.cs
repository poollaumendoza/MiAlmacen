using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Nivel
    {
        public int IdNivel { get; set; }
        public string NombreNivel { get; set; }
        public Estado oEstado { get; set; }
    }
}