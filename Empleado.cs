using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Usuario
    {

        public int IdEmpleado { get; set; }
        public decimal MontoPorHora { get; set; }
        public decimal MontoMensual { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<AsignacionTarea> AsignacionesTarea { get; set; }

        public Empleado()
        {
            AsignacionesTarea = new List<AsignacionTarea>();
        }


    }
}
