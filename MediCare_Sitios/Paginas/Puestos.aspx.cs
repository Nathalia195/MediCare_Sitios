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
        string url;
        protected void Page_Load(object sender, EventArgs e)
        {
         
                    List<EntidadPuesto> usuario = obj_Puesto.GetPuesto();

                    gvPuesto.DataSource = usuario;
                    gvPuesto.DataBind();

                    //List<EntidadEstado> estado = obj_estado.GetEstado();

                    //int i = 0;

                    //foreach (EntidadEstado c in estado)
                    //{
                    //    ddl_estado.Items.Insert(i, new ListItem(c.NombreEstado, c.CodigoEstado));
                    //    i += 1;
                    //}

                    //List<EntidadRol> rol = obj_rol.GetRol();

                    //i = 0;

                    //foreach (EntidadRol c in rol)
                    //{
                    //    ddl_rol.Items.Insert(i, new ListItem(c.NombreRol, c.CodigoRol));
                    //    i += 1;
                    //}

            
        }
        //private void MostrarMensaje(string mensaje)
        //{
        //    string message = mensaje;
        //    string url1 = "RegistroPuestos.aspx?MyVar=" + HttpUtility.UrlEncode(obj_general.Encrypt(url));
        //    string script = "{ alert('";
        //    script += message;
        //    script += "');";
        //    script += "window.location = '";
        //    script += url1;
        //    script += "'; }";
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
        //}
        protected void gv_puesto_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = gvPuesto.Rows[fila].Cells[0].Text;

            }
            else
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                string columna = gvPuesto.Rows[fila].Cells[0].Text;

                //LLAMAR FUNCION PARA ELIMINAR y pasar columna                

                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Hello World');", true);
            }
        }
    }
}