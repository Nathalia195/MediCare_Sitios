using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPuesto
    {
        DatosPuesto obj_datosPuesto = new DatosPuesto();

        public List<EntidadPuesto> GetPuesto()
        {
            return obj_datosPuesto.GetPuesto();
        }
    }
}
