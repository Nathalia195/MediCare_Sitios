using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediCare_Sitios
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {

        NegocioOferente obj_negociooferente = new NegocioOferente();
         private NegocioOferente negocioOferente = new NegocioOferente();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                List<EntidadOferentes> oferentes = obj_negociooferente.GetOferente();

                gvOferentes.DataSource = oferentes;
                gvOferentes.DataBind();
                //CargarOferente();
                Session["llave"] = null;

            }
       

        }


        protected void gvOferentes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = gvOferentes.Rows[fila].Cells[0].Text;
                Session["llave"] = columna;

                Response.Redirect("RegisOferente.aspx");
            }
            else if(e.CommandName == "Select1")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = gvOferentes.Rows[fila].Cells[0].Text;

                string mensaje = obj_negociooferente.EliminarOferente(columna);
                Response.Redirect("Oferentes.aspx");
                string username = Session["username"].ToString();
            }else if (e.CommandName == "Select2")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = gvOferentes.Rows[fila].Cells[0].Text;
                Session["llave2"] = columna;

                Response.Redirect("AsignarPuesto.aspx");
            }
            else
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = gvOferentes.Rows[fila].Cells[0].Text;
                Session["llave3"] = columna;

                Response.Redirect("VerPuestos.aspx");
            }
        }


        protected void CargarOferente()
        {
            {
                IEnumerable<EntidadOferentes> puestos = negocioOferente.GetOferente();
                gvOferentes.DataSource = puestos;
                gvOferentes.DataBind();
            }
        }

  
    }
}