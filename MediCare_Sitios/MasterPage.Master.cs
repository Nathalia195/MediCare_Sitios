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
            string myVar = obj_general.Decrypt(HttpUtility.UrlDecode(Request.QueryString["MyVar"]));
            //myVar.Split(',')[0]; NombreUsuario
            //myVar.Split(',')[1]; NombreCompleto
            //myVar.Split(',')[2]; Rol
            //myVar.Split(',')[3]; Validación que viene de login

            if (myVar.Split(',')[0] == "1") Lbl_usuario.Text = myVar.Split(',')[1]; else Lbl_usuario.Text = myVar.Split(',')[0];

            url = myVar;

            imgURL.ImageUrl = "Paginas/MostrarImagen.aspx?id=" + Lbl_usuario.Text;
        }
        protected void Btn_usuario(object sender, EventArgs e)
        {
            Response.Redirect("MantUsuario.aspx?MyVar=" + HttpUtility.UrlEncode(obj_general.Encrypt(url)));
        }

        protected void Btn_oferente(object sender, EventArgs e)
        {
            //Response.Redirect("MantenimientoUsuario.aspx?MyVar=" + HttpUtility.UrlEncode(obj_general.Encrypt("1," + Lbl_usuario.Text)));            
        }

        protected void Btn_puesto(object sender, EventArgs e)
        {
            Response.Redirect("Puesto.aspx?MyVar=" + HttpUtility.UrlEncode(obj_general.Encrypt("1," + Lbl_usuario.Text)));
        }

        protected void Btn_verificar(object sender, EventArgs e)
        {
            //Response.Redirect("MantenimientoUsuario.aspx?MyVar=" + HttpUtility.UrlEncode(obj_general.Encrypt("1," + Lbl_usuario.Text)));            
        }
    }
}