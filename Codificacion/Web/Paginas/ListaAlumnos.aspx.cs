using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Web.Paginas
{
    public partial class AsignarComisionAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                if(((Persona)Session["Persona"]).TipoPersona.IdTipoPersona==1)
                {

                    if (!IsPostBack)
                    { 
                        CargarComboBoxs();

                        if (Request.QueryString.Count != 0 && Request.QueryString["IdComision"].ToString() != "0")
                        {
                            this.comisiones.SelectedValue = Request.QueryString["IdComision"].ToString();
                            GenerarOrigenDeDatos(new Negocio.Personas().RecuperarTodosXComision(Request.QueryString["IdComision"]));
                        }
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

        protected void comisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Redirect(String.Format("~/Paginas/ListaAlumnos.aspx?IdComision={0}", this.comisiones.SelectedValue.ToString()));
            GenerarOrigenDeDatos(new Negocio.Personas().RecuperarTodosXComision(this.comisiones.SelectedValue.ToString()));
            Response.Redirect(String.Format("~/Paginas/ListaAlumnos.aspx?IdComision={0}", Convert.ToInt32(comisiones.SelectedValue)));
        }

        protected void tipopersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrillaPersonas.DataSource = null;
            GrillaPersonas.DataBind();
            ListadoPersonas personas = new ListadoPersonas();           
            this.GenerarOrigenDeDatos(personas);
        }

        protected void GenerarOrigenDeDatos(ListadoPersonas personas)
        {
            GrillaPersonas.DataSource = null;
            GrillaPersonas.DataBind();

            foreach (Persona ps in personas)
            {
                ps.Nombre = ps.Apellido + ", " + ps.Nombre;
            }

            List<Persona> pers = personas.OrderBy(p => p.Nombre).ToList();
                        
            GrillaPersonas.DataSource = pers;
            GrillaPersonas.DataBind();
        }

        protected void GrillaPersonas_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int IdPersona = Convert.ToInt32(this.GrillaPersonas.DataKeys[this.GrillaPersonas.SelectedRow.RowIndex].Value.ToString());
            Session["IdCom"] = comisiones.SelectedValue.ToString();
            Response.Redirect(String.Format("~/Paginas/FormularioPersona.aspx?IdPersona={0}", IdPersona));
        }
    }
}