using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Datos
{
    public class DatosOferentes
    {
        public string cnx;
        public DatosOferentes()
        {
            cnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }
         //Metodo Mostrar Listado Oferente....
        public List<EntidadOferentes> GetOferente()
        {
            List<EntidadOferentes> oferente = new List<EntidadOferentes>();

            try
            {
             using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    //ABRIMOS LA CONEXION
                    cnx.Open();

                    //DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_getoferente" ;
                    //LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx)) 
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            EntidadOferentes entidadOferentes = new EntidadOferentes();
                            {
                                entidadOferentes.Identificacion = Convert.ToString(dr["Identificacion"]);
                                entidadOferentes.CodigoTipoIdentificacion = Convert.ToInt32(dr["CodigoTipoIdentificacion"]);
                                entidadOferentes.Nombre = Convert.ToString(dr["Nombre completo"]);


                            };
                            oferente.Add(entidadOferentes);
                        }
                    }

                }
                return oferente;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo de insertar Oferente....


        public string InsertarOferentes(EntidadOferentes oferentes)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_insert_oferente";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", oferentes.Identificacion);
                        cmd.Parameters.AddWithValue("@CodiTipoIdentificacion", oferentes.CodigoTipoIdentificacion);
                        cmd.Parameters.AddWithValue("@Nombre", oferentes.Nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", oferentes.Apellidos);
                        cmd.Parameters.AddWithValue("@LugarResidencia", oferentes.LugarResidencia);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", oferentes.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Curriculum", oferentes.Curriculum);
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
        //Editar Oferente........  


        public string EditarOferente(EntidadOferentes oferentes)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_update_oferente";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", oferentes.Identificacion);
                        cmd.Parameters.AddWithValue("@CodiTipoIdentificacion", oferentes.CodigoTipoIdentificacion);
                        cmd.Parameters.AddWithValue("@Nombre", oferentes.Nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", oferentes.Apellidos);
                        cmd.Parameters.AddWithValue("@LugarResidencia", oferentes.LugarResidencia);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", oferentes.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Curriculum", oferentes.Curriculum);
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

        //Eliminar Oferente.....

        public string EliminarOferente(string id)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_delete_oferente";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", id);
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



        //Metodo Para traer la informacion guardada en bd y poder editarla

        public List<EntidadOferentes> TraerOferente(EntidadOferentes Oferentes)
        {

            List<EntidadOferentes> oferentes = new List<EntidadOferentes>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_getOferente_Trae";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@identificacion", Oferentes.Identificacion);

                        //DECLARAMOS UN OBJETO TIPO DATAREADER PARA GUARDAR LA LISTA DEVUELTA DE LA BASE DE DATOS
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        //SE DECLARA WHILE QUE RECORRE LO DEVULETO POR LA CONSULTA

                        while (dataReader.Read())
                        {
                            //SE LLENA UN OBJETO DE LA ENTIDAD CLIENTE
                            EntidadOferentes Oferentes1 = new EntidadOferentes
                            {
                                Identificacion = Convert.ToString(dataReader["identificacion"]),
                                CodigoTipoIdentificacion = Convert.ToInt32(dataReader["CodigoTipoIdentificacion"]),
                                 Nombre = Convert.ToString(dataReader["Nombre"]),
                                Apellidos = Convert.ToString(dataReader["Apellidos"]),
                                LugarResidencia = Convert.ToString(dataReader["LugarResidencia"]),
                                FechaNacimiento = DateTime.Parse(Convert.ToString(dataReader["FechaNacimiento"])),
                                Curriculum = (byte[])dataReader["Curriculum"]


                        };
                            oferentes.Add(Oferentes1);
                        }
                    }
                }
                return oferentes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }













    } //Fin clase DatosOferentes
}// Fin namespace
