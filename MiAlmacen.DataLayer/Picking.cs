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
    public class Picking
    {
        public List<EntityLayer.Picking> Listar()
        {
            List<EntityLayer.Picking> lista = new List<EntityLayer.Picking>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select n.IdPicking, n.NombrePicking, n.IdEstado, e.NombreEstado from Picking n join Estado e on n.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Picking()
                            {
                                IdPicking = Convert.ToInt32(Dr["IdPicking"]),
                                oEntidad = new EntityLayer.Entidad()
                                {
                                    IdEntidad = Convert.ToInt32(Dr["IdEntidad"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                oTipoMovimiento = new EntityLayer.TipoMovimiento()
                                {
                                    IdTipoMovimiento = Convert.ToInt32(Dr["IdTipoMovimiento"]),
                                    NombreTipoMovimiento = Dr["NombreTipoMovimiento"].ToString()
                                },
                                NroOrden = Dr["NroOrden"].ToString(),
                                Fecha = Dr["Fecha"].ToString(),
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
                lista = new List<EntityLayer.Picking>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.Picking obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Picking_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("oTipoMovimiento", obj.oTipoMovimiento.IdTipoMovimiento);
                    Cmd.Parameters.AddWithValue("NroOrden", obj.NroOrden);
                    Cmd.Parameters.AddWithValue("Fecha", obj.Fecha);
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

        public bool Editar(EntityLayer.Picking obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Picking_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdPicking", obj.IdPicking);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("oTipoMovimiento", obj.oTipoMovimiento.IdTipoMovimiento);
                    Cmd.Parameters.AddWithValue("NroOrden", obj.NroOrden);
                    Cmd.Parameters.AddWithValue("Fecha", obj.Fecha);
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
                    SqlCommand Cmd = new SqlCommand("sp_Picking_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdPicking", id);
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