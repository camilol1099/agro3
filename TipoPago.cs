using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoPago
    {
        public int IdTipoPago { get; set; }
        public string Nombre { get; set; }
        public bool AplicaComision { get; set; }

        public TipoPago() { }

        public TipoPago(int idTipoPago, string nombre, bool aplicaComision)
        {
            IdTipoPago = idTipoPago;
            Nombre = nombre;
            AplicaComision = aplicaComision;
        }
    }
}
