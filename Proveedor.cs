using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor
    {

        public int IdProveedor { get; set; }
        public string Identificacion { get; set; } // 1N o 1A
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

     
        public List<InsumoConsumible> InsumosConsumibles { get; set; }
        public List<ActivooFijp> ActivosFijos { get; set; }

        public Proveedor()
        {
            InsumosConsumibles = new List<InsumoConsumible>();
            ActivosFijos = new List<ActivooFijp>();
        }
    }
}
