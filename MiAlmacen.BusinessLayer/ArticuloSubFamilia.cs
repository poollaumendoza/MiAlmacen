using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
   public class ArticuloSubFamilia
    {
        DataLayer.ArticuloSubFamilia dArticuloSubFamilia = new DataLayer.ArticuloSubFamilia();

        public List<EntityLayer.ArticuloSubFamilia> Listar()
        {
            return dArticuloSubFamilia.Listar();
        }

        public int Registrar(EntityLayer.ArticuloSubFamilia obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (string.IsNullOrEmpty(obj.NombreSubFamilia) || string.IsNullOrWhiteSpace(obj.NombreSubFamilia))
                Mensaje = "El nombre de la subfamilia no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloSubFamilia.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ArticuloSubFamilia obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (string.IsNullOrEmpty(obj.NombreSubFamilia) || string.IsNullOrWhiteSpace(obj.NombreSubFamilia))
                Mensaje = "El nombre de la subfamilia no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloSubFamilia.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dArticuloSubFamilia.Eliminar(id, out Mensaje);
        }
    }
}