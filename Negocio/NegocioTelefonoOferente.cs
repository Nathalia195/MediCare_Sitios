using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioTelefonoOferente
    {
        DatosTelefonoOferente obj_datos = new DatosTelefonoOferente();


        //Validar Oferente.....

        private string ValidarTelefonoOferente(EntidadTelefonoOferente telefonoOferente, int opcion)
        {
            if (opcion == 0)
            {
                if (string.IsNullOrEmpty(telefonoOferente.Identificacion) || string.IsNullOrEmpty(telefonoOferente.Telefono) ) return "Debe de completar todos los campos"; else return "";
            }
            else
            {
                if (string.IsNullOrEmpty(telefonoOferente.Telefono) || string.IsNullOrEmpty(telefonoOferente.Telefono)) return "Debe de completar todos los campos"; else return "";
            }
        }







        //Metodo en la parte de negocio de insertar....
        public string InsertarOferenteTelefono(EntidadTelefonoOferente mcEntidad)
        {
            string mensaje = ValidarTelefonoOferente(mcEntidad, 0);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datos.InsertarTelefonoOferentes(mcEntidad);
            }
            else
            {
                return mensaje;
            }
        }
        //Metodo en la parte de Negocio de modificar....
        public string EditarOferenteTelefono(EntidadTelefonoOferente mcEntidad)
        {
            string mensaje = ValidarTelefonoOferente(mcEntidad, 0);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datos.InsertarTelefonoOferentes(mcEntidad);
            }
            else
            {
                return mensaje;
            }
        }

        //Metodo en La parte de nocio de eliminar 


        public void EliminarTelefonoOferente(string id)
        {
            try
            {
                obj_datos.EliminarTelefonoOferentes(id);
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera apropiada (por ejemplo, registrarla, notificar al usuario, etc.)
                throw ex;
            }
        }



    }// fin de la claseNeh¿gocio
}//fin de namespace 
