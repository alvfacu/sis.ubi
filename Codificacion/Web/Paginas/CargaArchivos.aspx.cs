using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entidades;
using Subgurim.Controles;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using System.Device.Location;
using System.Web.Security;
using Datos;
using System.Net;
using System.Net.NetworkInformation;

namespace Web.Paginas
{
    public partial class CargaArchivos : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                if(((Persona)Session["Persona"]).TipoPersona.IdTipoPersona == 1)
                {
                    //Session.Timeout = 10;
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
            this.comisiones.Items.Insert(0, new ListItem("Elija una Comisión..", "0"));
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            // 
            // CODEGEN: El Diseñador de formularios Web Forms ASP.NET requiere esta llamada.
            // 
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Método requerido para la compatibilidad del Diseñador - no modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            //this.Submit1.ServerClick += new System.EventHandler(this.btnSubir_ServerClick);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        protected void btnSubir_Click(object sender, System.EventArgs e)
        {
            Boolean fileOK = false;
            string latitud = Latitud.Text.Replace(",", ".");
            string longitud = Longitud.Text.Replace(",", ".");
            if (string.IsNullOrEmpty(latitud))
            {
                latitud = "0";
                longitud = "0";
            }
            double latA = Convert.ToDouble(latitud);
            double longA = Convert.ToDouble(longitud);

            if (string.IsNullOrEmpty(Radio.Text))
                Radio.Text = "0";
            double radio = Convert.ToDouble(Radio.Text);

            //string externalip = new WebClient().DownloadString("http://l2.io/ip.js?var=myp");
            //externalip = externalip.Split('"', '"')[1];
            //Session["IP"] = externalip;
            //ip.Text = Session["IP"].ToString();

            String path = Server.MapPath("Archivos/");

            if (Sube.Text.CompareTo("A") == 0)
            {
                String fileExtension = "";
                if (FileUpload1.HasFile)
                {
                    fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    String[] allowedExtensions = { ".doc", ".xls", ".docx", ".xlsx", ".pdf", ".txt", ".ppt", ".pptx" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                            break;
                        }
                    }
                }
            }

