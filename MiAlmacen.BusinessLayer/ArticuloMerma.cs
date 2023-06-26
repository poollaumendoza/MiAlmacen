using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class ArticuloMerma
    {
        DataLayer.ArticuloMerma dArticuloMerma = new DataLayer.ArticuloMerma();

        public List<EntityLayer.ArticuloMerma> Listar()
        {
            return dArticuloMerma.Listar();
        }

        public int Registrar(EntityLayer.ArticuloMerma obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (obj.Merma == 0)
                Mensaje = "La cantidad de merma no puede quedar 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloMerma.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ArticuloMerma obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (obj.Merma == 0)
                Mensaje = "La cantidad de merma no puede quedar 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloMerma.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dArticuloMerma.Eliminar(id, out Mensaje);
        }
    }
}
