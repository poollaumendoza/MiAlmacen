﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.DataLayer
{
    public class Entidad
    {
        public List<EntityLayer.Entidad> Listar()
        {
            List<EntityLayer.Entidad> lista = new List<EntityLayer.Entidad>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select en.IdEntidad, en.IdTipoDocumento, td.NombreTipoDocumento, en.NroDocumento, en.RazonSocial, en.Direccion, en.Telefono, en.Email, en.EsCliente, en.EsProveedor, en.EsTransportista, en.IdEstado, es.NombreEstado from Entidad en join TipoDocumento td on en.IdTipoDocumento = td.IdTipoDocumento join Estado es on en.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Entidad()
                            {
                                IdEntidad = Convert.ToInt32(Dr["IdEntidad"]),
                                oTipoDocumento = new EntityLayer.TipoDocumento()
                                {
                                    IdTipoDocumento = Convert.ToInt32(Dr["IdTipoDocumento"]),
                                    NombreTipoDocumento = Dr["NombreTipoDocumento"].ToString()
                                },
                                RazonSocial = Dr["RazonSocial"].ToString(),
                                Direccion = Dr["Direccion"].ToString(),
                                Telefono = Dr["Telefono"].ToString(),
                                Email = Dr["Email"].ToString(),
                                EsCliente = Convert.ToBoolean(Dr["EsCliente"]),
                                EsProveedor = Convert.ToBoolean(Dr["EsProveedor"]),
                                EsTransportista = Convert.ToBoolean(Dr["EsTransportista"]),
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
                lista = new List<EntityLayer.Entidad>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.Entidad obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Entidad_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    Cmd.Parameters.AddWithValue("Email", obj.Email);
                    Cmd.Parameters.AddWithValue("EsCliente", obj.EsCliente);
                    Cmd.Parameters.AddWithValue("EsProveedor", obj.EsProveedor);
                    Cmd.Parameters.AddWithValue("EsTransportista", obj.EsTransportista);
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

        public bool Editar(EntityLayer.Entidad obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Entidad_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    Cmd.Parameters.AddWithValue("Email", obj.Email);
                    Cmd.Parameters.AddWithValue("EsCliente", obj.EsCliente);
                    Cmd.Parameters.AddWithValue("EsProveedor", obj.EsProveedor);
                    Cmd.Parameters.AddWithValue("EsTransportista", obj.EsTransportista);
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
                    SqlCommand Cmd = new SqlCommand("sp_Entidad_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdEntidad", id);
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