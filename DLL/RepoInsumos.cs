using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoInsumos : BaseRepo<Insumo>
    {
        // === OBTENER TODOS ===
        public List<Insumo> ObtenerInsumos()
        {
            var insumos = new List<Insumo>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT 
                                    ID_INSUMO,
                                    ID_ADMIN_REGISTRO,
                                    NOMBRE,
                                    TIPO,
                                    STOCK_ACTUAL,
                                    STOCK_MINIMO,
                                    COSTO_UNITARIO
                                 FROM INSUMO";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        insumos.Add(new Insumo
                        {
                            IdInsumo = Convert.ToInt32(reader["ID_INSUMO"]),
                            IdAdminRegistro = Convert.ToInt32(reader["ID_ADMIN_REGISTRO"]),
                            Nombre = reader["NOMBRE"].ToString(),
                            Tipo = reader["TIPO"].ToString(),
                            StockActual = Convert.ToDecimal(reader["STOCK_ACTUAL"]),
                            StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]),
                            CostoUnitario = Convert.ToDecimal(reader["COSTO_UNITARIO"])
                        });
                    }
                }
            }

            return insumos;
        }

        // === GUARDAR ===
        public void GuardarInsumo(Insumo insumo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO INSUMO 
                                 (ID_INSUMO, ID_ADMIN_REGISTRO, NOMBRE, TIPO, STOCK_ACTUAL, STOCK_MINIMO, COSTO_UNITARIO)
                                 VALUES (:IdInsumo, :IdAdminRegistro, :Nombre, :Tipo, :StockActual, :StockMinimo, :CostoUnitario)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdInsumo", insumo.IdInsumo));
                    cmd.Parameters.Add(new OracleParameter(":IdAdminRegistro", insumo.IdAdminRegistro));
                    cmd.Parameters.Add(new OracleParameter(":Nombre", insumo.Nombre));
                    cmd.Parameters.Add(new OracleParameter(":Tipo", insumo.Tipo));
                    cmd.Parameters.Add(new OracleParameter(":StockActual", insumo.StockActual));
                    cmd.Parameters.Add(new OracleParameter(":StockMinimo", insumo.StockMinimo));
                    cmd.Parameters.Add(new OracleParameter(":CostoUnitario", insumo.CostoUnitario));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // === ACTUALIZAR ===
        public void ActualizarInsumo(Insumo insumo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"UPDATE INSUMO SET 
                                    ID_ADMIN_REGISTRO = :IdAdminRegistro,
                                    NOMBRE = :Nombre,
                                    TIPO = :Tipo,
                                    STOCK_ACTUAL = :StockActual,
                                    STOCK_MINIMO = :StockMinimo,
                                    COSTO_UNITARIO = :CostoUnitario
                                 WHERE ID_INSUMO = :IdInsumo";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdAdminRegistro", insumo.IdAdminRegistro));
                    cmd.Parameters.Add(new OracleParameter(":Nombre", insumo.Nombre));
                    cmd.Parameters.Add(new OracleParameter(":Tipo", insumo.Tipo));
                    cmd.Parameters.Add(new OracleParameter(":StockActual", insumo.StockActual));
                    cmd.Parameters.Add(new OracleParameter(":StockMinimo", insumo.StockMinimo));
                    cmd.Parameters.Add(new OracleParameter(":CostoUnitario", insumo.CostoUnitario));
                    cmd.Parameters.Add(new OracleParameter(":IdInsumo", insumo.IdInsumo));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // === ELIMINAR ===
        public void EliminarInsumo(int idInsumo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM INSUMO WHERE ID_INSUMO = :IdInsumo";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdInsumo", idInsumo));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
