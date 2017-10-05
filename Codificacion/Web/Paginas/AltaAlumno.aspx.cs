using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Entidades;

namespace Web.Paginas
{
    public partial class AltaAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                Persona persona = new Persona();
                persona = (Persona)Session["Persona"];
                //Session.Timeout = 10;

            }
            else
            {
                Response.Redirect("~/Paginas/Error.aspx");
            }
        }
    }
}