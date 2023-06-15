using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediCare_Sitios
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        NegocioOferentePuestoRequisito NegocioOferentePuestoRequisito = new NegocioOferentePuestoRequisito();
        EntidadOferentePuestoRequisito obj = new EntidadOferentePuestoRequisito();
        EntidadOferentePuestoRequisito obj2 = new EntidadOferentePuestoRequisito();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string user = Session["llave3"].ToString();
                string puesto = Session["puesto"].ToString();

                obj.Identificacion = user;
                obj.CodigoPuesto = Convert.ToInt32(puesto);

                gvPuestos.DataSource = NegocioOferentePuestoRequisito.TraerInformacion(obj);
                gvPuestos.DataBind();

                for (int i = 0; i < gvPuestos.Rows.Count; i++)
                {             
                    CheckBox ch = (CheckBox)gvPuestos.Rows[i].FindControl("CheckBox1");
                    gvPuestos.Rows[i].Cells[3].Visible = false;
                    if (gvPuestos.Rows[i].Cells[3].Text == "1")
                    {
                        ch.Checked = true;
                    }
                    else
                    {
                        ch.Checked = false;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";
                string user = Session["llave3"].ToString();
                string puesto = Session["puesto"].ToString();

                for (int i = 0; i < gvPuestos.Rows.Count; i++)
                {
                    obj2.Identificacion = user;
                    obj2.CodigoPuesto = Convert.ToInt32(puesto);
                    obj2.CodigoRequisito = Convert.ToInt32(gvPuestos.Rows[i].Cells[1].Text);

                    CheckBox ch = (CheckBox)gvPuestos.Rows[i].FindControl("CheckBox1");
                    if (ch.Checked == true)
                    {
                        obj2.Cumple = 1;
                    }
                    else
                    {
                        obj2.Cumple = 0;
                    }

                    mensaje = NegocioOferentePuestoRequisito.ModificarOferentePuestoRequisito(obj2);
                }

                MostrarMensaje(mensaje);
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
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

    }
}