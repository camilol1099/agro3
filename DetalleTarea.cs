using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleTarea
    {
        public int IdDetalleTarea { get; set; }
        public int IdTarea { get; set; }
        public int IdInsumo { get; set; }
        public decimal CantidadUsada { get; set; }

        // Relaciones
        public Tarea Tarea { get; set; }
        public Insumo Insumo { get; set; }
    }
}
