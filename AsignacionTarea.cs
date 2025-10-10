using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class AsignacionTarea
    {

        public int IdAsigTarea { get; set; }
        public decimal HorasTrabajadas { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }

        public AsignacionTarea() { }

        public AsignacionTarea(int idAsigTarea, decimal horasTrabajadas, int empleadoId, int tareaId)
        {
            IdAsigTarea = idAsigTarea;
            HorasTrabajadas = horasTrabajadas;
            EmpleadoId = empleadoId;
            TareaId = tareaId;
        }
    }
}
