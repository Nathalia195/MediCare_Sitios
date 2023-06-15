using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MediCare_Sitios
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        //NegocioGeneral obj_general = new NegocioGeneral();

        NegocioPuesto NegocioPuesto = new NegocioPuesto();
      
        EntidadPuesto obj = new EntidadPuesto();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void agregarPuesto_Click(object sender, EventArgs e)
        {
            try
            {
                obj.CodigoPuesto = int.Parse(txtPuesto.Text);
                obj.NombrePuesto = txtNombrePuesto.Text;
                



                string msj = NegocioPuesto.AgregarPuesto(obj);
                MostrarMensaje(msj);

                //limpiarForm();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            string message = mensaje;
            string url = "Puestos.aspx";
            string script = "{ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        }

        


    }
}