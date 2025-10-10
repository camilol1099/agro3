using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Administrador : Usuario
    {
        public int IdAdministrador { get; set; }
        public decimal MontoMensual { get; set; }

       
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<Venta> Ventas { get; set; } = new List<Venta>();
        public List<Cultivo> Cultivos { get; set; } = new List<Cultivo>();
    }
}
