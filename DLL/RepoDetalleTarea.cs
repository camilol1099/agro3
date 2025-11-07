using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoDetalleTarea : BaseRepo<DetalleTarea>
    {
        public List<DetalleTarea> ObtenerDetallesTarea()
        {
            List<DetalleTarea> detalles = new List<DetalleTarea>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT ID_DETALLE_TAREA, ID_TAREA, ID_INSUMO, CANTIDAD_USADA FROM DETALLE_TAREA";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detalles.Add(new DetalleTarea
                        {
                            IdDetalleTarea = Convert.ToInt32(reader["ID_DETALLE_TAREA"]),
                            IdTarea = Convert.ToInt32(reader["ID_TAREA"]),
                            IdInsumo = Convert.ToInt32(reader["ID_INSUMO"]),
                            CantidadUsada = Convert.ToDecimal(reader["CANTIDAD_USADA"])
                        });
                    }
                }
            }

            return detalles;
        }

        public void GuardarDetalleTarea(DetalleTarea detalle)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO DETALLE_TAREA 
                                (ID_DETALLE_TAREA, ID_TAREA, ID_INSUMO, CANTIDAD_USADA)
                                 VALUES (:ID_DETALLE_TAREA, :ID_TAREA, :ID_INSUMO, :CANTIDAD_USADA)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_DETALLE_TAREA", detalle.IdDetalleTarea);
                    cmd.Parameters.Add(":ID_TAREA", detalle.IdTarea);
                    cmd.Parameters.Add(":ID_INSUMO", detalle.IdInsumo);
                    cmd.Parameters.Add(":CANTIDAD_USADA", detalle.CantidadUsada);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarDetalleTarea(int idDetalleTarea)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM DETALLE_TAREA WHERE ID_DETALLE_TAREA = :ID_DETALLE_TAREA";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_DETALLE_TAREA", idDetalleTarea);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarDetalleTarea(DetalleTarea detalle)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE DETALLE_TAREA 
                                 SET ID_TAREA = :ID_TAREA,
                                     ID_INSUMO = :ID_INSUMO,
                                     CANTIDAD_USADA = :CANTIDAD_USADA
                                 WHERE ID_DETALLE_TAREA = :ID_DETALLE_TAREA";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_TAREA", detalle.IdTarea);
                    cmd.Parameters.Add(":ID_INSUMO", detalle.IdInsumo);
                    cmd.Parameters.Add(":CANTIDAD_USADA", detalle.CantidadUsada);
                    cmd.Parameters.Add(":ID_DETALLE_TAREA", detalle.IdDetalleTarea);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

