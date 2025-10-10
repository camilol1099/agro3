using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class ActivooFijp
    {

        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public List<Proveedor> Proveedores { get; set; }

        public ActivoFijo()
        {
            Proveedores = new List<Proveedor>();
        }


    }
}
