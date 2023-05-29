using Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosEstado
    {
        public List<EntidadEstado> GetEstado()
        {
            List<EntidadEstado> estados = new List<EntidadEstado>();

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ToString()))
                {
                    //ABRIMOS LA CONEXION
                    cnx.Open();

                    //DECLARAMOS LA CONSULTA
                    string sqlQuery = "sp_getEstado";

                    //LE MANDAMOS LA CONSULTA A LA BASE DE DATOS
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            EntidadEstado estado = new EntidadEstado
                            {
                                CodigoEstado = Convert.ToString(dr["CodigoEstado"]),
                                NombreEstado = Convert.ToString(dr["NombreEstado"])
                            };
                            estados.Add(estado);
                        }
                    }
                }
                return estados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
