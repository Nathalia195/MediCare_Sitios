using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class DatosTelefonoOferente
    {
        public string cnx;
        public DatosTelefonoOferente()
        {
            cnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }
        //Metodo de insertar Telefono

        public string InsertarTelefonoOferentes(EntidadTelefonoOferente oferentestelefono)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_insert_telefo_oferente"; 

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", oferentestelefono.Identificacion);
                        cmd.Parameters.AddWithValue("@Telefono", oferentestelefono.Telefono);
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

        //Modificar Telefono

        public string EditarTelefonoOferentes(EntidadTelefonoOferente oferentestelefono)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    // ABRIMOS LA CONEXION
                    cnx.Open();

                    // DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_update_telefonooferente";

                    // LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        // AGREGAMOS LOS PARÁMETROS
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", oferentestelefono.Identificacion);
                        cmd.Parameters.AddWithValue("@Telefono", oferentestelefono.Telefono);

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


        //Metodo Eliminar TelefonosOferentes

        public void EliminarTelefonoOferentes(string idtelefono)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    cnx.Open();
                    string sqlQuery = "sp_delete_telefonooferente";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", idtelefono);

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









    }//fin de la clase datostelefonooferente
}//fin de namespace
