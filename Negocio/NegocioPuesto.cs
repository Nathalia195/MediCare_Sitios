using Datos;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioPuesto
    {
        DatosPuesto obj_datosPuesto = new DatosPuesto();

        public List<EntidadPuesto> GetPuesto()
        {
            return obj_datosPuesto.GetPuesto();
        }


        private string ValidarPuesto(EntidadPuesto npuesto)
        {
            int codigoPuesto = npuesto.CodigoPuesto;
            string codigoPuestoStr = codigoPuesto.ToString();
            if 
                (string.IsNullOrEmpty(npuesto.NombrePuesto)) 
                return "Debe completar todos los campos";
            else return "";
        }



        public string AgregarPuesto(EntidadPuesto nPuesto)
        {
            string mensaje = ValidarPuesto(nPuesto);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datosPuesto.AgregarPuesto(nPuesto);

            }
            else
            {
                return mensaje;
            }
        }
    }

}
