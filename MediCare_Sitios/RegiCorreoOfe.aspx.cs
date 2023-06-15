using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediCare_Sitios
{
    public partial class Formulario_web111 : System.Web.UI.Page
    {
        NegocioCorreoOferente NegocioCorreoOferente = new NegocioCorreoOferente();

        EntidadCorreoOferente obj = new EntidadCorreoOferente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["username"] != null)
                {
                    if (Session["llave"] != null)
                    {
                        string llaves = Session["llave"].ToString();
                        btnRegistrarcorreoOferente.Text = "Modificar Correo";



                    }
                    else
                    {
                        btnRegistrarcorreoOferente.Text = "Agregar Correo";

                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }
        //Mostrar Mensaje
        private void MostrarMensaje(string mensaje)
        {
            string message = mensaje;
            string url = "Oferentes.aspx";
            string script = "{ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        }




        protected void btnRegistrarcorreoOferente_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["llave"] == null)
                {
                    obj.Identificacion = txtIdentificacion.Text;
                    obj.CorreoElectronico = txtcorreo.Text;



                    string mensaje = NegocioCorreoOferente.InsertarOferenteCorreo(obj);
                    MostrarMensaje(mensaje);
                }
                else
                {
                    obj.Identificacion = txtIdentificacion.Text;
                    obj.CorreoElectronico = txtcorreo.Text;


                    string mensaje = NegocioCorreoOferente.EditarOferenteCorreo(obj);
                    MostrarMensaje(mensaje);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
    }
}