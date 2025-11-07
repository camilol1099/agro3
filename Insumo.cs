using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Insumo
    {
        public int IdInsumo { get; set; }
        public int IdAdminRegistro { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; } // Activo fijo / Consumible
        public decimal StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal CostoUnitario { get; set; }

        // Relaciones
        public Administrador AdminRegistro { get; set; }
        public List<DetalleTarea> DetallesTarea { get; set; }
    }
    }
