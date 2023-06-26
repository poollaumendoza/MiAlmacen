using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Pasillo
    {
        public int IdPasillo { get; set; }
        public string NombrePasillo { get; set; }
        public Estado oEstado { get; set; }
    }
}