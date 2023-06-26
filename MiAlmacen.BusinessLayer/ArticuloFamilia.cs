using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class ArticuloFamilia
    {
        DataLayer.ArticuloFamilia dArticuloFamilia = new DataLayer.ArticuloFamilia();

        public List<EntityLayer.ArticuloFamilia> Listar()
        {
            return dArticuloFamilia.Listar();
        }

        public int Registrar(EntityLayer.ArticuloFamilia obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreArticuloFamilia) || string.IsNullOrWhiteSpace(obj.NombreArticuloFamilia))
                Mensaje = "El nombre de la familia del articulo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloFamilia.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ArticuloFamilia obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreArticuloFamilia) || string.IsNullOrWhiteSpace(obj.NombreArticuloFamilia))
                Mensaje = "El nombre de la familia del articulo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloFamilia.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dArticuloFamilia.Eliminar(id, out Mensaje);
        }
    }
}