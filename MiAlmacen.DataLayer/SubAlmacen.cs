using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MiAlmacen.DataLayer
{
    public class SubAlmacen
    {
        public List<EntityLayer.SubAlmacen> Listar()
        {
            List<EntityLayer.SubAlmacen> lista = new List<EntityLayer.SubAlmacen>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select sa.IdSubAlmacen, sa.IdAlmacen, a.NombreAlmacen, sa.NombreSubAlmacen, sa.IdEstado, e.NombreEstado from SubAlmacen sa join Almacen a on sa.IdAlmacen = a.IdAlmacen join Estado e on sa.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.SubAlmacen()
                            {
                                IdSubAlmacen = Convert.ToInt32(Dr["IdSubAlmacen"]),
                                oAlmacen = new EntityLayer.Almacen()
                                {
                                    IdAlmacen = Convert.ToInt32(Dr["IdAlmacen"]),
                                    NombreAlmacen = Dr["NombreAlmacen"].ToString()
                                },
                                NombreSubAlmacen = Dr["NombreSubAlmacen"].ToString(),
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
                lista = new List<EntityLayer.SubAlmacen>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.SubAlmacen obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_SubAlmacen_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdAlmacen", obj.oAlmacen.IdAlmacen);
                    Cmd.Parameters.AddWithValue("NombreSubAlmacen", obj.NombreSubAlmacen);
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

        public bool Editar(EntityLayer.SubAlmacen obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_SubAlmacen_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdSubAlmacen", obj.IdSubAlmacen);
                    Cmd.Parameters.AddWithValue("IdAlmacen", obj.oAlmacen.IdAlmacen);
                    Cmd.Parameters.AddWithValue("NombreSubAlmacen", obj.NombreSubAlmacen);
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
                    SqlCommand Cmd = new SqlCommand("sp_SubAlmacen_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdSubAlmacen", id);
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