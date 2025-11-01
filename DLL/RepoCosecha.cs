using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoCosecha : BaseRepo<Cosecha>
    {
        public List<Cosecha> ObtenerCosechas()
        {
            List<Cosecha> cosechas = new List<Cosecha>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT IdCosecha, NombreLote, FechaSiembra, FechaCosechaEstimada, AlertaNBn FROM cosecha";

                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cosechas.Add(new Cosecha
                            {
                                IdCosecha = reader.GetInt32(0),
                                NombreLote = reader.GetString(1),
                                FechaSiembra = reader.GetDateTime(2),
                                FechaCosechaEstimada = reader.GetDateTime(3),
                                AlertaNBn = reader.IsDBNull(4) ? null : reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return cosechas;
        }

        public void GuardarCosecha(Cosecha cosecha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO cosecha (IdCosecha, NombreLote, FechaSiembra, FechaCosechaEstimada, AlertaNBn) " +
                               "VALUES (:IdCosecha, :NombreLote, :FechaSiembra, :FechaCosechaEstimada, :AlertaNBn)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdCosecha", cosecha.IdCosecha));
                    cmd.Parameters.Add(new OracleParameter(":NombreLote", cosecha.NombreLote));
                    cmd.Parameters.Add(new OracleParameter(":FechaSiembra", cosecha.FechaSiembra));
                    cmd.Parameters.Add(new OracleParameter(":FechaCosechaEstimada", cosecha.FechaCosechaEstimada));
                    cmd.Parameters.Add(new OracleParameter(":AlertaNBn", cosecha.AlertaNBn ?? (object)DBNull.Value));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCosecha(int idCosecha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM cosecha WHERE IdCosecha = :IdCosecha";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdCosecha", idCosecha));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCosecha(Cosecha cosecha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE cosecha " +
                               "SET NombreLote = :NombreLote, FechaSiembra = :FechaSiembra, " +
                               "FechaCosechaEstimada = :FechaCosechaEstimada, AlertaNBn = :AlertaNBn " +
                               "WHERE IdCosecha = :IdCosecha";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":NombreLote", cosecha.NombreLote));
                    cmd.Parameters.Add(new OracleParameter(":FechaSiembra", cosecha.FechaSiembra));
                    cmd.Parameters.Add(new OracleParameter(":FechaCosechaEstimada", cosecha.FechaCosechaEstimada));
                    cmd.Parameters.Add(new OracleParameter(":AlertaNBn", cosecha.AlertaNBn ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new OracleParameter(":IdCosecha", cosecha.IdCosecha));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

