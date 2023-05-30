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


    }
}
