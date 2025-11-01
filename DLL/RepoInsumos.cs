using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DLL
{
    public class RepoInsumos : BaseRepo<Insumo>
    {
        public List<Insumo> ObtenerInsumos()
        {
            List<Insumo> insumos = new List<Insumo>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT IdInsumo, Nombre, StockMinimo, StockActual, AlertaNBn, GastoUnitario FROM insumos";
                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            insumos.Add(new Insumo
                            {
                                IdInsumo = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                StockMinimo = reader.GetInt32(2),
                                StockActual = reader.GetInt32(3),
                                AlertaNBn = reader.GetString(4),
                                GastoUnitario = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return insumos;
        }

        public void GuardarInsumo(Insumo insumo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO insumos (IdInsumo, Nombre, StockMinimo, StockActual, AlertaNBn, GastoUnitario) " +
                               "VALUES (:IdInsumo, :Nombre, :StockMinimo, :StockActual, :AlertaNBn, :GastoUnitario)";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdInsumo", insumo.IdInsumo));
                    cmd.Parameters.Add(new OracleParameter(":Nombre", insumo.Nombre));
                    cmd.Parameters.Add(new OracleParameter(":StockMinimo", insumo.StockMinimo));
                    cmd.Parameters.Add(new OracleParameter(":StockActual", insumo.StockActual));
                    cmd.Parameters.Add(new OracleParameter(":AlertaNBn", insumo.AlertaNBn));
                    cmd.Parameters.Add(new OracleParameter(":GastoUnitario", insumo.GastoUnitario));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarInsumo(int idInsumo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM insumos WHERE IdInsumo = :IdInsumo";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdInsumo", idInsumo));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarInsumo(Insumo insumo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE insumos SET Nombre = :Nombre, StockMinimo = :StockMinimo, " +
                               "StockActual = :StockActual, AlertaNBn = :AlertaNBn, GastoUnitario = :GastoUnitario " +
                               "WHERE IdInsumo = :IdInsumo";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":Nombre", insumo.Nombre));
                    cmd.Parameters.Add(new OracleParameter(":StockMinimo", insumo.StockMinimo));
                    cmd.Parameters.Add(new OracleParameter(":StockActual", insumo.StockActual));
                    cmd.Parameters.Add(new OracleParameter(":AlertaNBn", insumo.AlertaNBn));
                    cmd.Parameters.Add(new OracleParameter(":GastoUnitario", insumo.GastoUnitario));
                    cmd.Parameters.Add(new OracleParameter(":IdInsumo", insumo.IdInsumo));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
