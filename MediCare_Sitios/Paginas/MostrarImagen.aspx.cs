using Entidad;
using Negocio;
using System;

namespace MediCare_Sitios.Paginas
{
    public partial class MostrarImagen : System.Web.UI.Page
    {
        NegocioUsuario obj_negocio = new NegocioUsuario();
        private EntidadUsuario Usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Usuario == null) Usuario = new EntidadUsuario();

                Usuario.NombreUsuario = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(Usuario.NombreUsuario))
                {
                    Response.BinaryWrite(obj_negocio.TraerAvatar(Usuario));
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}