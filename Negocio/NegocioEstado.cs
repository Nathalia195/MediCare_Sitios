using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioEstado
    {
        DatosEstado obj_datos = new DatosEstado();

        public List<EntidadEstado> GetEstado()
        {
            return obj_datos.GetEstado();
        }



    }
}
