using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tarea
    {

        public int IdTarea { get; set; }
        public int IdCultivo { get; set; }
        public int IdAdminCreador { get; set; }
        public string TipoActividad { get; set; }
        public DateTime FechaProgramada { get; set; }
        public decimal TiempoTotalTarea { get; set; }
        public string Estado { get; set; }
        public string EsRecurrente { get; set; }
        public int? FrecuenciaDias { get; set; }
        public decimal? CostoTransporte { get; set; }

        // Relaciones
        public Cultivo Cultivo { get; set; }
        public Administrador AdminCreador { get; set; }
        public List<DetalleTarea> Detalles { get; set; }
        public List<AsignacionTarea> Asignaciones { get; set; }
    }
}
