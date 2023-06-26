using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.DataLayer
{
    public class Movimiento
    {
        public List<EntityLayer.Movimiento> Listar()
        {
            List<EntityLayer.Movimiento> lista = new List<EntityLayer.Movimiento>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select m.IdMovimiento, m.IdTipoMovimiento, tm.NombreTipoMovimiento, m.IdArticulo, a.DescripcionArticulo, m.Cantidad, m.FechaMovimiento, m.IdEstado, e.NombreEstado from Movimiento m join TipoMovimiento tm on m.IdTipoMovimiento = tm.IdTipoMovimiento join Articulo a on m.IdArticulo = m.IdArticulo join Estado e on m.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Movimiento()
                            {
                                IdMovimiento = Convert.ToInt32(Dr["IdMovimiento"]),
                                oTipoMovimiento = new EntityLayer.TipoMovimiento()
                                {
                                    IdTipoMovimiento = Convert.ToInt32(Dr["IdTipoMovimiento"]),
                                    NombreTipoMovimiento = Dr["NombreTipoMovimiento"].ToString()
                                },
                                oArticulo = new EntityLayer.Articulo()
                                {
                                    IdArticulo = Convert.ToInt32(Dr["IdArticulo"]),
                                    DescripcionArticulo = Dr["DescripcionArticulo"].ToString()
                                },
                                Cantidad = Convert.ToInt32(Dr["Cantidad"]),
                                FechaMovimiento = Dr["FechaMovimiento"].ToString(),
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
                lista = new List<EntityLayer.Movimiento>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.Movimiento obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Movimiento_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdTipoMovimiento", obj.oTipoMovimiento.IdTipoMovimiento);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                    Cmd.Parameters.AddWithValue("FechaMovimiento", obj.FechaMovimiento);
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

        public bool Editar(EntityLayer.Movimiento obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Movimiento_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdMovimiento", obj.IdMovimiento);
                    Cmd.Parameters.AddWithValue("IdTipoMovimiento", obj.oTipoMovimiento.IdTipoMovimiento);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                    Cmd.Parameters.AddWithValue("FechaMovimiento", obj.FechaMovimiento);
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
                    SqlCommand Cmd = new SqlCommand("sp_Movimiento_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdMovimiento", id);
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