using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Modelo
    {
        public int IdModelo { get; set; }
        public Entidad oEntidad { get; set; }
        public string NombreModelo { get; set; }
        public Estado oEstado { get; set; }
    }
}