using Entidad;
using Datos;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioOferentePuesto
    {
        DatosOferentePuesto obj_datos = new DatosOferentePuesto();

        public string InsertarOferentePuesto(EntidadOferentePuesto oferentePuesto)
        {
            return obj_datos.InsertarOferentePuesto(oferentePuesto);         
        }

        public List<EntidadOferentePuesto> TraerInformacion(EntidadOferentePuesto oferentePuesto)
        {
            return obj_datos.TraerInformacion(oferentePuesto);
        }
    }
}
