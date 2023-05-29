using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioRol
    {
        DatosRol obj_datos = new DatosRol();

        public List<EntidadRol> GetRol()
        {
            return obj_datos.GetRol();
        }

    }
}
