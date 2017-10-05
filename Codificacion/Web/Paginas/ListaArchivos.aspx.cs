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

namespace Web.Paginas
{
    public partial class ListaArchivos : System.Web.UI.Page
    {
        List<Archivo> archivos;
        
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (Session["Persona"] != null)
            {
                if(((Persona)Session["Persona"]).TipoPersona.IdTipoPersona==1)
                {
                    archivos = new Negocio.Archivos().RecuperarTodos();
                    this.GenerarOrigenDeDatos(archivos);

                    if (!IsPostBack)
                    {
                        CargarComboBoxs();
                    }
                }
                else
                    Response.Redirect("~/Paginas/Error.aspx");
            }
            else
                Response.Redirect("~/Paginas/Error.aspx");
        }

        private void CargarComboBoxs()
        {
            this.comisiones.DataSource = new Negocio.Comisiones().RecuperarTodos();
            this.comisiones.DataValueField = "IdComision";
            this.comisiones.DataTextField = "DescripcionComision";
            this.comisiones.DataBind();
        }

        protected void GenerarOrigenDeDatos(List<Archivo> archivos)
        {
            GrillaArchivos.DataSource = archivos;
            GrillaArchivos.DataBind();
        }

        protected void GrillaArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GrillaArchivos.Visible = false;
            this.Label1.Visible = false;
            this.panelEdicion.Visible = true;
            this.btnNuevo.Visible = false;
            Archivo archActual = archivos[this.GrillaArchivos.SelectedRow.RowIndex];
            Session["archActual"] = archActual;
            Comision comActual = new Negocio.Comisiones().RecuperarUnoPorIDArchivo(archActual.IDArchivo);
            Session["comActual"] = comActual;
            this.comisiones.SelectedValue = comActual.IdComision.ToString();
            this.comisiones.Enabled = false;
            
            this.descripcion.Text = archActual.Descripcion;
            this.fecha.Text = archActual.FechaHoraInicio.ToString("yyyy-MM-dd");
            this.inicio.Text = archActual.FechaHoraInicio.ToString("HH:mm");
            this.fin.Text = archActual.FechaHoraFin.ToString("HH:mm");
            this.ip.Text = archActual.IP.ToString();
            this.rad.Text = archActual.Radio.ToString();
            this.Latitud.Text = archActual.CoordenadaLatitud.ToString().Replace(",",".");
            this.Longitud.Text = archActual.CoordenadaLongitud.ToString().Replace(",", ".");
            this.Radio.Text = archActual.Radio.ToString().Replace(",", ".");
        }
        
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ListaArchivos.aspx",false);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/CargaArchivos.aspx",false);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idComision = Convert.ToInt32(comisiones.SelectedValue);
            if (((Comision)Session["comActual"]).IdComision != idComision)
            {
                new Negocio.Archivos().ModificarArchivoComision(((Comision)Session["comActual"]).IdComision, ((Archivo)Session["archActual"]).IDArchivo, idComision);
            }
            Archivo archActual = (Archivo)Session["archActual"];
            DateTime hoy = DateTime.Now;
            archActual.FechaArchivo = new DateTime(hoy.Year, hoy.Month, hoy.Day, hoy.Hour, hoy.Minute, hoy.Second);
            if (string.IsNullOrEmpty(fecha.Text))
                fecha.Text = DateTime.Now.ToShortDateString();
            DateTime Fecha = Convert.ToDateTime(fecha.Text);
            DateTime FechaIni = Fecha;
            DateTime FechaFin = Fecha;
            if (string.IsNullOrEmpty(inicio.Text))
                inicio.Text = "00:00";
            if (string.IsNullOrEmpty(fin.Text))
                fin.Text = "00:00";
            archActual.FechaHoraInicio = FechaIni.Add(TimeSpan.Parse(inicio.Text));
            archActual.FechaHoraFin = FechaFin.Add(TimeSpan.Parse(fin.Text));
            if (string.IsNullOrEmpty(ip.Text))
                ip.Text = "0.0.0.0";
            archActual.IP = ip.Text;
            if(!string.IsNullOrEmpty(Latitud.Text))
                archActual.CoordenadaLatitud = Convert.ToDouble(Latitud.Text.Replace(",", "."));
            if (!string.IsNullOrEmpty(Longitud.Text))
                archActual.CoordenadaLongitud = Convert.ToDouble(Longitud.Text.Replace(",", "."));
            if (string.IsNullOrEmpty(Radio.Text))
                Radio.Text = "0";
            archActual.Radio = Convert.ToDouble(Radio.Text);
            archActual.Descripcion = descripcion.Text;
            new Negocio.Archivos().Modificar(archActual);
            this.panelEdicion.Visible = false;
            this.GrillaArchivos.Visible = true;
            this.Label1.Visible = true;
            this.btnNuevo.Visible = true;
            Session.Remove("archActual");
            Session.Remove("comActual");
            Response.Write("<script>alert('Archivo editado correctamente correctamente.');</script>");
            Response.Write("<script>window.location='ListaArchivos.aspx';</script>");
        }

        protected void btnElminar_Click(object sender, EventArgs e)
        {
            new Negocio.Archivos().Borrar(((Archivo)Session["archActual"]).IDArchivo);
            Response.Redirect("~/Paginas/ListaArchivos.aspx",false);
        }
    }
}