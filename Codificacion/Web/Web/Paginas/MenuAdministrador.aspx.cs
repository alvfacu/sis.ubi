using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Web.Paginas
{
    public partial class MenuAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                if (((Persona)Session["Persona"]).TipoPersona.IdTipoPersona == 1)
                { }
                else
                    Response.Redirect("~/Paginas/Error.aspx");
            }
            else
                Response.Redirect("~/Paginas/Error.aspx");
        }

        protected void lbAgregarPersona_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Alumnos.aspx");
        }

        protected void btnArchivos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Archivos.aspx");
        }

        protected void btnMaterias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ABMMaterias.aspx");
        }

        protected void btnComisiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ABMComisiones.aspx");
        }
        
    }
}