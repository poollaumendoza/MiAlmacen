using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Pasillo
    {
        DataLayer.Pasillo dPasillo = new DataLayer.Pasillo();

        public List<EntityLayer.Pasillo> Listar()
        {
            return dPasillo.Listar();
        }

        public int Registrar(EntityLayer.Pasillo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombrePasillo) || string.IsNullOrWhiteSpace(obj.NombrePasillo))
                Mensaje = "El nombre del Pasillo no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPasillo.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Pasillo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombrePasillo) || string.IsNullOrWhiteSpace(obj.NombrePasillo))
                Mensaje = "El nombre del Pasillo no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPasillo.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dPasillo.Eliminar(id, out Mensaje);
        }
    }
}