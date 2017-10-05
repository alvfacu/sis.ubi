using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;

namespace Web.Account
{
    public partial class Login : Page
    {
        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Negocio.Personas pers = new Negocio.Personas();
            Entidades.Persona per = new Entidades.Persona();
            string latitud = "", longitud = "", externalip = "";

            try
            {
                //string ip = GetVisitorIPAddress();
                per = pers.Autenticar(LoginUser.UserName, LoginUser.Password)[0];
                Entidades.ListadoUsuarioLogins uls = new Datos.UsuarioLogins().RecuperarUsuarioLoginsActivos();
                foreach (Entidades.UsuarioLogin usrl in uls)
                {
                    if (per.Id == usrl._ID_Persona)
                    {
                        continue;
                        //LoginUser.FailureText = "El usuario ya se encuentra logueado";
                        //return;
                    }
                }

                latitud = Latitud.Value.ToString();
                longitud = Longitud.Value.ToString();
                
                //externalip = new WebClient().DownloadString("http://icanhazip.com");
                //externalip = externalip.Replace("\n", "");

                //externalip += "-";

                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    externalip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
                {
                    externalip = HttpContext.Current.Request.UserHostAddress;
                }
               
                Entidades.UsuarioLogin usr = new Entidades.UsuarioLogin();
                usr._ID_Persona = per.Id;
                usr._IP = externalip;
                usr._Fecha_Login = System.DateTime.Now;

                new Negocio.UsuarioLogins().Agregar(usr);
            }
            catch (Exception)
            {
                per = null;
            }

            if (per != null)
            {
                Session["Latitud"] = latitud;
                Session["Longitud"] = longitud;
                Session["IP"] = externalip;                

                if (per.TipoPersona.Descripcion == "Alumno")
                {
                    FormsAuthentication.SetAuthCookie(LoginUser.UserName, true);
                    Session["Persona"] = per;
                    Session.Timeout = 10;
                    Response.Redirect(String.Format("~/Paginas/MenuAlumno.aspx"));
                }
                else
                {
                    if (per.TipoPersona.Descripcion == "Administrador")
                    {
                        FormsAuthentication.SetAuthCookie(LoginUser.UserName, true);
                        Session["Persona"] = per;
                        Session.Timeout = 10;
                        Response.Redirect(String.Format("~/Paginas/MenuAdministrador.aspx"));
                    }
                    else
                    {
                        LoginUser.FailureText = "Ud no tiene permisos";
                    }
                }
            }
        }
        
        public static string GetVisitorIPAddress(bool GetLan = false)
        {
            string visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (String.IsNullOrEmpty(visitorIPAddress))
            {
                string visitorIPAddress1 = HttpContext.Current.Request.UserHostAddress;

                string visitorIPAddress2 = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                string visitorIPAddress3 = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
            }
            if (string.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
            {
                GetLan = true;
                visitorIPAddress = string.Empty;
            }

            if (GetLan && string.IsNullOrEmpty(visitorIPAddress))
            {
                //This is for Local(LAN) Connected ID Address
                string stringHostName = Dns.GetHostName();
                //Get Ip Host Entry
                IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
                //Get Ip Address From The Ip Host Entry Address List
                IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                try
                {
                    visitorIPAddress = arrIpAddress[arrIpAddress.Length - 1].ToString();
                }
                catch
                {
                    try
                    {
                        visitorIPAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            arrIpAddress = Dns.GetHostAddresses(stringHostName);
                            visitorIPAddress = arrIpAddress[1].ToString();
                        }
                        catch
                        {
                            visitorIPAddress = "127.0.0.1";
                        }
                    }
                }

            }


            return visitorIPAddress;
        }
        
        //Dim strHostName As String = Dns.GetHostName()  
        //Dim ipEntry As IPHostEntry = Dns.GetHostEntry(strHostName)  

        //lblIPAddress.Text = Convert.ToString(ipEntry.AddressList(ipEntry.AddressList.Length - 1))  
        //lblHostName.Text = Convert.ToString(ipEntry.HostName)  

        //'Find IP Address Behind Proxy Or Client Machine In ASP.NET  
        //Dim IPAdd As String = String.Empty  
        //IPAdd = Request.ServerVariables("HTTP_X_FORWARDED_FOR")  

        //If String.IsNullOrEmpty(IPAdd) Then  
        //IPAdd = Request.ServerVariables("REMOTE_ADDR")  
        //lblIPBehindProxy.Text = IPAdd  
    }
}