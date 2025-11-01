using Entidades;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class RepoUsuario : BaseRepo<Usuario>
    {
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuario = new List<Usuario>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT ID_Usuario, Cedula, Nombre , Email ,Contraseña,Telefono,Tipo_Usu FROM usuario";
                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario.Add(new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["ID_Usuario"]),
                                Cedula = reader["Cedula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Email = reader["Email"].ToString(),
                                Contraseña = reader["Contraseña"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                TipoUsuario = reader["Tipo_Usu"].ToString()
                            });
                        }
                    }
                }
            }
            return usuario;
        }


        public void GuardarUsuario(Usuario usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO usuario (ID_Usuario, Cedula, Nombre , Email ,Contraseña,Telefono,Tipo_Usu) VALUES (@ID_Usuario,@Cedula, @Nombre, @Email, @Contraseña, @Telefono, @Tipo_Usu)";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("@ID_Usuario", usuario.IdUsuario));
                    cmd.Parameters.Add(new OracleParameter("@Cedula", usuario.Cedula));
                    cmd.Parameters.Add(new OracleParameter("@Nombre", usuario.Nombre));
                    cmd.Parameters.Add(new OracleParameter("@Email", usuario.Email));
                    cmd.Parameters.Add(new OracleParameter("@Contraseña", usuario.Contraseña));
                    cmd.Parameters.Add(new OracleParameter("@Telefono", usuario.Telefono));
                    cmd.Parameters.Add(new OracleParameter("@Tipo_Usu", usuario.TipoUsuario));
                    int filas = cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM usuario WHERE ID_Usuario = @ID_Usuario";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("@ID_Usuario", idUsuario));
                    int filas = cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE usuario SET Cedula = @Cedula, Nombre = @Nombre, Email = @Email, Contraseña = @Contraseña, Telefono = @Telefono, Tipo_Usu = @Tipo_Usu WHERE ID_Usuario = @ID_Usuario";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":ID_USUARIO", usuario.IdUsuario));
                    cmd.Parameters.Add(new OracleParameter(":CEDULA", usuario.Cedula));
                    cmd.Parameters.Add(new OracleParameter(":NOMBRE", usuario.Nombre));
                    cmd.Parameters.Add(new OracleParameter(":EMAIL", usuario.Email));
                    cmd.Parameters.Add(new OracleParameter(":CONTRASEÑA", usuario.Contraseña));
                    cmd.Parameters.Add(new OracleParameter(":TELEFONO", usuario.Telefono));
                    cmd.Parameters.Add(new OracleParameter(":TIPO_USU", usuario.TipoUsuario));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}