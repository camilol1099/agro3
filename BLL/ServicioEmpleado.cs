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
    public class ServicioEmpleado 
    {

        RepoEmpleados repo = new RepoEmpleados();

        public List<Empleado> ObtenerEmpleados()
        {
            return repo.ObtenerEmpleados();
        }

        public void GuardarEmpleado(Empleado empleado)
        {
            if (empleado.IdEmpleado <= 0)
                throw new Exception("El ID del empleado no es válido.");
            if (empleado.IdUsuario <= 0)
                throw new Exception("El ID del usuario no puede ser cero.");
            if (empleado.MontoPorHora <= 0)
                throw new Exception("El monto por hora debe ser mayor que 0.");
            if (empleado.MontoMensual <= 0)
                throw new Exception("El monto mensual debe ser mayor que 0.");
            if (empleado.Monto_Por_Jornal <= 0)
                throw new Exception("El monto por jornal debe ser mayor que 0.");

            repo.GuardarEmpleado(empleado);
        }


        public void EliminarEmpleado(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new Exception("El ID del empleado no es válido.");
            repo.EliminarEmpleado(idEmpleado);
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            if (empleado.IdEmpleado <= 0)
                throw new Exception("El ID del empleado no es válido.");
            if (empleado.IdUsuario <= 0)
                throw new Exception("El ID del usuario no puede ser cero.");
            if (empleado.MontoPorHora <= 0)
                throw new Exception("El monto por hora debe ser mayor que 0.");
            repo.ActualizarEmpleado(empleado);

            if (empleado.MontoMensual <= 0)
                throw new Exception("El monto mensual debe ser mayor que 0.");
            if (empleado.Monto_Por_Jornal <= 0)
                throw new Exception("El monto por jornal debe ser mayor que 0.");
        }

    }
}
