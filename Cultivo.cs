using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Cultivo
    {
        public int IdCultivo { get; set; }
        public int IdAdminSupervisor { get; set; }
        public string NombreLote { get; set; }
        public DateTime FechaSiembra { get; set; }
        public DateTime FechaCosechaEstimada { get; set; }
        public string AlertaN8N { get; set; }

        // Relaciones
        public Administrador AdminSupervisor { get; set; }
        public List<Cosecha> Cosechas { get; set; }
        public List<Tarea> Tareas { get; set; }



    }
}
