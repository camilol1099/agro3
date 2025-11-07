using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioAsignaciónTarea
    {
        RepoAsignacionTarea repo = new RepoAsignacionTarea();
        public List<Entidades.AsignacionTarea> ObtenerAsignaciones()
        {
            return repo.ObtenerAsignacionesTarea();
        }

        public void GuardarAsignacion(Entidades.AsignacionTarea asignacion)
        {
            if (asignacion.IdTarea <= 0)
                throw new Exception("El ID de la tarea no es válido.");
            if (asignacion.IdEmpleado <= 0)
                throw new Exception("El ID del empleado no es válido.");
            repo.GuardarAsignacionTarea(asignacion);
        }

        public void EliminarAsignacion(int idAsignacion)
        {
            if (idAsignacion <= 0)
                throw new Exception("El ID de la asignación no es válido.");
            repo.EliminarAsignacionTarea(idAsignacion);
        }
    }
}
