using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace Web.Paginas
{
    public partial class EstadoAcademico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Alumno"] != null)
            {
                Persona persona = new Persona();
                persona = (Persona)Session["Alumno"];

                Negocio.Inscripciones inscripciones = new Negocio.Inscripciones();
                Entidades.ListadoInscripciones listInscrip = new Entidades.ListadoInscripciones();
                Entidades.ListadoInscripciones listadoInscripcionesMostrar = new Entidades.ListadoInscripciones();

                listInscrip = inscripciones.RecuperarPorIdAlumno(persona.Id);

                foreach (Inscripcion i in listInscrip)
                {
                    listadoInscripcionesMostrar.Add(i);
                }

                GVEstado.DataSource = listadoInscripcionesMostrar;
                GVEstado.DataBind();
                GVEstado.Columns[0].Visible = false;
               
            }
        }
        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdInscrip = Convert.ToInt32(GVEstado.DataKeys[this.GVEstado.SelectedRow.RowIndex].Value);
            Negocio.Inscripciones inscripcion = new Negocio.Inscripciones();
            Entidades.ListadoInscripciones listaInscripcion = new Entidades.ListadoInscripciones();
            listaInscripcion = inscripcion.RecuperarUno(IdInscrip);
            Inscripcion ins = listaInscripcion[0];
            if (ins.Curso.Estado.DescripcionEstado != "CERRADO")
            {
                inscripcion.Borrar(ins.IdInscripcion);
                Response.Redirect("~/Paginas/EstadoAcademico.aspx");
            }
            else
            {
                LblError.Visible = true;
            }
        }

    }
}