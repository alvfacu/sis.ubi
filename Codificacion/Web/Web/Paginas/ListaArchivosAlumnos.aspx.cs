using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Web.Security;
using System.Globalization;
using Datos;
using System.Net;
using System.Net.NetworkInformation;

namespace Web.Paginas
{
    public partial class ListaArchivosAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {              
            if (Session["Persona"] != null)
            {
                if (!IsPostBack)
                {
                    CargarComboBoxs();
                }
            }
        }

        private void CargarComboBoxs()
        {
            this.opciones.Items.Insert(0, new ListItem("Elija una opción..", "0"));
            this.opciones.Items.Insert(1, new ListItem("Archivos", "1"));
            this.opciones.Items.Insert(2, new ListItem("Páginas", "2"));
            this.opciones.Items.Insert(3, new ListItem("Parciales", "3"));
            this.opciones.Items.Insert(4, new ListItem("Todo", "4"));
        }
        
        protected void opciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GrillaArchivos.Visible = false;
            int idPersona = ((Persona)Session["Persona"]).Id;
            string IP = Session["IP"].ToString();

            //double Latitud = Convert.ToDouble(Session["Latitud"].ToString());
            //double Longitud = Convert.ToDouble(Session["Longitud"].ToString());
            //Response.Write("<script>alert(" + Latitud+" - " + Longitud +".');</script>");

            /*if (!(Latitud.ToString().Contains(",") || Latitud.ToString().Contains(".")))
            {
                string lati = Convert.ToString(Latitud).Substring(0, 3)+","+Convert.ToString(Latitud).Substring(3);
                Latitud = Convert.ToDouble(lati);
            }

            if (!(Longitud.ToString().Contains(",") || Longitud.ToString().Contains(".")))
            {
                string longi = Convert.ToString(Longitud).Substring(0, 3) + "," + Convert.ToString(Longitud).Substring(3);
                Longitud = Convert.ToDouble(longi);
            }
            Response.Write("<script>alert(" + Latitud + " - " + Longitud + ".');</script>");*/

            /*string externalip = new WebClient().DownloadString("http://l2.io/ip.js?var=myp");
            externalip = externalip.Split('"', '"')[1];
            Session["IP"] = externalip;            

            Response.Write("<script>alert('" + DateTime.Now + " - " + externalip + ".');</script>");
            Response.Write("<script>window.location='ListaArchivos.aspx';</script>");*/

            DateTime Ahora = DateTime.Now.AddHours(4);

            Entidades.ListadoArchivos archivos;

            if (Convert.ToInt32(this.opciones.SelectedIndex) == 4)
            {
                archivos = new Negocio.Archivos().RecuperarTodosPorAlumno(idPersona, 0, 0, IP, Ahora);
            }
            else if (Convert.ToInt32(this.opciones.SelectedIndex) != 0)
            {
                archivos = new Negocio.Archivos().RecuperarTodosPorAlumnoPorTipo(Convert.ToInt32(this.opciones.SelectedIndex), idPersona, 0, 0, IP, Ahora);
            }
            else
            {
                archivos = null;
            }

            if (archivos != null && archivos.Count() != 0)
            {
                Session["archivos"] = archivos;
                this.GrillaArchivos.DataSource = archivos;
                this.GrillaArchivos.DataBind();
                this.GrillaArchivos.Visible = true;
            }
            else
            {               
                string msj = "";
                switch((Convert.ToInt32(this.opciones.SelectedIndex)))
                {                    
                    case 2: msj = "Páginas"; break;
                    case 3: msj = "Parciales"; break;
                    case 1: 
                    case 4: msj = "Archivos"; break;
                }
                Response.Write("<script>alert('No tiene "+msj+" asignados.');</script>");
            }
        }

        protected void GrillaArchivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Entidades.ListadoArchivos archivos = (Entidades.ListadoArchivos)Session["archivos"];

                //VALIDAR
                if (archivos.Count() != 0)
                {
                    Archivo archActual = archivos[Convert.ToInt32(e.CommandArgument)];
                    if (archActual.IDTipo != 2)
                    {
                        string url = "Archivos/" + archActual.NombreArchivo + "";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "javascript:window.open('" + url + "', '_blank', 'height=700px,width=700px,scrollbars=1'); ", true);
                    }
                    else
                    {
                        string url = archActual.NombreArchivo;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "javascript:window.open('"+url+"', '_blank', 'height=600px,width=600px,scrollbars=1'); ", true);
                    }
                    
                }
                
            }
        }
    }
}