using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Articulo
    {
        DataLayer.Articulo dArticulo = new DataLayer.Articulo();

        public List<EntityLayer.Articulo> Listar()
        {
            return dArticulo.Listar();
        }

        public int Registrar(EntityLayer.Articulo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oAlmacen.IdAlmacen == 0)
                Mensaje = "Debe seleccionar un almacen";
            else if (obj.oSubAlmacen.IdSubAlmacen == 0)
                Mensaje = "Debe seleccionar un subalmacen";
            else if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (obj.oLinea.IdLinea == 0)
                Mensaje = "Debe seleccionar una línea";
            else if (obj.oTipo.IdTipo == 0)
                Mensaje = "Debe seleccionar un tipo";
            else if (obj.oMarca.IdMarca == 0)
                Mensaje = "Debe seleccionar una marca";
            else if (obj.oTalla.IdTalla == 0)
                Mensaje = "Debe seleccionar una talla";
            else if (obj.oModelo.IdModelo == 0)
                Mensaje = "Debe seleccionar un modelo";
            else if (obj.oColor.IdColor == 0)
                Mensaje = "Debe seleccionar un color";
            else if (obj.oUnidadMedida.IdUnidadMedida == 0)
                Mensaje = "Debe seleccionar una unidad de medida";
            else if (obj.oUbicacion.IdUbicacion == 0)
                Mensaje = "Debe seleccionar una ubicación";
            else if (obj.oArticuloFamilia.IdArticuloFamilia == 0)
                Mensaje = "Debe seleccionar una familia de artículos";
            else if (obj.oArticuloSubFamilia.IdArticuloSubFamilia == 0)
                Mensaje = "Debe seleccionar una sub familia de articulos";
            else if (obj.oArticuloTipo.IdArticuloTipo == 0)
                Mensaje = "Debe seleccionar un tipo de articulo";
            else if (obj.oArticuloSubTipo.IdArticuloSubTipo == 0)
                Mensaje = "Debe seleccionar un sub tipo de articulo";
            else if (string.IsNullOrEmpty(obj.CodigoArticulo) || string.IsNullOrWhiteSpace(obj.CodigoArticulo))
                Mensaje = "El código del articulo no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.DescripcionArticulo) || string.IsNullOrWhiteSpace(obj.DescripcionArticulo))
                Mensaje = "La descripción no puede ser vacío";
            else if (obj.Largo == 0)
                Mensaje = "El largo no puede ser vacío";
            else if (obj.Ancho == 0)
                Mensaje = "El ancho no puede ser vacío";
            else if (obj.Altura == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (obj.Volumen_x_Caja == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (obj.Peso == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (obj.StockMinimo == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (obj.StockMaximo == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.PuntoReposicion) || string.IsNullOrWhiteSpace(obj.PuntoReposicion))
                Mensaje = "La descripción no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Lote) || string.IsNullOrWhiteSpace(obj.Lote))
                Mensaje = "El lote no puede estar vacío";
            else if (obj.CantCjasxUbicacion == 0)
                Mensaje = "La cantidad de cajas por ubicación no puede ser vacío";
            else if (obj.CantCajas == 0)
                Mensaje = "La cantidad de cajas no puede ser vacío";
            else if (obj.UnidadxCaja == 0)
                Mensaje = "Las cantidad de unidades por caja no puede ser vacío";
            else if (obj.CajasxPaleta == 0)
                Mensaje = "La cantidad de cajas por paleta ser vacío";
            else if (obj.Unidades == 0)
                Mensaje = "La cantidad de unidades no puede ser vacía";
            else if (string.IsNullOrEmpty(obj.FechaIngreso) || string.IsNullOrWhiteSpace(obj.FechaIngreso))
                Mensaje = "La fecha de ingreso no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.FechaVencimiento) || string.IsNullOrWhiteSpace(obj.FechaVencimiento))
                Mensaje = "La fecha de vencimiento no puede estar vacío";
            else if (string.IsNullOrEmpty(obj.RutaImagen) || string.IsNullOrWhiteSpace(obj.RutaImagen))
                Mensaje = "La ruta de la imagen no puede estar vacío";
            else if (string.IsNullOrEmpty(obj.NombreImagen) || string.IsNullOrWhiteSpace(obj.NombreImagen))
                Mensaje = "El nombre de la imagen no puede estar vacío";
            else if (string.IsNullOrEmpty(obj.Observaciones) || string.IsNullOrWhiteSpace(obj.Observaciones))
                Mensaje = "La observación no puede estar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticulo.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Articulo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oAlmacen.IdAlmacen == 0)
                Mensaje = "Debe seleccionar un almacen";
            else if (obj.oSubAlmacen.IdSubAlmacen == 0)
                Mensaje = "Debe seleccionar un subalmacen";
            else if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (obj.oLinea.IdLinea == 0)
                Mensaje = "Debe seleccionar una línea";
            else if (obj.oTipo.IdTipo == 0)
                Mensaje = "Debe seleccionar un tipo";
            else if (obj.oMarca.IdMarca == 0)
                Mensaje = "Debe seleccionar una marca";
            else if (obj.oTalla.IdTalla == 0)
                Mensaje = "Debe seleccionar una talla";
            else if (obj.oModelo.IdModelo == 0)
                Mensaje = "Debe seleccionar un modelo";
            else if (obj.oColor.IdColor == 0)
                Mensaje = "Debe seleccionar un color";
            else if (obj.oUnidadMedida.IdUnidadMedida == 0)
                Mensaje = "Debe seleccionar una unidad de medida";
            else if (obj.oUbicacion.IdUbicacion == 0)
                Mensaje = "Debe seleccionar una ubicación";
            else if (obj.oArticuloFamilia.IdArticuloFamilia == 0)
                Mensaje = "Debe seleccionar una familia de artículos";
            else if (obj.oArticuloSubFamilia.IdArticuloSubFamilia == 0)
                Mensaje = "Debe seleccionar una sub familia de articulos";
            else if (obj.oArticuloTipo.IdArticuloTipo == 0)
                Mensaje = "Debe seleccionar un tipo de articulo";
            else if (obj.oArticuloSubTipo.IdArticuloSubTipo == 0)
                Mensaje = "Debe seleccionar un sub tipo de articulo";
            else if (string.IsNullOrEmpty(obj.CodigoArticulo) || string.IsNullOrWhiteSpace(obj.CodigoArticulo))
                Mensaje = "El código del articulo no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.DescripcionArticulo) || string.IsNullOrWhiteSpace(obj.DescripcionArticulo))
                Mensaje = "La descripción no puede ser vacío";
            else if (obj.Largo == 0)
                Mensaje = "El largo no puede ser vacío";
            else if (obj.Ancho == 0)
                Mensaje = "El ancho no puede ser vacío";
            else if (obj.Altura == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (obj.Volumen_x_Caja == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (obj.Peso == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (obj.StockMinimo == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (obj.StockMaximo == 0)
                Mensaje = "La altura no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.PuntoReposicion) || string.IsNullOrWhiteSpace(obj.PuntoReposicion))
                Mensaje = "La descripción no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Lote) || string.IsNullOrWhiteSpace(obj.Lote))
                Mensaje = "El lote no puede estar vacío";
            else if (obj.CantCjasxUbicacion == 0)
                Mensaje = "La cantidad de cajas por ubicación no puede ser vacío";
            else if (obj.CantCajas == 0)
                Mensaje = "La cantidad de cajas no puede ser vacío";
            else if (obj.UnidadxCaja == 0)
                Mensaje = "Las cantidad de unidades por caja no puede ser vacío";
            else if (obj.CajasxPaleta == 0)
                Mensaje = "La cantidad de cajas por paleta ser vacío";
            else if (obj.Unidades == 0)
                Mensaje = "La cantidad de unidades no puede ser vacía";
            else if (string.IsNullOrEmpty(obj.FechaIngreso) || string.IsNullOrWhiteSpace(obj.FechaIngreso))
                Mensaje = "La fecha de ingreso no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.FechaVencimiento) || string.IsNullOrWhiteSpace(obj.FechaVencimiento))
                Mensaje = "La fecha de vencimiento no puede estar vacío";
            else if (string.IsNullOrEmpty(obj.RutaImagen) || string.IsNullOrWhiteSpace(obj.RutaImagen))
                Mensaje = "La ruta de la imagen no puede estar vacío";
            else if (string.IsNullOrEmpty(obj.NombreImagen) || string.IsNullOrWhiteSpace(obj.NombreImagen))
                Mensaje = "El nombre de la imagen no puede estar vacío";
            else if (string.IsNullOrEmpty(obj.Observaciones) || string.IsNullOrWhiteSpace(obj.Observaciones))
                Mensaje = "La observación no puede estar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dArticulo.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dArticulo.Eliminar(id, out Mensaje);
        }
    }
}