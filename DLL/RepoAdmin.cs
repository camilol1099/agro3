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
                string query = "SELECT IdAdministrador, MontoMensual, UsuarioId FROM Administrador";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        administradores.Add(new Administrador
                        {
                            IdAdministrador = Convert.ToInt32(reader["IdAdministrador"]),
                            MontoMensual = Convert.ToDecimal(reader["MontoMensual"]),
                            UsuarioId = Convert.ToInt32(reader["UsuarioId"])
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

                // ⚙️ Usamos secuencia SEQ_ADMIN para generar el ID automáticamente
                string query = @"INSERT INTO Administrador 
                                (IdAdministrador, MontoMensual, UsuarioId)
                                VALUES (SEQ_ADMIN.NEXTVAL, :MontoMensual, :UsuarioId)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":MontoMensual", admin.MontoMensual);
                    cmd.Parameters.Add(":UsuarioId", admin.UsuarioId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAdmin(int idAdmin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Administrador WHERE IdAdministrador = :IdAdministrador";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":IdAdministrador", idAdmin);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarAdmin(Administrador admin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE Administrador 
                                 SET MontoMensual = :MontoMensual, 
                                     UsuarioId = :UsuarioId 
                                 WHERE IdAdministrador = :IdAdministrador";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":MontoMensual", admin.MontoMensual);
                    cmd.Parameters.Add(":UsuarioId", admin.UsuarioId);
                    cmd.Parameters.Add(":IdAdministrador", admin.IdAdministrador);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
