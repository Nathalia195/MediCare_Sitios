using Entidad;
using Datos;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioOferentePuestoRequisito
    {
        DatosOferentePuestoRequisito obj_datos = new DatosOferentePuestoRequisito();

        public string InsertarOferentePuestoRequisito(EntidadOferentePuestoRequisito oferentePuesto)
        {
            return obj_datos.InsertarOferentePuestoRequisito(oferentePuesto);
        }

        public List<EntidadOferentePuestoRequisito> TraerInformacion(EntidadOferentePuestoRequisito oferentePuesto)
        {
            return obj_datos.TraerInformacion(oferentePuesto);
        }

        public string ModificarOferentePuestoRequisito(EntidadOferentePuestoRequisito oferentePuesto)
        {
            return obj_datos.ModificarOferentePuestoRequisito(oferentePuesto);
        }
    }
}
