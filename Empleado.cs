using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Usuario
    {

        public new int IdUsuario { get; set; }
        public decimal MontoPorHora { get; set; }
        public decimal MontoPorJornal { get; set; }

        // Relaciones
        public Usuario Usuario { get; set; }
        public List<AsignacionTarea> Asignaciones { get; set; }




    }
}
