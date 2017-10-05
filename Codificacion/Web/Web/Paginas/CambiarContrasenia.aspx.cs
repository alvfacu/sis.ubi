using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using Datos;
using System.Globalization;

namespace Web.Paginas
{
    public partial class CambiarContrasenia : System.Web.UI.Page
    {
        int IdPs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
                if (((Persona)Session["Persona"]).TipoPersona.IdTipoPersona == 1 || ((Persona)Session["Persona"]).Id == Convert.ToInt32(Request.QueryString["IdPersona"]))
                    IdPs = Convert.ToInt32(Request.QueryString["IdPersona"]);
                else
                    Response.Redirect("~/Paginas/Error.aspx");
            else
                Response.Redirect("~/Paginas/Error.aspx");
        }

        protected void btnGuardarPassNueva_Click(object sender, EventArgs e)
        {
            if (IdPs != 0)
            {
                ListadoPersonas per = new Negocio.Personas().RecuperarUno(IdPs);

                if (per.Count != 0)
                {
                    string vieja = Seguridad.MD5Hash(passvieja.Value);
                    if (string.Compare(vieja, per[0].Contraseña) == 0)
                    {
                        per[0].Contraseña = Seguridad.MD5Hash(passnueva.Value);
                        new Negocio.Personas().Modificar(per[0]);
                        Response.Write("<script>alert('Contraseña modificada correctamente.');</script>");
                        Response.Redirect(String.Format("~/Paginas/FormularioPersona.aspx?IdPersona={0}", IdPs),false);
                    }
                    else
                    {
                        Response.Write("<script>alert('No es posible cambiar la contraseña. La contraseña antigua es incorrecta.');</script>");
                        return;
                    }
                }
            }                
        }
    }
}