using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Materias
    {
        #region Propiedades

        private SqlConnection conn;

        #endregion

        #region Constructor

        public Materias()
        {
            conn = Conexion.GetConexion();
        }

        #endregion

        #region Metodos

        public void Agregar(Entidades.Materia mat)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AgregarMateria";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@desc_materia", mat.DescripcionMateria);

            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
        }

        public void Modificar(Entidades.Materia mat)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ModificarMateria";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id_materia", mat.IdMateria);
            cmd.Parameters.AddWithValue("@desc_materia", mat.DescripcionMateria);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Borrar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BorrarMateria";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id_materia", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Entidades.ListadoMaterias RecuperarUno(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarMateria";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id_materia", id);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoMaterias mats = new Entidades.ListadoMaterias();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Materia m = new Entidades.Materia();
                    m.IdMateria = Convert.ToInt32(dr["id_materia"]);
                    m.DescripcionMateria = Convert.ToString(dr["descripcion_materia"]);
                    mats.Add(m);

                    m = null;
                }
                conn.Close();
                return mats;
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
                mats = null;
            }
        }
        public Entidades.ListadoMaterias RecuperarPorIdPlan(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarMateriasPorIdPlan";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id_plan", id);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoMaterias mats = new Entidades.ListadoMaterias();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Materia m = new Entidades.Materia();
                    m.IdMateria = Convert.ToInt32(dr["id_materia"]);
                    m.DescripcionMateria = Convert.ToString(dr["descripcion_materia"]);
                    mats.Add(m);

                    m = null;
                }
                conn.Close();
                return mats;
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
                mats = null;
            }
        }

        public Entidades.ListadoMaterias RecuperarMateriaPorDescripcion(string descMateria)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarMateriaPorDescripcion";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@descripcion_materia", descMateria);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoMaterias mats = new Entidades.ListadoMaterias();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Materia m = new Entidades.Materia();
                    m.IdMateria = Convert.ToInt32(dr["id_materia"]);
                    m.DescripcionMateria = Convert.ToString(dr["descripcion_materia"]);
                    mats.Add(m);

                    m = null;
                }
                conn.Close();
                return mats;
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
                mats = null;
            }

        }

        public Entidades.ListadoMaterias RecuperarTodos()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarMaterias";
            cmd.Connection = conn;

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            Entidades.ListadoMaterias mats = new Entidades.ListadoMaterias();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entidades.Materia m = new Entidades.Materia();
                    m.IdMateria = Convert.ToInt32(dr["id_materia"]);
                    m.DescripcionMateria = Convert.ToString(dr["descripcion_materia"]);
                    mats.Add(m);
                    m = null;
                }
                cmd.Dispose();
                conn.Close();
                return mats;

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
                mats = null;
            }
        }
        #endregion
    }
}