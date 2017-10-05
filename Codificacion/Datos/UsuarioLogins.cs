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
    public class UsuarioLogins
    {
        #region Propiedades

        private SqlConnection conn;

        #endregion

        #region Constructor

        public UsuarioLogins()
        {
            //Se crea la conexion
            this.conn = Conexion.GetConexion();
        }

        #endregion

        #region Metodos

        public void Agregar(UsuarioLogin usr)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AgregarUsuarioLogin";
            cmd.Connection = conn;
            //como la clase persona es abstracta y no se puede instanciar
            //agrego todos los datos en alumnos y profesores dejando nulos los que corresponden

            //agrego parametros
            cmd.Parameters.AddWithValue("@ID_Persona", usr._ID_Persona);
            cmd.Parameters.AddWithValue("@Fecha_Login", usr._Fecha_Login);
            //cmd.Parameters.AddWithValue("@Fecha_Logout", usr._Fecha_Logout);
            cmd.Parameters.AddWithValue("@IP", usr._IP);

            //cmd.Parameters.AddWithValue("@Id", 0);

            //cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();

            //return Convert.ToInt32(cmd.Parameters["@Id"].Value);
        }

        public void Modificar(UsuarioLogin usr)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ModificarUsuarioLogin";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@IDUsuarioLogin", usr._ID_Persona);
            cmd.Parameters.AddWithValue("@Fecha_Logout", usr._Fecha_Logout);

            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();
        }


        public Entidades.ListadoUsuarioLogins RecuperarUsuarioLoginsActivos()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarUsuarioLoginsActivos";

            //agrego parametros
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoUsuarioLogins usrls = new Entidades.ListadoUsuarioLogins();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    UsuarioLogin usr = new UsuarioLogin();
                    usr._ID_Persona = Convert.ToInt32(dr["ID_Persona"]);
                    usr._Fecha_Login = Convert.ToDateTime(dr["Fecha_Login"]);
                    //usr._Fecha_Logout = Convert.ToDateTime(dr["Fecha_Logout"]);
                    usr._IP = Convert.ToString(dr["IP"]);
                    usrls.Add(usr);
                    usr = null;
                }

                conn.Close();
                return usrls;
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
                usrls = null;
            }
        }

        //public void Borrar(int id)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "BorrarPersona";
        //    cmd.Connection = conn;

        //    //agrego parametros
        //    cmd.Parameters.AddWithValue("@id", id);

        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    cmd.Dispose();
        //    conn.Close();
        //}

        //public Entidades.ListadoPersonas RecuperarPersonaPorNombreDeUsuario(string nomUsr)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "RecuperarPersonaPorNombreDeUsuario";

        //    //agrego parametros
        //    cmd.Parameters.AddWithValue("@usuario", nomUsr);
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
        //            //Planes p = new Planes();
        //            TiposPersonas tp = new TiposPersonas();
        //            Entidades.Persona per = new Entidades.Persona();
        //            per.Id = Convert.ToInt32(dr["id_persona"]);
        //            per.Apellido = Convert.ToString(dr["apellido"]);
        //            per.Nombre = Convert.ToString(dr["nombre"]);
        //            per.Telefono = Convert.ToString(dr["telefono"]);
        //            per.Direccion = Convert.ToString(dr["direccion"]);
        //            per.Email = Convert.ToString(dr["email"]);
        //            if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //            {
        //                per.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //            }
        //            per.NombreUsuario = Convert.ToString(dr["usuario"]);
        //            per.Contraseña = Convert.ToString(dr["contrasenia"]);
        //            per.TipoPersona = tp.RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));
        //            pers.Add(per);

        //            per = null;
        //        }
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
        //        conn.Close();
        //        cmd.Dispose();
        //        pers = null;
        //    }
        //}

        ////public Entidades.ListadoPersonas RecuperarPorTipoActivos(int IDTipoPs)
        ////{
        ////    SqlCommand cmd = new SqlCommand();
        ////    cmd.CommandType = CommandType.StoredProcedure;
        ////    cmd.CommandText = "RecuperarPersonasPorTipoActivos";

        ////    //agrego parametros
        ////    cmd.Parameters.AddWithValue("@id_tipo", IDTipoPs);
        ////    cmd.Connection = conn;

        ////    //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
        ////    Entidades.ListadoPersonas pers = new Entidades.ListadoPersonas();

        ////    SqlDataReader dr;

        ////    try
        ////    {
        ////        conn.Open();
        ////        dr = cmd.ExecuteReader();

        ////        while (dr.Read())
        ////        {
        ////            Planes p = new Planes();
        ////            Alumno alu = new Alumno();
        ////            Profesor prof = new Profesor();
        ////            TiposPersona tp = new TiposPersonas().RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));
        ////            Entidades.Persona per = new Entidades.Persona();
        ////            string TipoPersona = tp.Descripcion;
        ////            if (TipoPersona == "Alumno")
        ////            {
        ////                alu.Id = Convert.ToInt32(dr["id_persona"]);
        ////                alu.Apellido = Convert.ToString(dr["apellido"]);
        ////                alu.Nombre = Convert.ToString(dr["nombre"]);
        ////                alu.Activo = Convert.ToBoolean(dr["activo"]);
        ////                alu.Legajo = Convert.ToString(dr["legajo"]);
        ////                alu.Telefono = Convert.ToString(dr["telefono"]);
        ////                alu.Direccion = Convert.ToString(dr["direccion"]);
        ////                alu.Plan = p.RecuperarUno(Convert.ToInt32(dr["id_plan"]))[0];
        ////                pers.Add(alu);
        ////            }
        ////            else
        ////            {
        ////                if (TipoPersona == "Profesor")
        ////                {
        ////                    prof.Id = Convert.ToInt32(dr["id_persona"]);
        ////                    prof.Apellido = Convert.ToString(dr["apellido"]);
        ////                    prof.Nombre = Convert.ToString(dr["nombre"]);
        ////                    prof.Activo = Convert.ToBoolean(dr["activo"]);
        ////                    prof.Legajo = Convert.ToString(dr["legajo"]);
        ////                    prof.Telefono = Convert.ToString(dr["telefono"]);
        ////                    prof.Direccion = Convert.ToString(dr["direccion"]);
        ////                    pers.Add(prof);
        ////                }
        ////                else
        ////                {
        ////                    per.Id = Convert.ToInt32(dr["id_persona"]);
        ////                    per.Apellido = Convert.ToString(dr["apellido"]);
        ////                    per.Nombre = Convert.ToString(dr["nombre"]);
        ////                    per.Activo = Convert.ToBoolean(dr["activo"]);
        ////                    per.Legajo = Convert.ToString(dr["legajo"]);
        ////                    per.Telefono = Convert.ToString(dr["telefono"]);
        ////                    per.Direccion = Convert.ToString(dr["direccion"]);
        ////                    pers.Add(per);
        ////                }
        ////            }
        ////            per = null;
        ////        }

        ////        conn.Close();
        ////        return pers;

        ////    }
        ////    catch (SqlException ex)
        ////    {
        ////        throw new Exception("ERROR DB:" + ex.Message.ToString());
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        throw new Exception("ERROR:" + ex.Message.ToString());
        ////    }
        ////    finally
        ////    {
        ////        //limpio memoria 
        ////        pers = null;
        ////    }
        ////}

        //public Entidades.ListadoPersonas RecuperarTodos()
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "RecuperarPersonas";

        //    //agrego parametros
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
        //                alu.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //                {
        //                    alu.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                }
        //                alu.Activo = Convert.ToBoolean(dr["activo"]);
        //                alu.Legajo = Convert.ToString(dr["legajo"]);
        //                alu.Telefono = Convert.ToString(dr["telefono"]);
        //                alu.Direccion = Convert.ToString(dr["direccion"]);
        //                alu.Email = Convert.ToString(dr["email"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                {
        //                    alu.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                }
        //                alu.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                alu.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_ingreso"])))
        //                {
        //                    alu.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                }
        //                alu.TipoPersona = tp;
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
        //                    prof.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //                    {
        //                        prof.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                    }
        //                    prof.Activo = Convert.ToBoolean(dr["activo"]);
        //                    prof.Legajo = Convert.ToString(dr["legajo"]);
        //                    prof.Telefono = Convert.ToString(dr["telefono"]);
        //                    prof.Direccion = Convert.ToString(dr["direccion"]);
        //                    prof.Email = Convert.ToString(dr["email"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                    {
        //                        prof.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                    }
        //                    prof.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                    prof.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_ingreso"])))
        //                    {
        //                        prof.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                    }
        //                    prof.TipoPersona = tp;

        //                    prof.Titulo = Convert.ToString(dr["titulo"]);
        //                    pers.Add(prof);
        //                }
        //                else
        //                {
        //                    per.Id = Convert.ToInt32(dr["id_persona"]);
        //                    per.Apellido = Convert.ToString(dr["apellido"]);
        //                    per.Nombre = Convert.ToString(dr["nombre"]);
        //                    per.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //                    {
        //                        per.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                    }
        //                    per.Activo = Convert.ToBoolean(dr["activo"]);
        //                    per.Legajo = Convert.ToString(dr["legajo"]);
        //                    per.Telefono = Convert.ToString(dr["telefono"]);
        //                    per.Direccion = Convert.ToString(dr["direccion"]);
        //                    per.Email = Convert.ToString(dr["email"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                    {
        //                        per.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                    }
        //                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_ingreso"])))
        //                    {
        //                        per.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                    }
        //                    per.TipoPersona = tp;
        //                    pers.Add(per);
        //                }
        //            }
        //            per = null;
        //        }
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
        //        conn.Close();
        //        cmd.Dispose();
        //        pers = null;
        //    }
        //}

        //public Entidades.ListadoPersonas RecuperarTodos(bool activo)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "RecuperarPersonasActivo";

        //    //agrego parametros
        //    cmd.Parameters.AddWithValue("@activo", activo);
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
        //                alu.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //                {
        //                    alu.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                }
        //                alu.Activo = Convert.ToBoolean(dr["activo"]);
        //                alu.Legajo = Convert.ToString(dr["legajo"]);
        //                alu.Telefono = Convert.ToString(dr["telefono"]);
        //                alu.Direccion = Convert.ToString(dr["direccion"]);
        //                alu.Email = Convert.ToString(dr["email"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                {
        //                    alu.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                }
        //                alu.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                alu.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_ingreso"])))
        //                {
        //                    alu.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                }
        //                alu.TipoPersona = tp;
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
        //                    prof.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //                    {
        //                        prof.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                    }
        //                    prof.Activo = Convert.ToBoolean(dr["activo"]);
        //                    prof.Legajo = Convert.ToString(dr["legajo"]);
        //                    prof.Telefono = Convert.ToString(dr["telefono"]);
        //                    prof.Direccion = Convert.ToString(dr["direccion"]);
        //                    prof.Email = Convert.ToString(dr["email"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                    {
        //                        prof.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                    }
        //                    prof.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                    prof.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_ingreso"])))
        //                    {
        //                        prof.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                    }
        //                    prof.TipoPersona = tp;

        //                    prof.Titulo = Convert.ToString(dr["titulo"]);
        //                    pers.Add(prof);
        //                }
        //                else
        //                {
        //                    per.Id = Convert.ToInt32(dr["id_persona"]);
        //                    per.Apellido = Convert.ToString(dr["apellido"]);
        //                    per.Nombre = Convert.ToString(dr["nombre"]);
        //                    per.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //                    {
        //                        per.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                    }
        //                    per.Activo = Convert.ToBoolean(dr["activo"]);
        //                    per.Legajo = Convert.ToString(dr["legajo"]);
        //                    per.Telefono = Convert.ToString(dr["telefono"]);
        //                    per.Direccion = Convert.ToString(dr["direccion"]);
        //                    per.Email = Convert.ToString(dr["email"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                    {
        //                        per.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                    }
        //                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_ingreso"])))
        //                    {
        //                        per.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                    }
        //                    per.TipoPersona = tp;
        //                    pers.Add(per);
        //                }
        //            }
        //            per = null;
        //        }
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
        //        conn.Close();
        //        cmd.Dispose();
        //        pers = null;
        //    }
        //}

        //public ListadoPersonas RecuperarPersonaPorNumeroDocumento(int numDoc)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "RecuperarPersonaPorNumeroDocumento";

        //    //agrego parametros
        //    cmd.Parameters.AddWithValue("@numero_documento", numDoc);
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
        //            TiposPersonas tp = new TiposPersonas();
        //            Entidades.Persona per = new Entidades.Persona();
        //            per.Id = Convert.ToInt32(dr["id_persona"]);
        //            per.Apellido = Convert.ToString(dr["apellido"]);
        //            per.Nombre = Convert.ToString(dr["nombre"]);
        //            per.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //            if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //            {
        //                per.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //            }
        //            per.Activo = Convert.ToBoolean(dr["activo"]);
        //            per.Legajo = Convert.ToString(dr["legajo"]);
        //            per.Telefono = Convert.ToString(dr["telefono"]);
        //            per.Direccion = Convert.ToString(dr["direccion"]);
        //            per.Email = Convert.ToString(dr["email"]);
        //            if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //            {
        //                per.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //            }
        //            per.NombreUsuario = Convert.ToString(dr["usuario"]);
        //            per.Contraseña = Convert.ToString(dr["contrasenia"]);
        //            per.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //            per.TipoPersona = tp.RecuperarUno(Convert.ToInt32(dr["id_tipo_persona"]));

        //            if (per.TipoPersona.Descripcion == "Alumno")
        //            {
        //                alu.Plan = p.RecuperarUno(Convert.ToInt32(dr["id_plan"]))[0];
        //                pers.Add(alu);
        //            }
        //            else
        //            {
        //                if (per.TipoPersona.Descripcion == "Profesor")
        //                {
        //                    prof.Titulo = Convert.ToString(dr["titulo"]);
        //                    pers.Add(prof);
        //                }
        //            }
        //            pers.Add(per);

        //            per = null;
        //        }
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
        //        conn.Close();
        //        cmd.Dispose();
        //        pers = null;
        //    }
        //}

        //public ListadoPersonas RecuperarPersonaPorLegajo(string legajo)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "RecuperarPersonaPorLegajo";

        //    //agrego parametros
        //    cmd.Parameters.AddWithValue("@legajo", legajo);
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
        //                alu.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                alu.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                alu.Activo = Convert.ToBoolean(dr["activo"]);
        //                alu.Legajo = Convert.ToString(dr["legajo"]);
        //                alu.Telefono = Convert.ToString(dr["telefono"]);
        //                alu.Direccion = Convert.ToString(dr["direccion"]);
        //                alu.Email = Convert.ToString(dr["email"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                {
        //                    alu.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                }
        //                alu.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                alu.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                alu.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                alu.TipoPersona = tp;
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
        //                    prof.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                    prof.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                    prof.Activo = Convert.ToBoolean(dr["activo"]);
        //                    prof.Legajo = Convert.ToString(dr["legajo"]);
        //                    prof.Telefono = Convert.ToString(dr["telefono"]);
        //                    prof.Direccion = Convert.ToString(dr["direccion"]);
        //                    prof.Email = Convert.ToString(dr["email"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                    {
        //                        prof.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                    }
        //                    prof.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                    prof.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                    prof.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                    prof.TipoPersona = tp;

        //                    prof.Titulo = Convert.ToString(dr["titulo"]);
        //                    pers.Add(prof);
        //                }
        //                else
        //                {
        //                    per.Id = Convert.ToInt32(dr["id_persona"]);
        //                    per.Apellido = Convert.ToString(dr["apellido"]);
        //                    per.Nombre = Convert.ToString(dr["nombre"]);
        //                    per.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                    per.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                    per.Activo = Convert.ToBoolean(dr["activo"]);
        //                    per.Legajo = Convert.ToString(dr["legajo"]);
        //                    per.Telefono = Convert.ToString(dr["telefono"]);
        //                    per.Direccion = Convert.ToString(dr["direccion"]);
        //                    per.Email = Convert.ToString(dr["email"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                    {
        //                        per.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                    }
        //                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                    per.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                    per.TipoPersona = tp;
        //                    pers.Add(per);
        //                }
        //            }
        //            per = null;
        //        }
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
        //        conn.Close();
        //        cmd.Dispose();
        //        pers = null;
        //    }
        //}

        //public Entidades.ListadoPersonas RecuperarUno(int id)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "RecuperarPersona"; //Debería decir RecuperarAlumno
        //    cmd.Connection = conn;

        //    //agrego parametros
        //    cmd.Parameters.AddWithValue("@id", id);

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
        //                alu.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //                {
        //                    alu.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                }
        //                alu.Activo = Convert.ToBoolean(dr["activo"]);
        //                alu.Legajo = Convert.ToString(dr["legajo"]);
        //                alu.Telefono = Convert.ToString(dr["telefono"]);
        //                alu.Direccion = Convert.ToString(dr["direccion"]);
        //                alu.Email = Convert.ToString(dr["email"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                {
        //                    alu.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                }
        //                alu.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                alu.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_ingreso"])))
        //                {
        //                    alu.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                }
        //                alu.TipoPersona = tp;
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
        //                    prof.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //                    {
        //                        prof.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                    }
        //                    prof.Activo = Convert.ToBoolean(dr["activo"]);
        //                    prof.Legajo = Convert.ToString(dr["legajo"]);
        //                    prof.Telefono = Convert.ToString(dr["telefono"]);
        //                    prof.Direccion = Convert.ToString(dr["direccion"]);
        //                    prof.Email = Convert.ToString(dr["email"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                    {
        //                        prof.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                    }
        //                    prof.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                    prof.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_ingreso"])))
        //                    {
        //                        prof.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                    }
        //                    prof.TipoPersona = tp;
        //                    prof.Titulo = Convert.ToString(dr["titulo"]);
        //                    pers.Add(prof);
        //                }
        //                else
        //                {
        //                    per.Id = Convert.ToInt32(dr["id_persona"]);
        //                    per.Apellido = Convert.ToString(dr["apellido"]);
        //                    per.Nombre = Convert.ToString(dr["nombre"]);
        //                    per.TipoDocumento = Convert.ToString(dr["tipo_documento"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["nro_documento"])))
        //                    {
        //                        per.NumeroDocumento = Convert.ToInt32(dr["nro_documento"]);
        //                    }
        //                    per.Activo = Convert.ToBoolean(dr["activo"]);
        //                    per.Legajo = Convert.ToString(dr["legajo"]);
        //                    per.Telefono = Convert.ToString(dr["telefono"]);
        //                    per.Direccion = Convert.ToString(dr["direccion"]);
        //                    per.Email = Convert.ToString(dr["email"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_nacimiento"])))
        //                    {
        //                        per.FechaNacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
        //                    }
        //                    per.NombreUsuario = Convert.ToString(dr["usuario"]);
        //                    per.Contraseña = Convert.ToString(dr["contrasenia"]);
        //                    if (!string.IsNullOrEmpty(Convert.ToString(dr["fecha_ingreso"])))
        //                    {
        //                        per.FechaIngreso = Convert.ToDateTime(dr["fecha_ingreso"]);
        //                    }
        //                    per.TipoPersona = tp;
        //                    pers.Add(per);
        //                }
        //            }
        //            per = null;
        //        }
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

        #endregion
    }
}
