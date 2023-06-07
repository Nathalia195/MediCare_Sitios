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
    public partial class Formulario_web110 : System.Web.UI.Page
    {
        NegocioRequisitos negociorequisito = new NegocioRequisitos();
        EntidadRequisitos obj = new EntidadRequisitos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarRequisito_Click(object sender, EventArgs e)
        {
            try
            {
                obj.CodigoRequisito = int.Parse(txtCodigoRequisito.Text);
                obj.NombreRequisito = txtNombreRequisito.Text;
                obj.CodigoPuesto = int.Parse(txtCodigoPuesto.Text);




                string msj = negociorequisito.AgregarRequisito(obj);
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
            string url = "Requisitos.aspx";
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