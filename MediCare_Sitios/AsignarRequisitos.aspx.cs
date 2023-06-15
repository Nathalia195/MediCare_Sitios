using Entidad;
using Negocio;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediCare_Sitios
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        NegocioRequisitos obj = new NegocioRequisitos();
        NegocioOferentePuestoRequisito NegocioOferentePuestoRequisito = new NegocioOferentePuestoRequisito();
        EntidadOferentePuestoRequisito obj2 = new EntidadOferentePuestoRequisito();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string usuario = Session["llave2"].ToString();
                string puesto = Session["llave3"].ToString();

                dvrequisitos.DataSource = obj.GetRequisitos(Convert.ToInt32(puesto));
                dvrequisitos.DataBind();
            }           
        }

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

        protected void BtnAsignarPuesto_Click(object sender, EventArgs e)
        {                       
            try
            {
                string mensaje = "";
                string usuario = Session["llave2"].ToString();
                string puesto = Session["llave3"].ToString();

                for (int i = 0; i < dvrequisitos.Rows.Count; i++)
                {
                    obj2.Identificacion = usuario;
                    obj2.CodigoPuesto = Convert.ToInt32(puesto);
                    obj2.CodigoRequisito = Convert.ToInt32(dvrequisitos.Rows[i].Cells[1].Text);

                    CheckBox ch = (CheckBox)dvrequisitos.Rows[i].FindControl("CheckBox1");
                    if (ch.Checked == true)
                    {
                        obj2.Cumple = 1;
                    }
                    else
                    {
                        obj2.Cumple = 0;
                    }

                    mensaje = NegocioOferentePuestoRequisito.InsertarOferentePuestoRequisito(obj2);
                }                

                MostrarMensaje(mensaje);
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
    }
}