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
    public partial class Formulario_web112 : System.Web.UI.Page
    {
        NegocioReferenteOferente NegocioReferenteOferente = new NegocioReferenteOferente();

        EntidadReferenteOferente obj = new EntidadReferenteOferente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["username"] != null)
                {
                    if (Session["llave"] != null)
                    {
                        string llaves = Session["llave"].ToString();
                        btnRegisOferente.Text = "Modificar Telefono";



                    }
                    else
                    {
                        btnRegisOferente.Text = "Agregar Referente";

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

        protected void btnRegisOferente_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["llave"] == null)
                {

                    obj.Identificacion = txtIdentificacion.Text;
                    obj.NombreReferente = txtnombrereferente.Text;
                    obj.TelefonoReferente = txttelefonoferente.Text;



                    string mensaje = NegocioReferenteOferente.InsertarOferenteReferente(obj);
                    MostrarMensaje(mensaje);
                }
                else
                {
                    obj.Identificacion = txtIdentificacion.Text;
                    obj.NombreReferente = txtnombrereferente.Text;
                    obj.TelefonoReferente = txttelefonoferente.Text;


                    string mensaje = NegocioReferenteOferente.EditarOferenteReferente(obj);
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