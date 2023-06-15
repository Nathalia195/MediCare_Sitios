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
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        NegocioPuesto negociopuesto = new NegocioPuesto();
       

        EntidadPuesto objPuesto = new EntidadPuesto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int llaves = Convert.ToInt32(Session["llave"]);

                btnEditarPuesto.Text = "Modificar usuario";

                    
                    TraerPuesto(llaves);
               
            }
        }

        protected void editarPuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["llave"] == null)
                {
                    objPuesto.CodigoPuesto = int.Parse(txtPuesto.Text);
                    objPuesto.NombrePuesto = txtNombrePuesto.Text;

                    string mensaje = negociopuesto.AgregarPuesto(objPuesto);
                    MostrarMensaje(mensaje);
                }
                else
                {
                    int codigoPuesto;
                    if (int.TryParse(txtPuesto.Text, out codigoPuesto))
                    {
                        objPuesto.CodigoPuesto = codigoPuesto;
                        objPuesto.NombrePuesto = txtNombrePuesto.Text;

                        string mensaje = negociopuesto.EditarPuesto(objPuesto);
                        MostrarMensaje(mensaje);
                    }
                    else
                    {
                        MostrarMensaje("El código de puesto no es válido. Por favor, ingrese un valor numérico.");
                    }
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
            string url = "Puestos.aspx";
            string script = "{ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        }

        private void TraerPuesto(int llave)
        {
            objPuesto.CodigoPuesto = llave;

            List<EntidadPuesto> objP = negociopuesto.TraerPuesto(objPuesto);

            foreach (var i in objP)
            {
                txtPuesto.Text = i.CodigoPuesto.ToString();

                txtNombrePuesto.Text = i.NombrePuesto;

            }

            txtPuesto.ReadOnly = true;
            txtNombrePuesto.Visible = true;
            
        }

    }
}