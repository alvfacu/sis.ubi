using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Web.UI.WebControls;

namespace Datos
{
    public class Personas
    {
        #region Propiedades

        private SqlConnection conn;

        #endregion

        #region Constructor

        public Personas()
        {
            //Se crea la conexion
            this.conn = Conexion.GetConexion();
        }

        #endregion

        #region Metodos

        public void Agregar(Persona per)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AgregarPersona";
            cmd.Connection = conn;
            //como la clase persona es abstracta y no se puede instanciar
            //agrego todos los datos en alumnos y profesores dejando nulos los que corresponden

            //agrego parametros
            cmd.Parameters.AddWithValue("@nombre", per.Nombre);
            cmd.Parameters.AddWithValue("@apellido", per.Apellido);
            cmd.Parameters.AddWithValue("@legajo", per.Legajo);
            cmd.Parameters.AddWithValue("@email", per.Email);
            cmd.Parameters.AddWithValue("@id_tipo_persona", per.TipoPersona.IdTipoPersona);
            cmd.Parameters.AddWithValue("@usuario", per.NombreUsuario);
            cmd.Parameters.AddWithValue("@contrasenia", per.Contraseña);
            cmd.Parameters.AddWithValue("@activo", per.Activo);
            //cmd.Parameters.AddWithValue("@Id", 0);

            //cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();

            //return Convert.ToInt32(cmd.Parameters["@Id"].Value);

        }

