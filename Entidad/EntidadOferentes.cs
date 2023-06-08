using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntidadOferentes
    {
        public string Identificacion { get; set; }
        public int CodigoTipoIdentificacion { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string LugarResidencia { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public byte[] Curriculum { get; set; }

        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellidos}"; }
        }

    }
}
