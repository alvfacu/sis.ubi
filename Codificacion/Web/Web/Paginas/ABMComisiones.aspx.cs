using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Paginas
{
    public partial class ABMComisiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                if(((Persona)Session["Persona"]).TipoPersona.IdTipoPersona==1)
                {
                    Persona persona = new Persona();
                    persona = (Persona)Session["Persona"];

                    //Session.Timeout = 10;
                    if (!IsPostBack)
                    {
                        CargarComboBoxs();
                        this.btnNuevaComision.Visible = false;

                        int IdMat = Convert.ToInt32(Request.QueryString["IdMateria"]);
                        if (IdMat != 0)
                        {
                            Session["idmateria"] = Convert.ToInt32(IdMat);
                            Session["comisiones"] = new Negocio.Comisiones().RecuperarPorIdMateria(Convert.ToInt32(IdMat));
                            this.materias.SelectedValue = IdMat.ToString();
                            this.GrillaComisiones.DataSource = new Negocio.Comisiones().RecuperarPorIdMateria(Convert.ToInt32(IdMat));
                            this.GrillaComisiones.DataBind();
                            this.btnNuevaComision.Visible = true;
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
            this.materias.DataSource = new Negocio.Materias().RecuperarTodos();
            this.materias.DataValueField = "IdMateria";
            this.materias.DataTextField = "DescripcionMateria";
            this.materias.DataBind();
            this.materias.Items.Insert(0, new ListItem("Seleccione una materia...", "0"));

        }

        protected void materias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idmateria"] = Convert.ToInt32(materias.SelectedValue);
            Session["comisiones"] = new Negocio.Comisiones().RecuperarPorIdMateria(Convert.ToInt32(materias.SelectedValue));
            this.GrillaComisiones.DataSource = new Negocio.Comisiones().RecuperarPorIdMateria(Convert.ToInt32(materias.SelectedValue));
            Response.Redirect(String.Format("~/Paginas/ABMComisiones.aspx?IdMateria={0}", Convert.ToInt32(materias.SelectedValue)));
            this.GrillaComisiones.DataBind();
            this.btnNuevaComision.Visible = true;
        }

        protected void btnAgregarComision_Click(object sender, EventArgs e)
        {            
            if (this.btnAgregarComision.Text == "Guardar cambios")
            {
                Comision comActual = (Comision)Session["comision"];
                comActual.DescripcionComision = this.nombreComisionNueva.Text;
                comActual.Anio = Convert.ToInt32(this.txtAnio.Text);                
                new Negocio.Comisiones().Modificar(comActual);
                this.btnAgregarComision.Text = "Agregar";
            }
            else
            {
                Comision nvComision = new Comision();
                nvComision.DescripcionComision = this.nombreComisionNueva.Text;
                nvComision.Anio = Convert.ToInt32(this.txtAnio.Text);
                nvComision.IdMateria = Convert.ToInt32(Session["idmateria"]);
                new Negocio.Comisiones().Agregar(nvComision);
            }
            this.materias.Enabled = true;
            this.panelNuevaComision.Visible = false;
            this.panelListado.Visible = true;
            this.nombreComisionNueva.Text = "";
            this.txtAnio.Text = "";
            Session["comisiones"] = new Negocio.Comisiones().RecuperarPorIdMateria(Convert.ToInt32(Session["idmateria"]));
            GrillaComisiones.DataSource = new Negocio.Comisiones().RecuperarPorIdMateria(Convert.ToInt32(Session["idmateria"]));
            GrillaComisiones.DataBind();
            btnNuevaComision.Visible = true;
        }

        protected void btnNuevaComision_Click(object sender, EventArgs e)
        {
            this.panelListado.Visible = false;
            this.panelNuevaComision.Visible = true;
            this.nombreComisionNueva.Focus();
        }

        protected void GrillaComisiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                new Negocio.Comisiones().Borrar(((List<Comision>)Session["comisiones"])[Convert.ToInt32(e.CommandArgument)].IdComision);
                //Response.Redirect("~/Paginas/ABMMaterias.aspx");
                Session["comisiones"] = new Negocio.Comisiones().RecuperarPorIdMateria(Convert.ToInt32(Session["idmateria"]));
            }
            else if (e.CommandName == "Select")
            {
                this.panelNuevaComision.Visible = true;
                this.panelListado.Visible = false;
                this.materias.Enabled = false;
                Comision comActual = ((List<Comision>)Session["comisiones"])[Convert.ToInt32(e.CommandArgument)];
                Session["comision"] = comActual;
                string desc = ((Comision)Session["comision"]).DescripcionComision;
                this.nombreComisionNueva.Text = desc.Substring(0,desc.Length-7).Trim();
                this.txtAnio.Text = ((Comision)Session["comision"]).Anio.ToString();
                this.nombreComisionNueva.Focus();
                this.btnNuevaComision.Visible = false;
                this.btnAgregarComision.Text = "Guardar cambios";
            }
        }

        protected void GrillaComisiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GrillaComisiones.DataSource = (List<Comision>)Session["comisiones"];
            GrillaComisiones.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.panelNuevaComision.Visible = false;
            this.nombreComisionNueva.Text = "";
            Session["comisiones"] = new Negocio.Comisiones().RecuperarPorIdMateria(Convert.ToInt32(Session["idmateria"]));
            GrillaComisiones.DataSource = new Negocio.Comisiones().RecuperarPorIdMateria(Convert.ToInt32(Session["idmateria"]));
            GrillaComisiones.DataBind();
            this.panelListado.Visible = true;
            btnNuevaComision.Visible = true;
            this.materias.Enabled = true;
        }
    }
}