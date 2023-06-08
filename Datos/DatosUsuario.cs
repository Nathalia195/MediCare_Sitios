using Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosUsuario
    {
        public string cnx;

        public DatosUsuario()
        {
            cnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }

        public string Autentificacion(EntidadUsuario Usuario)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_Autentificacion";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreUsuario", Usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@Contrasena", Usuario.Contrasena);

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            return dr["Nombre"].ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public byte[] TraerAvatar(EntidadUsuario Usuario)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    //ABRIMOS LA CONEXION
                    cnx.Open();

                    //DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_getAvatar";

                    //LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        //AGREGARON LOS PARAMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 50).Value = Usuario.NombreUsuario;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            byte[] imagen = (byte[])dr["Imagen"];
                            return imagen;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EntidadUsuario> GetUsuario()
        {
            List<EntidadUsuario> usuarios = new List<EntidadUsuario>();

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    //ABRIMOS LA CONEXION
                    cnx.Open();

                    //DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_getUsuario";

                    //LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            EntidadUsuario entidadUsuario = new EntidadUsuario
                            {
                                NombreUsuario = Convert.ToString(dr["NombreUsuario"]),
                                NombreCompleto = Convert.ToString(dr["NombreCompleto"]),
                                CorreoElectronico = Convert.ToString(dr["CorreoElectronico"]),
                                CodigoEstado = Convert.ToString(dr["NombreEstado"])
                            };
                            usuarios.Add(entidadUsuario);
                        }
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void BloquearUsuario(EntidadUsuario usuario)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_BloquearUsuario";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string InsertarUsuarios(EntidadUsuario Usuario)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_insert_usuario";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreUsuario", Usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@NombreCompleto", Usuario.NombreCompleto);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", Usuario.CorreoElectronico);
                        cmd.Parameters.AddWithValue("@Contrasena", Usuario.Contrasena);
                        cmd.Parameters.AddWithValue("@Imagen", Usuario.Imagen);
                        cmd.Parameters.AddWithValue("@CodigoRol", Usuario.CodigoRol);
                        cmd.Parameters.AddWithValue("@CodigoEstado", Usuario.CodigoEstado);
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;

                        //EJECUTAMOS LA CONSULTA
                        cmd.ExecuteNonQuery();

                        //SE OBTIENE EL RESULTADO DE LA CONSULTA
                        return cmd.Parameters["@Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EntidadUsuario> TraerUsuario(EntidadUsuario Usuario)
        {

            List<EntidadUsuario> usuarios = new List<EntidadUsuario>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_getUsuarios";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreUsuario", Usuario.NombreUsuario);

                        //DECLARAMOS UN OBJETO TIPO DATAREADER PARA GUARDAR LA LISTA DEVUELTA DE LA BASE DE DATOS
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        //SE DECLARA WHILE QUE RECORRE LO DEVULETO POR LA CONSULTA

                        while (dataReader.Read())
                        {
                            //SE LLENA UN OBJETO DE LA ENTIDAD CLIENTE
                            EntidadUsuario usuario1 = new EntidadUsuario
                            {
                                NombreUsuario = Convert.ToString(dataReader["NombreUsuario"]),
                                NombreCompleto = Convert.ToString(dataReader["NombreCompleto"]),
                                CorreoElectronico = Convert.ToString(dataReader["CorreoElectronico"]),
                                Contrasena = Convert.ToString(dataReader["Contrasena"]),
                                Imagen = (byte[])dataReader["Imagen"],
                                CodigoRol = Convert.ToString(dataReader["CodigoRol"]),
                                CodigoEstado = Convert.ToString(dataReader["CodigoEstado"])
                            };
                            usuarios.Add(usuario1);
                        }
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditarUsuario(EntidadUsuario Usuario)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_update_usuario";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreUsuario", Usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@NombreCompleto", Usuario.NombreCompleto);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", Usuario.CorreoElectronico);
                        cmd.Parameters.AddWithValue("@Contrasena", Usuario.Contrasena);
                        cmd.Parameters.AddWithValue("@Imagen", Usuario.Imagen);
                        cmd.Parameters.AddWithValue("@CodigoRol", Usuario.CodigoRol);
                        cmd.Parameters.AddWithValue("@CodigoEstado", Usuario.CodigoEstado);
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;

                        //EJECUTAMOS LA CONSULTA
                        cmd.ExecuteNonQuery();

                        //SE OBTIENE EL RESULTADO DE LA CONSULTA
                        return cmd.Parameters["@Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EliminarUsuarios(string username)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_delete_usuario";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreUsuario", username);
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;

                        //EJECUTAMOS LA CONSULTA
                        cmd.ExecuteNonQuery();

                        //SE OBTIENE EL RESULTADO DE LA CONSULTA
                        return cmd.Parameters["@Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
