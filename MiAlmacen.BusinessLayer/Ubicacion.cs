using System.Collections.Generic;

namespace MiAlmacen.BusinessLayer
{
    public class Ubicacion
    {
        DataLayer.Ubicacion dUbicacion = new DataLayer.Ubicacion();

        public List<EntityLayer.Ubicacion> Listar()
        {
            return dUbicacion.Listar();
        }

        public int Registrar(EntityLayer.Ubicacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPasillo.IdPasillo == 0)
                Mensaje = "Debe seleccionar un pasillo";
            else if (obj.oColumna.IdColumna == 0)
                Mensaje = "Debe seleccionar un columna";
            else if (obj.oNivel.IdNivel == 0)
                Mensaje = "Debe seleccionar un nivel";
            else if (string.IsNullOrEmpty(obj.NombreUbicacion) || string.IsNullOrWhiteSpace(obj.NombreUbicacion))
                Mensaje = "El nombre de la ubicación no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUbicacion.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Ubicacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPasillo.IdPasillo == 0)
                Mensaje = "Debe seleccionar un pasillo";
            else if (obj.oColumna.IdColumna == 0)
                Mensaje = "Debe seleccionar un columna";
            else if (obj.oNivel.IdNivel == 0)
                Mensaje = "Debe seleccionar un nivel";
            else if (string.IsNullOrEmpty(obj.NombreUbicacion) || string.IsNullOrWhiteSpace(obj.NombreUbicacion))
                Mensaje = "El nombre de la ubicación no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUbicacion.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dUbicacion.Eliminar(id, out Mensaje);
        }
    }
}