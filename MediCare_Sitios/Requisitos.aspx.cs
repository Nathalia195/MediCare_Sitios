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
                if (Request.QueryString["CodigoPuesto"] != null)
                {
                    int CodigoPuesto = Convert.ToInt32(Request.QueryString["CodigoPuesto"]);

                    // Utiliza el ID del puesto para cargar los requisitos relacionados en el GridView
                    List<EntidadRequisitos> requisitos = obj_Requisito.GetRequisitos(CodigoPuesto);

                    gvRequisito.DataSource = requisitos;
                    gvRequisito.DataBind();
                }
                else
                {
                    // Carga todos los requisitos si no se proporciona el ID del puesto
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