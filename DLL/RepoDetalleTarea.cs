using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                string query = "SELECT IdDetalleTarea, CantidadUsada, TareaId, InsumoId FROM detalle_tarea";
                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detalles.Add(new DetalleTarea
                            {
                                IdDetalleTarea = reader.GetInt32(0),
                                CantidadUsada = reader.GetInt32(1),
                                TareaId = reader.GetInt32(2),
                                InsumoId = reader.GetInt32(3)
                            });
                        }
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
                string query = "INSERT INTO detalle_tarea (IdDetalleTarea, CantidadUsada, TareaId, InsumoId) " +
                               "VALUES (:IdDetalleTarea, :CantidadUsada, :TareaId, :InsumoId)";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdDetalleTarea", detalle.IdDetalleTarea));
                    cmd.Parameters.Add(new OracleParameter(":CantidadUsada", detalle.CantidadUsada));
                    cmd.Parameters.Add(new OracleParameter(":TareaId", detalle.TareaId));
                    cmd.Parameters.Add(new OracleParameter(":InsumoId", detalle.InsumoId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarDetalleTarea(int idDetalleTarea)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM detalle_tarea WHERE IdDetalleTarea = :IdDetalleTarea";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdDetalleTarea", idDetalleTarea));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarDetalleTarea(DetalleTarea detalle)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE detalle_tarea SET CantidadUsada = :CantidadUsada, " +
                               "TareaId = :TareaId, InsumoId = :InsumoId " +
                               "WHERE IdDetalleTarea = :IdDetalleTarea";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":CantidadUsada", detalle.CantidadUsada));
                    cmd.Parameters.Add(new OracleParameter(":TareaId", detalle.TareaId));
                    cmd.Parameters.Add(new OracleParameter(":InsumoId", detalle.InsumoId));
                    cmd.Parameters.Add(new OracleParameter(":IdDetalleTarea", detalle.IdDetalleTarea));
                    cmd.ExecuteNonQuery();
                }
            }
        }
      
    
        
    }
}
