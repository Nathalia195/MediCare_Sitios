using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace MediCare_Sitios
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {

        NegocioOferente obj_negociooferente = new NegocioOferente();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                List<EntidadOferentes> oferentes = obj_negociooferente.GetUsuario();

                gvOferentes.DataSource = oferentes;
                gvOferentes.DataBind();



            }
            else
            {
                // Response.Redirect("login.aspx");
                Response.Redirect("RegisOferente.aspx");
            }

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

        //Metodo para ir la pantalla para poder editar y eliminar 


        protected void gvOferentes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = gvOferentes.Rows[fila].Cells[0].Text;
                Session["llave"] = columna;

                Response.Redirect("RegisOferente.aspx");
            }
            else
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = gvOferentes.Rows[fila].Cells[0].Text;

                string mensaje = obj_negociooferente.EliminarOferente(columna);

                string username = Session["username"].ToString();


                if (columna == username)
                {
                    Session["Indicador"] = "0";
                    //   MostrarMensaje2(mensaje, "login.aspx");
                }
                else
                {
                    //MostrarMensaje2(mensaje, "Oferentes.aspx");
                }
            }
        }
    }
}