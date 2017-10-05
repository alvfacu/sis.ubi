using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Web.Paginas
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Persona"] == null) && (Session["Alumno"] == null))
            {
               LblError.Text = "NO TIENE PERMISOS PARA ACCEDER"; 
            }
            else
            {
                if (Session["Persona"] == null)
                {
                    LblError.Text = "NO TIENE PERMISOS COMO ADMINISTRADOR";
                }

                if (Session["Alumno"] == null)
                {
                    LblError.Text = "NO TIENE PERMISOS COMO ALUMNO";
                }
            }
        }
    }
}