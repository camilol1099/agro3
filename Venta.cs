using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal TotalVenta { get; set; }

        public int UsuarioId { get; set; }
        public Usuario UsuarioRegistra { get; set; }

        public int TipoPagoId { get; set; }

        public List<DetalleVenta> DetallesVenta { get; set; }
        public List<Cultivo> Cultivos { get; set; }

        public Venta()
        {
            DetallesVenta = new List<DetalleVenta>();
            Cultivos = new List<Cultivo>();
        }
    }
}
