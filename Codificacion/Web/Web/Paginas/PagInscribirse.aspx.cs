using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Web.Paginas
{
    public partial class PagInscribirse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Alumno"] != null)
            {
                Persona persona = new Persona();
                persona = (Persona)Session["Alumno"];


                int idCur = Convert.ToInt32(Request.QueryString["i"]);

                Negocio.Cursos cursos = new Negocio.Cursos();

                Curso cur = cursos.RecuperarUno(idCur);
                LblMat.Text = cur.Materia.DescripcionMateria;
                LblCom.Text = cur.Comision.DescripcionComision;

                Random r = new Random();
                int rnd = r.Next();
                LblCodInsc.Text = Convert.ToString(rnd);

                Negocio.Inscripciones ins = new Negocio.Inscripciones();
                Entidades.Inscripcion inscrip = new Entidades.Inscripcion();

                inscrip.Alumno = persona;

                inscrip.Curso = cur;
                inscrip.Condicion = "Inscripto";
                inscrip.FechaInscripcion = DateTime.Today;
                inscrip.CodigoInscripcion = rnd;
                

                ins.Agregar(inscrip);

                //Modifico cantidad de cupos
                cur.Cupo = cur.Cupo - 1;

                //Si cantidad de cupos = 0, cambio a Estado 'SIN CUPOS'
                if (cur.Cupo == 0)
                {
                    cur.Estado.IdEstado = 2;
                }
                cursos.Modificar(cur);
            }
        }
    }
}