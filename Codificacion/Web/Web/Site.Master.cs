using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Persona"] != null)
            {
                if (((Entidades.Persona)Session["Persona"]).TipoPersona.Descripcion == "Alumno")
                {
                    lblUsr.Visible = true;
                    lblUsr.Text = "Bienvenido " + ((Entidades.Persona)Session["Persona"]).NombreUsuario;
                    //lblUsr.Text = Session["Latitud"].ToString() +" - "+ Session["Longitud"].ToString();
                    Sesion.Text = "Cerrar Sesión";
                    Menu.Visible = true;
                    Menu.Text = "Menú Alumno";
                }
                else if (((Entidades.Persona)Session["Persona"]).TipoPersona.Descripcion == "Administrador")
                {
                    lblUsr.Visible = true;
                    lblUsr.Text = "Bienvenido " + ((Entidades.Persona)Session["Persona"]).NombreUsuario;
                    //lblUsr.Text = Session["Latitud"].ToString() +" - "+Session["Longitud"].ToString();
                    Sesion.Text = "Cerrar Sesión";
                    Menu.Visible = true;
                    Menu.Text = "Menú Administrador";
                }
                else
                {
                    Sesion.Text = "Iniciar Sesión";
                    lblUsr.Visible = false;
                    Menu.Visible = false;
                }
            }
            else
            {
                Sesion.Text = "Iniciar Sesión";
                Menu.Visible = false;
                lblUsr.Visible = false;
            }            
        }

        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
        }

        protected void InicioSesion_Click(object sender, EventArgs e)
        {
            if(Sesion.Text=="Iniciar Sesión")
                Response.Redirect("~/Account/Login.aspx");
            else
            { 
                Session.Abandon();
                lblUsr.Visible = false;
                Response.Redirect("~/Default.aspx");
            }
        }        

        protected void Inicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void Menu_Click(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                if (((Entidades.Persona)Session["Persona"]).TipoPersona.Descripcion == "Alumno")
                {
                    Response.Redirect("~/Paginas/MenuAlumno.aspx");
                }
                else if (((Entidades.Persona)Session["Persona"]).TipoPersona.Descripcion == "Administrador")
                {
                    Response.Redirect("~/Paginas/MenuAdministrador.aspx");
                }
            }
        }
    }
}