using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Talla
    {
        DataLayer.Talla dTalla = new DataLayer.Talla();

        public List<EntityLayer.Talla> Listar()
        {
            return dTalla.Listar();
        }

        public int Registrar(EntityLayer.Talla obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreTalla) || string.IsNullOrWhiteSpace(obj.NombreTalla))
                Mensaje = "El nombre de la Talla no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTalla.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Talla obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreTalla) || string.IsNullOrWhiteSpace(obj.NombreTalla))
                Mensaje = "El nombre de la Talla no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTalla.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dTalla.Eliminar(id, out Mensaje);
        }
    }
}