using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediCare_Sitios
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NegocioPuesto NegocioPuesto = new NegocioPuesto();
        NegocioOferentePuesto NegocioOferentePuesto = new NegocioOferentePuesto();
        EntidadOferentePuesto obj = new EntidadOferentePuesto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<EntidadPuesto> puesto = NegocioPuesto.GetPuesto();

                int i = 0;
                foreach (EntidadPuesto c in puesto)
                {
                    ddl_puesto.Items.Insert(i, new ListItem(c.NombrePuesto, c.CodigoPuesto.ToString()));
                    i += 1;
                }

                txtOferente.Text = Session["llave2"].ToString();
            }
        }

        //Metodo Mostrar Mensaje
        private void MostrarMensaje(string mensaje)
        {
            string message = mensaje;
            string url = "AsignarRequisitos.aspx";
            string script = "{ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        }

        private void MostrarMensaje2(string mensaje)
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

        protected void BtnAsignarPuesto_Click(object sender, EventArgs e)
        {
            try
            {
                obj.Identificacion = txtOferente.Text;
                obj.CodigoPuesto = Convert.ToInt32(ddl_puesto.Text);

                string mensaje = NegocioOferentePuesto.InsertarOferentePuesto(obj);

                if(mensaje.Equals("Se le ha asignado el puesto al oferente"))
                {
                    Session["llave3"] = obj.CodigoPuesto;
                    MostrarMensaje(mensaje);
                }
                else
                {
                    MostrarMensaje2(mensaje);
                }       
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
    }
}