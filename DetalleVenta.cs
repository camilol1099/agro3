using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        
        public int VentaId { get; set; }
        public Venta Venta { get; set; }

       
        public int CultivoId { get; set; }
        public Cultivo Cultivo { get; set; }

        public DetalleVenta() { }

        public DetalleVenta(int idDetalleVenta, int cantidad, decimal precioUnitario, int ventaId, int cultivoId )
        {
            IdDetalleVenta = idDetalleVenta;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            VentaId = ventaId;
            CultivoId = cultivoId;
        }   


    }
}
