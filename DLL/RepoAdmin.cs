using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoAdmin : BaseRepo<Administrador>
    {
        public List<Administrador> ObtenerAdministradores()
        {
            List<Administrador> administradores = new List<Administrador>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT ID_USUARIO, MONTO_MENSUAL FROM ADMINISTRADOR";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        administradores.Add(new Administrador
                        {
                            UsuarioId = Convert.ToInt32(reader["ID_USUARIO"]),
                            MontoMensual = Convert.ToDecimal(reader["MONTO_MENSUAL"])
                        });
                    }
                }
            }

            return administradores;
        }

        public void GuardarAdmin(Administrador admin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO ADMINISTRADOR (ID_USUARIO, MONTO_MENSUAL)
                                 VALUES (:ID_USUARIO, :MONTO_MENSUAL)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_USUARIO", admin.UsuarioId);
                    cmd.Parameters.Add(":MONTO_MENSUAL", admin.MontoMensual);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAdmin(int idUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM ADMINISTRADOR WHERE ID_USUARIO = :ID_USUARIO";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_USUARIO", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarAdmin(Administrador admin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE ADMINISTRADOR 
                                 SET MONTO_MENSUAL = :MONTO_MENSUAL
                                 WHERE ID_USUARIO = :ID_USUARIO";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":MONTO_MENSUAL", admin.MontoMensual);
                    cmd.Parameters.Add(":ID_USUARIO", admin.UsuarioId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

