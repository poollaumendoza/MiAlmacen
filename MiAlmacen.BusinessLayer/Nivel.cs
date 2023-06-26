using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Nivel
    {
        DataLayer.Nivel dNivel = new DataLayer.Nivel();

        public List<EntityLayer.Nivel> Listar()
        {
            return dNivel.Listar();
        }

        public int Registrar(EntityLayer.Nivel obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreNivel) || string.IsNullOrWhiteSpace(obj.NombreNivel))
                Mensaje = "El nombre del Nivel no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dNivel.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Nivel obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreNivel) || string.IsNullOrWhiteSpace(obj.NombreNivel))
                Mensaje = "El nombre del Nivel no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dNivel.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dNivel.Eliminar(id, out Mensaje);
        }
    }
}
