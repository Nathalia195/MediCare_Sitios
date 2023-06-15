using Entidad;
using Negocio;
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace MediCare_Sitios.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        NegocioUsuario obj_negocio = new NegocioUsuario();
        private EntidadUsuario Usuario;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["usuario"] = "";
                Session["contador"] = 0;
            }
            else
            {
                Session["username"] = "";
                Session["fullname"] = "";
                Session["rol"] = "";
            }

        }

        protected void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (Usuario == null) Usuario = new EntidadUsuario();

                Usuario.NombreUsuario = Txt_usuario.Text;
                Usuario.Contrasena = Txt_contrasena.Text;

                string Mensaje = obj_negocio.Autentificacion(Usuario);


                if (String.IsNullOrEmpty(Mensaje))
                {
                    if (string.IsNullOrEmpty(Session["usuario"].ToString()))
                    {
                        Session["usuario"] = Usuario.NombreUsuario;
                        Session["contador"] = Convert.ToInt32(Session["contador"].ToString()) + 1;
                    }
                    else
                    {
                        if (Session["usuario"].ToString() == Usuario.NombreUsuario)
                        {
                            Session["contador"] = Convert.ToInt32(Session["contador"].ToString()) + 1;

                            if (Convert.ToInt32(Session["contador"].ToString()) == 3)
                            {
                                obj_negocio.BloquearUsuario(Usuario);
                            }
                        }
                        else
                        {
                            Session["usuario"] = Usuario.NombreUsuario;
                            Session["contador"] = Convert.ToInt32(Session["contador"].ToString()) + 1;
                        }
                    }
                    Txt_usuario.Text = string.Empty;
                    Txt_contrasena.Text = string.Empty;
                    MostrarMensaje("Usuario y/o contraseña incorrectos.");
                }
                else
                {
                    Session["username"] = Mensaje.Split(',')[0];
                    Session["fullname"] = Mensaje.Split(',')[1];
                    Session["rol"] = Mensaje.Split(',')[2];
                    Response.Redirect("Index.aspx");
                }

        
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            string message = mensaje;
            string script = "{ alert('";
            script += message;
            script += "');}";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        }

    }
}