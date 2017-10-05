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
    public partial class ABMMaterias : System.Web.UI.Page
    {
        List<Materia> materias;
        List<Comision> comisiones;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
                if (((Persona)Session["Persona"]).TipoPersona.IdTipoPersona == 1)
                {
                    Persona persona = new Persona();
                    persona = (Persona)Session["Persona"];
                    //Session.Timeout = 10;

                    materias = new Negocio.Materias().RecuperarTodos();
                    GrillaMaterias.DataSource = materias;
                    GrillaMaterias.DataBind();
                }
                else
                    Response.Redirect("~/Paginas/Error.aspx");
            else
                Response.Redirect("~/Paginas/Error.aspx");
        }

        protected void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if ((char)Session["estadoABM"] == 'M')
            {
                ListadoMaterias mat = new Negocio.Materias().RecuperarUno(Convert.ToInt32(Session["IdMateria"]));
                mat[0].DescripcionMateria = this.nombreMateria.Text;
                new Negocio.Materias().Modificar(mat[0]);
            }
            else
            {
                Materia nuevaMateria = new Materia();
                nuevaMateria.DescripcionMateria = nombreMateria.Text;
                new Negocio.Materias().Agregar(nuevaMateria);                             
            }
            this.panelListado.Visible = true;
            this.panelNuevo.Visible = false;
            this.btnNuevo.Visible = true;
            Response.Redirect("~/Paginas/ABMMaterias.aspx");

        }
        
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.panelListado.Visible = false;
            this.panelNuevo.Visible = true;
            this.nombreMateria.Focus();
            Session["estadoABM"] = 'A';
        }
        
        protected void GrillaMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Materia matActual = materias[Convert.ToInt32(e.CommandArgument)];
                Response.Redirect(String.Format("~/Paginas/ABMComisiones.aspx?IdMateria={0}", matActual.IdMateria));
            }
            else if (e.CommandName == "Delete")
            {
                new Negocio.Materias().Borrar(materias[Convert.ToInt32(e.CommandArgument)].IdMateria);
                Response.Redirect("~/Paginas/ABMMaterias.aspx");
            }
            else if (e.CommandName == "Edit")
            {
                Session["estadoABM"] = 'M';
                this.panelListado.Visible = false;
                this.btnNuevo.Visible = false;
                this.panelNuevo.Visible = true;
                Materia matActual = materias[Convert.ToInt32(e.CommandArgument)];
                Session["IdMateria"] = matActual.IdMateria;
                this.nombreMateria.Text = matActual.DescripcionMateria;
                this.btnGuardarNuevo.Text = "Guardar Cambios";
            }
        }

        protected void GrillaComisiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                new Negocio.Comisiones().Borrar(((List<Comision>)Session["comisiones"])[Convert.ToInt32(e.CommandArgument)].IdComision);
                //Response.Redirect("~/Paginas/ABMMaterias.aspx");
                comisiones = new Negocio.Comisiones().RecuperarPorIdMateria(((Materia)Session["matActual"]).IdMateria);
                Session["comisiones"] = comisiones;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/ABMMaterias.aspx");
        }

        protected void GrillaMaterias_RowEditing(object sender, GridViewEditEventArgs e)
        {        }
        
    }
}