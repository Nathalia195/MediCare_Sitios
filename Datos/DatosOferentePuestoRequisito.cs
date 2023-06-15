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
    public class DatosOferentePuestoRequisito
    {
        public string cnx;

        public DatosOferentePuestoRequisito()
        {
            cnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }

        public string InsertarOferentePuestoRequisito(EntidadOferentePuestoRequisito oferentePuesto)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_insert_oferente_puesto_requisito";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", oferentePuesto.Identificacion);
                        cmd.Parameters.AddWithValue("@Puesto", oferentePuesto.CodigoPuesto);
                        cmd.Parameters.AddWithValue("@Requisito", oferentePuesto.CodigoRequisito);
                        cmd.Parameters.AddWithValue("@Cumple", oferentePuesto.Cumple);
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

        public List<EntidadOferentePuestoRequisito> TraerInformacion(EntidadOferentePuestoRequisito oferentePuesto)
        {

            List<EntidadOferentePuestoRequisito> oferentes = new List<EntidadOferentePuestoRequisito>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_get_OferentePuestoRequisito";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Puesto", oferentePuesto.CodigoPuesto);
                        cmd.Parameters.AddWithValue("@identificacion", oferentePuesto.Identificacion);

                        //DECLARAMOS UN OBJETO TIPO DATAREADER PARA GUARDAR LA LISTA DEVUELTA DE LA BASE DE DATOS
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        //SE DECLARA WHILE QUE RECORRE LO DEVULETO POR LA CONSULTA

                        while (dataReader.Read())
                        {
                            //SE LLENA UN OBJETO DE LA ENTIDAD CLIENTE
                            EntidadOferentePuestoRequisito Oferentes1 = new EntidadOferentePuestoRequisito
                            {
                                nombre = Convert.ToString(dataReader["NombreRequisito"]),
                                CodigoRequisito = Convert.ToInt32(dataReader["CodigoRequisito"]),
                                CodigoPuesto = Convert.ToInt32(dataReader["CodigoPuesto"]),
                                Cumple = Convert.ToInt32(dataReader["CumpleRequisitios"])

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


        public string ModificarOferentePuestoRequisito(EntidadOferentePuestoRequisito oferentePuesto)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_update_oferente_puesto_requisito";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", oferentePuesto.Identificacion);
                        cmd.Parameters.AddWithValue("@Puesto", oferentePuesto.CodigoPuesto);
                        cmd.Parameters.AddWithValue("@Requisito", oferentePuesto.CodigoRequisito);
                        cmd.Parameters.AddWithValue("@Cumple", oferentePuesto.Cumple);
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
