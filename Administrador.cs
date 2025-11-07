using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Administrador : Usuario
    {
        public int UsuarioId { get; set; }
        public decimal MontoMensual { get; set; }

        // Relaciones
        public Usuario Usuario { get; set; }
        public List<Cultivo> CultivosSupervisados { get; set; }
        public List<Cosecha> CosechasRegistradas { get; set; }
        public List<Insumo> InsumosRegistrados { get; set; }
        public List<Tarea> TareasCreadas { get; set; }
        public List<AsignacionTarea> TareasAsignadas { get; set; }
    }
}
