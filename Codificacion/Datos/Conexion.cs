using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    class Conexion
    {
        #region Miembros

        const string consKeyDefaultConnectionString = "Default";

        #endregion

        #region Metodos

        public static SqlConnection GetConexion()
        {
            SqlConnection dConn;
            string connectionString = "";
            try
            {
                //aca se obtiene el connectionstring desde la clase utilidades, ese key es esta constante
                connectionString = Configuracion.Configuracion.GetValue(consKeyDefaultConnectionString);
                dConn = new SqlConnection();
                dConn.ConnectionString = connectionString;
                return dConn;
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
                dConn = null;
            }

        }
        #endregion
    }
}
