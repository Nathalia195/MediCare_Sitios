using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntidadOferentePuestoRequisito
    {
        public string Identificacion { get; set; }
        public int? CodigoPuesto { get; set; }
        public int? CodigoRequisito { get; set; }
        public string nombre { get; set; }
        public int? Cumple { get; set; }
    }
}
