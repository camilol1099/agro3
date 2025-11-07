using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoAsignacionTarea : BaseRepo<AsignacionTarea>
    {
        public List<AsignacionTarea> ObtenerAsignacionesTarea()
        {
            var asignaciones = new List<AsignacionTarea>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                                    ID_ASIG_TAREA,
                                    ID_TAREA,
                                    ID_EMPLEADO,
                                    ID_ADMIN_ASIGNADOR,
                                    FECHA_ASIGNACION,
                                    HORAS_TRABAJADAS,
                                    JORNADAS_TRABAJADAS,
                                    PAGO_ACORDADO,
                                    ESTADO
                                 FROM ASIGNACION_TAREA";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        asignaciones.Add(new AsignacionTarea
                        {
                            IdAsigTarea = Convert.ToInt32(reader["ID_ASIG_TAREA"]),
                            IdTarea = Convert.ToInt32(reader["ID_TAREA"]),
                            IdEmpleado = Convert.ToInt32(reader["ID_EMPLEADO"]),
                            IdAdminAsignador = Convert.ToInt32(reader["ID_ADMIN_ASIGNADOR"]),
                            FechaAsignacion = Convert.ToDateTime(reader["FECHA_ASIGNACION"]),
                            HorasTrabajadas = reader["HORAS_TRABAJADAS"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["HORAS_TRABAJADAS"]),
                            JornadasTrabajadas = reader["JORNADAS_TRABAJADAS"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["JORNADAS_TRABAJADAS"]),
                            PagoAcordado = reader["PAGO_ACORDADO"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["PAGO_ACORDADO"]),
                            Estado = reader["ESTADO"].ToString()
                        });
                    }
                }
            }

            return asignaciones;
        }

        // === GUARDAR ===
        public void GuardarAsignacionTarea(AsignacionTarea asignacion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO ASIGNACION_TAREA 
                                (ID_ASIG_TAREA, ID_TAREA, ID_EMPLEADO, ID_ADMIN_ASIGNADOR, 
                                 FECHA_ASIGNACION, HORAS_TRABAJADAS, JORNADAS_TRABAJADAS, 
                                 PAGO_ACORDADO, ESTADO)
                                 VALUES 
                                (:ID_ASIG_TAREA, :ID_TAREA, :ID_EMPLEADO, :ID_ADMIN_ASIGNADOR, 
                                 :FECHA_ASIGNACION, :HORAS_TRABAJADAS, :JORNADAS_TRABAJADAS, 
                                 :PAGO_ACORDADO, :ESTADO)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_ASIG_TAREA", asignacion.IdAsigTarea);
                    cmd.Parameters.Add(":ID_TAREA", asignacion.IdTarea);
                    cmd.Parameters.Add(":ID_EMPLEADO", asignacion.IdEmpleado);
                    cmd.Parameters.Add(":ID_ADMIN_ASIGNADOR", asignacion.IdAdminAsignador);
                    cmd.Parameters.Add(":FECHA_ASIGNACION", asignacion.FechaAsignacion);
                    cmd.Parameters.Add(":HORAS_TRABAJADAS", (object)asignacion.HorasTrabajadas ?? DBNull.Value);
                    cmd.Parameters.Add(":JORNADAS_TRABAJADAS", (object)asignacion.JornadasTrabajadas ?? DBNull.Value);
                    cmd.Parameters.Add(":PAGO_ACORDADO", (object)asignacion.PagoAcordado ?? DBNull.Value);
                    cmd.Parameters.Add(":ESTADO", asignacion.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // === ELIMINAR ===
        public void EliminarAsignacionTarea(int idAsigTarea)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM ASIGNACION_TAREA WHERE ID_ASIG_TAREA = :ID_ASIG_TAREA";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_ASIG_TAREA", idAsigTarea);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // === ACTUALIZAR ===
        public void ActualizarAsignacionTarea(AsignacionTarea asignacion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"UPDATE ASIGNACION_TAREA SET 
                                    ID_TAREA = :ID_TAREA,
                                    ID_EMPLEADO = :ID_EMPLEADO,
                                    ID_ADMIN_ASIGNADOR = :ID_ADMIN_ASIGNADOR,
                                    FECHA_ASIGNACION = :FECHA_ASIGNACION,
                                    HORAS_TRABAJADAS = :HORAS_TRABAJADAS,
                                    JORNADAS_TRABAJADAS = :JORNADAS_TRABAJADAS,
                                    PAGO_ACORDADO = :PAGO_ACORDADO,
                                    ESTADO = :ESTADO
                                 WHERE ID_ASIG_TAREA = :ID_ASIG_TAREA";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_TAREA", asignacion.IdTarea);
                    cmd.Parameters.Add(":ID_EMPLEADO", asignacion.IdEmpleado);
                    cmd.Parameters.Add(":ID_ADMIN_ASIGNADOR", asignacion.IdAdminAsignador);
                    cmd.Parameters.Add(":FECHA_ASIGNACION", asignacion.FechaAsignacion);
                    cmd.Parameters.Add(":HORAS_TRABAJADAS", (object)asignacion.HorasTrabajadas ?? DBNull.Value);
                    cmd.Parameters.Add(":JORNADAS_TRABAJADAS", (object)asignacion.JornadasTrabajadas ?? DBNull.Value);
                    cmd.Parameters.Add(":PAGO_ACORDADO", (object)asignacion.PagoAcordado ?? DBNull.Value);
                    cmd.Parameters.Add(":ESTADO", asignacion.Estado);
                    cmd.Parameters.Add(":ID_ASIG_TAREA", asignacion.IdAsigTarea);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // === OBTENER POR ID ===
        public AsignacionTarea ObtenerPorId(int idAsigTarea)
        {
            AsignacionTarea asignacion = null;

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                                    ID_ASIG_TAREA,
                                    ID_TAREA,
                                    ID_EMPLEADO,
                                    ID_ADMIN_ASIGNADOR,
                                    FECHA_ASIGNACION,
                                    HORAS_TRABAJADAS,
                                    JORNADAS_TRABAJADAS,
                                    PAGO_ACORDADO,
                                    ESTADO
                                 FROM ASIGNACION_TAREA
                                 WHERE ID_ASIG_TAREA = :ID_ASIG_TAREA";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_ASIG_TAREA", idAsigTarea);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            asignacion = new AsignacionTarea
                            {
                                IdAsigTarea = Convert.ToInt32(reader["ID_ASIG_TAREA"]),
                                IdTarea = Convert.ToInt32(reader["ID_TAREA"]),
                                IdEmpleado = Convert.ToInt32(reader["ID_EMPLEADO"]),
                                IdAdminAsignador = Convert.ToInt32(reader["ID_ADMIN_ASIGNADOR"]),
                                FechaAsignacion = Convert.ToDateTime(reader["FECHA_ASIGNACION"]),
                                HorasTrabajadas = Convert.ToDecimal(reader["HORAS_TRABAJADAS"]),
                                JornadasTrabajadas = Convert.ToDecimal(reader["JORNADAS_TRABAJADAS"]),
                                PagoAcordado =  Convert.ToDecimal(reader["PAGO_ACORDADO"]),
                                Estado = reader["ESTADO"].ToString()
                            };
                        }
                    }
                }
            }

            return asignacion;
        }
    }
}
