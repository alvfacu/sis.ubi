using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia
    {
        private int _IdMateria;
        private string _Descripcion;

        public int IdMateria
        {
            get { return _IdMateria; }
            set { _IdMateria = value; }
        }

        public string DescripcionMateria
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
