using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TiposPersona
    {
        private int _IdTipoPersona;
        private string _Descripcion;

        public int IdTipoPersona
        {
            get { return _IdTipoPersona; }
            set { _IdTipoPersona = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
