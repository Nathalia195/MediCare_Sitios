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
    public class DatosRequisitos
    {
        public string cnx;


        public DatosRequisitos()
        {
            cnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }
        public List<EntidadRequisitos> GetRequisitos(int codigoPuesto)
        {
            List<EntidadRequisitos> requisitos = new List<EntidadRequisitos>();

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_GetRequisito";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CodigoPuesto", SqlDbType.Int).Value = codigoPuesto;
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            EntidadRequisitos requisito = new EntidadRequisitos
                            {
                                CodigoRequisito = Convert.ToInt32(dr["CodigoRequisito"]),
                                NombreRequisito = Convert.ToString(dr["NombreRequisito"]),
                                CodigoPuesto = Convert.ToInt32(dr["CodigoPuesto"])
                            };
                            requisitos.Add(requisito);
                        }
                    }
                }
                return requisitos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EntidadRequisitos> GetRequisito()
        {
            List<EntidadRequisitos> requisitos = new List<EntidadRequisitos>();

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    //ABRIMOS LA CONEXION
                    cnx.Open();

                    //DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_GetRequisitos";

                    //LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            EntidadRequisitos requisito = new EntidadRequisitos
                            {
                                CodigoRequisito = Convert.ToInt32(dr["CodigoRequisito"]),
                                NombreRequisito = Convert.ToString(dr["NombreRequisito"]),
                                CodigoPuesto = Convert.ToInt32(dr["CodigoPuesto"])
                            };
                            requisitos.Add(requisito);
                        }
                    }
                }
                return requisitos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string AgregarRequisito(EntidadRequisitos Requisito)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_insert_requisitopuesto";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoRequisito", Requisito.CodigoRequisito);
                        cmd.Parameters.AddWithValue("@NombreRequisito", Requisito.NombreRequisito);

                        cmd.Parameters.AddWithValue("@CodigoPuesto", Requisito.CodigoPuesto);


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

        public void EditarRequisito(EntidadRequisitos requisito)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS EL PROCEDIMIENTO ALMACENADO
                    string storedProcedure = "sp_update_requisitospuesto";

                    // LE MANDAMOS EL PROCEDIMIENTO ALMACENADO A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoRequisito", requisito.CodigoRequisito);
                        cmd.Parameters.AddWithValue("@NombreRequisitos", requisito.NombreRequisito);

                        // EJECUTAMOS EL PROCEDIMIENTO ALMACENADO
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void ActualizarRequisito(EntidadRequisitos requisito)
        {
            using (IDbConnection connection = new SqlConnection(cnx))
            {
                connection.Open();

                string storedProcedure = "sp_update_requisitospuesto"; // Nombre del stored procedure
                var parameters = new
                {
                    CodigoRequisito = requisito.CodigoRequisito,
                    NombrePuesto = requisito.NombreRequisito,
                    CodigoPuesto = requisito.CodigoPuesto
                };

                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public string BorrarRequisito(int codigoRequisito)
        {
            string mensaje = string.Empty;

            using (IDbConnection connection = new SqlConnection(cnx))
            {
                connection.Open();

                string storedProcedure = "sp_delete_requisitospuestos"; // Nombre del stored procedure

                var cmd = connection.CreateCommand();
                cmd.CommandText = storedProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CodigoRequisito", SqlDbType.Int) { Value = codigoRequisito });
                


                mensaje = "<script>alert('El elemento se ha eliminado.'); </script>" + mensaje;


                cmd.ExecuteNonQuery();



                return mensaje;
            }



        }

    }
}
