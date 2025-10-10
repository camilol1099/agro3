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
        public string NombreLote { get; set; }
        public DateTime FechaSiembra { get; set; }
        public DateTime FechaCosechaEstimada { get; set; }
        public string AlertaNBn { get; set; }
     
        public int VentaId { get; set; }
        public Venta Venta { get; set; }

     
        public List<DetalleVenta> DetallesVenta { get; set; }

        public Cultivo()
        {
            DetallesVenta = new List<DetalleVenta>();
        }
         

    }
}
