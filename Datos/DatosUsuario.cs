using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidad;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DatosUsuario
    {
        public string cnx;


        EntidadUsuario mcEntidad = new EntidadUsuario();
        SqlCommand cmd = new SqlCommand();
        bool vexito;
        public DatosUsuario()
        {
            cnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }

        //public IEnumerable<EntidadPuesto> Autenticacion()
        //{
        //    using (IDbConnection connection = new SqlConnection(cnx))
        //    {
        //        connection.Open();
        //        string query = "SELECT CodigoPuesto, NombrePuesto From Puesto";
        //        IEnumerable<EntidadPuesto> entidadpuesto = connection.Query<EntidadPuesto>(query);
        //        return entidadpuesto;
        //    }
        //}

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

    }
}
