using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare_Sitios
{
    public class NegocioUsuario
    {
        DatosUsuario obj_datos = new DatosUsuario();

        public string Autentificacion(EntidadUsuario Usuario)
        {
            if (!string.IsNullOrEmpty(ValidarUsuario(Usuario)))
            {
                return obj_datos.Autentificacion(Usuario);
            }
            else
            {
                return "";
            }
        }

        public byte[] TraerAvatar(EntidadUsuario Usuario)
        {
            return obj_datos.TraerAvatar(Usuario);
        }

        private string ValidarUsuario(EntidadUsuario Usuario)
        {
            if (string.IsNullOrEmpty(Usuario.NombreUsuario) || string.IsNullOrEmpty(Usuario.Contrasena)) return ""; else return "ok";
        }

        public List<EntidadUsuario> GetUsuario()
        {
            return obj_datos.GetUsuario();
        }

    }
}