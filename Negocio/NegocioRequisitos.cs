using Datos;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioRequisitos
    {
        DatosRequisitos obj_datosRequisito = new DatosRequisitos();
        private DatosRequisitos negociorequisito;
        public NegocioRequisitos()
        {
            negociorequisito = new DatosRequisitos();
        }

        public List<EntidadRequisitos> GetRequisitos(int codigoPuesto)
        {
            return obj_datosRequisito.GetRequisitos(codigoPuesto);
        }

        private string ValidarRequisito(EntidadRequisitos nRequisito)
        {
            //int codigoPuesto = npuesto.CodigoPuesto;
            //string codigoPuestoStr = codigoPuesto.ToString();
            if
                (string.IsNullOrEmpty(nRequisito.NombreRequisito))
                return "Debe completar todos los campos";
            else return "";
        }
        public string AgregarRequisito(EntidadRequisitos nRequisito)
        {
            string mensaje = ValidarRequisito(nRequisito);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datosRequisito.AgregarRequisito(nRequisito);

            }
            else
            {
                return mensaje;
            }
        }
        public List<EntidadRequisitos> GetRequisito()
        {
            return obj_datosRequisito.GetRequisito();
        }

        public void ActualizarRequisito(EntidadRequisitos requisito)
        {
            negociorequisito.EditarRequisito(requisito);
        }

        public void BorrarRequisito(int codigorequisito)
        {
            negociorequisito.BorrarRequisito(codigorequisito);
        }
    }
}
