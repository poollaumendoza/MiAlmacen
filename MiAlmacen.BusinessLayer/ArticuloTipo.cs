using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class ArticuloTipo
    {
        DataLayer.ArticuloTipo dArticuloTipo = new DataLayer.ArticuloTipo();

        public List<EntityLayer.ArticuloTipo> Listar()
        {
            return dArticuloTipo.Listar();
        }

        public int Registrar(EntityLayer.ArticuloTipo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (string.IsNullOrEmpty(obj.NombreArticuloTipo) || string.IsNullOrWhiteSpace(obj.NombreArticuloTipo))
                Mensaje = "El nombre del tipo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloTipo.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ArticuloTipo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un articulo";
            else if (string.IsNullOrEmpty(obj.NombreArticuloTipo) || string.IsNullOrWhiteSpace(obj.NombreArticuloTipo))
                Mensaje = "El nombre del tipo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticuloTipo.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dArticuloTipo.Eliminar(id, out Mensaje);
        }
    }
}