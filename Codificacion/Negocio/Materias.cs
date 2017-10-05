using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Materias
    {
        #region Propiedades
        private Datos.Materias mats;
        #endregion

        #region Constructor
        public Materias()
        {
            mats = new Datos.Materias();
        }
        #endregion

        #region Metodos

        public void Agregar(Entidades.Materia mat)
        {
            mats.Agregar(mat);
        }

        public void Modificar(Entidades.Materia mat)
        {
            mats.Modificar(mat);
        }

        public void Borrar(int id)
        {
            mats.Borrar(id);
        }

        public Entidades.ListadoMaterias RecuperarUno(int id)
        {
            return mats.RecuperarUno(id);
        }

        public Entidades.ListadoMaterias RecuperarPorIdPlan(int idPlan)
        {
            return mats.RecuperarPorIdPlan(idPlan);
        }

        public Entidades.ListadoMaterias RecuperarMateriaPorDescripcion(string descMateria)
        {
            return mats.RecuperarMateriaPorDescripcion(descMateria);
        }

        public Entidades.ListadoMaterias RecuperarTodos()
        {
            return mats.RecuperarTodos();
        }


        #endregion
    }
}
