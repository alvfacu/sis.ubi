using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class Comisiones
    {
        #region Propiedades

        private SqlConnection conn;

        #endregion

        #region Constructor

        public Comisiones()
        {
            conn = Conexion.GetConexion();
        }

        #endregion

        #region Metodos
        
        public void Agregar(Entidades.Comision com)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AgregarComision";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@desc_comision", com.DescripcionComision);
            cmd.Parameters.AddWithValue("@idMateria", com.IdMateria);
            cmd.Parameters.AddWithValue("@anio", com.Anio);
            
            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();
        }

        public void Modificar(Entidades.Comision com)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ModificarComision";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@id_comision", com.IdComision);
            cmd.Parameters.AddWithValue("@desc_comision", com.DescripcionComision);
            cmd.Parameters.AddWithValue("@id_materia", com.IdMateria);
            cmd.Parameters.AddWithValue("@anio", com.Anio);

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose(); 
            conn.Close();
        }

        public Comision RecuperarComisionPorIDArchivo(int idArchivo)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarComisionPorIdArchivo";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id_archivo", idArchivo);
            
            SqlDataReader dr;
            Entidades.Comision com = null;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    com = new Entidades.Comision();
                    com.IdComision = Convert.ToInt32(dr["id_comision"]);
                    com.IdMateria = Convert.ToInt32(dr["id_materia"]);
                }
                cmd.Dispose();
                conn.Close();
                return com;
            }
            catch (SqlException ex)
            {
                throw new Exception("ERROR DB:" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR:" + ex.Message.ToString());
            }
            finally
            {
                //limpio memoria
                com = null;
            }
        }

        public void EliminarAlumnoEnComision(string idpersona, string idcomision)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BorrarAlumnoDeComision";
            cmd.Connection = conn;
            
            cmd.Parameters.AddWithValue("@idcomision", idcomision);
            cmd.Parameters.AddWithValue("@idpersona", idpersona);

            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();
        }

        public void AgregarAlumnoAComision(string idpersona, string idcomision, string notap1, string notap2, string notar1, string notar2)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AgregarAlumnoAComision";
            cmd.Connection = conn;
            //como la clase persona es abstracta y no se puede instanciar
            //agrego todos los datos en alumnos y profesores dejando nulos los que corresponden

            //agrego parametros
            cmd.Parameters.AddWithValue("@idcomision", idcomision);
            cmd.Parameters.AddWithValue("@idpersona", idpersona);
            cmd.Parameters.AddWithValue("@notap1", Convert.ToDouble(notap1.Replace(".", ",")));
            cmd.Parameters.AddWithValue("@notap2", Convert.ToDouble(notap2.Replace(".", ",")));
            cmd.Parameters.AddWithValue("@notar1", Convert.ToDouble(notar1.Replace(".", ",")));
            cmd.Parameters.AddWithValue("@notar2", Convert.ToDouble(notar2.Replace(".", ","))); 

            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();
        }

        public DataTable RecuperarTodosComisionesPersonas()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarComisionesPersonas";
            cmd.Connection = conn;

            DataTable percoms = new DataTable();
            percoms.Columns.Add("IdPerCom", Type.GetType("System.Int32"));
            percoms.Columns.Add("IdPersona", Type.GetType("System.Int32"));
            percoms.Columns.Add("IdComision", Type.GetType("System.Int32"));
            percoms.Columns.Add("Anio", Type.GetType("System.Int32"));

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    percoms.Rows.Add(Convert.ToInt32(dr["idpersona_idcomision"]), Convert.ToInt32(dr["id_persona"]), Convert.ToInt32(dr["id_comision"]), Convert.ToInt32(dr["anio"]));
                }
                cmd.Dispose();
                conn.Close();
                return percoms;
            }
            catch (SqlException ex)
            {
                throw new Exception("ERROR DB:" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR:" + ex.Message.ToString());
            }
            finally
            {
                //limpio memoria utilizada
                percoms = null;
            }
        }

        public void Borrar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BorrarComision";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        public Entidades.ListadoComisiones RecuperarUno(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarComision";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id", id);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoComisiones coms = new Entidades.ListadoComisiones();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Comision com = new Entidades.Comision();
                    //Datos.Turnos tur = new Datos.Turnos();
                    //Datos.Planes pla = new Datos.Planes();
                    com.IdComision = Convert.ToInt32(dr["id_comision"]);
                    com.DescripcionComision = Convert.ToString(dr["descripcion_comision"]);
                    com.IdMateria = Convert.ToInt32(dr["id_materia"]);
                    com.Anio = Convert.ToInt32(dr["anio"]);
                    //com.Plan = pla.RecuperarUno(Convert.ToInt32(dr["id_plan"]))[0];
                    //com.Turno = tur.RecuperarUno(Convert.ToInt32(dr["id_turno"]))[0];
                    coms.Add(com);
                    com = null;
                }
                cmd.Dispose();
                conn.Close();
                return coms;
            }
            catch (SqlException ex)
            {
                throw new Exception("ERROR DB:" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR:" + ex.Message.ToString());
            }
            finally
            {
                //limpio memoria utilizada
                coms = null;
            }
        }

        public Entidades.ListadoComisiones RecuperarComisionPorDescripcion(string descComision)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarComisionPorDescripcion";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@descripcion_comision", descComision);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoComisiones coms = new Entidades.ListadoComisiones();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Comision com = new Entidades.Comision();
                    //Datos.Turnos tur = new Datos.Turnos();
                    //Datos.Planes pla = new Datos.Planes();

                    com.IdComision = Convert.ToInt32(dr["id_comision"]);
                    com.DescripcionComision = Convert.ToString(dr["descripcion_comision"]);
                    //com.Plan = pla.RecuperarUno(Convert.ToInt32(dr["id_plan"]))[0];
                    //com.Turno = tur.RecuperarUno(Convert.ToInt32(dr["id_turno"]))[0];
                    coms.Add(com);
                    com = null;
                }
                cmd.Dispose();
                conn.Close();
                return coms;
            }
            catch (SqlException ex)
            {
                throw new Exception("ERROR DB:" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR:" + ex.Message.ToString());
            }
            finally
            {
                //limpio memoria utilizada
                coms = null;
            }
        }

        public Entidades.ListadoComisiones RecuperarPorIdPlan(int idPlan)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarComisionPorIdPlan";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id_plan", idPlan);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoComisiones coms = new Entidades.ListadoComisiones();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Comision com = new Entidades.Comision();
                    //Datos.Turnos tur = new Datos.Turnos();
                    //Datos.Planes pla = new Datos.Planes();

                    com.IdComision = Convert.ToInt32(dr["id_comision"]);
                    com.DescripcionComision = Convert.ToString(dr["descripcion_comision"]);
                    //com.Plan = pla.RecuperarUno(Convert.ToInt32(dr["id_plan"]))[0];
                    //com.Turno = tur.RecuperarUno(Convert.ToInt32(dr["id_turno"]))[0];
                    coms.Add(com);
                    com = null;
                }
                cmd.Dispose();
                conn.Close();
                return coms;
            }
            catch (SqlException ex)
            {
                throw new Exception("ERROR DB:" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR:" + ex.Message.ToString());
            }
            finally
            {
                //limpio memoria
                coms = null;
            }
        }

        public List<Comision> RecuperarTodos()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarComisiones";
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            List<Comision> coms = new List<Comision>();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Comision com = new Entidades.Comision();
                    com.IdComision = Convert.ToInt32(dr["id_comision"]);
                    com.DescripcionComision = Convert.ToString(dr["descripcion"]);
                    coms.Add(com);
                    com = null;
                }
                cmd.Dispose();
                conn.Close();
                return coms;

            }
            catch (SqlException ex)
            {
                throw new Exception("ERROR DB:" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR:" + ex.Message.ToString());
            }
            finally
            {
                //limpio memoria
                coms = null;
            }

        }

        public ListadoComisiones RecuperarPorIdMateria(int idMat)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarComisionPorIdMateria";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id_materia", idMat);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            ListadoComisiones coms = new ListadoComisiones();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Comision com = new Entidades.Comision();
                    com.IdComision = Convert.ToInt32(dr["id_comision"]);
                    com.DescripcionComision = Convert.ToString(dr["descripcion_comision"])+" - "+Convert.ToInt32(dr["anio"]);
                    com.IdMateria = Convert.ToInt32(dr["id_materia"]);
                    com.Anio = Convert.ToInt32(dr["anio"]);
                    coms.Add(com);
                    com = null;
                }
                cmd.Dispose();
                conn.Close();
                return coms;
            }
            catch (SqlException ex)
            {
                throw new Exception("ERROR DB:" + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR:" + ex.Message.ToString());
            }
            finally
            {
                //limpio memoria
                coms = null;
            }
        }



        #endregion
    }
}
