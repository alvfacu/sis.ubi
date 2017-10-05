using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;


namespace Negocio
{
    public class Archivos
    {
        #region Propiedades
        private Datos.Archivos archs;
        #endregion

        #region Constructor
        public Archivos()
        {
            archs = new Datos.Archivos();
        }
        #endregion

        #region Metodos
        public void Agregar(Entidades.Archivo arch)
        {
            archs.Agregar(arch);
        }

        public void Modificar(Entidades.Archivo arch)
        {
            archs.Modificar(arch);
        }

        public void Borrar(int id)
        {
            archs.Borrar(id);
        }

        public Entidades.ListadoArchivos RecuperarTodos()
        {
            return archs.RecuperarTodos();
        }

        public void AgregarArchivoComision(int idComision, int idArchivo)
        {
            archs.AgregarArchivoComision(idComision, idArchivo);
        }

        public int DameUltId()
        {
            return archs.DameUltId();
        }

        public void ModificarArchivoComision(int idComision, int iDArchivo, int nuevaComision)
        {
            archs.ModificarArchivoComision(idComision, iDArchivo, nuevaComision);
        }

        public ListadoArchivos RecuperarTodosPorAlumno(int idPersona, double latitud, double longitud, string iP, DateTime fechaHora)
        {
            ListadoArchivos archivos = archs.RecuperarTodosPorAlumno(idPersona);
            return RecuperarArchivosPermitidos(latitud, longitud, iP, archivos, fechaHora);
        }

        private ListadoArchivos RecuperarArchivosPermitidos(double latitud, double longitud, string iP, ListadoArchivos archivos, DateTime fechaHora)
        {
            ListadoArchivos archivosPermitidos = new ListadoArchivos();
            
            foreach (Archivo arch in archivos)
            {
                if (arch.IP == iP) //MISMO IP
                {
                    //double distancia = CalcularDistancia(arch.CoordenadaLatitud, arch.CoordenadaLongitud, latitud, longitud);
                    //if (distancia <= arch.Radio) //DENTRO DEL RANGO
                    //{
                        if (arch.FechaHoraFin.Date == fechaHora.Date) //MISMA FECHA
                        {
                            if (arch.FechaHoraInicio.TimeOfDay <= fechaHora.TimeOfDay && fechaHora.TimeOfDay <= arch.FechaHoraFin.TimeOfDay) //DENTRO DEL HORARIO
                            {
                                archivosPermitidos.Add(arch);
                            }
                        }
                        
                    //}
                }
            }

            return archivosPermitidos;
        }

        public ListadoArchivos RecuperarTodosPorAlumnoPorTipo(int idTipo, int idPersona, double latitud, double longitud, string iP, DateTime fechaHora)
        {
            ListadoArchivos archivos = archs.RecuperarTodosPorAlumnoPorTipo(idTipo, idPersona);
            return RecuperarArchivosPermitidos(latitud, longitud, iP, archivos, fechaHora);
        }

        private double CalcularDistancia(double latA, double longA, double latB, double longB)
        {
            var locA = new GeoCoordinate(latA, longA);
            var locB = new GeoCoordinate(latB, longB);
            return locA.GetDistanceTo(locB); //DISTANCIA EN METROS
        }

        #endregion
    }
}