using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public Almacen oAlmacen { get; set; }
        public SubAlmacen oSubAlmacen { get; set; }
        public Entidad oEntidad { get; set; }
        public Linea oLinea { get; set; }
        public Tipo oTipo { get; set; }
        public Marca oMarca { get; set; }
        public Talla oTalla { get; set; }
        public Modelo oModelo { get; set; }
        public Color oColor { get; set; }
        public UnidadMedida oUnidadMedida { get; set; }
        public Ubicacion oUbicacion { get; set; }
        public ArticuloFamilia oArticuloFamilia { get; set; }
        public ArticuloSubFamilia oArticuloSubFamilia { get; set; }
        public ArticuloTipo oArticuloTipo { get; set; }
        public ArticuloSubTipo oArticuloSubTipo { get; set; }
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Altura { get; set; }
        public decimal Volumen_x_Caja { get; set; }
        public decimal Peso { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public string PuntoReposicion { get; set; }
        public string Lote { get; set; }
        public int CantCjasxUbicacion { get; set; }
        public int CantCajas { get; set; }
        public int UnidadxCaja { get; set; }
        public int CajasxPaleta { get; set; }
        public int Unidades { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaVencimiento { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public string Observaciones { get; set; }
        public Estado oEstado { get; set; }
    }
}