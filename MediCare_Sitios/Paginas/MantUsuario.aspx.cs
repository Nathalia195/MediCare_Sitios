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


        //NegocioGeneral obj_general = new NegocioGeneral();
        NegocioUsuario obj_usuario = new NegocioUsuario();


        protected void Page_Load(object sender, EventArgs e)
        {

            string rol = Session["rol"].ToString();

            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(rol))
                {

                    if (rol != "AD")
                    {
                        MostrarMensaje2("Lo sentimos, usted no tiene acceso a este mantenimiento");
                    }
                    else
                    {
                        List<EntidadUsuario> usuario = obj_usuario.GetUsuario();

                        GvUsuario.DataSource = usuario;
                        GvUsuario.DataBind();


                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            string message = mensaje;
            string url1 = "MantUsuario.aspx";
            string script = "{ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url1;
            script += "'; }";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        }

        private void MostrarMensaje2(string mensaje)
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

        protected void DgvUsuario_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = GvUsuario.Rows[fila].Cells[0].Text;
                Session["llave"] = columna;

                Response.Redirect("AgregarUsuario.aspx");
            }
            else
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = GvUsuario.Rows[fila].Cells[0].Text;

                //LLAMAR FUNCION PARA ELIMINAR y pasar columna                

                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Hello World');", true);
            }
        }
        protected void redi(object sender, EventArgs e)
        {
            Session["llave"] = null;



            Response.Redirect("AgregarUsuario.aspx");
        }

    }
}