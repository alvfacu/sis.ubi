using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Persona
    {
        #region Propiedades

        private string _Contraseña;
        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }

        private string _NombreUsuario;
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        private string _Apellido;
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private TiposPersona _TipoPersona;
        public TiposPersona TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

        private string _Legajo;
        public string Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }

        private bool _Activo;
        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        private double _NotaP1;
        public double NotaP1
        {
            get { return _NotaP1; }
            set { _NotaP1 = value; }
        }

        private double _NotaP2;
        public double NotaP2
        {
            get { return _NotaP2; }
            set { _NotaP2 = value; }
        }

        private double _NotaR1;

        public double NotaR1
        {
            get { return _NotaR1; }
            set { _NotaR1 = value; }
        }
        private double _NotaR2;
        public double NotaR2
        {
            get { return _NotaR2; }
            set { _NotaR2 = value; }
        }

        #endregion
    }
}
