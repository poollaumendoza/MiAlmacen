using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Talla
    {
        public int IdTalla { get; set; }
        public Entidad oEntidad { get; set; }
        public string NombreTalla { get; set; }
        public Estado oEstado { get; set; }
    }
}