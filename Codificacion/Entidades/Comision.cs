using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comision
    {
        private string _Descripcion;
        private int _IdComision;
        private int _IdMateria;
        private int _Anio;

        public int IdMateria
        {
            get { return _IdMateria; }
            set { _IdMateria = value; }
        }

        public int IdComision
        {
            get { return _IdComision; }
            set { _IdComision = value; }
        }

        public string DescripcionComision
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }


    }
}