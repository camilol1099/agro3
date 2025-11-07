using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL
{
    public class ServicioTarea
    {

        RepoTarea repoTarea = new RepoTarea();
        RepoDetalleTarea repoDetalleTarea = new RepoDetalleTarea();

        public List<Tarea> ObtenerTareas()
        {
            return repoTarea.ObtenerTareas();
        }

        public void AgregarTarea(Tarea tarea)
        {
            repoTarea.GuardarTarea(tarea);
            if (tarea.EsRecurrente == "Si")
            {
                DateTime fechaActual = tarea.FechaProgramada;
                for (int i = 1; i <= 5; i++)
                {
                    fechaActual = fechaActual.AddDays(tarea.FrecuenciaDias ?? 0);
                    Tarea nuevaTarea = new Tarea
                    {
                        IdCultivo = tarea.IdCultivo,
                        IdAdminCreador = tarea.IdAdminCreador,
                        TipoActividad = tarea.TipoActividad,
                        FechaProgramada = fechaActual,
                        TiempoTotalTarea = tarea.TiempoTotalTarea,
                        Estado = "Pendiente",
                        EsRecurrente = "No",
                        CostoTransporte = tarea.CostoTransporte
                    };
                    repoTarea.GuardarTarea(nuevaTarea);
                }
            }

            if (tarea.Detalles != null)
            {
                foreach (var detalle in tarea.Detalles)
                {
                    detalle.IdTarea = tarea.IdTarea;
                    repoDetalleTarea.GuardarDetalleTarea(detalle);
                }
            }

            if (tarea.Asignaciones != null)
            {
                foreach (var asignacion in tarea.Asignaciones)
                {
                    asignacion.IdTarea = tarea.IdTarea;
                    RepoAsignacionTarea repoAsignacionTarea = new RepoAsignacionTarea();
                    repoAsignacionTarea.GuardarAsignacionTarea(asignacion);
                }
            }
        }

        public void EliminarTarea(int id)
        {
            if (id <= 0)
                throw new Exception("El ID de la tarea no es válido.");
            repoTarea.EliminarTarea(id);
        }
    }
}
