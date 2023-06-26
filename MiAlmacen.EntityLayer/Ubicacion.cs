using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Ubicacion
    {
        public int IdUbicacion { get; set; }
        public Pasillo oPasillo { get; set; }
        public Columna oColumna { get; set; }
        public Nivel oNivel { get; set; }
        public string NombreUbicacion { get; set; }
        public Estado oEstado { get; set; }
    }
}