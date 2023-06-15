using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace MediCare_Sitios
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {

        NegocioUsuario obj_usuario = new NegocioUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["rol"] != null)
                {
                    string rol = Session["rol"].ToString();
                    if (rol != "AD")
                    {
                        MostrarMensaje("Lo sentimos, usted no tiene acceso a este mantenimiento");
                    }
                    else
                    {
                        List<EntidadUsuario> usuario = obj_usuario.GetUsuario();

                        Dgv_usuario.DataSource = usuario;
                        Dgv_usuario.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            string message = mensaje;
            string url1 = "Index.aspx";
            string script = "{ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url1;
            script += "'; }";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        }

        private void MostrarMensaje2(string mensaje, string url)
        {
            string message = mensaje;
            string url1 = url;
            string script = "{ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url1;
            script += "'; }";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        }

        protected void Dgv_usuario_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = Dgv_usuario.Rows[fila].Cells[0].Text;
                Session["llave"] = columna;

                Response.Redirect("AgregarUsuario.aspx");
            }
            else
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = Dgv_usuario.Rows[fila].Cells[0].Text;

                string mensaje = obj_usuario.EliminarUsuarios(columna);

                string username = Session["username"].ToString();


                if (columna == username)
                {
                    Session["Indicador"] = "0";
                    MostrarMensaje2(mensaje, "Login.aspx");
                }
                else
                {
                    MostrarMensaje2(mensaje, "MantUsuario.aspx");
                }
            }
        }

        protected void redi(object sender, EventArgs e)
        {
            Session["llave"] = null;

            Response.Redirect("AgregarUsuario.aspx");
        }

        protected void Dgv_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}