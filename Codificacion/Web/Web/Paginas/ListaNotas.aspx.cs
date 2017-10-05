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
    public partial class ListaNotas : System.Web.UI.Page
    {
        DataTable dtNotas = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Persona"] != null)
            {
                if (!IsPostBack)
                {
                    dtNotas = new Negocio.Personas().RecuperarNotas(((Persona)Session["Persona"]).Id);
                    if(dtNotas.Rows.Count!=0)
                    {
                        GrillaNotas.DataSource = dtNotas;
                        GrillaNotas.DataBind();
                    }
                    else
                    {
                        dtNotas.Rows.Add(dtNotas.NewRow());
                        GrillaNotas.DataSource = dtNotas;
                        GrillaNotas.DataBind();

                        int TotalColumns = GrillaNotas.Rows[0].Cells.Count;
                        GrillaNotas.Rows[0].Cells.Clear();
                        GrillaNotas.Rows[0].Cells.Add(new TableCell());
                        GrillaNotas.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                        GrillaNotas.Rows[0].Cells[0].Text = "No se encontraron notas registradas";
                    }
                }
            }
        }        
    }
}