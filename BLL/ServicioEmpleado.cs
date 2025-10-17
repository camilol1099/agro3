using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DLL;
using System.Collections.ObjectModel;

namespace BLL
{
    public class ServicioEmpleado : IcrudEscritura<Empleado>, IcrudLectura<Empleado>
    {
        RepoEmpleados RepoEmpleado;
  
        public ServicioEmpleado()
        {
            RepoEmpleado = new RepoEmpleados(Utils.ARC_Empleado);
        }
        public bool Actualizar(Empleado entidad)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Empleado> Consultar()
        {
            var lista = RepoEmpleado.Consultar();
            return new ReadOnlyCollection<Empleado>(lista);
        }

        public bool Eliminar(Empleado entidad)
        {
            throw new NotImplementedException();
        }

        public string Guardar(Empleado entidad)
        {
            //validar
            return RepoEmpleado.Guardar(entidad);
        }

        public Empleado ObtenerPorId(int id)
        {
            return RepoEmpleado.ObtenerPorId(id);
        }

    }
}
