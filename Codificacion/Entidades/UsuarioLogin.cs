using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioLogin
    {
        private int IDUsuarioLogin;

        public int _IDUsuarioLogin
        {
            get { return IDUsuarioLogin; }
            set { IDUsuarioLogin = value; }
        }

        int ID_Persona;

        public int _ID_Persona
        {
            get { return ID_Persona; }
            set { ID_Persona = value; }
        }

        private DateTime Fecha_Login;

        public DateTime _Fecha_Login
        {
            get { return Fecha_Login; }
            set { Fecha_Login = value; }
        }

        private DateTime Fecha_Logout;

        public DateTime _Fecha_Logout
        {
            get { return Fecha_Logout; }
            set { Fecha_Logout = value; }
        }

        private string IP;

        public string _IP
        {
            get { return IP; }
            set { IP = value; }
        }

        private Persona per;

        public Persona _per
        {
            get { return per; }
            set { per = value; }
        }
    }
}