using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Paginas
{
    public partial class Archivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                if (((Persona)Session["Persona"]).TipoPersona.IdTipoPersona == 1)
                {   }
                else
                    Response.Redirect("~/Paginas/Error.aspx");
            }
            else
                Response.Redirect("~/Paginas/Error.aspx");
        }

        protected void lbCargarArchivo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/CargaArchivos.aspx");
        }

        protected void lbAsignarArchivo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/AsignarArchivoPersonas.aspx");
        }

        protected void lbListadoArchivos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ListaArchivos.aspx");
        }
    }
}