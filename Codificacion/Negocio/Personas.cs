using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Web.UI.WebControls;
using System.Data;

namespace Negocio
{
    public class Personas
    {
        #region Propiedades
        Datos.Personas pers;
        #endregion

        #region Constructor
        public Personas()
        {
            pers = new Datos.Personas();
        }
        #endregion

        #region Metodos

        public void Borrar(int id)
        {
            pers.Borrar(id);
        }

        public void Modificar(Entidades.Persona per)
        {
            pers.Modificar(per);
        }

        public DataTable RecuperarNotas(int id)
        {
            return pers.RecuperarNotas(id);
        }

        public void Agregar(Entidades.Persona per)
        {
            pers.Agregar(per);
        }

        public Entidades.ListadoPersonas RecuperarTodos()
        {
            return pers.RecuperarTodos();
        }

        public Entidades.ListadoPersonas RecuperarTodos(bool activo)
        {
            return pers.RecuperarTodos(activo);
        }

        public Entidades.ListadoPersonas RecuperarUno(int IdPersona)
        {
            return pers.RecuperarUno(IdPersona);
        }
        public Entidades.ListadoPersonas RecuperarPorNombreDeUsuario(string userName)
        {
            return pers.RecuperarPersonaPorNombreDeUsuario(userName);
        }

        public Entidades.ListadoPersonas RecuperarPorNumeroDocumento(int numDoc)
        {
            return pers.RecuperarPersonaPorNumeroDocumento(numDoc);
        }

        public ListadoPersonas RecuperarTodosXComision(string com)
        {
            return pers.RecuperarTodosXComision(com);
        }

        public Entidades.ListadoPersonas RecuperarPorLegajo(string legajo)
        {
            return pers.RecuperarPersonaPorLegajo(legajo);
        }

        public Entidades.ListadoPersonas RecuperarPorTipoPersona(int tipoPs, bool activo)
        {
            return pers.RecuperarPorTipo(tipoPs, activo);
        }

        public Entidades.ListadoPersonas Autenticar(string NomUsuario, string Clave)
        {
            Entidades.ListadoPersonas personas = new Entidades.ListadoPersonas();
            personas = RecuperarPorNombreDeUsuario(NomUsuario.Trim());

            string Pass = Seguridad.MD5Hash(Clave.Trim());

            if (personas.Count > 0)
            {
                if (personas[0].Contraseña == Pass)
                {
                    return personas;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void ModificarNotas(string Comi, string ID, string NotaP1, string NotaP2, string NotaR1, string NotaR2)
        {
            pers.ModificarNotas(Comi, ID, NotaP1, NotaP2, NotaR1, NotaR2);
        }

        public void AgregarNuevoAlumnoAComision(string Comi, string Legajo, string Nombre, string Apellido, string NotaP1, string NotaP2, string NotaR1, string NotaR2)
        {
            pers.AgregarNuevoAlumnoAComision(Comi,Legajo,Nombre,Apellido,NotaP1,NotaP2,NotaR1,NotaR2);
        }

        public bool Existe(Persona per)
        {
            ListadoPersonas personas = pers.RecuperarTodos();
            Persona perso = personas.Find(x => x.Legajo == per.Legajo);
            if (perso != null)
                return true;
            else
                return false;
        }
        #endregion
    }
}