        public DataTable RecuperarNotas(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarNotasPorID";

            //agrego parametros
            cmd.Parameters.AddWithValue("@idpersona", id.ToString());
            cmd.Connection = conn;

            DataTable dtNotas = new DataTable();
            dtNotas.Columns.Add("Descripcion", Type.GetType("System.String"));
            dtNotas.Columns.Add("NotaP1", Type.GetType("System.Decimal"));
            dtNotas.Columns.Add("NotaP2", Type.GetType("System.Decimal"));
            dtNotas.Columns.Add("NotaR1", Type.GetType("System.Decimal"));
            dtNotas.Columns.Add("NotaR2", Type.GetType("System.Decimal"));

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dtNotas.Rows.Add(dr["Descripcion"], dr["NotaP1"], dr["NotaP2"], dr["NotaR1"], dr["NotaR2"]);
                }
                return dtNotas;
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
                conn.Close();
                cmd.Dispose();
            }
        }

        public ListadoPersonas RecuperarTodosXComision(string com)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarAlumnosXComision";

            //agrego parametros
            cmd.Parameters.AddWithValue("@idcom", com);
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            ListadoPersonas pers = new Entidades.ListadoPersonas();
            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TiposPersona tp = new TiposPersonas().RecuperarUno(3);
                    Entidades.Persona per = new Entidades.Persona();
                    per.Id = Convert.ToInt32(dr["id_persona"]);
                    per.Apellido = Convert.ToString(dr["apellido"]);
                    per.Nombre = Convert.ToString(dr["nombre"]);
                    per.Legajo = Convert.ToString(dr["legajo"]);
                    if (dr["notaP1"] != DBNull.Value)
                        per.NotaP1 = Convert.ToDouble(dr["notaP1"]);
                    else
                        per.NotaP1 = Convert.ToDouble(0);
                    if (dr["notaP2"] != DBNull.Value)
                        per.NotaP2 = Convert.ToDouble(dr["notaP2"]);
                    else
                        per.NotaP2 = Convert.ToDouble(0);
                    if (dr["notaR1"] != DBNull.Value)
                        per.NotaR1 = Convert.ToDouble(dr["notaR1"]);
                    else
                        per.NotaR1 = Convert.ToDouble(0);
                    if (dr["notaR2"] != DBNull.Value)
                        per.NotaR2 = Convert.ToDouble(dr["notaR2"]);
                    else
                        per.NotaR2 = Convert.ToDouble(0);
                    pers.Add(per);
                    per = null;
                }
                return pers;
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
                conn.Close();
                cmd.Dispose();
                pers = null;
            }
        }

        public void AgregarNuevoAlumnoAComision(string comi, string legajo, string nombre, string apellido, string notaP1, string notaP2, string notaR1, string notaR2)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AgregarNuevoAlumnoAComision";
            cmd.Connection = conn;
            //como la clase persona es abstracta y no se puede instanciar
            //agrego todos los datos en alumnos y profesores dejando nulos los que corresponden

            //agrego parametros
            cmd.Parameters.AddWithValue("@idcomision", comi);
            cmd.Parameters.AddWithValue("@legajo", legajo);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@usr", nombre.ToLower()[0]+legajo);
            cmd.Parameters.AddWithValue("@pass", Seguridad.MD5Hash(nombre.ToLower()[0]+legajo));
            cmd.Parameters.AddWithValue("@notap1", Convert.ToDouble(notaP1.Replace(".", ",")));
            cmd.Parameters.AddWithValue("@notap2", Convert.ToDouble(notaP2.Replace(".", ",")));
            cmd.Parameters.AddWithValue("@notar1", Convert.ToDouble(notaR1.Replace(".", ",")));
            cmd.Parameters.AddWithValue("@notar2", Convert.ToDouble(notaR2.Replace(".", ",")));;

            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();

            //return Convert.ToInt32(cmd.Parameters["@Id"].Value);
        }

        public void ModificarNotas(string Comi, string iD, string notaP1, string notaP2, string notaR1, string notaR2)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ModificarNotas";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@idcomision", Comi);
            cmd.Parameters.AddWithValue("@idpersona", iD);
            cmd.Parameters.AddWithValue("@notap1", Convert.ToDouble(notaP1.Replace(".",",")));
            cmd.Parameters.AddWithValue("@notap2", Convert.ToDouble(notaP2.Replace(".", ",")));
            cmd.Parameters.AddWithValue("@notar1", Convert.ToDouble(notaR1.Replace(".", ",")));
            cmd.Parameters.AddWithValue("@notar2", Convert.ToDouble(notaR2.Replace(".", ",")));

            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();
        }

        public void Modificar(Persona per)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ModificarPersona";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id", per.Id);
            cmd.Parameters.AddWithValue("@nombre", per.Nombre);
            cmd.Parameters.AddWithValue("@apellido", per.Apellido);
            cmd.Parameters.AddWithValue("@legajo", per.Legajo);
            cmd.Parameters.AddWithValue("@email", per.Email);
            cmd.Parameters.AddWithValue("@tipo_persona", per.TipoPersona.IdTipoPersona);
            cmd.Parameters.AddWithValue("@usuario", per.NombreUsuario);
            cmd.Parameters.AddWithValue("@contrasenia", per.Contraseña);
            cmd.Parameters.AddWithValue("@activo", per.Activo);

            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();
        }

        public void Borrar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BorrarPersona";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        public Entidades.ListadoPersonas RecuperarPersonaPorNombreDeUsuario(string nomUsr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarPersonaPorNombreDeUsuario";

            //agrego parametros
            cmd.Parameters.AddWithValue("@usuario", nomUsr);
            conn.Close();
            cmd.Dispose();

            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoPersonas pers = new Entidades.ListadoPersonas();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //Planes p = new Planes();
                    TiposPersonas tp = new TiposPersonas();
                    Entidades.Persona per = new Entidades.Persona();
                    per.Id = Convert.ToInt32(dr["id_persona"]);
                    per.Apellido = Convert.ToString(dr["apellido"]);
                    per.Nombre = Convert.ToString(dr["nombre"]);
                    per.Email = Convert.ToString(dr["email"]);
                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
                    per.TipoPersona = tp.RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));
                    pers.Add(per);

                    per = null;
                }
                return pers;
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
                conn.Close();
                cmd.Dispose();
                pers = null;
            }
        }

        public Entidades.ListadoPersonas RecuperarPorTipo(int IDTipoPs, bool activo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarPersonasPorTipo";

            //agrego parametros
            cmd.Parameters.AddWithValue("@id_tipo", IDTipoPs);
            cmd.Parameters.AddWithValue("@activo", activo);
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoPersonas pers = new Entidades.ListadoPersonas();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TiposPersona tp = new TiposPersonas().RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));
                    Entidades.Persona per = new Entidades.Persona();
                    per.Id = Convert.ToInt32(dr["id_persona"]);
                    per.Apellido = Convert.ToString(dr["apellido"]);
                    per.Nombre = Convert.ToString(dr["nombre"]);
                    per.Activo = Convert.ToBoolean(dr["activo"]);
                    per.Legajo = Convert.ToString(dr["legajo"]);
                    pers.Add(per);

                    per = null;
                }

                conn.Close();
                return pers;
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
                pers = null;
            }
        }

        //public Entidades.ListadoPersonas RecuperarPorTipoActivos(int IDTipoPs)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "RecuperarPersonasPorTipoActivos";

        //    //agrego parametros
        //    cmd.Parameters.AddWithValue("@id_tipo", IDTipoPs);
        //    cmd.Connection = conn;

        //    //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
        //    Entidades.ListadoPersonas pers = new Entidades.ListadoPersonas();

        //    SqlDataReader dr;

        //    try
        //    {
        //        conn.Open();
        //        dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            Planes p = new Planes();
        //            Alumno alu = new Alumno();
        //            Profesor prof = new Profesor();
        //            TiposPersona tp = new TiposPersonas().RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));
        //            Entidades.Persona per = new Entidades.Persona();
        //            string TipoPersona = tp.Descripcion;
        //            if (TipoPersona == "Alumno")
        //            {
        //                alu.Id = Convert.ToInt32(dr["id_persona"]);
        //                alu.Apellido = Convert.ToString(dr["apellido"]);
        //                alu.Nombre = Convert.ToString(dr["nombre"]);
        //                alu.Activo = Convert.ToBoolean(dr["activo"]);
        //                alu.Legajo = Convert.ToString(dr["legajo"]);
        //                alu.Telefono = Convert.ToString(dr["telefono"]);
        //                alu.Direccion = Convert.ToString(dr["direccion"]);
        //                alu.Plan = p.RecuperarUno(Convert.ToInt32(dr["id_plan"]))[0];
        //                pers.Add(alu);
        //            }
        //            else
        //            {
        //                if (TipoPersona == "Profesor")
        //                {
        //                    prof.Id = Convert.ToInt32(dr["id_persona"]);
        //                    prof.Apellido = Convert.ToString(dr["apellido"]);
        //                    prof.Nombre = Convert.ToString(dr["nombre"]);
        //                    prof.Activo = Convert.ToBoolean(dr["activo"]);
        //                    prof.Legajo = Convert.ToString(dr["legajo"]);
        //                    prof.Telefono = Convert.ToString(dr["telefono"]);
        //                    prof.Direccion = Convert.ToString(dr["direccion"]);
        //                    pers.Add(prof);
        //                }
        //                else
        //                {
        //                    per.Id = Convert.ToInt32(dr["id_persona"]);
        //                    per.Apellido = Convert.ToString(dr["apellido"]);
        //                    per.Nombre = Convert.ToString(dr["nombre"]);
        //                    per.Activo = Convert.ToBoolean(dr["activo"]);
        //                    per.Legajo = Convert.ToString(dr["legajo"]);
        //                    per.Telefono = Convert.ToString(dr["telefono"]);
        //                    per.Direccion = Convert.ToString(dr["direccion"]);
        //                    pers.Add(per);
        //                }
        //            }
        //            per = null;
        //        }

        //        conn.Close();
        //        return pers;

        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("ERROR DB:" + ex.Message.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ERROR:" + ex.Message.ToString());
        //    }
        //    finally
        //    {
        //        //limpio memoria 
        //        pers = null;
        //    }
        //}

        public Entidades.ListadoPersonas RecuperarTodos()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarPersonas";

            //agrego parametros
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoPersonas pers = new Entidades.ListadoPersonas();
            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TiposPersona tp = new TiposPersonas().RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));
                    Entidades.Persona per = new Entidades.Persona();
                    per.Id = Convert.ToInt32(dr["id_persona"]);
                    per.Apellido = Convert.ToString(dr["apellido"]);
                    per.Nombre = Convert.ToString(dr["nombre"]);
                    per.Activo = Convert.ToBoolean(dr["activo"]);
                    per.Legajo = Convert.ToString(dr["legajo"]);
                    per.Email = Convert.ToString(dr["email"]);
                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
                    per.TipoPersona = tp;
                    pers.Add(per);

                    per = null;
                }
                return pers;
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
                conn.Close();
                cmd.Dispose();
                pers = null;
            }
        }

        public Entidades.ListadoPersonas RecuperarTodos(bool activo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarPersonasActivo";

            //agrego parametros
            cmd.Parameters.AddWithValue("@activo", activo);
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoPersonas pers = new Entidades.ListadoPersonas();
            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TiposPersona tp = new TiposPersonas().RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));
                    Entidades.Persona per = new Entidades.Persona();
                    per.Id = Convert.ToInt32(dr["id_persona"]);
                    per.Apellido = Convert.ToString(dr["apellido"]);
                    per.Nombre = Convert.ToString(dr["nombre"]);
                    per.Activo = Convert.ToBoolean(dr["activo"]);
                    per.Legajo = Convert.ToString(dr["legajo"]);
                    per.Email = Convert.ToString(dr["email"]);
                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
                    per.TipoPersona = tp;
                    pers.Add(per);

                    per = null;
                }
                return pers;
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
                conn.Close();
                cmd.Dispose();
                pers = null;
            }
        }

        public ListadoPersonas RecuperarPersonaPorNumeroDocumento(int numDoc)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarPersonaPorNumeroDocumento";

            //agrego parametros
            cmd.Parameters.AddWithValue("@numero_documento", numDoc);
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoPersonas pers = new Entidades.ListadoPersonas();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TiposPersonas tp = new TiposPersonas();
                    Entidades.Persona per = new Entidades.Persona();
                    per.Id = Convert.ToInt32(dr["id_persona"]);
                    per.Apellido = Convert.ToString(dr["apellido"]);
                    per.Nombre = Convert.ToString(dr["nombre"]);

                    per.Activo = Convert.ToBoolean(dr["activo"]);
                    per.Legajo = Convert.ToString(dr["legajo"]);
                    per.Email = Convert.ToString(dr["email"]);
                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
                    per.TipoPersona = tp.RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));

                    pers.Add(per);

                    per = null;
                }
                return pers;
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
                conn.Close();
                cmd.Dispose();
                pers = null;
            }
        }

        public ListadoPersonas RecuperarPersonaPorLegajo(string legajo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarPersonaPorLegajo";

            //agrego parametros
            cmd.Parameters.AddWithValue("@legajo", legajo);
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoPersonas pers = new Entidades.ListadoPersonas();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TiposPersona tp = new TiposPersonas().RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));
                    Entidades.Persona per = new Entidades.Persona();
                    per.Id = Convert.ToInt32(dr["id_persona"]);
                    per.Apellido = Convert.ToString(dr["apellido"]);
                    per.Nombre = Convert.ToString(dr["nombre"]);
                    per.Activo = Convert.ToBoolean(dr["activo"]);
                    per.Legajo = Convert.ToString(dr["legajo"]);
                    per.Email = Convert.ToString(dr["email"]);
                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
                    per.TipoPersona = tp;
                    pers.Add(per);

                    per = null;
                }
                return pers;
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
                conn.Close();
                cmd.Dispose();
                pers = null;
            }
        }

        public Entidades.ListadoPersonas RecuperarUno(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarPersona"; //Debería decir RecuperarAlumno
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id", id);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoPersonas pers = new Entidades.ListadoPersonas();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TiposPersona tp = new TiposPersonas().RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));
                    Entidades.Persona per = new Entidades.Persona();
                    per.Id = Convert.ToInt32(dr["id_persona"]);
                    per.Apellido = Convert.ToString(dr["apellido"]);
                    per.Nombre = Convert.ToString(dr["nombre"]);
                    per.Activo = Convert.ToBoolean(dr["activo"]);
                    per.Legajo = Convert.ToString(dr["legajo"]);
                    per.Email = Convert.ToString(dr["email"]);
                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
                    per.TipoPersona = tp;
                    pers.Add(per);

                    per = null;
                }
                return pers;
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
                pers = null;
            }
        }

        #endregion
    }
}