using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cosecha
    {
        public int IdCosecha { get; set; }
        public int IdCultivo { get; set; }
        public int IdAdminRegistro { get; set; }
        public DateTime FechaCosecha { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal CantidadObtenida { get; set; }
        public string UnidadMedida { get; set; }
        public string Calidad { get; set; }
        public string Observaciones { get; set; }

        // Relaciones
        public Cultivo Cultivo { get; set; }
        public Administrador AdminRegistro { get; set; }
    }
}
