using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediCare_Sitios
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        NegocioGeneral obj_general = new NegocioGeneral();

        protected void Page_Load(object sender, EventArgs e)
        {
            string fullname = Session["fullname"].ToString();

            Lbl_Bienvenida.Text = "Bienvenido " + fullname;
        }
    }
}