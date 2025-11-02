using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoUsuario : BaseRepo<Usuario>
    {
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT IdUsuario, Cedula, Nombre, Email, Contrasena, Telefono, TipoUsuario FROM Usuario";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Cedula = reader["Cedula"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Email = reader["Email"].ToString(),
                            Contraseña = reader["Contrasena"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            TipoUsuario = reader["TipoUsuario"].ToString()
                        });
                    }
                }
            }

            return usuarios;
        }

        public void GuardarUsuario(Usuario usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO Usuario 
                                (IdUsuario, Cedula, Nombre, Email, Contrasena, Telefono, TipoUsuario)
                                VALUES (:IdUsuario, :Cedula, :Nombre, :Email, :Contrasena, :Telefono, :TipoUsuario)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.Add(":Cedula", usuario.Cedula);
                    cmd.Parameters.Add(":Nombre", usuario.Nombre);
                    cmd.Parameters.Add(":Email", usuario.Email);
                    cmd.Parameters.Add(":Contrasena", usuario.Contraseña);
                    cmd.Parameters.Add(":Telefono", usuario.Telefono);
                    cmd.Parameters.Add(":TipoUsuario", usuario.TipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Usuario WHERE IdUsuario = :IdUsuario";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":IdUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE Usuario 
                                 SET Cedula = :Cedula, 
                                     Nombre = :Nombre, 
                                     Email = :Email, 
                                     Contrasena = :Contrasena, 
                                     Telefono = :Telefono, 
                                     TipoUsuario = :TipoUsuario
                                 WHERE IdUsuario = :IdUsuario";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":Cedula", usuario.Cedula);
                    cmd.Parameters.Add(":Nombre", usuario.Nombre);
                    cmd.Parameters.Add(":Email", usuario.Email);
                    cmd.Parameters.Add(":Contrasena", usuario.Contraseña);
                    cmd.Parameters.Add(":Telefono", usuario.Telefono);
                    cmd.Parameters.Add(":TipoUsuario", usuario.TipoUsuario);
                    cmd.Parameters.Add(":IdUsuario", usuario.IdUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
