using Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosPuesto
    {
        public string cnx;


        EntidadPuesto npuesto = new EntidadPuesto();
        SqlCommand cmd = new SqlCommand();
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
             ;


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
