using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class ArticuloSubTipo
    {
        DataLayer.ArticuloSubTipo dArticuloSubTipo = new DataLayer.ArticuloSubTipo();

        public List<EntityLayer.ArticuloSubTipo> Listar()
        {
            return dArticuloSubTipo.Listar();
        }

        public int Registrar(EntityLayer.ArticuloSubTipo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (string.IsNullOrEmpty(obj.NombreArticuloSubTipo) || string.IsNullOrWhiteSpace(obj.NombreArticuloSubTipo))
                Mensaje = "El nombre del subtipo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloSubTipo.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ArticuloSubTipo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (string.IsNullOrEmpty(obj.NombreArticuloSubTipo) || string.IsNullOrWhiteSpace(obj.NombreArticuloSubTipo))
                Mensaje = "El nombre del subtipo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloSubTipo.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dArticuloSubTipo.Eliminar(id, out Mensaje);
        }
    }
}