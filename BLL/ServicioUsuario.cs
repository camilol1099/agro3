using DLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioUsuario
    {
        RepoUsuario repo = new RepoUsuario();
        public List<Usuario> ObtenerUsuarios()
        {
            DLL.RepoUsuario repo = new DLL.RepoUsuario();
            return repo.ObtenerUsuarios();
        }

        public String GuardarUsuario(Usuario usuario)
        {
          
            if (string.IsNullOrWhiteSpace(usuario.Primer_Nombre))
                throw new Exception("El primer nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Segundo_Nombre))
                throw new Exception("El segundo nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Apellido_Pri))
                throw new Exception("El primer apellido no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Apellido_Segu))
                throw new Exception("El segundo apellido no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("El email no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Contraseña))
                throw new Exception("La contraseña no puede estar vacía.");
            if (usuario.Telefono <= 0)
                throw new Exception("El teléfono debe ser un número válido mayor que cero.");
            

            DLL.RepoUsuario repo = new DLL.RepoUsuario();

            return repo.GuardarUsuario(usuario);
        }

        public void EliminarUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("El ID del usuario no es válido.");
            DLL.RepoUsuario repo = new DLL.RepoUsuario();
            repo.EliminarUsuario(idUsuario);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            if (usuario.IdUsuario <= 0)
                throw new Exception("El ID del usuario no es válido.");
            
            if (string.IsNullOrWhiteSpace(usuario.Primer_Nombre))
                throw new Exception("El primer nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Segundo_Nombre))
                throw new Exception("El segundo nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Apellido_Pri))
                throw new Exception("El primer apellido no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Apellido_Segu))
                throw new Exception("El segundo apellido no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("El email no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Contraseña))
                throw new Exception("La contraseña no puede estar vacía.");
            if (usuario.Telefono <= 0)
                throw new Exception("El teléfono debe ser un número válido mayor que cero.");
            

            DLL.RepoUsuario repo = new DLL.RepoUsuario();
            repo.ActualizarUsuario(usuario);
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return repo.ObtenerUsuarioPorId(id);
        }
    }
}
