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
                string query = "SELECT IdCosecha, NombreLote, FechaSiembra, FechaCosechaEstimada, AlertaNBn FROM Cosecha";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cosechas.Add(new Cosecha
                        {
                            IdCosecha = Convert.ToInt32(reader["IdCosecha"]),
                            NombreLote = reader["NombreLote"].ToString(),
                            FechaSiembra = Convert.ToDateTime(reader["FechaSiembra"]),
                            FechaCosechaEstimada = Convert.ToDateTime(reader["FechaCosechaEstimada"]),
                            AlertaNBn = reader["AlertaNBn"] == DBNull.Value ? null : reader["AlertaNBn"].ToString()
                        });
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

                // ⚙️ Usamos una secuencia para autogenerar el IdCosecha
                string query = @"INSERT INTO Cosecha 
                                 (IdCosecha, NombreLote, FechaSiembra, FechaCosechaEstimada, AlertaNBn)
                                 VALUES (SEQ_COSECHA.NEXTVAL, :NombreLote, :FechaSiembra, :FechaCosechaEstimada, :AlertaNBn)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":NombreLote", cosecha.NombreLote);
                    cmd.Parameters.Add(":FechaSiembra", cosecha.FechaSiembra);
                    cmd.Parameters.Add(":FechaCosechaEstimada", cosecha.FechaCosechaEstimada);
                    cmd.Parameters.Add(":AlertaNBn", cosecha.AlertaNBn ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCosecha(int idCosecha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Cosecha WHERE IdCosecha = :IdCosecha";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":IdCosecha", idCosecha);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCosecha(Cosecha cosecha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE Cosecha 
                                 SET NombreLote = :NombreLote,
                                     FechaSiembra = :FechaSiembra,
                                     FechaCosechaEstimada = :FechaCosechaEstimada,
                                     AlertaNBn = :AlertaNBn
                                 WHERE IdCosecha = :IdCosecha";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":NombreLote", cosecha.NombreLote);
                    cmd.Parameters.Add(":FechaSiembra", cosecha.FechaSiembra);
                    cmd.Parameters.Add(":FechaCosechaEstimada", cosecha.FechaCosechaEstimada);
                    cmd.Parameters.Add(":AlertaNBn", cosecha.AlertaNBn ?? (object)DBNull.Value);
                    cmd.Parameters.Add(":IdCosecha", cosecha.IdCosecha);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


