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
        public int IdTarea { get; set; }
        public int IdEmpleado { get; set; }
        public int IdAdminAsignador { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public decimal HorasTrabajadas { get; set; }
        public decimal JornadasTrabajadas { get; set; }
        public decimal PagoAcordado { get; set; }
        public string Estado { get; set; }

        // Relaciones
        public Tarea Tarea { get; set; }
        public Empleado Empleado { get; set; }
        public Administrador AdminAsignador { get; set; }
    }
}
