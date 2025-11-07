using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Apellido_Pri { get; set; }

        public string Apellido_Segu { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public long Telefono { get; set; }

        public Empleado Empleado { get; set; }
        public Administrador Administrador { get; set; }

    }
}
