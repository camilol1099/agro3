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
        public int CantidadUsada { get; set; }
        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public DetalleTarea() { }

        public DetalleTarea(int idDetalleTarea, int cantidadUsada, int tareaId, int insumoId)
        {
            IdDetalleTarea = idDetalleTarea;
            CantidadUsada = cantidadUsada;
            TareaId = tareaId;
            InsumoId = insumoId;
        }
    }
}
