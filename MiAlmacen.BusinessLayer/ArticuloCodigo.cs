using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class ArticuloCodigo
    {
        DataLayer.ArticuloCodigo dArticuloCodigo = new DataLayer.ArticuloCodigo();

        public List<EntityLayer.ArticuloCodigo> Listar()
        {
            return dArticuloCodigo.Listar();
        }

        public int Registrar(EntityLayer.ArticuloCodigo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (string.IsNullOrEmpty(obj.NombreCodigo) || string.IsNullOrWhiteSpace(obj.NombreCodigo))
                Mensaje = "El código del articulo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloCodigo.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ArticuloCodigo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oArticulo.IdArticulo == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (string.IsNullOrEmpty(obj.NombreCodigo) || string.IsNullOrWhiteSpace(obj.NombreCodigo))
                Mensaje = "El código del articulo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloCodigo.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dArticuloCodigo.Eliminar(id, out Mensaje);
        }
    }
}