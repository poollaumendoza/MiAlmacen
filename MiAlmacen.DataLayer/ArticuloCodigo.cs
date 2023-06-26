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
    public class ArticuloCodigo
    {
        public List<EntityLayer.ArticuloCodigo> Listar()
        {
            List<EntityLayer.ArticuloCodigo> lista = new List<EntityLayer.ArticuloCodigo>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select ac.IdArticuloCodigo, ac.IdArticulo, a.DescripcionArticulo, ac.NombreCodigo, ac.IdEstado, e.NombreEstado from ArticuloCodigo ac join Articulo a on ac.IdArticulo = a.IdArticulo join Estado e on ac.IdEstado = a.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ArticuloCodigo()
                            {
                                IdArticuloCodigo = Convert.ToInt32(Dr["IdArticuloCodigo"]),
                                oArticulo = new EntityLayer.Articulo()
                                {
                                    IdArticulo = Convert.ToInt32(Dr["IdArticulo"]),
                                    DescripcionArticulo = Dr["DescripcionArticulo"].ToString()
                                },
                                NombreCodigo = Dr["NombreCodigo"].ToString(),
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
                lista = new List<EntityLayer.ArticuloCodigo>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.ArticuloCodigo obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ArticuloCodigo_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("NombreCodigo", obj.NombreCodigo);
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

        public bool Editar(EntityLayer.ArticuloCodigo obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ArticuloCodigo_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdArticuloCodigo", obj.IdArticuloCodigo);
                    Cmd.Parameters.AddWithValue("IdArticulo", obj.oArticulo.IdArticulo);
                    Cmd.Parameters.AddWithValue("NombreCodigo", obj.NombreCodigo);
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
                    SqlCommand Cmd = new SqlCommand("sp_ArticuloCodigo_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdArticuloCodigo", id);
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