using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Datos
{
    public class DatosReferenteOferente
    {
        public string cnx;
        public DatosReferenteOferente()
        {
            cnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }
        //Insertar Metodo Referente Oferente....
        public string InsertarReferenteOferentes(EntidadReferenteOferente oferenteReferente)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_insert_referenteoferente";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@CodigoReferente", oferenteReferente.CodigoReferente);
                        cmd.Parameters.AddWithValue("@Identificacion", oferenteReferente.Identificacion);
                        cmd.Parameters.AddWithValue("@NombreReferente", oferenteReferente.NombreReferente);
                        cmd.Parameters.AddWithValue("@TelefonoReferente", oferenteReferente.TelefonoReferente);
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;

                        // EJECUTAMOS LA CONSULTA
                        cmd.ExecuteNonQuery();
                        return cmd.Parameters["@Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Modificar Metodo Referente Oferente
        public string EditarReferenteOferentes(EntidadReferenteOferente oferenteReferente)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = " sp_update_referenteoferente";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoReferente", oferenteReferente.CodigoReferente);
                        cmd.Parameters.AddWithValue("@Identificacion", oferenteReferente.Identificacion);
                        cmd.Parameters.AddWithValue("@NombreReferente", oferenteReferente.NombreReferente);
                        cmd.Parameters.AddWithValue("@TelefonoReferente", oferenteReferente.TelefonoReferente);
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;

                        // EJECUTAMOS LA CONSULTA
                        cmd.ExecuteNonQuery();
                        return cmd.Parameters["@Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Eliminar Referente oferente
        public void EliminarReferenteOferentes(string idreferente)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    cnx.Open();
                    string sqlQuery = "sp_delete_referenteoferente";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodigoReferente", idreferente);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí  agregar un registro de error o lanzar una excepción más específica
                throw ex;
            }
        }






    }//fin de clase datos
}// fin de namespace 
