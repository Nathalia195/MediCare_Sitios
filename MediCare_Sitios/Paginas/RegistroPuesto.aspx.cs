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
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        //NegocioGeneral obj_general = new NegocioGeneral();
        NegocioPuesto obj_Puesto = new NegocioPuesto();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void agregarPuesto_Click(object sender, EventArgs e)
        {
            //string script = "window.open('NuevoPuesto.aspx', 'Agregar Puesto', 'width=500,height=500');";
            //ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", script, true);
        }
    }
}