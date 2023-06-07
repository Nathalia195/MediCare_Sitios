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
    public partial class Formulario_web19 : System.Web.UI.Page
    {
        NegocioRequisitos obj_Requisito = new NegocioRequisitos();
        private NegocioRequisitos negociorequisito;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["llave"] != null && Request.UrlReferrer.AbsolutePath.EndsWith("Puestos.aspx"))
                {
                    int codigoPuesto = Convert.ToInt32(Session["llave"]);

                    // Aquí puedes usar el código de puesto para cargar los requisitos correspondientes al valor seleccionado en el GridView
                    List<EntidadRequisitos> requisitos = obj_Requisito.GetRequisitos(codigoPuesto);

                    gvRequisito.DataSource = requisitos;
                    gvRequisito.DataBind();
                }
                else
                {
                    List<EntidadRequisitos> requisitos = obj_Requisito.GetRequisito();

                    gvRequisito.DataSource = requisitos;
                    gvRequisito.DataBind();
                }
            }
        }

        protected void CargarRequisito()
        {
            {
                IEnumerable<EntidadRequisitos> requisito = obj_Requisito.GetRequisito();
                gvRequisito.DataSource = requisito;
                gvRequisito.DataBind();
            }
        }

        protected void gvRequisito_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRequisito.EditIndex = e.NewEditIndex;
            CargarRequisito();
        }

        protected void gvRequisito_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRequisito.EditIndex = -1;
            CargarRequisito();
        }

        protected void gvRequisito_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvRequisito.Rows[e.RowIndex];
            int CodigoRequisito = Convert.ToInt32(gvRequisito.DataKeys[e.RowIndex].Value);
            string NombreRequisito = ((TextBox)gvRequisito.Rows[e.RowIndex].Cells[1].Controls[0]).Text;

            EntidadRequisitos requisito1 = new EntidadRequisitos
            {
                CodigoRequisito = CodigoRequisito,
                NombreRequisito = NombreRequisito,
           
            };

            obj_Requisito.ActualizarRequisito(requisito1);

            gvRequisito.EditIndex = -1;
            CargarRequisito();
        }


        protected void gvRequisito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codigopuesto1 = Convert.ToInt32(gvRequisito.DataKeys[e.RowIndex].Value);
            obj_Requisito.BorrarRequisito(codigopuesto1);
            CargarRequisito();
        }
    }
}