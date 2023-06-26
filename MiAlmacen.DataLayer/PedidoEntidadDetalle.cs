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
    public class PedidoEntidadDetalle
    {
        public List<EntityLayer.PedidoEntidadDetalle> Listar()
        {
            List<EntityLayer.PedidoEntidadDetalle> lista = new List<EntityLayer.PedidoEntidadDetalle>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select ped.IdPedidoEntidadDetalle, ped.IdPedidoEntidad, pe.NroPedido, ped.IdArticulo, a.DescripcionArticulo, ped.Cantidad, ped.IdEstado, e.NombreEstado from PedidoEntidadDetalle ped join PedidoEntidad pe on ped.IdPedidoEntidad = pe.IdPedidoEntidad join Articulo a on ped.IdArticulo = a.IdArticulo join Estado e on ped.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.PedidoEntidadDetalle()
                            {
                                IdPedidoEntidadDetalle = Convert.ToInt32(Dr["IdPedidoEntidadDetalle"]),
                                oPedidoEntidad = new EntityLayer.PedidoEntidad()
                                {
                                    IdPedidoEntidad = Convert.ToInt32(Dr["IdPedidoEntidad"]),
                                    NroPedido = Dr["NroPedido"].ToString()
                                },
                                oArticulo = new EntityLayer.Articulo()
                                {
                                    IdArticulo = Convert.ToInt32(Dr["IdArticulo"]),
                                    DescripcionArticulo = Dr["DescripcionArticulo"].ToString()
                                },
                                Cantidad = Convert.ToInt32(Dr["Cantidad"]),
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
                lista = new List<EntityLayer.PedidoEntidadDetalle>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.PedidoEntidadDetalle obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_PedidoEntidadDetalle_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdPedidoEntidad", obj.oPedidoEntidad.IdPedidoEntidad);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
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

        public bool Editar(EntityLayer.PedidoEntidadDetalle obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_PedidoEntidadDetalle_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdPedidoEntidadDetalle", obj.IdPedidoEntidadDetalle);
                    Cmd.Parameters.AddWithValue("IdPedidoEntidad", obj.oPedidoEntidad.IdPedidoEntidad);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
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
                    SqlCommand Cmd = new SqlCommand("sp_PedidoEntidadDetalle_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdPedidoEntidadDetalle", id);
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