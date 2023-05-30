using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace MediCare_Sitios
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        NegocioGeneral obj_general = new NegocioGeneral();
        string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string fullname = Session["fullname"].ToString();
            string rol = Session["rol"].ToString();

            Lbl_usuario.Text = username;


            imgURL.ImageUrl = "Paginas/MostrarImagen.aspx?id=" + Lbl_usuario.Text;


        }
        protected void Btn_usuario(object sender, EventArgs e)
        {
            Response.Redirect("MantUsuario.aspx");
        }

        protected void Btn_oferente(object sender, EventArgs e)
        {
            //Response.Redirect("MantenimientoUsuario.aspx?MyVar=" + HttpUtility.UrlEncode(obj_general.Encrypt("1," + Lbl_usuario.Text)));            
        }

        protected void Btn_puesto(object sender, EventArgs e)
        {
            Response.Redirect("Puestos.aspx");
        }

        protected void Btn_verificar(object sender, EventArgs e)
        {
            //Response.Redirect("MantenimientoUsuario.aspx?MyVar=" + HttpUtility.UrlEncode(obj_general.Encrypt("1," + Lbl_usuario.Text)));            
        }
    }
}