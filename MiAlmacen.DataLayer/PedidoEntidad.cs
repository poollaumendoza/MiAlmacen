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
    public class PedidoEntidad
    {
        public List<EntityLayer.PedidoEntidad> Listar()
        {
            List<EntityLayer.PedidoEntidad> lista = new List<EntityLayer.PedidoEntidad>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select pe.IdPedidoEntidad, pe.IdEntidad, en.RazonSocial, pe.NroPedido, pe.FechaPedido, pe.IdEstado, es.NombreEstado from PedidoEntidad pe join Entidad en on pe.IdEntidad = en.IdEntidad join Estado es on pe.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.PedidoEntidad()
                            {
                                IdPedidoEntidad = Convert.ToInt32(Dr["IdPedidoEntidad"]),
                                oEntidad = new EntityLayer.Entidad()
                                {
                                    IdEntidad = Convert.ToInt32(Dr["IdEntidad"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                NroPedido = Dr["NroPedido"].ToString(),
                                FechaPedido = Dr["FechaPedido"].ToString(),
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
                lista = new List<EntityLayer.PedidoEntidad>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.PedidoEntidad obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_PedidoEntidad_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("NroPedido", obj.NroPedido);
                    Cmd.Parameters.AddWithValue("FechaPedido", obj.FechaPedido);
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

        public bool Editar(EntityLayer.PedidoEntidad obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_PedidoEntidad_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdPedidoEntidad", obj.IdPedidoEntidad);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("NroPedido", obj.NroPedido);
                    Cmd.Parameters.AddWithValue("FechaPedido", obj.FechaPedido);
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
                    SqlCommand Cmd = new SqlCommand("sp_PedidoEntidad_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdPedidoEntidad", id);
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