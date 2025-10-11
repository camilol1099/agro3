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
        public string Nombre { get; set; }
        public int StockMinimo { get; set; }
        public int StockActual { get; set; }
        public string AlertaNBn { get; set; }
        public string GastoUnitario { get; set; }

       
        public List<DetalleTarea> DetallesTarea { get; set; }
        public InsumoConsumible InsumoConsumible { get; set; }
        public ActivooFijp ActivoFijo { get; set; } 

        public Insumo()
        {
            DetallesTarea = new List<DetalleTarea>();
        }
    }
}
