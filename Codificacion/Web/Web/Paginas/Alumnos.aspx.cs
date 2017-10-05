using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Web.Paginas
{
    public partial class AgregarPersonas : System.Web.UI.Page
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

        protected void lbImportarPersonas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ImportarPersonas.aspx");
        }

        protected void lbAgregarPersona_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/FormularioPersona.aspx");
        }       

        protected void lbAlumnosComision_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ListaAlumnos.aspx");
        }

        protected void lbListadoPersonas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ListaInscripciones.aspx");
        }
    }
}