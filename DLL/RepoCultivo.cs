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
                string query = @"SELECT ID_CULTIVO, ID_ADMIN_SUPERVISOR, NOMBRE_LOTE, 
                                        FECHA_SIEMBRA, FECHA_COSECHA_ESTIMADA, ALERTA_NBN 
                                 FROM CULTIVO";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cultivos.Add(new Cultivo
                        {
                            IdCultivo = Convert.ToInt32(reader["ID_CULTIVO"]),
                            IdAdminSupervisor = Convert.ToInt32(reader["ID_ADMIN_SUPERVISOR"]),
                            NombreLote = reader["NOMBRE_LOTE"].ToString(),
                            FechaSiembra = Convert.ToDateTime(reader["FECHA_SIEMBRA"]),
                            FechaCosechaEstimada = Convert.ToDateTime(reader["FECHA_COSECHA_ESTIMADA"]),
                            AlertaN8N = reader["ALERTA_NBN"] == DBNull.Value ? null : reader["ALERTA_NBN"].ToString()
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

                string query = @"INSERT INTO CULTIVO 
                                (ID_CULTIVO, ID_ADMIN_SUPERVISOR, NOMBRE_LOTE, FECHA_SIEMBRA, FECHA_COSECHA_ESTIMADA, ALERTA_NBN)
                                VALUES (SEQ_CULTIVO.NEXTVAL, :ID_ADMIN_SUPERVISOR, :NOMBRE_LOTE, 
                                        :FECHA_SIEMBRA, :FECHA_COSECHA_ESTIMADA, :ALERTA_NBN)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_ADMIN_SUPERVISOR", cultivo.IdAdminSupervisor);
                    cmd.Parameters.Add(":NOMBRE_LOTE", cultivo.NombreLote);
                    cmd.Parameters.Add(":FECHA_SIEMBRA", cultivo.FechaSiembra);
                    cmd.Parameters.Add(":FECHA_COSECHA_ESTIMADA", cultivo.FechaCosechaEstimada);
                    cmd.Parameters.Add(":ALERTA_NBN", cultivo.AlertaN8N ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCultivo(int idCultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM CULTIVO WHERE ID_CULTIVO = :ID_CULTIVO";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_CULTIVO", idCultivo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCultivo(Cultivo cultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE CULTIVO 
                                 SET ID_ADMIN_SUPERVISOR = :ID_ADMIN_SUPERVISOR,
                                     NOMBRE_LOTE = :NOMBRE_LOTE,
                                     FECHA_SIEMBRA = :FECHA_SIEMBRA,
                                     FECHA_COSECHA_ESTIMADA = :FECHA_COSECHA_ESTIMADA,
                                     ALERTA_NBN = :ALERTA_NBN
                                 WHERE ID_CULTIVO = :ID_CULTIVO";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_ADMIN_SUPERVISOR", cultivo.IdAdminSupervisor);
                    cmd.Parameters.Add(":NOMBRE_LOTE", cultivo.NombreLote);
                    cmd.Parameters.Add(":FECHA_SIEMBRA", cultivo.FechaSiembra);
                    cmd.Parameters.Add(":FECHA_COSECHA_ESTIMADA", cultivo.FechaCosechaEstimada);
                    cmd.Parameters.Add(":ALERTA_NBN", cultivo.AlertaN8N ?? (object)DBNull.Value);
                    cmd.Parameters.Add(":ID_CULTIVO", cultivo.IdCultivo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}







