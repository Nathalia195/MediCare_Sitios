using Datos;
using Entidad;
using System.Collections.Generic;

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

        private string ValidarUsuario(EntidadUsuario Usuario)
        {
            if (string.IsNullOrEmpty(Usuario.NombreUsuario) || string.IsNullOrEmpty(Usuario.Contrasena)) return ""; else return "ok";
        }

        private string ValidarUsuario1(EntidadUsuario Usuario)
        {
            if (string.IsNullOrEmpty(Usuario.NombreUsuario) || string.IsNullOrEmpty(Usuario.NombreCompleto) || string.IsNullOrEmpty(Usuario.CorreoElectronico) || string.IsNullOrEmpty(Usuario.Contrasena) || string.IsNullOrEmpty(Usuario.Imagen.ToString())) return "Debe de completar todos los campos"; else return "";
        }

        public byte[] TraerAvatar(EntidadUsuario Usuario)
        {
            return obj_datos.TraerAvatar(Usuario);
        }


        public List<EntidadUsuario> GetUsuario()
        {
            return obj_datos.GetUsuario();
        }
        public void BloquearUsuario(EntidadUsuario usuario)
        {
            obj_datos.BloquearUsuario(usuario);
        }


        public string InsertarUsuarios(EntidadUsuario mcEntidad)
        {
            string mensaje = ValidarUsuario1(mcEntidad);

            if (string.IsNullOrEmpty(mensaje))
            {
                return obj_datos.InsertarUsuarios(mcEntidad);
            }
            else
            {
                return mensaje;
            }



        }



        //public void Editar(EntidadUsuario mcEntidad)
        //{
        //    obj_datos.EditarUsuario(mcEntidad);
        //}


    }
}