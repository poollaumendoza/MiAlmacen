using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public Entidad oEntidad { get; set; }
        public string NombreMarca { get; set; }
        public Estado oEstado { get; set; }
    }
}