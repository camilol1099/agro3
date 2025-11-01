using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class ServicioAdministrador
    {
        RepoAdmin repo = new RepoAdmin();
        public List<Entidades.Administrador> ObtenerAdministradores()
        {
            return repo.ObtenerEmpleados();
        }
        public void GuardarAdministrador(Entidades.Administrador admin)
        {
            if (admin.IdAdministrador <= 0)
                throw new Exception("El ID del administrador no es válido.");
            if (admin.MontoMensual <= 0)
                throw new Exception("El monto mensual debe ser mayor que cero.");
            repo.GuardarAdmin(admin);
        }
        public void EliminarAdministrador(int idAdmin)
        {
            if (idAdmin <= 0)
                throw new Exception("El ID del administrador no es válido.");
            repo.EliminarAdmin(idAdmin);
        }

        public Entidades.Administrador ObtenerAdministradorPorId(int idAdmin)
        {
            var administradores = repo.ObtenerEmpleados();
            var admin = administradores.FirstOrDefault(a => a.IdAdministrador == idAdmin);
            if (admin == null)
                throw new Exception("Administrador no encontrado.");
            return admin;
        }

        public void ActualizarAdministrador(Entidades.Administrador admin)
        {
            if (admin.IdAdministrador <= 0)
                throw new Exception("El ID del administrador no es válido.");
            if (admin.MontoMensual <= 0)
                throw new Exception("El monto mensual debe ser mayor que cero.");
            // Aquí podrías implementar la lógica para actualizar el administrador en la base de datos.
            // Actualmente, el RepoAdmin no tiene un método para actualizar, así que esto es solo un marcador de posición.
            throw new NotImplementedException("Método de actualización no implementado.");
        }
    }
}
