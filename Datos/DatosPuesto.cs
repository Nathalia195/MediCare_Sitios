using Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Datos
{
    public class DatosPuesto
    {
        public string cnx;


        public DatosPuesto()
        {
            cnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
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
        public List<EntidadPuesto> GetPuesto()
        {
            List<EntidadPuesto> puestos = new List<EntidadPuesto>();

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    //ABRIMOS LA CONEXION
                    cnx.Open();

                    //DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_getpuesto";

                    //LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            EntidadPuesto puesto = new EntidadPuesto
                            {
                                CodigoPuesto = Convert.ToInt32(dr["CodigoPuesto"]),
                                NombrePuesto = Convert.ToString(dr["NombrePuesto"])
                            };
                            puestos.Add(puesto);
                        }
                    }
                }
                return puestos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string AgregarPuesto(EntidadPuesto Puesto)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_insertpuesto";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoPuesto", Puesto.CodigoPuesto);
                        cmd.Parameters.AddWithValue("@NombrePuesto", Puesto.NombrePuesto);
             


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

        public string EditarPuesto(EntidadPuesto puesto)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS EL PROCEDIMIENTO ALMACENADO
                    string storedProcedure = "sp_update_puesto";

                    // LE MANDAMOS EL PROCEDIMIENTO ALMACENADO A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoPuesto", puesto.CodigoPuesto);
                        cmd.Parameters.AddWithValue("@NombrePuesto", puesto.NombrePuesto);
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;

                        // EJECUTAMOS EL PROCEDIMIENTO ALMACENADO
                        cmd.ExecuteNonQuery();

                        // OBTENEMOS EL RESULTADO DEL PROCEDIMIENTO ALMACENADO
                        return cmd.Parameters["@Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<EntidadPuesto> TraerPuesto(EntidadPuesto Puesto)
        {
            List<EntidadPuesto> puestos = new List<EntidadPuesto>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_getPuestos";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoPuesto", Puesto.CodigoPuesto);

                        // DECLARAMOS UN OBJETO TIPO DATAREADER PARA GUARDAR LA LISTA DEVUELTA DE LA BASE DE DATOS
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            // RECORREMOS LOS RESULTADOS DEL DATA READER
                            while (dataReader.Read())
                            {
                                // CREAMOS UN NUEVO OBJETO EntidadPuesto Y LO LLENAMOS CON LOS VALORES DEL DATA READER
                                EntidadPuesto puesto1 = new EntidadPuesto
                                {
                                    CodigoPuesto = Convert.ToInt32(dataReader["CodigoPuesto"]),
                                    NombrePuesto = Convert.ToString(dataReader["NombrePuesto"]),
                                };

                                // AGREGAMOS EL OBJETO AL LISTADO DE PUESTOS
                                puestos.Add(puesto1);
                            }
                        }
                    }
                }
                return puestos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EliminarPuesto(int idpuesto)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_delete_puesto";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoPuesto", idpuesto);
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


        public void ActualizarCliente(EntidadPuesto puesto)
        {
            using (IDbConnection connection = new SqlConnection(cnx))
            {
                connection.Open();

                string storedProcedure = "sp_update_puesto"; // Nombre del stored procedure
                var parameters = new
                {
                    CodigoPuesto = puesto.CodigoPuesto,
                    NombrePuesto = puesto.NombrePuesto
                };

                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public string BorrarCliente(int codigoPuesto)
        {
            string mensaje = string.Empty;

            using (IDbConnection connection = new SqlConnection(cnx))
            {
                connection.Open();

                string storedProcedure = "sp_delete_puesto"; // Nombre del stored procedure

                var cmd = connection.CreateCommand();
                cmd.CommandText = storedProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoPuesto", SqlDbType.Int) { Value = codigoPuesto });
                cmd.Parameters.Add(new SqlParameter("@Mensaje", SqlDbType.VarChar, 150) { Direction = ParameterDirection.Output });


                mensaje = "<script>alert('El elemento se ha eliminado.'); </script>" + mensaje;

                
                cmd.ExecuteNonQuery();



                return mensaje;
            }



        }

    }
}
