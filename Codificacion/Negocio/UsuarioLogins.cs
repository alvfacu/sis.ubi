using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioLogins
    {
        #region Propiedades
        Datos.UsuarioLogins usrl;
        #endregion

        #region Constructor
        public UsuarioLogins()
        {
            usrl = new Datos.UsuarioLogins();
        }
        #endregion

        #region Metodos

        //public void Borrar(int id)
        //{
        //    usrl.Borrar(id);
        //}

        //public void Modificar(Entidades.Persona per, Entidades.Profesor prof, Entidades.Alumno alum)
        //{
        //    usrl.Modificar(per, prof, alum);
        //}

        public void Agregar(Entidades.UsuarioLogin usr)
        {
            usrl.Agregar(usr);
        }

        //public Entidades.ListadoPersonas RecuperarTodos()
        //{
        //    return usrl.RecuperarTodos();
        //}

        //public Entidades.ListadoPersonas RecuperarTodos(bool activo)
        //{
        //    return usrl.RecuperarTodos(activo);
        //}

        //public Entidades.ListadoPersonas RecuperarUno(int IdPersona)
        //{
        //    return usrl.RecuperarUno(IdPersona);
        //}
        //public Entidades.ListadoPersonas RecuperarPorNombreDeUsuario(string userName)
        //{
        //    return usrl.RecuperarPersonaPorNombreDeUsuario(userName);
        //}

        //public Entidades.ListadoPersonas RecuperarPorNumeroDocumento(int numDoc)
        //{
        //    return usrl.RecuperarPersonaPorNumeroDocumento(numDoc);
        //}

        //public Entidades.ListadoPersonas RecuperarPorLegajo(string legajo)
        //{
        //    return usrl.RecuperarPersonaPorLegajo(legajo);
        //}

        //public Entidades.ListadoPersonas RecuperarPorTipoPersona(int tipoPs, bool activo)
        //{
        //    return usrl.RecuperarPorTipo(tipoPs, activo);
        //}

        ////public Entidades.ListadoPersonas RecuperarPorTipoPersonaActivos(int tipoPs)
        ////{
        ////    return pers.RecuperarPorTipoActivos(tipoPs);
        ////}

        //public Entidades.ListadoPersonas Autenticar(string NomUsuario, string Clave)
        //{
        //    Entidades.ListadoPersonas personas = new Entidades.ListadoPersonas();
        //    personas = RecuperarPorNombreDeUsuario(NomUsuario);

        //    if (personas.Count > 0)
        //    {
        //        if (personas[0].Contraseña == Clave)
        //        {
        //            return personas;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        #endregion
    }
}