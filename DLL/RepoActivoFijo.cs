using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoActivoFijo : BaseRepo<ActivooFijp>
    {
        public List<ActivooFijp> ObtenerTodos()
        {
            List<ActivooFijp> lista = new List<ActivooFijp>();

            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = "SELECT Id_Insumo FROM Activofijo";

                using (var comando = new OracleCommand(query, conexion))
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new ActivooFijp
                        {
                            InsumoId = Convert.ToInt32(lector["Id_Insumo"])
                        });
                    }
                }
            }

            return lista;
        }

        public void Insertar(ActivooFijp activo)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = "INSERT INTO Activofijo (Id_Insumo) VALUES (:InsumoId)";

                using (var comando = new OracleCommand(query, conexion))
                {
                    comando.Parameters.Add(":InsumoId", activo.InsumoId);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(ActivooFijp activo)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = "UPDATE Activofijo SET Id_Insumo = :NuevoId WHERE Id_Insumo = :IdActual";

                using (var comando = new OracleCommand(query, conexion))
                {
                    comando.Parameters.Add(":NuevoId", activo.InsumoId);
                    comando.Parameters.Add(":IdActual", activo.InsumoId);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var conexion = GetConnection())
            {
                conexion.Open();
                string query = "DELETE FROM Activofijo WHERE Id_Insumo = :Id";

                using (var comando = new OracleCommand(query, conexion))
                {
                    comando.Parameters.Add(":Id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}


