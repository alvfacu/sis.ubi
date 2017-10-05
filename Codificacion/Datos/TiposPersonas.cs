using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class TiposPersonas
    {
        #region Propiedades

        private SqlConnection conn;

        #endregion

        #region Constructor

        public TiposPersonas()
        {
            conn = Conexion.GetConexion();
        }

        #endregion

        #region Metodos

        SqlCommand cmd = new SqlCommand();

        public Entidades.TiposPersona RecuperarUno(int id)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RecuperarTipoPersona";
            cmd.Connection = conn;

            //agrego parametros
            cmd.Parameters.AddWithValue("@id_tipo", id);

            //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
            //Entidades.ListadoEstados ests = new Entidades.ListadoEstados();
            Entidades.TiposPersona tp = new Entidades.TiposPersona();

            SqlDataReader dr;

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tp.IdTipoPersona = Convert.ToInt32(dr["id_tipo_persona"]);
                    tp.Descripcion = Convert.ToString(dr["descripcion_persona"]);
                }


                conn.Close();
                return tp;
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
                tp = null;
            }
        }

        //public Entidades.ListadoEstados RecuperarTodos()
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "RecuperarEstados";
        //    cmd.Connection = conn;

        //    //siempre se devuelve una coleccion para homogenaizar la forma de trabajo
        //    Entidades.ListadoEstados ests = new Entidades.ListadoEstados();

        //    SqlDataReader dr;

        //    try
        //    {
        //        conn.Open();
        //        dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            Entidades.Estado e = new Entidades.Estado();
        //            e.IdEstado = Convert.ToInt32(dr["id_estado"]);
        //            e.DescripcionEstado = Convert.ToString(dr["descripcion_estado"]);
        //            ests.Add(e);
        //            e = null;
        //        }
        //        cmd.Dispose();
        //        conn.Close();
        //        return ests;

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
        //        ests = null;
        //    }

        //}

        #endregion
    }
}
