using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoCultivo : BaseRepo<Cultivo>
    {
        public List<Cultivo> ObtenerCultivos()
        {
            List<Cultivo> cultivos = new List<Cultivo>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT IdCultivo, NombreLote, FechaSiembra, FechaCosechaEstimada, AlertaNBn FROM Cultivo";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cultivos.Add(new Cultivo
                        {
                            IdCultivo = Convert.ToInt32(reader["IdCultivo"]),
                            NombreLote = reader["NombreLote"].ToString(),
                            FechaSiembra = Convert.ToDateTime(reader["FechaSiembra"]),
                            FechaCosechaEstimada = Convert.ToDateTime(reader["FechaCosechaEstimada"]),
                            AlertaNBn = reader["AlertaNBn"] == DBNull.Value ? null : reader["AlertaNBn"].ToString()
                        });
                    }
                }
            }
            return cultivos;
        }

        public void GuardarCultivo(Cultivo cultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // ⚙️ Usamos secuencia para autogenerar el IdCultivo
                string query = @"INSERT INTO Cultivo 
                                (IdCultivo, NombreLote, FechaSiembra, FechaCosechaEstimada, AlertaNBn)
                                VALUES (SEQ_CULTIVO.NEXTVAL, :NombreLote, :FechaSiembra, :FechaCosechaEstimada, :AlertaNBn)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":NombreLote", cultivo.NombreLote);
                    cmd.Parameters.Add(":FechaSiembra", cultivo.FechaSiembra);
                    cmd.Parameters.Add(":FechaCosechaEstimada", cultivo.FechaCosechaEstimada);
                    cmd.Parameters.Add(":AlertaNBn", cultivo.AlertaNBn ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCultivo(int idCultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Cultivo WHERE IdCultivo = :IdCultivo";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":IdCultivo", idCultivo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCultivo(Cultivo cultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE Cultivo 
                                 SET NombreLote = :NombreLote,
                                     FechaSiembra = :FechaSiembra,
                                     FechaCosechaEstimada = :FechaCosechaEstimada,
                                     AlertaNBn = :AlertaNBn
                                 WHERE IdCultivo = :IdCultivo";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":NombreLote", cultivo.NombreLote);
                    cmd.Parameters.Add(":FechaSiembra", cultivo.FechaSiembra);
                    cmd.Parameters.Add(":FechaCosechaEstimada", cultivo.FechaCosechaEstimada);
                    cmd.Parameters.Add(":AlertaNBn", cultivo.AlertaNBn ?? (object)DBNull.Value);
                    cmd.Parameters.Add(":IdCultivo", cultivo.IdCultivo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}






