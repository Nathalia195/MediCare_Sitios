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
    public partial class Formulario_web15 : System.Web.UI.Page
    {

        NegocioOferente NegocioOferente = new NegocioOferente();

        EntidadOferentes obj = new EntidadOferentes();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["username"] != null)
                {
                    if (Session["llave"] != null)
                    {
                        string llaves = Session["llave"].ToString();
                        btnRegisOferente.Text = "Modificar Oferente";


                        TraerOferente(llaves);
                    }
                    else
                    {
                        btnRegisOferente.Text = "Agregar Oferente";

                    }
                }
                else
                {
                    //Response.Redirect("login.aspx");
                    Response.Redirect("RegisOferente.aspx");
                }
            }






        }


        //Metodo Mostrar Mensaje
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


        //Metodo de Traer Oferente 

        private void TraerOferente(string llave)
        {
            obj.Identificacion = llave;

            List<EntidadOferentes> objs = NegocioOferente.TraerOferente(obj);

            foreach (var i in objs)
            {
                txtIdentificacion.Text = i.Identificacion;
                txtcodtipoid.Text = i.CodigoTipoIdentificacion.ToString();
                txtNombreOfe.Text = i.Nombre;
                txtApellidosOfe.Text = i.Apellidos;
                txtRecidencia.Text = i.LugarResidencia;
                txtFechaNaci.Text = i.FechaNacimiento.ToString("dd/MM/yyyy");
                flUpcurriculum.Visible = true;
            }

            // txtNombreOfe.ReadOnly = true;
            //txtApellidosOfe.ReadOnly = true;
        }

        protected void btnRegisOferente_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["llave"] == null)
                {
                    obj.Identificacion = txtIdentificacion.Text;
                    obj.CodigoTipoIdentificacion = Convert.ToInt32(txtcodtipoid.Text);
                    obj.Nombre = txtNombreOfe.Text;
                    obj.Apellidos = txtApellidosOfe.Text;
                    obj.LugarResidencia = txtRecidencia.Text;
                    obj.FechaNacimiento = DateTime.Parse(txtFechaNaci.Text);
                    obj.Curriculum = flUpcurriculum.FileBytes;


                    string mensaje = NegocioOferente.InsertarOferente(obj);
                    MostrarMensaje(mensaje);
                }
                else
                {
                    obj.Identificacion = txtIdentificacion.Text;
                    obj.CodigoTipoIdentificacion = Convert.ToInt32(txtcodtipoid.Text);
                    obj.Nombre = txtNombreOfe.Text;
                    obj.Apellidos = txtApellidosOfe.Text;
                    obj.LugarResidencia = txtRecidencia.Text;
                    obj.FechaNacimiento = DateTime.Parse(txtFechaNaci.Text);
                    obj.Curriculum = flUpcurriculum.FileBytes;

                    string mensaje = NegocioOferente.EditarOferente(obj);
                    MostrarMensaje(mensaje);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
    }
}