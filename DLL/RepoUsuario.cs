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
                string query = @"SELECT 
                                    ID_USUARIO, 
                                    PRIMER_NOMBRE, 
                                    SEGUNDO_NOMBRE, 
                                    PRIMER_APELLIDO, 
                                    SEGUNDO_APELLIDO,  
                                    EMAIL, 
                                    CONTRASENA, 
                                    TELEFONO
                                 FROM USUARIO";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(reader["ID_USUARIO"]),
                            Primer_Nombre = reader["PRIMER_NOMBRE"].ToString(),
                            Segundo_Nombre = reader["SEGUNDO_NOMBRE"].ToString(),
                            Apellido_Pri = reader["PRIMER_APELLIDO"].ToString(),
                            Apellido_Segu = reader["SEGUNDO_APELLIDO"].ToString(),    // <-- cambio aquí
                            Email = reader["EMAIL"].ToString(),
                            Contraseña = reader["CONTRASENA"].ToString(),
                            Telefono = Convert.ToInt64(reader["TELEFONO"]) // <-- cambio aquí

                        });
                    }
                }
            }

            return usuarios;
        }

        public string GuardarUsuario(Usuario usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO USUARIO 
                                (ID_USUARIO, PRIMER_NOMBRE, SEGUNDO_NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, 
                                 EMAIL, CONTRASENA, TELEFONO)
                                VALUES 
                                (:ID_USUARIO, :PRIMER_NOMBRE, :SEGUNDO_NOMBRE, :PRIMER_APELLIDO, :SEGUNDO_APELLIDO,
                                 :EMAIL, :CONTRASENA, :TELEFONO)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_USUARIO", usuario.IdUsuario);
                    cmd.Parameters.Add(":PRIMER_NOMBRE", usuario.Primer_Nombre);
                    cmd.Parameters.Add(":SEGUNDO_NOMBRE", usuario.Segundo_Nombre);
                    cmd.Parameters.Add(":PRIMER_APELLIDO", usuario.Apellido_Pri);
                    cmd.Parameters.Add(":SEGUNDO_APELLIDO", usuario.Apellido_Segu);
                    cmd.Parameters.Add(":EMAIL", usuario.Email);
                    cmd.Parameters.Add(":CONTRASENA", usuario.Contraseña);
                    cmd.Parameters.Add(":TELEFONO", usuario.Telefono);

                    cmd.ExecuteNonQuery();
                }
            }
            return "Usuario registrado correctamente ✅";
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM USUARIO WHERE ID_USUARIO = :ID_USUARIO";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_USUARIO", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE USUARIO 
                                 SET PRIMER_NOMBRE = :PRIMER_NOMBRE,
                                     SEGUNDO_NOMBRE = :SEGUNDO_NOMBRE,
                                     PRIMER_APELLIDO = :PRIMER_APELLIDO,
                                     SEGUNDO_APELLIDO = :SEGUNDO_APELLIDO,
                                     EMAIL = :EMAIL,
                                     CONTRASENA = :CONTRASENA,
                                     TELEFONO = :TELEFONO
                                 WHERE ID_USUARIO = :ID_USUARIO";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":PRIMER_NOMBRE", usuario.Primer_Nombre);
                    cmd.Parameters.Add(":SEGUNDO_NOMBRE", usuario.Segundo_Nombre);
                    cmd.Parameters.Add(":PRIMER_APELLIDO", usuario.Apellido_Pri);
                    cmd.Parameters.Add(":SEGUNDO_APELLIDO", usuario.Apellido_Segu);

                    // Convertir string a número si no está vacío
                    cmd.Parameters.Add(":EMAIL", usuario.Email);
                    cmd.Parameters.Add(":CONTRASENA", usuario.Contraseña);
                    cmd.Parameters.Add(":TELEFONO", Convert.ToInt64(usuario.Telefono));
                    cmd.Parameters.Add(":ID_USUARIO", usuario.IdUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario usuario = null;

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                            ID_USUARIO, 
                            PRIMER_NOMBRE, 
                            SEGUNDO_NOMBRE, 
                            PRIMER_APELLIDO, 
                            SEGUNDO_APELLIDO,  
                            EMAIL, 
                            CONTRASENA, 
                            TELEFONO
                         FROM USUARIO
                         WHERE ID_USUARIO = :id";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["ID_USUARIO"]),
                                Primer_Nombre = reader["PRIMER_NOMBRE"].ToString(),
                                Segundo_Nombre = reader["SEGUNDO_NOMBRE"].ToString(),
                                Apellido_Pri = reader["PRIMER_APELLIDO"].ToString(),
                                Apellido_Segu = reader["SEGUNDO_APELLIDO"].ToString(),
                                Email = reader["EMAIL"].ToString(),
                                Contraseña = reader["CONTRASENA"].ToString(),
                                Telefono = Convert.ToInt64(reader["TELEFONO"])
                            };
                        }
                    }
                }
            }

            return usuario;
        }

    }
}

