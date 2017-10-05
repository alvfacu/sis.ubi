using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Comisiones
    {
        #region Propiedades
        private Datos.Comisiones coms;
        #endregion

        #region Constructor
        public Comisiones()
        {
            coms = new Datos.Comisiones();
        }
        #endregion

        #region Metodos
        public void Agregar(Entidades.Comision com)
        {
            coms.Agregar(com);
        }

        public void Modificar(Entidades.Comision com)
        {
            coms.Modificar(com);
        }

        public void Borrar(int id)
        {
            coms.Borrar(id);
        }

        public ListadoComisiones RecuperarUno(int id)
        {
            return coms.RecuperarUno(id);
        }

        public List<Comision> RecuperarComisionPorDescripcion(string descComision)
        {
            return coms.RecuperarComisionPorDescripcion(descComision);
        }

        public List<Comision> RecuperarPorIdPlan(int idPlan)
        {
            return coms.RecuperarPorIdPlan(idPlan);
        }

        public List<Comision> RecuperarTodos()
        {
            return coms.RecuperarTodos();
        }

        public ListadoComisiones RecuperarPorIdMateria(int idMat)
        {
            return coms.RecuperarPorIdMateria(idMat);
        }

        public Comision RecuperarUnoPorIDArchivo(int iDArchivo)
        {
            return coms.RecuperarComisionPorIDArchivo(iDArchivo);
        }

        public DataTable RecuperarTodosComisionesPersonas()
        {
            return coms.RecuperarTodosComisionesPersonas();
        }

        public void AgregarAlumnoAComision(string idpersona, string idcomision, string notap1, string notap2, string notar1, string notar2)
        {
            coms.AgregarAlumnoAComision(idpersona, idcomision, notap1, notap2, notar1, notar2);
        }

        public void EliminarAlumnoEnComision(string idpersona, string idcomision)
        {
            coms.EliminarAlumnoEnComision(idpersona,idcomision);
        }
        #endregion
    }
}
