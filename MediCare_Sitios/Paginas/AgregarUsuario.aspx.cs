using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediCare_Sitios
{
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        NegocioUsuario NegocioUsuario = new NegocioUsuario();
        NegocioEstado neg = new NegocioEstado();
        NegocioRol roles = new NegocioRol();

        EntidadUsuario obj = new EntidadUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["llave"] != null)
            {
                string llaves = Session["llave"].ToString();
                txtNombreUsuario.Text = llaves;
            }

            List<EntidadEstado> estado = neg.GetEstado();

            int i = 0;
            foreach (EntidadEstado c in estado)
            {
                txtCodigoEstado.Items.Insert(i, new ListItem(c.NombreEstado, c.CodigoEstado));
                i += 1;
            }


            List<EntidadRol> rol = roles.GetRol();
            i = 0;
            foreach (EntidadRol c in rol)
            {
                txtCodigoRol.Items.Insert(i, new ListItem(c.NombreRol, c.CodigoRol));
                i += 1;
            }
        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {

            try
            {
                obj.NombreUsuario = txtNombreUsuario.Text;
                obj.NombreCompleto = txtNombreCompleto.Text;
                obj.CorreoElectronico = txtCorreoElectronico.Text;
                obj.Contrasena = txtlContrasena.Text;
                obj.Imagen = FileUpload1.FileBytes;
                obj.CodigoRol = txtCodigoRol.SelectedValue;
                obj.CodigoEstado = txtCodigoEstado.SelectedValue;



                string mensaje = NegocioUsuario.InsertarUsuarios(obj);
                MostrarMensaje(mensaje);

                //limpiarForm();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }

        }


        private void MostrarMensaje(string mensaje)
        {
            string message = mensaje;
            string url = "MantUsuario.aspx";
            string script = "{ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        }

        protected void txtCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantUsuario.aspx");
        }
    }
}