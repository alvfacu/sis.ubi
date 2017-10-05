using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Web.Paginas
{
    public partial class Menu : System.Web.UI.Page
    {
        Persona per;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                per = (Persona)Session["Persona"];
            }
            else
            {
                Response.Redirect("~/Paginas/Error.aspx");
            }
        }

        protected void lblVerArchivos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ListaArchivosAlumnos.aspx");
        }

        protected void lblNotas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ListaNotas.aspx");
        }

        protected void lblModificarDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Paginas/FormularioPersona.aspx?IdPersona={0}", per.Id));
        }
    }
}