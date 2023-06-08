using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioReferenteOferente
    {
        DatosReferenteOferente obj_datos = new DatosReferenteOferente();


        //Validar Oferente.....

        private string ValidarReferenteOferente(EntidadReferenteOferente referenteOferente, int opcion)
        {
            if (opcion == 0)
            {
                if (string.IsNullOrEmpty(referenteOferente.Identificacion) || string.IsNullOrEmpty(referenteOferente.NombreReferente)) return "Debe de completar todos los campos"; else return "";
            }
            else
            {
                if (string.IsNullOrEmpty(referenteOferente.TelefonoReferente) || string.IsNullOrEmpty(referenteOferente.NombreReferente)) return "Debe de completar todos los campos"; else return "";
            }
        }






        //Metodo en la parte de negocio de insertar....
        public string InsertarOferenteReferente(EntidadReferenteOferente mcEntidad)
        {
            string mensaje = ValidarReferenteOferente(mcEntidad, 0);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datos.InsertarReferenteOferentes(mcEntidad);
            }
            else
            {
                return mensaje;
            }
        }

        //Metodo de modificar....  

        public string EditarOferenteReferente(EntidadReferenteOferente mcEntidad)
        {
            string mensaje = ValidarReferenteOferente(mcEntidad, 0);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datos.EditarReferenteOferentes(mcEntidad);
            }
            else
            {
                return mensaje;
            }
        }
        //Metodo de eliminar ......

        public void EliminarOferenteReferente(string id)
        {
            try
            {
                obj_datos.EliminarReferenteOferentes(id);
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera apropiada (por ejemplo, registrarla, notificar al usuario, etc.)
                throw ex;
            }
        }









    }// fin de la clase 
}// fin de namespace
