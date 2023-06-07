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
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        //NegocioGeneral obj_general = new NegocioGeneral();
        NegocioPuesto obj_Puesto = new NegocioPuesto();
        private NegocioPuesto negociopuesto;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<EntidadPuesto> puesto = obj_Puesto.GetPuesto();

                gvPuesto.DataSource = puesto;
                gvPuesto.DataBind();


            }

        }
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        if (Request.QueryString["CodigoPuesto"] != null)
        //        {
        //            int CodigoPuesto = Convert.ToInt32(Request.QueryString["CodigoPuesto"]);

        //            // Aquí puedes usar el código de puesto para cargar los requisitos correspondientes al valor seleccionado en el GridView

        //            // Por ejemplo:
        //            List<EntidadPuesto> puesto = obj_Puesto.GetPuesto();

        //            gvPuesto.DataSource = puesto;
        //            gvPuesto.DataBind();
        //        }
        //    }
        //}



        //protected void gv_puesto_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Select")
        //    {
        //        int fila = Convert.ToInt32(e.CommandArgument);
        //        string columna = gvPuesto.Rows[fila].Cells[0].Text;
        //        Session["llave"] = columna;
        //        Response.Redirect("EditarPuesto.aspx");
        //    }
        //    else
        //    {
        //        int fila = Convert.ToInt32(e.CommandArgument);
        //        string columna = gvPuesto.Rows[fila].Cells[0].Text;

        //        string mensaje = obj_Puesto.EliminarPuesto(int.Parse(columna));

        //    }
        //}
        protected void redi(object sender, EventArgs e)
        {
            Session["llave"] = null;

            Response.Redirect("RegistroPuesto.aspx");
        }
        protected void CargarPuesto()
        {
            {
                IEnumerable<EntidadPuesto> puestos = obj_Puesto.ObtenerPuesto();
                gvPuesto.DataSource = puestos;
                gvPuesto.DataBind();
            }
        }
        protected void gvPuesto_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPuesto.EditIndex = e.NewEditIndex;
            CargarPuesto();
        }

        protected void gvPuesto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPuesto.Rows[e.RowIndex];
            int CodigoPuesto = Convert.ToInt32(gvPuesto.DataKeys[e.RowIndex].Value);
            string NombrePuesto = ((TextBox)gvPuesto.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            

            EntidadPuesto puesto1 = new EntidadPuesto
            {
                CodigoPuesto = CodigoPuesto,
                NombrePuesto = NombrePuesto,
               
            };

            obj_Puesto.ActualizarCliente(puesto1);

            gvPuesto.EditIndex = -1;
            CargarPuesto();
        }

        protected void gvPuesto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codigopuesto1 = Convert.ToInt32(gvPuesto.DataKeys[e.RowIndex].Value);
            obj_Puesto.BorrarCliente(codigopuesto1);
            CargarPuesto();
        }

        protected void gvPuesto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPuesto.EditIndex = -1;
            CargarPuesto();
        }

        protected void btnRequisitos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Requisitos.aspx");
        }

        protected void gvPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvPuesto.SelectedIndex;

            // Obtener los datos de la fila seleccionada
            int CodigoPuesto = Convert.ToInt32(gvPuesto.Rows[selectedIndex].Cells[2].Text);

            // Redireccionar a la nueva página y pasar los datos
            Response.Redirect("Requisitos.aspx?CodigoPuesto=" + CodigoPuesto);
        }




        //protected void gvPuesto_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Select")
        //    {
        //        int fila = Convert.ToInt32(e.CommandArgument);
        //        string columna = gvPuesto.Rows[fila].Cells[0].Text;
        //        ;

        //        Response.Redirect("RegistrarRequsito.aspx");
        //    }
        //    else
        //    {
        //        int fila = Convert.ToInt32(e.CommandArgument);
        //        string columna = gvPuesto.Rows[fila].Cells[0].Text;

        //        //LLAMAR FUNCION PARA ELIMINAR y pasar columna                

        //        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Hello World');", true);
        //    }
        //}
        protected void redi1(object sender, EventArgs e)
        {
            Session["llave"] = null;



            Response.Redirect("RegistrarRequsito.aspx");
        }
    }
}