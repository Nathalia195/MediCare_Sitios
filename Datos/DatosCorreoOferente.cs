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
    public class DatosCorreoOferente
    {
        public string cnx;
        public DatosCorreoOferente()
        {
            cnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }
        //Metodo de insertar Correo Oferente...

        public string InsertarCorreoOferentes(EntidadCorreoOferente oferentecorreo)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_insert_correoelctoferente";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", oferentecorreo.Identificacion);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", oferentecorreo.CorreoElectronico);
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;


                        // EJECUTAMOS LA CONSULTA
                        cmd.ExecuteNonQuery();
                        //SE OBTIENE EL RESULTADO DE LA CONSULTA
                        return cmd.Parameters["@Mensaje"].Value.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Metodo de modificar CorreoOferente   

        public string EditarCorreoOferentes(EntidadCorreoOferente oferentecorreo)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_update_correoelectoferente";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", oferentecorreo.Identificacion);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", oferentecorreo.CorreoElectronico);
                        cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;


                        // EJECUTAMOS LA CONSULTA
                        cmd.ExecuteNonQuery();
                        //SE OBTIENE EL RESULTADO DE LA CONSULTA
                        return cmd.Parameters["@Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Metodo de Eliminar Correo .....

        public void EliminarCorreoOferentes(string idcorreo)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    cnx.Open();
                    string sqlQuery = "sp_delete_correoelctoferente";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", idcorreo);

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






    }//fin de clase datoscorreooferente
}// fin de namespace
