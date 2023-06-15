using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediCare_Sitios
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        NegocioOferentePuesto NegocioOferentePuesto = new NegocioOferentePuesto();
        EntidadOferentePuesto obj = new EntidadOferentePuesto();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string user = Session["llave3"].ToString();

                obj.Identificacion = user;                

                gvPuestos.DataSource = NegocioOferentePuesto.TraerInformacion(obj);
                gvPuestos.DataBind();

                foreach (GridViewRow row in gvPuestos.Rows)
                {
                    row.Cells[4].Visible = false;
                    if(row.Cells[4].Text == "Cumple")
                    {
                        row.Cells[5].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        row.Cells[5].BackColor = System.Drawing.Color.Red;
                    }
                }                
            }
        }

        protected void gvPuestos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            string columna = gvPuestos.Rows[fila].Cells[3].Text;
            Session["puesto"] = columna;

            Response.Redirect("VerRequisitos.aspx");
        }
    }
}