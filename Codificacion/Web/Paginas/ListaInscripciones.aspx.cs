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
    public partial class ListaAlumnos : System.Web.UI.Page
    {
        List<Persona> alumnos;
        DataTable dtAlumnos;        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
                if(((Persona)Session["Persona"]).TipoPersona.IdTipoPersona == 1)
                { 
                    if (!IsPostBack)
                        CargarComboBoxs();
                }
                else
                        Response.Redirect("~/Paginas/Error.aspx");
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
            Response.Write("<script>alert('Seleccionaste " + this.comisiones.SelectedValue.ToString() + ");</script>");
            CargarGrilla();
        }

        private void CargarGrilla()
        {   
            if(this.comisiones.SelectedValue.ToString()!="0")
            {
                dtAlumnos = new DataTable();
                dtAlumnos.Columns.Add("Id", Type.GetType("System.Int32"));
                dtAlumnos.Columns.Add("Legajo", Type.GetType("System.Int32"));
                dtAlumnos.Columns.Add("Nombre", Type.GetType("System.String"));
                dtAlumnos.Columns.Add("Apellido", Type.GetType("System.String"));
                dtAlumnos.Columns.Add("NotaP1", Type.GetType("System.Double"));
                dtAlumnos.Columns.Add("NotaP2", Type.GetType("System.Double"));
                dtAlumnos.Columns.Add("NotaR1", Type.GetType("System.Double"));
                dtAlumnos.Columns.Add("NotaR2", Type.GetType("System.Double"));
                alumnos = new Negocio.Personas().RecuperarTodosXComision(this.comisiones.SelectedValue.ToString());

                if (alumnos.Count != 0)
                {
                    foreach (Persona per in alumnos)
                    {
                        dtAlumnos.Rows.Add(per.Id, per.Legajo, per.Nombre, per.Apellido, per.NotaP1, per.NotaP2, per.NotaR1, per.NotaR2);
                    }
                    grdPersonas.DataSource = dtAlumnos;
                    grdPersonas.DataBind();
                }
                else
                {
                    dtAlumnos.Rows.Add(dtAlumnos.NewRow());
                    grdPersonas.DataSource = dtAlumnos;
                    grdPersonas.DataBind();

                    int TotalColumns = grdPersonas.Rows[0].Cells.Count;
                    grdPersonas.Rows[0].Cells.Clear();
                    grdPersonas.Rows[0].Cells.Add(new TableCell());
                    grdPersonas.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    grdPersonas.Rows[0].Cells[0].Text = "No se encontraron registros";
                }
            }
            else
                Response.Redirect("~/Paginas/ListaAlumnos.aspx");
        }
                       
        protected void grdPersonas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPersonas.EditIndex = -1;
            CargarGrilla();
        }

        protected void grdPersonas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblId = (Label)grdPersonas.Rows[e.RowIndex].FindControl("lblId");
            TextBox txtNotaP1 = (TextBox)grdPersonas.Rows[e.RowIndex].FindControl("txtNotaP1");        
            TextBox txtNotaR1 = (TextBox)grdPersonas.Rows[e.RowIndex].FindControl("txtNotaR1");
            TextBox txtNotaP2 = (TextBox)grdPersonas.Rows[e.RowIndex].FindControl("txtNotaP2");
            TextBox txtNotaR2 = (TextBox)grdPersonas.Rows[e.RowIndex].FindControl("txtNotaR2");

            //ACTUALIZAR
            new Negocio.Personas().ModificarNotas(this.comisiones.SelectedValue.ToString(), lblId.Text, txtNotaP1.Text, txtNotaP2.Text, txtNotaR1.Text, txtNotaR2.Text);
            grdPersonas.EditIndex = -1;
            CargarGrilla();

        }
        protected void grdPersonas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int id = Convert.ToInt32(grdPersonas.Rows[e.RowIndex].Cells[0].ToString());
            Label lblId = (Label)grdPersonas.Rows[e.RowIndex].FindControl("lblId");
            //contact.Delete(id);
            new Negocio.Comisiones().EliminarAlumnoEnComision(lblId.Text, this.comisiones.SelectedValue.ToString());
            CargarGrilla();
        }
        protected void grdPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                TextBox txtLegajo = (TextBox)grdPersonas.FooterRow.FindControl("lblLegajo");
                TextBox txtNombre = (TextBox)grdPersonas.FooterRow.FindControl("lblNombre");
                TextBox txtApellido = (TextBox)grdPersonas.FooterRow.FindControl("lblApellido");
                TextBox txtNotaP1 = (TextBox)grdPersonas.FooterRow.FindControl("txtNotaP1");
                if (string.IsNullOrEmpty(txtNotaP1.Text))
                    txtNotaP1.Text = "0";
                TextBox txtNotaP2 = (TextBox)grdPersonas.FooterRow.FindControl("txtNotaP2");
                if (string.IsNullOrEmpty(txtNotaP2.Text))
                    txtNotaP2.Text = "0";
                TextBox txtNotaR1 = (TextBox)grdPersonas.FooterRow.FindControl("txtNotaR1");
                if (string.IsNullOrEmpty(txtNotaR1.Text))
                    txtNotaR1.Text = "0";
                TextBox txtNotaR2 = (TextBox)grdPersonas.FooterRow.FindControl("txtNotaR2");
                if (string.IsNullOrEmpty(txtNotaR2.Text))
                    txtNotaR2.Text = "0";
                
                ListadoPersonas personas = new Negocio.Personas().RecuperarPorLegajo(txtLegajo.Text);
                //PREGUNTO SI YA EXISTE LA PERSONA CON ESE LEGAJO
                //SI NO -> AGREGO PERSONA Y LA ASIGNO A LA COMISION
                if (!(personas.Count > 0))
                {
                    if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text))
                        Response.Write("<script>alert('Ingrese nombre y apellido del nuevo alumno');</script>");
                    else
                    {
                        new Negocio.Personas().AgregarNuevoAlumnoAComision(this.comisiones.SelectedValue.ToString(), txtLegajo.Text, txtNombre.Text, txtApellido.Text, txtNotaP1.Text, txtNotaP2.Text, txtNotaR1.Text, txtNotaR2.Text);
                        CargarGrilla();
                    }                        
                }
                else
                {
                    //SI EXISTE -> PREGUNTO SI TIENE EL MISMO NOMBRE Y APELLIDO
                    //SI NO -> INFORMO LA SITUACION
                    if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtApellido.Text))
                    {
                        //SI SI -> PREGUNTO SI SE ENCUENTRA REGISTRADO EN LA COMISION
                        alumnos = new Negocio.Personas().RecuperarTodosXComision(this.comisiones.SelectedValue.ToString());
                        Persona Encontro = alumnos.Find(x => x.Id == personas[0].Id);
                        //SI SI -> AVISO QUE YA SE ENCUENTRA REGISTRADO
                        if (Encontro != null)
                        {
                            //INFORMO QUE EL ALUMNO YA SE ENCUENTRA REGISTRADO EN LA COMISION
                            Response.Write("<script>alert('El Alumno ya se encuentra registrado en esta comisión.');</script>");
                            //new Negocio.Personas().ModificarNotas(this.comisiones.SelectedValue.ToString(), Encontro.Id.ToString(), txtNotaP1.Text, txtNotaP2.Text, txtNotaR1.Text, txtNotaR2.Text);
                        }
                        //SI NO -> PREGUNTO SI SE ENCUENTRA REGISTRADO EN ALGUNA OTRA COMISION DE LA MATERIA
                        else
                        {
                            //BUSCO LA COMISION
                            ListadoComisiones comi = new Negocio.Comisiones().RecuperarUno(Convert.ToInt32(this.comisiones.SelectedValue.ToString()));
                            //BUSCO LAS COMISIONES QUE SON DE ESA MISMA MATERIA
                            ListadoComisiones comiMateria = new Negocio.Comisiones().RecuperarPorIdMateria(comi[0].IdMateria);

                            //BUSCO TODAS LOS REGISTROS COMISIONES-PERSONAS
                            DataTable dtPerComs = new Negocio.Comisiones().RecuperarTodosComisionesPersonas();

                            //BUSCO SI EL ALUMNO INGRESADO SE ENCUENTRA EN OTRA COMISION DE LA MISMA MATERIA
                            DataRow Existe = null;
                            foreach (Entidades.Comision com in comiMateria)
                            {
                                Existe = dtPerComs.Select("IdPersona=" + personas[0].Id.ToString() + " AND IdComision=" + com.IdComision + " AND Anio=" + comi[0].Anio).FirstOrDefault();
                                if (Existe != null)
                                    break;
                            }

                            if (Existe != null)
                                Response.Write("<script>alert('El Alumno ingresado ya se encuentra registrado en otra comisión.');</script>");
                            else
                            {
                                new Negocio.Comisiones().AgregarAlumnoAComision(personas[0].Id.ToString(), this.comisiones.SelectedValue.ToString(), txtNotaP1.Text, txtNotaP2.Text, txtNotaR1.Text, txtNotaR2.Text);
                                CargarGrilla();
                            }
                        }
                    }
                    else if (string.Compare(txtNombre.Text, personas[0].Nombre, true) != 0 || string.Compare(txtApellido.Text, personas[0].Apellido, true) != 0)
                    {
                        Response.Write("<script>alert('Ya existe un Alumno con el legajo ingresado.');</script>");
                    }
                    else
                    {
                        //SI SI -> PREGUNTO SI SE ENCUENTRA REGISTRADO EN LA COMISION
                        alumnos = new Negocio.Personas().RecuperarTodosXComision(this.comisiones.SelectedValue.ToString());
                        Persona Encontro = alumnos.Find(x => x.Id == personas[0].Id);
                        //SI SI -> AVISO QUE YA SE ENCUENTRA REGISTRADO
                        if (Encontro != null)
                        {
                            //INFORMO QUE EL ALUMNO YA SE ENCUENTRA REGISTRADO EN LA COMISION
                            Response.Write("<script>alert('El Alumno ya se encuentra registrado en esta comisión.');</script>");
                            //new Negocio.Personas().ModificarNotas(this.comisiones.SelectedValue.ToString(), Encontro.Id.ToString(), txtNotaP1.Text, txtNotaP2.Text, txtNotaR1.Text, txtNotaR2.Text);
                        }
                        //SI NO -> PREGUNTO SI SE ENCUENTRA REGISTRADO EN ALGUNA OTRA COMISION DE LA MATERIA
                        else
                        {
                            //BUSCO LA COMISION
                            ListadoComisiones comi = new Negocio.Comisiones().RecuperarUno(Convert.ToInt32(this.comisiones.SelectedValue.ToString()));
                            //BUSCO LAS COMISIONES QUE SON DE ESA MISMA MATERIA
                            ListadoComisiones comiMateria = new Negocio.Comisiones().RecuperarPorIdMateria(comi[0].IdMateria);

                            //BUSCO TODAS LOS REGISTROS COMISIONES-PERSONAS
                            DataTable dtPerComs = new Negocio.Comisiones().RecuperarTodosComisionesPersonas();

                            //BUSCO SI EL ALUMNO INGRESADO SE ENCUENTRA EN OTRA COMISION DE LA MISMA MATERIA
                            DataRow Existe = null;
                            foreach (Entidades.Comision com in comiMateria)
                            {
                                Existe = dtPerComs.Select("IdPersona=" + personas[0].Id.ToString() + " AND IdComision=" + com.IdComision + " AND Anio=" + comi[0].Anio).FirstOrDefault();
                                if (Existe != null)
                                    break;
                            }

                            if (Existe != null)
                                Response.Write("<script>alert('El Alumno ingresado ya se encuentra registrado en otra comisión.');</script>");
                            else
                            {
                                new Negocio.Comisiones().AgregarAlumnoAComision(personas[0].Id.ToString(), this.comisiones.SelectedValue.ToString(), txtNotaP1.Text, txtNotaP2.Text, txtNotaR1.Text, txtNotaR2.Text);
                                CargarGrilla();
                            }
                        }
                    }
                }
            }
        }

        protected void grdPersonas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPersonas.EditIndex = e.NewEditIndex;
            /*grdPersonas.Rows[grdPersonas.EditIndex].Cells[1].Enabled = false;
            grdPersonas.Rows[grdPersonas.EditIndex].Cells[2].Enabled = false;
            grdPersonas.Rows[grdPersonas.EditIndex].Cells[3].Enabled = false;*/
            CargarGrilla();
        }

    }
}