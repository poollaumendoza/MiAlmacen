using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MiAlmacen.DataLayer
{
    public class Articulo
    {
        public List<EntityLayer.Articulo> Listar()
        {
            List<EntityLayer.Articulo> lista = new List<EntityLayer.Articulo>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select a.IdArticulo, a.IdAlmacen, alm.NombreAlmacen, a.IdSubAlmacen, salm.NombreSubAlmacen, a.IdEntidad, ent.RazonSocial, a.IdLinea, ln.NombreLinea, a.IdTipo, tp.NombreTipo, a.IdMarca, mrc.NombreMarca, a.IdTalla, tll.NombreTalla, a.IdModelo, mdl.NombreModelo, a.IdColor, col.NombreColor, a.IdUnidadMedida, um.NombreUnidadMedida, a.IdUbicacion, ub.NombreUbicacion, a.IdArticuloFamilia, af.NombreArticuloFamilia, a.IdArticuloSubFamilia, asf.NombreSubFamilia, a.IdArticuloTipo, atp.NombreArticuloTipo, a.IdArticuloSubTipo, astp.NombreArticuloSubTipo, a.CodigoArticulo, a.DescripcionArticulo, a.Largo, a.Ancho, a.Altura, a.Volumen_x_Caja, a.Peso, a.StockMinimo, a.StockMaximo, a.PuntoReposicion, a.Lote, a.CantCjasxUbicacion, a.CantCjas, a.UnidxCja, a.CjasxPaleta, a.Unidades, FechaIngreso, a.FechaVencimiento, a.RutaImagen, a.NombreImagen, a.Observaciones, a.IdEstado, e.NombreEstado from Articulo a join Almacen alm on a.IdAlmacen = alm.IdAlmacen join SubAlmacen salm on a.IdSubAlmacen = salm.IdSubAlmacen join Entidad ent on a.IdEntidad = ent.IdEntidad join Linea ln on a.IdLinea = ln.IdLinea join Tipo tp on a.IdTipo = tp.IdTipo join Marca mrc on a.IdMarca = mrc.IdMarca join Talla tll on a.IdTalla = tll.IdTalla join Modelo mdl on a.IdModelo = mdl.IdModelo join Color col on a.IdColor = col.IdColor join UnidadMedida um on a.IdUnidadMedida = um.IdUnidadMedida join Ubicacion ub on a.IdUbicacion = ub.IdUbicacion join ArticuloFamilia af on a.IdArticuloFamilia = af.IdArticuloFamilia join ArticuloSubFamilia asf on a.IdArticuloSubFamilia = asf.IdArticuloSubFamilia join ArticuloTipo atp on a.IdArticuloTipo = atp.IdArticuloTipo join ArticuloSubTipo astp on a.IdArticuloSubTipo = astp.IdArticuloSubTipo join Estado e on a.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Articulo()
                            {
                                IdArticulo = Convert.ToInt32(Dr["IdArticulo"]),
                                oAlmacen = new EntityLayer.Almacen()
                                {
                                    IdAlmacen = Convert.ToInt32(Dr["IdAlmacen"]),
                                    NombreAlmacen = Dr["NombreAlmacen"].ToString()
                                },
                                oSubAlmacen = new EntityLayer.SubAlmacen()
                                {
                                    IdSubAlmacen = Convert.ToInt32(Dr["IdSubAlmacen"]),
                                    NombreSubAlmacen = Dr["NombreSubAlmacen"].ToString()
                                },
                                oEntidad = new EntityLayer.Entidad()
                                {
                                    IdEntidad = Convert.ToInt32(Dr["IdEntidad"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                oLinea = new EntityLayer.Linea()
                                {
                                    IdLinea = Convert.ToInt32(Dr["IdLinea"]),
                                    NombreLinea = Dr["NombreLinea"].ToString()
                                },
                                oTipo = new EntityLayer.Tipo()
                                {
                                    IdTipo = Convert.ToInt32(Dr["IdTipo"]),
                                    NombreTipo = Dr["NombreTipo"].ToString()
                                },
                                oMarca = new EntityLayer.Marca()
                                {
                                    IdMarca = Convert.ToInt32(Dr["IdMarca"]),
                                    NombreMarca = Dr["NombreMarca"].ToString()
                                },
                                oTalla = new EntityLayer.Talla()
                                {
                                    IdTalla = Convert.ToInt32(Dr["IdTalla"]),
                                    NombreTalla = Dr["NombreTalla"].ToString()
                                },
                                oModelo = new EntityLayer.Modelo()
                                {
                                    IdModelo = Convert.ToInt32(Dr["IdModelo"]),
                                    NombreModelo = Dr["NombreModelo"].ToString()
                                },
                                oColor = new EntityLayer.Color()
                                {
                                    IdColor = Convert.ToInt32(Dr["IdColor"]),
                                    NombreColor = Dr["NombreColor"].ToString()
                                },
                                oUnidadMedida = new EntityLayer.UnidadMedida()
                                {
                                    IdUnidadMedida = Convert.ToInt32(Dr["IdUnidadMedida"]),
                                    NombreUnidadMedida = Dr["NombreUnidadMedida"].ToString()
                                },
                                oUbicacion = new EntityLayer.Ubicacion()
                                {
                                    IdUbicacion = Convert.ToInt32(Dr["IdUbicacion"]),
                                    NombreUbicacion = Dr["NombreUbicacion"].ToString()
                                },
                                oArticuloFamilia = new EntityLayer.ArticuloFamilia()
                                {
                                    IdArticuloFamilia = Convert.ToInt32(Dr["IdArticuloFamilia"]),
                                    NombreArticuloFamilia = Dr["NombreArticuloFamilia"].ToString()
                                },
                                oArticuloSubFamilia = new EntityLayer.ArticuloSubFamilia()
                                {
                                    IdArticuloSubFamilia = Convert.ToInt32(Dr["IdArticuloSubFamilia"]),
                                    NombreSubFamilia = Dr["NombreSubFamilia"].ToString()
                                },
                                oArticuloTipo = new EntityLayer.ArticuloTipo()
                                {
                                    IdArticuloTipo = Convert.ToInt32(Dr["IdArticuloTipo"]),
                                    NombreArticuloTipo = Dr["NombreArticuloTipo"].ToString()
                                },
                                oArticuloSubTipo = new EntityLayer.ArticuloSubTipo()
                                {
                                    IdArticuloSubTipo = Convert.ToInt32(Dr["IdArticuloSubTipo"]),
                                    NombreArticuloSubTipo = Dr["NombreArticuloSubTipo"].ToString()
                                },
                                CodigoArticulo = Dr["CodigoArticulo"].ToString(),
                                DescripcionArticulo = Dr["CodigoArticulo"].ToString(),
                                Largo = Convert.ToDecimal(Dr["Largo"]),
                                Ancho = Convert.ToDecimal(Dr["Ancho"]),
                                Altura = Convert.ToDecimal(Dr["Altura"]),
                                Volumen_x_Caja = Convert.ToDecimal(Dr["Volumen_x_Caja"]),
                                Peso = Convert.ToDecimal(Dr["Peso"]),
                                StockMinimo = Convert.ToInt32(Dr["StockMinimo"]),
                                StockMaximo = Convert.ToInt32(Dr["StockMaximo"]),
                                PuntoReposicion = Dr["PuntoReposicion"].ToString(),
                                Lote = Dr["Lote"].ToString(),
                                CantCjasxUbicacion = Convert.ToInt32(Dr["CantCjasxUbicacion"]),
                                CantCajas = Convert.ToInt32(Dr["CantCajas"]),
                                UnidadxCaja = Convert.ToInt32(Dr["UnidadxCaja"]),
                                CajasxPaleta = Convert.ToInt32(Dr["CajasxPaleta"]),
                                Unidades = Convert.ToInt32(Dr["Unidades"]),
                                FechaIngreso = Dr["FechaIngreso"].ToString(),
                                FechaVencimiento = Dr["FechaVencimiento"].ToString(),
                                RutaImagen = Dr["RutaImagen"].ToString(),
                                NombreImagen = Dr["NombreImagen"].ToString(),
                                Observaciones = Dr["Observaciones"].ToString(),
                                oEstado = new EntityLayer.Estado()
                                {
                                    IdEstado = Convert.ToInt32(Dr["IdEstado"]),
                                    NombreEstado = Dr["NombreEstado"].ToString()
                                }
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<EntityLayer.Articulo>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.Articulo obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Articulo_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdAlmacen", obj.oAlmacen.IdAlmacen);
                    Cmd.Parameters.AddWithValue("IdSubAlmacen", obj.oSubAlmacen.IdSubAlmacen);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdLinea", obj.oLinea.IdLinea);
                    Cmd.Parameters.AddWithValue("IdTipo", obj.oTipo.IdTipo);
                    Cmd.Parameters.AddWithValue("IdMarca", obj.oMarca.IdMarca);
                    Cmd.Parameters.AddWithValue("IdTalla", obj.oTalla.IdTalla);
                    Cmd.Parameters.AddWithValue("IdModelo", obj.oModelo.IdModelo);
                    Cmd.Parameters.AddWithValue("IdColor", obj.oColor.IdColor);
                    Cmd.Parameters.AddWithValue("IdUnidadMedida", obj.oUnidadMedida.IdUnidadMedida);
                    Cmd.Parameters.AddWithValue("IdUbicacion", obj.oUbicacion.IdUbicacion);
                    Cmd.Parameters.AddWithValue("IdArticuloFamilia", obj.oArticuloFamilia.IdArticuloFamilia);
                    Cmd.Parameters.AddWithValue("IdArticuloSubFamilia", obj.oArticuloSubFamilia.IdArticuloSubFamilia);
                    Cmd.Parameters.AddWithValue("IdArticuloTipo", obj.oArticuloTipo.IdArticuloTipo);
                    Cmd.Parameters.AddWithValue("IdArticuloSubTipo", obj.oArticuloSubTipo.IdArticuloSubTipo);
                    Cmd.Parameters.AddWithValue("CodigoArticulo", obj.CodigoArticulo);
                    Cmd.Parameters.AddWithValue("Descrip", obj.DescripcionArticulo);
                    Cmd.Parameters.AddWithValue("Largo", obj.Largo);
                    Cmd.Parameters.AddWithValue("Ancho", obj.Ancho);
                    Cmd.Parameters.AddWithValue("Altura", obj.Altura);
                    Cmd.Parameters.AddWithValue("Volumen_x_Caja", obj.Volumen_x_Caja);
                    Cmd.Parameters.AddWithValue("Peso", obj.Peso);
                    Cmd.Parameters.AddWithValue("StockMinimo", obj.StockMinimo);
                    Cmd.Parameters.AddWithValue("StockMaximo", obj.StockMaximo);
                    Cmd.Parameters.AddWithValue("PuntoReposicion", obj.PuntoReposicion);
                    Cmd.Parameters.AddWithValue("Lote", obj.Lote);
                    Cmd.Parameters.AddWithValue("CantCjasxUbicacion", obj.CantCjasxUbicacion);
                    Cmd.Parameters.AddWithValue("CantCajas", obj.CantCajas);
                    Cmd.Parameters.AddWithValue("UnidadxCaja", obj.UnidadxCaja);
                    Cmd.Parameters.AddWithValue("CajasxPaleta", obj.CajasxPaleta);
                    Cmd.Parameters.AddWithValue("Unidades", obj.Unidades);
                    Cmd.Parameters.AddWithValue("FechaIngreso", obj.FechaIngreso);
                    Cmd.Parameters.AddWithValue("FechaVencimiento", obj.FechaVencimiento);
                    Cmd.Parameters.AddWithValue("RutaImagen", obj.RutaImagen);
                    Cmd.Parameters.AddWithValue("NombreImagen", obj.NombreImagen);
                    Cmd.Parameters.AddWithValue("Observaciones", obj.Observaciones);
                    Cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
                    Cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cnx.Open();
                    Cmd.ExecuteNonQuery();

                    IdAutogenerado = Convert.ToInt32(Cmd.Parameters["Resultado"].Value);
                    Mensaje = Cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                IdAutogenerado = 0;
                Mensaje = ex.Message;
            }
            return IdAutogenerado;
        }

        public bool Editar(EntityLayer.Articulo obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Articulo_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.IdArticulo);
                    Cmd.Parameters.AddWithValue("IdAlmacen", obj.oAlmacen.IdAlmacen);
                    Cmd.Parameters.AddWithValue("IdSubAlmacen", obj.oSubAlmacen.IdSubAlmacen);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdLinea", obj.oLinea.IdLinea);
                    Cmd.Parameters.AddWithValue("IdTipo", obj.oTipo.IdTipo);
                    Cmd.Parameters.AddWithValue("IdMarca", obj.oMarca.IdMarca);
                    Cmd.Parameters.AddWithValue("IdTalla", obj.oTalla.IdTalla);
                    Cmd.Parameters.AddWithValue("IdModelo", obj.oModelo.IdModelo);
                    Cmd.Parameters.AddWithValue("IdColor", obj.oColor.IdColor);
                    Cmd.Parameters.AddWithValue("IdUnidadMedida", obj.oUnidadMedida.IdUnidadMedida);
                    Cmd.Parameters.AddWithValue("IdUbicacion", obj.oUbicacion.IdUbicacion);
                    Cmd.Parameters.AddWithValue("IdArticuloFamilia", obj.oArticuloFamilia.IdArticuloFamilia);
                    Cmd.Parameters.AddWithValue("IdArticuloSubFamilia", obj.oArticuloSubFamilia.IdArticuloSubFamilia);
                    Cmd.Parameters.AddWithValue("IdArticuloTipo", obj.oArticuloTipo.IdArticuloTipo);
                    Cmd.Parameters.AddWithValue("IdArticuloSubTipo", obj.oArticuloSubTipo.IdArticuloSubTipo);
                    Cmd.Parameters.AddWithValue("CodigoArticulo", obj.CodigoArticulo);
                    Cmd.Parameters.AddWithValue("Descrip", obj.DescripcionArticulo);
                    Cmd.Parameters.AddWithValue("Largo", obj.Largo);
                    Cmd.Parameters.AddWithValue("Ancho", obj.Ancho);
                    Cmd.Parameters.AddWithValue("Altura", obj.Altura);
                    Cmd.Parameters.AddWithValue("Volumen_x_Caja", obj.Volumen_x_Caja);
                    Cmd.Parameters.AddWithValue("Peso", obj.Peso);
                    Cmd.Parameters.AddWithValue("StockMinimo", obj.StockMinimo);
                    Cmd.Parameters.AddWithValue("StockMaximo", obj.StockMaximo);
                    Cmd.Parameters.AddWithValue("PuntoReposicion", obj.PuntoReposicion);
                    Cmd.Parameters.AddWithValue("Lote", obj.Lote);
                    Cmd.Parameters.AddWithValue("CantCjasxUbicacion", obj.CantCjasxUbicacion);
                    Cmd.Parameters.AddWithValue("CantCajas", obj.CantCajas);
                    Cmd.Parameters.AddWithValue("UnidadxCaja", obj.UnidadxCaja);
                    Cmd.Parameters.AddWithValue("CajasxPaleta", obj.CajasxPaleta);
                    Cmd.Parameters.AddWithValue("Unidades", obj.Unidades);
                    Cmd.Parameters.AddWithValue("FechaIngreso", obj.FechaIngreso);
                    Cmd.Parameters.AddWithValue("FechaVencimiento", obj.FechaVencimiento);
                    Cmd.Parameters.AddWithValue("RutaImagen", obj.RutaImagen);
                    Cmd.Parameters.AddWithValue("NombreImagen", obj.NombreImagen);
                    Cmd.Parameters.AddWithValue("Observaciones", obj.Observaciones);
                    Cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
                    Cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cnx.Open();
                    Cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(Cmd.Parameters["Resultado"].Value);
                    Mensaje = Cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Articulo_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdArticulo", id);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cnx.Open();
                    resultado = Cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
    }
}