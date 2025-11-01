using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL
{
    public class ServicioUsuario
    {
        public List<Entidades.Usuario> ObtenerUsuarios()
        {
            DLL.RepoUsuario repo = new DLL.RepoUsuario();
            return repo.ObtenerUsuarios();
        }

        public void GuardarUsuario(Entidades.Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Cedula))
                throw new Exception("La cédula no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("El email no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Contraseña))
                throw new Exception("La contraseña no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(usuario.Telefono))
                throw new Exception("El teléfono no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.TipoUsuario))
                throw new Exception("El tipo de usuario no puede estar vacío.");
            DLL.RepoUsuario repo = new DLL.RepoUsuario();
            repo.GuardarUsuario(usuario);
        }

        public void EliminarUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("El ID del usuario no es válido.");
            DLL.RepoUsuario repo = new DLL.RepoUsuario();
            repo.EliminarUsuario(idUsuario);
        }

        public void ActualizarUsuario(Entidades.Usuario usuario)
        {
            if (usuario.IdUsuario <= 0)
                throw new Exception("El ID del usuario no es válido.");
            if (string.IsNullOrWhiteSpace(usuario.Cedula))
                throw new Exception("La cédula no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("El email no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Contraseña))
                throw new Exception("La contraseña no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(usuario.Telefono))
                throw new Exception("El teléfono no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.TipoUsuario))
                throw new Exception("El tipo de usuario no puede estar vacío.");
            DLL.RepoUsuario repo = new DLL.RepoUsuario();
            repo.ActualizarUsuario(usuario);
        }

    }
}
