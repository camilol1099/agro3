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
        public string TipoActividad { get; set; }
        public int FrecuenciaDias { get; set; }
        public DateTime FechaProgramada { get; set; }
        public string Estado { get; set; }
        public decimal TiempoTotalTarea { get; set; }

       
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

       
        public List<AsignacionTarea> AsignacionesTarea { get; set; }
        public List<DetalleTarea> DetallesTarea { get; set; }

        public Tarea()
        {
            AsignacionesTarea = new List<AsignacionTarea>();
            DetallesTarea = new List<DetalleTarea>();
        }
    }
}
