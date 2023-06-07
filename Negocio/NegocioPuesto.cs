using Datos;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioPuesto
    {
        DatosPuesto obj_datosPuesto = new DatosPuesto();
        private DatosPuesto negociopuesto;
        public NegocioPuesto()
        {
            negociopuesto = new DatosPuesto();
        }

        public List<EntidadPuesto> GetPuesto()
        {
            return obj_datosPuesto.GetPuesto();
        }


        private string ValidarPuesto(EntidadPuesto npuesto)
        {
            //int codigoPuesto = npuesto.CodigoPuesto;
            //string codigoPuestoStr = codigoPuesto.ToString();
            if 
                (string.IsNullOrEmpty(npuesto.NombrePuesto)) 
                return "Debe completar todos los campos";
            else return "";
        }

        private string ValidarPuesto1(EntidadPuesto Puesto, int opcion)
        {
            if (opcion == 0)
            {
                if (string.IsNullOrEmpty(Puesto.NombrePuesto))
                    return "Debe de completar todos los campos"; 
                else 
                    return "";
            }
            else
            {
                if (string.IsNullOrEmpty(Puesto.NombrePuesto))
                    return "Debe de completar todos los campos"; 
                else 
                    return "";
            }
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
        public List<EntidadPuesto> TraerPuesto(EntidadPuesto nPuesto)
        {
            return obj_datosPuesto.TraerPuesto(nPuesto);
        }


      

        public string EditarPuesto(EntidadPuesto nPuesto)
        {

            string mensaje = ValidarPuesto1(nPuesto, 1);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datosPuesto.EditarPuesto(nPuesto);
            }
            else
            {
                return mensaje;
            }
        }



        public string EliminarPuesto(int eliminarpuesto)
        {
            return obj_datosPuesto.EliminarPuesto(eliminarpuesto);
        }



        public IEnumerable<EntidadPuesto> ObtenerPuesto()
        {
            return negociopuesto.GetPuesto();
        }

        public void ActualizarCliente(EntidadPuesto puesto)
        {
            negociopuesto.ActualizarCliente(puesto);
        }

        public void BorrarCliente(int puestoid)
        {
            negociopuesto.BorrarCliente(puestoid);
        }


    }

}
