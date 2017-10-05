using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;


namespace Configuracion
{
    public class Configuracion
    {
        #region Metodos

        private static Configuration GetConfiguracion()
        {
            string path;//archivo de configuracion
            Configuration config;

            //se ve si se esta usando web o widows
            if (System.Web.HttpContext.Current == null)
            {
                path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName);
                //se abre configuracion win
                config = System.Configuration.ConfigurationManager.OpenExeConfiguration(path);
            }
            else
            {
                path = System.Web.HttpContext.Current.Request.ApplicationPath.ToString();
                //se abre configuracion web
                config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(path);
            }

            return config;
        }

        public static string GetValue(string key)
        {
            string value;
            Configuration config;

            try
            {
                config = GetConfiguracion();

                try
                {
                    value = config.AppSettings.Settings[key].Value;
                }
                catch (Exception)
                {
                    throw new Exception(String.Format("Error la clave {0} no existe", key));
                }
                return value;

            }

            finally
            {
                config = null;
            }
        }

        #endregion

        #region Enumeradores

        public enum TipoOperacion
        {
            Alta = 0,
            Edicion = 1
        }

        #endregion

        #region Propiedades

        private Configuracion.TipoOperacion m_Operacion;
        public Configuracion.TipoOperacion Operacion
        {
            get
            {
                return m_Operacion;
            }
            set
            {
                m_Operacion = value;
            }
        }

        #endregion

    }
}
