using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class ArticuloSubTipo
    {
        public int IdArticuloSubTipo { get; set; }
        public Entidad oEntidad { get; set; }
        public string NombreArticuloSubTipo { get; set; }
        public Estado oEstado { get; set; }
    }
}