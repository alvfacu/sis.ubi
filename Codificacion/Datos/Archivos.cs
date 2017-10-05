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
    public class Archivos
    {
        #region Propiedades

        private SqlConnection conn;

        #endregion

        #region Constructor

        public Archivos()
        {
            conn = Conexion.GetConexion();
        }

        #endregion

        #region Metodos
                
        public void Agregar(Entidades.Archivo arch)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AgregarArchivo";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@nom_archivo", arch.NombreArchivo);
            cmd.Parameters.AddWithValue("@ubicacion_archivo", arch.UbicacionArchivo);
            cmd.Parameters.AddWithValue("@fec_archivo", arch.FechaArchivo);
            cmd.Parameters.AddWithValue("@fechora_ini", arch.FechaHoraInicio);
            cmd.Parameters.AddWithValue("@fechora_fin", arch.FechaHoraFin);
            cmd.Parameters.AddWithValue("@ip", arch.IP);
            cmd.Parameters.AddWithValue("@latitud_archivo", arch.CoordenadaLatitud);
            cmd.Parameters.AddWithValue("@longitud_archivo", arch.CoordenadaLongitud);
            cmd.Parameters.AddWithValue("@radio", arch.Radio);
            cmd.Parameters.AddWithValue("@descripcion", arch.Descripcion);
            cmd.Parameters.AddWithValue("@tipo", arch.IDTipo);
            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();
        }

        public ListadoArchivos RecuperarTodosPorAlumno(int idPersona)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarArchivosPorAlumno";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@id", idPersona);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoArchivos archivos = new Entidades.ListadoArchivos();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Archivo arch = new Archivo();
                    arch.IDArchivo = Convert.ToInt32(dr["IDArchivo"]);
                    arch.NombreArchivo = Convert.ToString(dr["NombreArchivo"]);
                    arch.UbicacionArchivo = Convert.ToString(dr["UbicacionArchivo"]);
                    arch.FechaArchivo = Convert.ToDateTime(dr["FechaArchivo"]).Date;
                    arch.FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]);
                    arch.FechaHoraFin = Convert.ToDateTime(dr["FechaHoraFin"]);
                    arch.IP = Convert.ToString(dr["IP"]);
                    arch.CoordenadaLatitud = Convert.ToDouble(dr["CoordenadaLatitud"]);
                    arch.CoordenadaLongitud = Convert.ToDouble(dr["CoordenadaLongitud"]);
                    arch.Radio = Convert.ToDouble(dr["Radio"]);
                    arch.Descripcion = Convert.ToString(dr["Descripcion"]);
                    arch.IDTipo = Convert.ToInt32(dr["IDTipo"]);
                    arch.DescripcionTipo = Convert.ToString(dr["descripcion"]);
                    archivos.Add(arch);
                }
                cmd.Dispose();
                conn.Close();
                return archivos;

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
                archivos = null;
            }
        }

        public ListadoArchivos RecuperarTodosPorAlumnoPorTipo(int idTipo, int idPersona)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarArchivosPorAlumnoPorTipo";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@id", idPersona);
            cmd.Parameters.AddWithValue("@idtipo", idTipo);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoArchivos archivos = new Entidades.ListadoArchivos();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Archivo arch = new Archivo();
                    arch.IDArchivo = Convert.ToInt32(dr["IDArchivo"]);
                    arch.NombreArchivo = Convert.ToString(dr["NombreArchivo"]);
                    arch.UbicacionArchivo = Convert.ToString(dr["UbicacionArchivo"]);
                    arch.FechaArchivo = Convert.ToDateTime(dr["FechaArchivo"]).Date;
                    arch.FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]);
                    arch.FechaHoraFin = Convert.ToDateTime(dr["FechaHoraFin"]);
                    arch.IP = Convert.ToString(dr["IP"]);
                    arch.CoordenadaLatitud = Convert.ToDouble(dr["CoordenadaLatitud"]);
                    arch.CoordenadaLongitud = Convert.ToDouble(dr["CoordenadaLongitud"]);
                    arch.Radio = Convert.ToDouble(dr["Radio"]);
                    arch.Descripcion = Convert.ToString(dr["Descripcion"]);
                    arch.IDTipo = Convert.ToInt32(dr["IDTipo"]);
                    arch.DescripcionTipo = Convert.ToString(dr["descripcion"]);
                    archivos.Add(arch);
                }
                cmd.Dispose();
                conn.Close();
                return archivos;

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
                archivos = null;
            }
        }

        public void ModificarArchivoComision(int idComision, int iDArchivo, int nuevaComision)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ModificarArchivoComision";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@idComViejo", idComision);
            cmd.Parameters.AddWithValue("@idArchivo", iDArchivo);
            cmd.Parameters.AddWithValue("@idComNuevo", nuevaComision);

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        
        public void AgregarArchivoComision(int idCom, int idArch)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AgregarArchivoComision";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@IdArchivo", idArch);
            cmd.Parameters.AddWithValue("@IdComision", idCom);
            conn.Open();
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();
        }

        public int DameUltId()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarUltimoID";
            cmd.Connection = conn;
            
            SqlDataReader dr;
            
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                int ultimo = 0;
                if (dr.Read())
                {
                    ultimo = Convert.ToInt32(dr["id"]);
                }
                cmd.Dispose();
                conn.Close();
                return ultimo;

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
            }
        }

        public void Modificar(Entidades.Archivo arch)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ModificarArchivo";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@idarchivo",arch.IDArchivo);
            cmd.Parameters.AddWithValue("@fec_archivo",arch.FechaArchivo);
            cmd.Parameters.AddWithValue("@fechora_ini",arch.FechaHoraInicio);
            cmd.Parameters.AddWithValue("@fechora_fin",arch.FechaHoraFin);
            cmd.Parameters.AddWithValue("@ip", arch.IP);
            cmd.Parameters.AddWithValue("@latitud_archivo", arch.CoordenadaLatitud);
            cmd.Parameters.AddWithValue("@longitud_archivo", arch.CoordenadaLongitud);
            cmd.Parameters.AddWithValue("@radio", arch.Radio);
            cmd.Parameters.AddWithValue("@descripcion", arch.Descripcion);

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose(); 
            conn.Close();
        }

        public void Borrar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BorrarArchivo";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        public Entidades.ListadoArchivos RecuperarTodos()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarArchivos";
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoArchivos archivos = new Entidades.ListadoArchivos();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Archivo arch = new Archivo();
                    arch.IDArchivo = Convert.ToInt32(dr["IDArchivo"]);
                    arch.NombreArchivo = Convert.ToString(dr["NombreArchivo"]);
                    arch.UbicacionArchivo = Convert.ToString(dr["UbicacionArchivo"]);
                    arch.FechaArchivo = Convert.ToDateTime(dr["FechaArchivo"]).Date;
                    arch.FechaHoraInicio = Convert.ToDateTime(dr["FechaHoraInicio"]);
                    arch.FechaHoraFin = Convert.ToDateTime(dr["FechaHoraFin"]);
                    arch.IP = Convert.ToString(dr["IP"]);
                    arch.CoordenadaLatitud = Convert.ToDouble(dr["CoordenadaLatitud"]);
                    arch.CoordenadaLongitud = Convert.ToDouble(dr["CoordenadaLongitud"]);
                    arch.Radio = Convert.ToDouble(dr["Radio"]);
                    arch.Descripcion = Convert.ToString(dr["Descripcion"]);
                    arch.IDTipo = Convert.ToInt32(dr["IDTipo"]);
                    arch.DescripcionTipo = Convert.ToString(dr["descripcion"]);
                    archivos.Add(arch);
                }
                cmd.Dispose();
                conn.Close();
                return archivos;

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
                archivos = null;
            }
        }

        #endregion
    }
}
