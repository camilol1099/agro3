using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class RepoTarea : BaseRepo<Tarea>
    {
        public List<Tarea> ObtenerTareas()
        {
            List<Tarea> tareas = new List<Tarea>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
                     SELECT 
                         ID_TAREA,
                         ID_CULTIVO,
                          ID_ADMIN_CREADOR,
                           TIPO_ACTIVIDAD,
                            FECHA_PROGRAMADA,
                            TIEMPO_TOTAL_TAREA,
                             ESTADO,
                             ES_RECURRENT,
                                FRECUENCIA_DIAS,
                             COSTO_TRANSPORTE
                            FROM TAREA";
                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tareas.Add(new Tarea
                            {
                                IdTarea = reader.GetInt32(0),
                                IdCultivo = reader.GetInt32(1),
                                IdAdminCreador = reader.GetInt32(2),
                                TipoActividad = reader.GetString(3),
                                EsRecurrente = reader.GetString(7),
                                FrecuenciaDias = reader.GetInt32(8),
                                FechaProgramada = reader.GetDateTime(4),
                                Estado = reader.GetString(6),
                                TiempoTotalTarea = reader.GetDecimal(5),
                                CostoTransporte = reader.GetDecimal(9)

                            });
                        }
                    }
                }
            }
            return tareas;
        }

        public void GuardarTarea(Tarea tarea)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO TAREA (
                    ID_TAREA,
                    ID_CULTIVO,
                    ID_ADMIN_CREADOR,
                    TIPO_ACTIVIDAD,
                    FECHA_PROGRAMADA,
                    TIEMPO_TOTAL_TAREA,
                    ESTADO,
                    ES_RECURRENT,
                    FRECUENCIA_DIAS,
                    COSTO_TRANSPORTE
                ) VALUES (
                    :IdTarea,
                    :IdCultivo,
                    :IdAdminCreador,
                    :TipoActividad,
                    :FechaProgramada,
                    :TiempoTotalTarea,
                    :Estado,
                    :EsRecurrente,
                    :FrecuenciaDias,
                    :CostoTransporte
                )";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdTarea", tarea.IdTarea));
                    cmd.Parameters.Add(new OracleParameter(":IdCultivo", tarea.IdCultivo));
                    cmd.Parameters.Add(new OracleParameter(":IdAdminCreador", tarea.IdAdminCreador));
                    cmd.Parameters.Add(new OracleParameter(":TipoActividad", tarea.TipoActividad));
                    cmd.Parameters.Add(new OracleParameter(":FechaProgramada", tarea.FechaProgramada));
                    cmd.Parameters.Add(new OracleParameter(":TiempoTotalTarea", tarea.TiempoTotalTarea));
                    cmd.Parameters.Add(new OracleParameter(":Estado", tarea.Estado));
                    cmd.Parameters.Add(new OracleParameter(":EsRecurrente", tarea.EsRecurrente));
                    cmd.Parameters.Add(new OracleParameter(":FrecuenciaDias", tarea.FrecuenciaDias));
                    cmd.Parameters.Add(new OracleParameter(":CostoTransporte", tarea.CostoTransporte));

                    cmd.ExecuteNonQuery();
                }

            }
        }



        public void EliminarTarea(int idTarea)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM TAREA WHERE ID_TAREA = :IdTarea";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdTarea", idTarea));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarTarea(Tarea tarea)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"UPDATE TAREA 
                         SET 
                             ID_CULTIVO = :IdCultivo,
                             ID_ADMIN_CREADOR = :IdAdminCreador,
                             TIPO_ACTIVIDAD = :TipoActividad,
                             FECHA_PROGRAMADA = :FechaProgramada,
                             TIEMPO_TOTAL_TAREA = :TiempoTotalTarea,
                             ESTADO = :Estado,
                             ES_RECURRENT = :EsRecurrente,
                             FRECUENCIA_DIAS = :FrecuenciaDias,
                             COSTO_TRANSPORTE = :CostoTransporte
                         WHERE ID_TAREA = :IdTarea";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdCultivo", tarea.IdCultivo));
                    cmd.Parameters.Add(new OracleParameter(":IdAdminCreador", tarea.IdAdminCreador));
                    cmd.Parameters.Add(new OracleParameter(":TipoActividad", tarea.TipoActividad));
                    cmd.Parameters.Add(new OracleParameter(":FechaProgramada", tarea.FechaProgramada));
                    cmd.Parameters.Add(new OracleParameter(":TiempoTotalTarea", tarea.TiempoTotalTarea));
                    cmd.Parameters.Add(new OracleParameter(":Estado", tarea.Estado));
                    cmd.Parameters.Add(new OracleParameter(":EsRecurrente", tarea.EsRecurrente));
                    cmd.Parameters.Add(new OracleParameter(":FrecuenciaDias", tarea.FrecuenciaDias));
                    cmd.Parameters.Add(new OracleParameter(":CostoTransporte", tarea.CostoTransporte));
                    cmd.Parameters.Add(new OracleParameter(":IdTarea", tarea.IdTarea));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Tarea> ObtenerTareasPorAdmin(int idAdminCreador)
        {
            var tareas = new List<Tarea>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                            ID_TAREA,
                            ID_CULTIVO,
                            ID_ADMIN_CREADOR,
                            TIPO_ACTIVIDAD,
                            FECHA_PROGRAMADA,
                            TIEMPO_TOTAL_TAREA,
                            ESTADO,
                            ES_RECURRENT,
                            FRECUENCIA_DIAS,
                            COSTO_TRANSPORTE
                         FROM TAREA
                         WHERE ID_ADMIN_CREADOR = :IdAdminCreador";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdAdminCreador", idAdminCreador));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tareas.Add(new Tarea
                            {
                                IdTarea = Convert.ToInt32(reader["ID_TAREA"]),
                                IdCultivo = Convert.ToInt32(reader["ID_CULTIVO"]),
                                IdAdminCreador = Convert.ToInt32(reader["ID_ADMIN_CREADOR"]),
                                TipoActividad = reader["TIPO_ACTIVIDAD"].ToString(),
                                FechaProgramada = Convert.ToDateTime(reader["FECHA_PROGRAMADA"]),
                                TiempoTotalTarea = Convert.ToDecimal(reader["TIEMPO_TOTAL_TAREA"]),
                                Estado = reader["ESTADO"].ToString(),
                                EsRecurrente = reader["ES_RECURRENT"].ToString(),
                                FrecuenciaDias =  Convert.ToInt32(reader["FRECUENCIA_DIAS"]),
                                CostoTransporte = Convert.ToDecimal(reader["COSTO_TRANSPORTE"])
                            });
                        }
                    }
                }
            }

            return tareas;
        }


    }
}
