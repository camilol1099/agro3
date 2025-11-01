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
                string query = "SELECT IdTarea, TipoActividad, FrecuenciaDias, FechaProgramada, Estado, " +
                               "TiempoTotalTarea, Costo_transporte, UsuarioId FROM tarea";
                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tareas.Add(new Tarea
                            {
                                IdTarea = reader.GetInt32(0),
                                TipoActividad = reader.GetString(1),
                                FrecuenciaDias = reader.GetInt32(2),
                                FechaProgramada = reader.GetDateTime(3),
                                Estado = reader.GetString(4),
                                TiempoTotalTarea = reader.GetDecimal(5),
                                Costo_transporte = reader.GetInt32(6),
                                UsuarioId = reader.GetInt32(7)
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
                string query = "INSERT INTO tarea (IdTarea, TipoActividad, FrecuenciaDias, FechaProgramada, Estado, " +
                               "TiempoTotalTarea, Costo_transporte, UsuarioId) " +
                               "VALUES (:IdTarea, :TipoActividad, :FrecuenciaDias, :FechaProgramada, :Estado, " +
                               ":TiempoTotalTarea, :Costo_transporte, :UsuarioId)";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdTarea", tarea.IdTarea));
                    cmd.Parameters.Add(new OracleParameter(":TipoActividad", tarea.TipoActividad));
                    cmd.Parameters.Add(new OracleParameter(":FrecuenciaDias", tarea.FrecuenciaDias));
                    cmd.Parameters.Add(new OracleParameter(":FechaProgramada", tarea.FechaProgramada));
                    cmd.Parameters.Add(new OracleParameter(":Estado", tarea.Estado));
                    cmd.Parameters.Add(new OracleParameter(":TiempoTotalTarea", tarea.TiempoTotalTarea));
                    cmd.Parameters.Add(new OracleParameter(":Costo_transporte", tarea.Costo_transporte));
                    cmd.Parameters.Add(new OracleParameter(":UsuarioId", tarea.UsuarioId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarTarea(int idTarea)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM tarea WHERE IdTarea = :IdTarea";
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
                string query = "UPDATE tarea SET TipoActividad = :TipoActividad, FrecuenciaDias = :FrecuenciaDias, " +
                               "FechaProgramada = :FechaProgramada, Estado = :Estado, TiempoTotalTarea = :TiempoTotalTarea, " +
                               "Costo_transporte = :Costo_transporte, UsuarioId = :UsuarioId " +
                               "WHERE IdTarea = :IdTarea";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":TipoActividad", tarea.TipoActividad));
                    cmd.Parameters.Add(new OracleParameter(":FrecuenciaDias", tarea.FrecuenciaDias));
                    cmd.Parameters.Add(new OracleParameter(":FechaProgramada", tarea.FechaProgramada));
                    cmd.Parameters.Add(new OracleParameter(":Estado", tarea.Estado));
                    cmd.Parameters.Add(new OracleParameter(":TiempoTotalTarea", tarea.TiempoTotalTarea));
                    cmd.Parameters.Add(new OracleParameter(":Costo_transporte", tarea.Costo_transporte));
                    cmd.Parameters.Add(new OracleParameter(":UsuarioId", tarea.UsuarioId));
                    cmd.Parameters.Add(new OracleParameter(":IdTarea", tarea.IdTarea));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Tarea> ObtenerTareasPorUsuario(int usuarioId)
        {
            List<Tarea> tareas = new List<Tarea>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT IdTarea, TipoActividad, FrecuenciaDias, FechaProgramada, Estado, " +
                               "TiempoTotalTarea, Costo_transporte, UsuarioId FROM tarea WHERE UsuarioId = :UsuarioId";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":UsuarioId", usuarioId));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tareas.Add(new Tarea
                            {
                                IdTarea = reader.GetInt32(0),
                                TipoActividad = reader.GetString(1),
                                FrecuenciaDias = reader.GetInt32(2),
                                FechaProgramada = reader.GetDateTime(3),
                                Estado = reader.GetString(4),
                                TiempoTotalTarea = reader.GetDecimal(5),
                                Costo_transporte = reader.GetInt32(6),
                                UsuarioId = reader.GetInt32(7)
                            });
                        }
                    }
                }
            }
            return tareas;
        }
       
    }
}
