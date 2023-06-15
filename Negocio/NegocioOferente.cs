using Datos;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public  class NegocioOferente
    {
        DatosOferentes obj_datos = new DatosOferentes();

        //Negocio Mostrar Usuario
        public List<EntidadOferentes> GetOferente()
        {
            return obj_datos.GetOferente();
        }

        //Validar Oferente.....

        private string ValidarOferente(EntidadOferentes oferentes, int opcion)
        {
            if (opcion == 0)
            {
                if (string.IsNullOrEmpty(oferentes.Identificacion) || string.IsNullOrEmpty(oferentes.Nombre) || string.IsNullOrEmpty(oferentes.Apellidos) ) return "Debe de completar todos los campos"; else return "";
            }
            else
            {
                if (string.IsNullOrEmpty(oferentes.Nombre) || string.IsNullOrEmpty(oferentes.Apellidos)) return "Debe de completar todos los campos"; else return "";
            }
        }
        //Metodo en la parte de negocio insertar Oferente.....



        public string InsertarOferente(EntidadOferentes mcEntidad)
        {
            string mensaje = ValidarOferente(mcEntidad, 0);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datos.InsertarOferentes(mcEntidad);
            }
            else
            {
                return mensaje;
            }
        }
        //Metodo en la parte de negocio Modificar Oferente....


        public string EditarOferente(EntidadOferentes mcEntidad)
        {

            string mensaje = ValidarOferente(mcEntidad, 1);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datos.EditarOferente(mcEntidad);
            }
            else
            {
                return mensaje;
            }
        }
        //Metodo en La parte de Negocio para eliminar 

        public string EliminarOferente(string id)
        {
            return obj_datos.EliminarOferente(id);
        }


        public List<EntidadOferentes> TraerOferente(EntidadOferentes mcEntidad)
        {
            return obj_datos.TraerOferente(mcEntidad);
        }

      








    } //Fin ClaseNegocioOferente
} //Negocio fin 
