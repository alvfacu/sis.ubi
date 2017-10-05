using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Entidades
{
    public class Archivo
    {
        private int _IDArchivo;
        public int IDArchivo
        {
            get { return _IDArchivo; }
            set { _IDArchivo = value; }
        }

        private string _NombreArchivo;
        public string NombreArchivo
        {
            get { return _NombreArchivo; }
            set { _NombreArchivo = value; }
        }

        private string _UbicacionArchivo;
        public string UbicacionArchivo
        {
            get { return _UbicacionArchivo; }
            set { _UbicacionArchivo = value; }
        }

        private DateTime _FechaArchivo;
        public DateTime FechaArchivo
        {
            get { return _FechaArchivo; }
            set { _FechaArchivo = value; }
        }

        private DateTime _FechaHoraInicio;
        public DateTime FechaHoraInicio
        {
            get { return _FechaHoraInicio; }
            set { _FechaHoraInicio = value; }
        }

        private DateTime _FechaHoraFin;
        public DateTime FechaHoraFin
        {
            get { return _FechaHoraFin; }
            set { _FechaHoraFin = value; }
        }

        private string _IP;
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        private double _CoordenadaLatitud;
        public double CoordenadaLatitud
        {
            get { return _CoordenadaLatitud; }
            set { _CoordenadaLatitud = value; }
        }

        private double _CoordenadaLongitud;
        public double CoordenadaLongitud
        {
            get { return _CoordenadaLongitud; }
            set { _CoordenadaLongitud = value; }
        }

        private double _Radio;
        public double Radio
        {
            get { return _Radio; }
            set { _Radio = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _IDTipo;

        public int IDTipo
        {
            get { return _IDTipo; }
            set { _IDTipo = value; }
        }

        private string _DescripcionTipo;

        public string DescripcionTipo
        {
            get { return _DescripcionTipo; }
            set { _DescripcionTipo = value; }
        }
    }
}