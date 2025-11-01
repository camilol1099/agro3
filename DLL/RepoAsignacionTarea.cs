using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class RepoAsignacionTarea : BaseRepo<AsignacionTarea>
    {
        public List<AsignacionTarea> ObtenerAsignacionesTarea()
        {
            List<AsignacionTarea> asignaciones = new List<AsignacionTarea>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT IdAsigTarea, HorasTrabajadas, Jornadas_Trabajadas, EmpleadoId, TareaId FROM asignacion_tarea";
                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            asignaciones.Add(new AsignacionTarea
                            {
                                IdAsigTarea = reader.GetInt32(0),
                                HorasTrabajadas = reader.GetDecimal(1),
                                Jornadas_Trabajadas = reader.GetInt32(2),
                                EmpleadoId = reader.GetInt32(3),
                                TareaId = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }
            return asignaciones;
        }

        public void GuardarAsignacionTarea(AsignacionTarea asignacion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO asignacion_tarea (IdAsigTarea, HorasTrabajadas, Jornadas_Trabajadas, EmpleadoId, TareaId) " +
                               "VALUES (:IdAsigTarea, :HorasTrabajadas, :Jornadas_Trabajadas, :EmpleadoId, :TareaId)";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdAsigTarea", asignacion.IdAsigTarea));
                    cmd.Parameters.Add(new OracleParameter(":HorasTrabajadas", asignacion.HorasTrabajadas));
                    cmd.Parameters.Add(new OracleParameter(":Jornadas_Trabajadas", asignacion.Jornadas_Trabajadas));
                    cmd.Parameters.Add(new OracleParameter(":EmpleadoId", asignacion.EmpleadoId));
                    cmd.Parameters.Add(new OracleParameter(":TareaId", asignacion.TareaId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAsignacionTarea(int idAsigTarea)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM asignacion_tarea WHERE IdAsigTarea = :IdAsigTarea";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdAsigTarea", idAsigTarea));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarAsignacionTarea(AsignacionTarea asignacion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE asignacion_tarea SET HorasTrabajadas = :HorasTrabajadas, " +
                               "Jornadas_Trabajadas = :Jornadas_Trabajadas, EmpleadoId = :EmpleadoId, TareaId = :TareaId " +
                               "WHERE IdAsigTarea = :IdAsigTarea";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":HorasTrabajadas", asignacion.HorasTrabajadas));
                    cmd.Parameters.Add(new OracleParameter(":Jornadas_Trabajadas", asignacion.Jornadas_Trabajadas));
                    cmd.Parameters.Add(new OracleParameter(":EmpleadoId", asignacion.EmpleadoId));
                    cmd.Parameters.Add(new OracleParameter(":TareaId", asignacion.TareaId));
                    cmd.Parameters.Add(new OracleParameter(":IdAsigTarea", asignacion.IdAsigTarea));
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
