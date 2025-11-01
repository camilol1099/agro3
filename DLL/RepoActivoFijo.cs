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
            try
            {
                using (var conexion = GetConnection())
                {
                    conexion.Open();
                    string query = "SELECT Id_Insumo FROM activofijo";
                    using (var comando = new OracleCommand(query, conexion))
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            ActivooFijp activo = new ActivooFijp
                            {
                                InsumoId = Convert.ToInt32(lector["Id_Insumo"])
                            };
                            lista.Add(activo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener activos fijos: " + ex.Message);
            }
            return lista;
        }

        public bool Insertar(ActivooFijp activo)
        {
            try
            {
                using (var conexion = GetConnection())
                {
                    conexion.Open();
                    string query = "INSERT INTO activofijo (Id_Insumo) VALUES (:InsumoId)";
                    using (var comando = new OracleCommand(query, conexion))
                    {
                        comando.Parameters.Add(new OracleParameter(":InsumoId", activo.InsumoId));
                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar activo fijo: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var conexion = GetConnection())
                {
                    conexion.Open();
                    string query = "DELETE FROM activofijo WHERE Id_Insumo = :id";
                    using (var comando = new OracleCommand(query, conexion))
                    {
                        comando.Parameters.Add(new OracleParameter(":id", id));
                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar activo fijo: " + ex.Message);
            }
        }

        public bool ActualizarActivo(ActivooFijp activo)
        {
            try
            {
                using (var conexion = GetConnection())
                {
                    conexion.Open();
                    string query = "UPDATE activofijo SET Id_Insumo = :InsumoId WHERE Id_Insumo = :InsumoId";
                    using (var comando = new OracleCommand(query, conexion))
                    {
                        comando.Parameters.Add(new OracleParameter(":InsumoId", activo.InsumoId));
                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar activo fijo: " + ex.Message);
            }
        }
    }
}

