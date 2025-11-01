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
                string query = "SELECT IdCultivo, NombreLote, FechaSiembra, FechaCosechaEstimada, AlertaNBn FROM cultivo";

                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cultivos.Add(new Cultivo
                            {
                                IdCultivo = reader.GetInt32(0),
                                NombreLote = reader.GetString(1),
                                FechaSiembra = reader.GetDateTime(2),
                                FechaCosechaEstimada = reader.GetDateTime(3),
                                AlertaNBn = reader.IsDBNull(4) ? null : reader.GetString(4)
                            });
                        }
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
                string query = "INSERT INTO cultivo (IdCultivo, NombreLote, FechaSiembra, FechaCosechaEstimada, AlertaNBn) " +
                               "VALUES (:IdCultivo, :NombreLote, :FechaSiembra, :FechaCosechaEstimada, :AlertaNBn)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdCultivo", cultivo.IdCultivo));
                    cmd.Parameters.Add(new OracleParameter(":NombreLote", cultivo.NombreLote));
                    cmd.Parameters.Add(new OracleParameter(":FechaSiembra", cultivo.FechaSiembra));
                    cmd.Parameters.Add(new OracleParameter(":FechaCosechaEstimada", cultivo.FechaCosechaEstimada));
                    cmd.Parameters.Add(new OracleParameter(":AlertaNBn", cultivo.AlertaNBn ?? (object)DBNull.Value));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCultivo(int idCultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM cultivo WHERE IdCultivo = :IdCultivo";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdCultivo", idCultivo));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCultivo(Cultivo cultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE cultivo " +
                               "SET NombreLote = :NombreLote, FechaSiembra = :FechaSiembra, " +
                               "FechaCosechaEstimada = :FechaCosechaEstimada, AlertaNBn = :AlertaNBn " +
                               "WHERE IdCultivo = :IdCultivo";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":NombreLote", cultivo.NombreLote));
                    cmd.Parameters.Add(new OracleParameter(":FechaSiembra", cultivo.FechaSiembra));
                    cmd.Parameters.Add(new OracleParameter(":FechaCosechaEstimada", cultivo.FechaCosechaEstimada));
                    cmd.Parameters.Add(new OracleParameter(":AlertaNBn", cultivo.AlertaNBn ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new OracleParameter(":IdCultivo", cultivo.IdCultivo));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}





