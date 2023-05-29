using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntidadUsuario
    {
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }

        public byte[] Imagen { get; set; }
        public string CodigoRol { get; set; }
        public string CodigoEstado { get; set; }
    }
}
