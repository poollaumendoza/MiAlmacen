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
    public class Ubicacion
    {
        public List<EntityLayer.Ubicacion> Listar()
        {
            List<EntityLayer.Ubicacion> lista = new List<EntityLayer.Ubicacion>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select u.IdUbicacion, u.IdPasillo, p.NombrePasillo, u.IdColumna, c.NombreColumna, u.IdNivel, n.NombreNivel, u.NombreUbicacion, u.IdEstado, e.NombreEstado from Ubicacion u join Pasillo p on u.IdPasillo = p.IdPasillo join Columna c on u.IdColumna = c.IdColumna join Nivel n on u.IdNivel = n.IdNivel join Estado e on u.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Ubicacion()
                            {
                                IdUbicacion = Convert.ToInt32(Dr["IdUbicacion"]),
                                oPasillo = new EntityLayer.Pasillo()
                                {
                                    IdPasillo = Convert.ToInt32(Dr["IdPasillo"]),
                                    NombrePasillo = Dr["NombrePasillo"].ToString()
                                },
                                oColumna = new EntityLayer.Columna()
                                {
                                    IdColumna = Convert.ToInt32(Dr["IdColumna"]),
                                    NombreColumna = Dr["NombreColumna"].ToString()
                                },
                                oNivel = new EntityLayer.Nivel()
                                {
                                    IdNivel = Convert.ToInt32(Dr["IdNivel"]),
                                    NombreNivel = Dr["NombreNivel"].ToString()
                                },
                                NombreUbicacion = Dr["NombreUbicacion"].ToString(),
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
                lista = new List<EntityLayer.Ubicacion>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.Ubicacion obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Ubicacion_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdPasillo", obj.oPasillo.IdPasillo);
                    Cmd.Parameters.AddWithValue("IdColumna", obj.oColumna.IdColumna);
                    Cmd.Parameters.AddWithValue("IdNivel", obj.oNivel.IdNivel);
                    Cmd.Parameters.AddWithValue("NombreUbicacion", obj.NombreUbicacion);
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

        public bool Editar(EntityLayer.Ubicacion obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Ubicacion_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdUbicacion", obj.IdUbicacion);
                    Cmd.Parameters.AddWithValue("IdPasillo", obj.oPasillo.IdPasillo);
                    Cmd.Parameters.AddWithValue("IdColumna", obj.oColumna.IdColumna);
                    Cmd.Parameters.AddWithValue("IdNivel", obj.oNivel.IdNivel);
                    Cmd.Parameters.AddWithValue("NombreUbicacion", obj.NombreUbicacion);
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
                    SqlCommand Cmd = new SqlCommand("sp_Ubicacion_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdUbicacion", id);
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