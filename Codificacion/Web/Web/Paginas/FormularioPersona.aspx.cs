using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using Datos;
using System.Globalization;

namespace Web.Paginas
{
    public partial class FormularioPersona : System.Web.UI.Page
    {
        Persona ps;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                tipopersona.SelectedValue = "3";
                int IdPs = Convert.ToInt32(Request.QueryString["IdPersona"]);
                if (((Persona)Session["Persona"]).TipoPersona.IdTipoPersona == 1 || ((Persona)Session["Persona"]).Id == IdPs)
                    if (IdPs != 0)
                    {
                        BtnAgregar.Click += BtnModificar_Click;
                        this.Title = "Modificar Persona";
                        if (!IsPostBack)
                        {
                            //Negocio.Cursos cursos = new Negocio.Cursos();
                            //ps = new Persona();
                            //alu = new Alumno();
                            //prof = new Profesor();

                            ListadoPersonas per = new Negocio.Personas().RecuperarUno(IdPs);

                            if (per.Count != 0)
                            {
                                Persona perActual = (Persona)Session["Persona"];
                                Session["estadoABM"] = 'M';
                                ps = per[0];
                                apellido.Value = ps.Apellido;
                                nombre.Value = ps.Nombre;
                                legajo.Value = ps.Legajo;
                                email.Value = ps.Email;

                                //fechanacimiento.Value = ps.FechaNacimiento.ToShortDateString();
                                tipopersona.SelectedValue = ps.TipoPersona.IdTipoPersona.ToString();
                                //activo.Value = ps.Activo.ToString();
                                usr.Value = ps.NombreUsuario;
                                pass.Visible = false;
                                repite.Visible = false;

                                if (perActual.TipoPersona.IdTipoPersona == 1)
                                {
                                    reiniciar.Style.Add("display", "yes");
                                    msjreiniciar.Visible = true;
                                    BtnCambiarPass.Visible = true;
                                    BtnCambiarPass.Text = "Cancelar";
                                }
                                else
                                {
                                    BtnCambiarPass.Visible = true;
                                    tipopersona.Enabled = false;
                                    legajo.Disabled = true;
                                }

                                Session["personamodifica"] = per[0];
                                BtnAgregar.Text = "Modificar";
                            }
                        }
                    }
                    else
                    {
                        BtnCambiarPass.Visible = true;
                        BtnCambiarPass.Text = "Cancelar";
                        Session["estadoABM"] = 'A';
                        this.Title = "Agregar Persona";
                        BtnAgregar.Click += btnAgregar_Click;
                    }
                else
                    Response.Redirect("~/Paginas/Error.aspx");
            }
            else
                Response.Redirect("~/Paginas/Error.aspx");
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            ps = (Persona)Session["personamodifica"];
            ListadoPersonas personas = new Negocio.Personas().RecuperarPorNombreDeUsuario(usr.Value);
            if (personas.Count != 0)
            {
                if (personas[0].Id != ps.Id)
                {
                    Response.Write("<script>alert('¡Nombre de usuario en uso!');</script>");
                    return;
                }
                else
                {
                    ps.NombreUsuario = usr.Value;
                    ps.Nombre = nombre.Value;
                    ps.Apellido = apellido.Value;
                    ps.Legajo = legajo.Value;
                    ps.Email = email.Value;
                    ps.TipoPersona = new TiposPersonas().RecuperarUno(Convert.ToInt32(tipopersona.SelectedValue));
                    if (reiniciar.Checked)
                        ps.Contraseña = Seguridad.MD5Hash("1234");
                    new Negocio.Personas().Modificar(ps);
                    Persona perActual = (Persona)Session["Persona"];
                    if (perActual.TipoPersona.IdTipoPersona == 1)
                    {
                        Response.Write("<script>alert('Persona modificada correctamente.');</script>");
                        Response.Redirect(String.Format("~/Paginas/ListaAlumnos.aspx?IdComision={0}", Session["IdCom"]));
                    }
                    else
                    {
                        Response.Write("<script>alert('Datos modificados correctamente.');</script>");
                        Response.Redirect("~/Paginas/MenuAlumno.aspx");
                    }

                    
                }
            }
            else
            {
                ps.NombreUsuario = usr.Value;
                ps.Nombre = nombre.Value;
                ps.Apellido = apellido.Value;
                ps.Legajo = legajo.Value;
                ps.Email = email.Value;
                ps.TipoPersona = new TiposPersonas().RecuperarUno(Convert.ToInt32(tipopersona.SelectedValue));
                if (reiniciar.Checked)
                    ps.Contraseña = Seguridad.MD5Hash("1234");
                new Negocio.Personas().Modificar(ps);
                Persona perActual = (Persona)Session["Persona"];
                if (perActual.TipoPersona.IdTipoPersona == 1)
                {
                    Response.Write("<script>alert('Persona modificada correctamente.');</script>");
                    Response.Redirect(String.Format("~/Paginas/ListaAlumnos.aspx?IdComision={0}", Session["IdCom"]));
                }
                else
                {
                    Response.Write("<script>alert('Datos modificados correctamente.');</script>");
                    Response.Redirect("~/Paginas/MenuAlumno.aspx");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Entidades.ListadoPersonas personas = new Entidades.ListadoPersonas();
            Persona ps = new Persona();
            //Alumno alu = new Alumno();
            //Profesor pro = new Profesor();
            ps.Apellido = apellido.Value;
            ps.Nombre = nombre.Value;
            personas = new Negocio.Personas().RecuperarPorLegajo(Convert.ToString(legajo.Value));
            //Count = 0: No hay personas con ese DNI; Count = 1 si es administrador; Count = 2: si es alumno o profesor, ya que se asigna un objeto persona con todos sus datos, más un objeto de alumno/profesor según corresponda para obtener sus datos que no se encunetran en Entidades.Persona.
            if (personas.Count != 0)
            {
                foreach (Persona per in personas)
                {
                    if (per.TipoPersona.IdTipoPersona == Convert.ToInt32(tipopersona.SelectedValue))
                    {
                        Response.Write("<script>alert('¡Legajo existente para el mismo tipo de persona!');</script>");
                        return;
                    }
                }
            }
            else
            {
                ps.Legajo = Convert.ToString(legajo.Value);
            }
            //Count = 0: No hay personas con ese DNI; Count = 1 si es administrador; Count = 2: si es alumno o profesor, ya que se asigna un objeto persona con todos sus datos, más un objeto de alumno/profesor según corresponda para obtener sus datos que no se encunetran en Entidades.Persona.
            if (personas.Count != 0)
            {
                Response.Write("<script>alert('¡Controle los datos ingresados!');</script>");
                return;
            }
            else
            {
                personas = null;
            }
            ps.TipoPersona = new TiposPersonas().RecuperarUno(Convert.ToInt32(tipopersona.SelectedValue));
            ps.Email = email.Value;
            string usuario = usr.Value;
            personas = new Negocio.Personas().RecuperarPorNombreDeUsuario(usuario);
            if (personas.Count != 0)
            {
                Response.Write("<script>alert('¡Nombre de usuario en uso!');</script>");
                return;
            }
            else
            {
                ps.NombreUsuario = usr.Value;
                personas = null;
            }
            ps.Contraseña = Seguridad.MD5Hash(pass.Value);
            ps.Activo = true;

            try
            {
                new Negocio.Personas().Agregar(ps);                
                Response.Write("<script>alert('Persona agregada correctamente.');</script>");
                int IdPs = new Negocio.Personas().RecuperarPorLegajo(ps.Legajo)[0].Id;
                Response.Redirect(String.Format("~/Paginas/MenuAlumno.aspx", IdPs));
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
            }
        }

        protected void BtnCambiarPass_Click(object sender, EventArgs e)
        {
            if((char)Session["estadoABM"]=='A')
                Response.Redirect("~/Paginas/Alumnos.aspx");
            else
            {
                if(((Persona)Session["Persona"]).TipoPersona.IdTipoPersona==1)
                    Response.Redirect(String.Format("~/Paginas/ListaAlumnos.aspx?IdComision={0}", Session["IdCom"]));
                else
                {
                    Persona perActual = (Persona)Session["Persona"];
                    Response.Redirect(String.Format("~/Paginas/CambiarContrasenia.aspx?IdPersona={0}", perActual.Id));
                }
                
            }           
        }

    }
}