            try
            {
                if (Convert.ToInt32(comisiones.SelectedValue) != 0)
                {
                    Archivo archivo = new Archivo();
                    switch (Sube.Text)
                    {
                        case "A":
                            {
                                if (fileOK)
                                {
                                    FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                                    archivo.NombreArchivo = FileUpload1.FileName;
                                    archivo.UbicacionArchivo = path;
                                    int idComision = Convert.ToInt32(comisiones.SelectedValue);
                                    DateTime hoy = DateTime.Now;
                                    archivo.FechaArchivo = new DateTime(hoy.Year, hoy.Month, hoy.Day, hoy.Hour, hoy.Minute, hoy.Second);
                                    if (string.IsNullOrEmpty(fecha.Text))
                                        fecha.Text = DateTime.Now.ToShortDateString();
                                    DateTime Fecha = Convert.ToDateTime(fecha.Text);
                                    DateTime FechaIni = Fecha;
                                    DateTime FechaFin = Fecha;
                                    if (string.IsNullOrEmpty(inicio.Text))
                                        inicio.Text = "00:00";
                                    if (string.IsNullOrEmpty(fin.Text))
                                        fin.Text = "00:00";
                                    archivo.FechaHoraInicio = FechaIni.Add(TimeSpan.Parse(inicio.Text));
                                    archivo.FechaHoraFin = FechaFin.Add(TimeSpan.Parse(fin.Text));
                                    if (string.IsNullOrEmpty(ip.Text))
                                        ip.Text = "0.0.0.0";
                                    archivo.IP = ip.Text;
                                    archivo.CoordenadaLatitud = latA;
                                    archivo.CoordenadaLongitud = longA;
                                    archivo.Radio = radio;
                                    archivo.Descripcion = descripcion.Text;
                                    archivo.IDTipo = 1;
                                    new Negocio.Archivos().Agregar(archivo);
                                    int idArchivo = new Negocio.Archivos().DameUltId();
                                    new Negocio.Archivos().AgregarArchivoComision(idComision, idArchivo);
                                }
                                break;
                            }
                        case "P":
                            {
                                archivo.NombreArchivo = pagina.Text;
                                archivo.UbicacionArchivo = pagina.Text;
                                int idComision = Convert.ToInt32(comisiones.SelectedValue);
                                DateTime hoy = DateTime.Now;
                                archivo.FechaArchivo = new DateTime(hoy.Year, hoy.Month, hoy.Day, hoy.Hour, hoy.Minute, hoy.Second);
                                if (string.IsNullOrEmpty(fecha.Text))
                                    fecha.Text = DateTime.Now.ToShortDateString();
                                DateTime Fecha = Convert.ToDateTime(fecha.Text);
                                DateTime FechaIni = Fecha;
                                DateTime FechaFin = Fecha;
                                if (string.IsNullOrEmpty(inicio.Text))
                                    inicio.Text = "00:00";
                                if (string.IsNullOrEmpty(fin.Text))
                                    fin.Text = "00:00";
                                archivo.FechaHoraInicio = FechaIni.Add(TimeSpan.Parse(inicio.Text));
                                archivo.FechaHoraFin = FechaFin.Add(TimeSpan.Parse(fin.Text));
                                if (string.IsNullOrEmpty(ip.Text))
                                    ip.Text = "0.0.0.0";
                                archivo.IP = ip.Text;
                                archivo.CoordenadaLatitud = latA;
                                archivo.CoordenadaLongitud = longA;
                                archivo.Radio = radio;
                                archivo.Descripcion = descripcion.Text;
                                archivo.IDTipo = 2;
                                new Negocio.Archivos().Agregar(archivo);
                                int idArchivo = new Negocio.Archivos().DameUltId();
                                new Negocio.Archivos().AgregarArchivoComision(idComision, idArchivo);
                                fileOK = true;
                                break;
                            }
                        case "E":
                            {
                                //ENCRIPTAR RUTA
                                FileUpload2.PostedFile.SaveAs(path + FileUpload2.FileName);
                                archivo.NombreArchivo = FileUpload2.FileName;
                                archivo.UbicacionArchivo = Seguridad.Encriptar(path + FileUpload2.FileName);
                                int idComision = Convert.ToInt32(comisiones.SelectedValue);
                                DateTime hoy = DateTime.Now;
                                if (string.IsNullOrEmpty(fecha.Text))
                                    fecha.Text = DateTime.Now.ToShortDateString();
                                DateTime Fecha = Convert.ToDateTime(fecha.Text);
                                DateTime FechaIni = Fecha;
                                DateTime FechaFin = Fecha;
                                if (string.IsNullOrEmpty(inicio.Text))
                                    inicio.Text = "00:00";
                                if (string.IsNullOrEmpty(fin.Text))
                                    fin.Text = "00:00";
                                archivo.FechaHoraInicio = FechaIni.Add(TimeSpan.Parse(inicio.Text));
                                archivo.FechaHoraFin = FechaFin.Add(TimeSpan.Parse(fin.Text));
                                if (string.IsNullOrEmpty(ip.Text))
                                    ip.Text = "0.0.0.0";
                                archivo.IP = ip.Text;
                                archivo.CoordenadaLatitud = latA;
                                archivo.CoordenadaLongitud = longA;
                                archivo.Radio = radio;
                                archivo.Descripcion = descripcion.Text;
                                archivo.IDTipo = 3;
                                new Negocio.Archivos().Agregar(archivo);
                                int idArchivo = new Negocio.Archivos().DameUltId();
                                new Negocio.Archivos().AgregarArchivoComision(idComision, idArchivo);
                                fileOK = true;
                                break;
                            }
                    }
                    if (fileOK)
                    {
                        Response.Write("<script>alert('Carga correcta.');</script>");
                        Response.Write("<script>window.location='ListaArchivos.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('¡Carga Incorrecta! La extensión del documento seleccionado es incorrecta');</script>");
                        Response.Write("<script>window.location='CargaArchivos.aspx';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('¡Carga Incorrecta! Seleccione una comisión');</script>");
                    Response.Write("<script>window.location='CargaArchivos.aspx';</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('¡Carga Incorrecta! No ha seleccionado ningún documento para cargar');</script>");
                Response.Write("<script>window.location='CargaArchivos.aspx';</script>");
            }
        }

        private void LimpiarControles()
        {
            descripcion.Text = "";
            fecha.Text = "";
            inicio.Text = "";
            fin.Text = "";
            ip.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Archivos.aspx");
        }
        

        /*
        protected void bt_Buscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_Buscar.Text))
            {
                string key = ConfigurationManager.AppSettings.Get("googlemaps.subgurim.net");

                //Response.Write(GMap.geoCodeRequest(tb_Buscar.Text, Key, GeoCode.outputEnum.json));
                //return;

                GeoCode geocode = GMap.geoCodeRequest(tb_Buscar.Text, key); //, new GLatLngBounds(new GLatLng(40, 10), new GLatLng(50, 20)));

                //GMap gMap1 = new GMap();
                GMap1.getGeoCodeRequest(tb_Buscar.Text, new GLatLngBounds(new GLatLng(40, 10), new GLatLng(50, 20)));
                AddMarker(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);

                ReinicarMapa(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);

                StringBuilder sb = new StringBuilder();

                if ((null != geocode) && geocode.valid)
                {
                    /*sb.Append("<ul>");
                    sb.AppendFormat("<li><i>geocode.name</i>:{0}</li>", geocode.name);
                    sb.AppendFormat("<li><i>geocode.Status.code</i>:{0}</li>", geocode.Status.code);
                    sb.AppendFormat("<li><i>geocode.Status.request</i>:{0}</li>", geocode.Status.request);
                    sb.AppendFormat("<li><i>geocode.Placemark.address</i>:{0}</li>", geocode.Placemark.address);
                    sb.AppendFormat("<li><i>geocode.Placemark.AddressDetails.accuracy</i>:{0}</li>", geocode.Placemark.AddressDetails.accuracy);
                    sb.AppendFormat("<li><i>geocode.Placemark.AddressDetails.Country.CountryNameCode</i>:{0}</li>",
                        geocode.Placemark.AddressDetails.Country.CountryNameCode);
                    sb.AppendFormat("<li><i>geocode.Placemark.AddressDetails.Country.AdministrativeArea.AdministrativeAreaName</i>:{0}</li>",
                       geocode.Placemark.AddressDetails.Country.AdministrativeArea.AdministrativeAreaName);
                    sb.AppendFormat("<li><i>geocode.Placemark.AddressDetails.Country.AdministrativeArea.SubAdministrativeArea.SubAdministrativeAreaName</i>:{0}</li>",
                        geocode.Placemark.AddressDetails.Country.AdministrativeArea.SubAdministrativeArea.SubAdministrativeAreaName);
                    sb.AppendFormat("<li><i>geocode.Placemark.AddressDetails.Country.AdministrativeArea.SubAdministrativeArea.Locality.LocalityName</i>:{0}</li>",
                       geocode.Placemark.AddressDetails.Country.AdministrativeArea.SubAdministrativeArea.Locality.LocalityName);
                    sb.AppendFormat("<li><i>geocode.Placemark.AddressDetails.Country.AdministrativeArea.SubAdministrativeArea.Locality.PostalCode.PostalCodeNumber</i>:{0}</li>",
                        geocode.Placemark.AddressDetails.Country.AdministrativeArea.SubAdministrativeArea.Locality.PostalCode.PostalCodeNumber);
                    sb.AppendFormat("<li><i>geocode.Placemark.AddressDetails.Country.AdministrativeArea.SubAdministrativeArea.Locality.Thoroughfare.ThoroughfareName</i>:{0}</li>",
                        geocode.Placemark.AddressDetails.Country.AdministrativeArea.SubAdministrativeArea.Locality.Thoroughfare.ThoroughfareName);
                    sb.AppendFormat("<li><i>geocode.Placemark.coordinates</i>:{0}</li>", geocode.Placemark.coordinates);
                    sb.Append("</ul>");
                }
                else
                {
                    sb.Append("Locations not found");
                }

                //lb_Buscar.Text = sb.ToString();
            }
        }

        private void AddMarker(Double dLat, Double dLong)
        {
            try
            {
	            GLatLng gLatLng = new GLatLng(dLat, dLong);
                Session["coordenada"] = gLatLng;
	            GMarkerOptions oOption = new GMarkerOptions();
	            oOption.draggable = true;

                GMap1.resetMarkers();
	            GMap1.resetListeners();
	            GMarker oMarker = new GMarker(gLatLng, oOption);

	            GMap1.Add(oMarker);
                //GMap1.addListener(new Subgurim.Controles.GListener(oMarker.ID, Subgurim.Controles.GListener.Event.dragend, "function(){ document.getElementById(‘hidLat’).value=” & oMarker.ID & “.getPoint().lat();document.getElementById(‘hidLng’).value=” & oMarker.ID & “.getPoint().lng() }"));
            }
            catch (Exception ex)
            {
	            Msg(ex.Message);
            }
        }

        private void Msg(String sText)
        {
	        Response.Write("<script type=’text/javascript’>alert(‘” & sText & “‘);</script>");
        }
        
        protected string GMap1_Click(object s, GAjaxServerEventArgs e)
        {
            GMarker marker = new GMarker(e.point);
            AddMarker(marker.point.lat, marker.point.lng);

            GeoCode objAddress = new GeoCode();
            objAddress = GMap1.getGeoCodeRequest(new GLatLng(marker.point.lat, marker.point.lng));

            GInfoWindow window;

            ReinicarMapa(marker.point.lat, marker.point.lng);

            if (objAddress.valid)
            {
                window = new GInfoWindow(marker,
                                     string.Format(@"<b>{0}</b>",objAddress.Placemark.address),true);
            }
            else
            {
                window = new GInfoWindow(marker,
                                                 string.Format(
                                                     @"<b>Ultimas coordenadas: </b><br />SW = {0}<br/>NE = {1}",
                                                     e.bounds.getSouthWest(),
                                                     e.bounds.getNorthEast()),
                                                 true);
            }

            return window.ToString(e.map);
        }        

        private void clearMarkers()
        {
            GMap1.resetInfoWindows(); // .resetGInfoWindows();
        }*/

    }
}