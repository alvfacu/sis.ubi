using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Subgurim.Controles;
using System.Configuration;
using System.Text;
using System.IO;
using Entidades;
using Datos;

namespace Web.Paginas
{
    public partial class ImportarPersonas : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
        ListadoPersonas alumnos;
        //private string cn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DatosExcel.xls;Extended Properties='Excel 8.0;HDR=Yes;IMEX=0'";

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                if(((Persona)Session["Persona"]).TipoPersona.IdTipoPersona == 1)
                {
                    Persona persona = new Persona();
                    persona = (Persona)Session["Persona"];
                    if(!IsPostBack)
                        CargarComisiones();
                    //Session.Timeout = 10;
                    gvExcelFile.DataSource = null;
                }     
                else
                    Response.Redirect("~/Paginas/Error.aspx");
            }
            else
                Response.Redirect("~/Paginas/Error.aspx");
        }

        private void CargarComisiones()
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            gvExcelFile.DataSource = null;

            Boolean fileOK = false;

            //Coneection String by default empty  
            string ConStr = "";
            //Extantion of the file upload control saving into ext because   
            //there are two types of extation .xls and .xlsx of Excel   
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            //getting the path of the file   
            string path = Server.MapPath("Archivos/");
            //saving the file inside the MyFolder of the server  
            String fileExtension = "";
            if (FileUpload1.HasFile)
            {
                fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = { ".xls", ".xlsx" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                        break;
                    }
                }
            }

            if (fileOK)
            {
                FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);

                //FileUpload1.SaveAs(path);
                //Label1.Text = FileUpload1.FileName; // +"\'s Data showing into the GridView";
                //checking that extantion is .xls or .xlsx  
                if (ext.Trim() == ".xls")
                {
                    //connection string for that file which extantion is .xls  
                    ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + FileUpload1.FileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (ext.Trim() == ".xlsx")
                {
                    //connection string for that file which extantion is .xlsx  
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + FileUpload1.FileName + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                //making query  
                string query = "SELECT * FROM [Sheet1$]";
                //Providing connection  
                OleDbConnection conn = new OleDbConnection(ConStr);
                //checking that connection state is closed or not if closed the   
                //open the connection  
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //create command object  
                OleDbCommand cmd = new OleDbCommand(query, conn);
                // create a data adapter and get the data into dataadapter  
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                //fill the Excel data to data set  
                da.Fill(ds);
                //set data source of the grid view  
                gvExcelFile.DataSource = ds.Tables[0].Select("Legajo is not null");
                //binding the gridview  
                gvExcelFile.DataBind();
                //close the connection  
                conn.Close();

                lblElija.Visible = true;
                comisiones.Visible = true;
                btnGuardar.Visible = true;
                btnCancelar.Visible = true;
                FileUpload1.Visible = false;
                subtitulo.Visible = false;
                btnUpload.Visible = false;
            }
        }

        protected void btnGuardar_Click(object sender, System.EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvExcelFile.Rows)
                {
                    if(!string.IsNullOrEmpty(row.Cells[2].Text))
                    {
                        Persona per = new Persona();
                        //Alumno alum = new Alumno();
                        per.Nombre = row.Cells[0].Text;
                        per.Apellido = row.Cells[1].Text;
                        per.Legajo = row.Cells[2].Text;
                        //per.Telefono = row.Cells[3].Text;
                        //per.Direccion = row.Cells[4].Text;
                        per.Email = row.Cells[3].Text;
                        //per.FechaNacimiento = Convert.ToDateTime(row.Cells[6].Text);
                        TiposPersona tipoPer = new TiposPersona();
                        tipoPer = new Datos.TiposPersonas().RecuperarUno(3);
                        per.TipoPersona = tipoPer;
                        //per.id_plan = row.Cells[1].Text;
                        per.NombreUsuario = per.Nombre.ToLower()[0] + per.Legajo;
                        per.Contraseña = Seguridad.MD5Hash(per.Nombre.ToLower()[0] + per.Legajo);
                        //per.FechaIngreso = Convert.ToDateTime(row.Cells[9].Text);
                        per.Activo = true;
                        //per.TipoDocumento = row.Cells[11].Text;
                        //per.NumeroDocumento = Convert.ToInt32(row.Cells[12].Text);
                        if (!(new Negocio.Personas().Existe(per)))
                            new Negocio.Personas().Agregar(per);

                        alumnos = new Negocio.Personas().RecuperarTodosXComision(this.comisiones.SelectedValue.ToString());
                        Persona alumno = new Negocio.Personas().RecuperarPorLegajo(per.Legajo).FirstOrDefault();
                        Persona Encontro = alumnos.Find(x => x.Id == alumno.Id);
                        if (Encontro == null)
                        {
                            ListadoComisiones comi = new Negocio.Comisiones().RecuperarUno(Convert.ToInt32(this.comisiones.SelectedValue.ToString()));
                            ListadoComisiones comiMateria = new Negocio.Comisiones().RecuperarPorIdMateria(comi[0].IdMateria);
                            DataTable dtPerComs = new Negocio.Comisiones().RecuperarTodosComisionesPersonas();
                            DataRow Existe = null;
                            foreach (Entidades.Comision com in comiMateria)
                            {
                                Existe = dtPerComs.Select("IdPersona=" + alumno.Id.ToString() + " AND IdComision=" + com.IdComision + " AND Anio=" + comi[0].Anio).FirstOrDefault();
                                if (Existe != null)
                                    break;
                            }

                            if (Existe == null)
                                new Negocio.Comisiones().AgregarAlumnoAComision(alumno.Id.ToString(), this.comisiones.SelectedValue.ToString(), "0", "0", "0", "0");
                        }
                    }                    
                }
                
                Response.Write("<script>alert('¡Carga Correcta!');</script>");
                string pag = String.Format("ListaAlumnos.aspx?IdComision={0}", Convert.ToInt32(comisiones.SelectedValue));
                Response.Write("<script>window.location='"+pag+"';</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('¡Error durante la carga! Controle y reintente cargar');</script>");
                Response.Write("<script>window.location='ImportarPersonas.aspx';</script>");
            }
        }

        private void Msg(String sText)
        {
            Response.Write("<script type=’text/javascript’>alert(‘” & sText & “‘);</script>");
        }

        //protected void GenerarOrigenDeDatos(ListadoPersonas personas)
        //{
        //    GrillaPersonas.DataSource = null;
        //    GrillaPersonas.DataBind();

        //    foreach (Persona ps in personas)
        //    {
        //        ps.Nombre = ps.Apellido + ", " + ps.Nombre;
        //    }

        //    List<Persona> pers = personas.OrderBy(p => p.Nombre).ToList();

        //    GrillaPersonas.Columns[1].Visible = true;
        //    GrillaPersonas.DataSource = pers;
        //    GrillaPersonas.DataBind();
        //    GrillaPersonas.Columns[1].Visible = false;
        //}

        //protected void GrillaPersonas_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int IdPersona = Convert.ToInt32(this.GrillaPersonas.DataKeys[this.GrillaPersonas.SelectedRow.RowIndex].Value.ToString());
        //    Response.Redirect(String.Format("~/Paginas/FormularioPersona.aspx?IdPersona={0}", IdPersona));
        //}

        private void LimpiarControles()
        {
            //TextBox1.Text = "";
            //TextBox2.Text = "";
            //TextBox3.Text = "";
            //TextBox4.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Alumnos.aspx");
        }
    }
}