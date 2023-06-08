using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioCorreoOferente
    {
        DatosCorreoOferente obj_datos = new DatosCorreoOferente();



        //Validar Oferente.....

        private string ValidarCorreoOferente(EntidadCorreoOferente correoOferente, int opcion)
        {
            if (opcion == 0)
            {
                if (string.IsNullOrEmpty(correoOferente.Identificacion) || string.IsNullOrEmpty(correoOferente.CorreoElectronico)) return "Debe de completar todos los campos"; else return "";
            }
            else
            {
                if (string.IsNullOrEmpty(correoOferente.Identificacion) || string.IsNullOrEmpty(correoOferente.CorreoElectronico)) return "Debe de completar todos los campos"; else return "";
            }
        }



        //Metodo en la parte de negocio de insertar....
        public string InsertarOferenteCorreo(EntidadCorreoOferente mcEntidad)
        {
            string mensaje = ValidarCorreoOferente(mcEntidad, 0);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datos.InsertarCorreoOferentes(mcEntidad);
            }
            else
            {
                return mensaje;
            }
        }

        //Metodo de Modificar...  

        public string EditarOferenteCorreo(EntidadCorreoOferente mcEntidad)
        {
            string mensaje = ValidarCorreoOferente(mcEntidad, 0);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datos.EditarCorreoOferentes(mcEntidad);
            }
            else
            {
                return mensaje;
            }
        }

        //Eliminar metodo..........
        public void EliminarCorreoOferente(string id)
        {
            try
            {
                obj_datos.EliminarCorreoOferentes(id);
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera apropiada (por ejemplo, registrarla, notificar al usuario, etc.)
                throw ex;
            }
        }





    }// fin de la clase 
}// fin de namespace 
