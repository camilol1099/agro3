using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoCosecha : BaseRepo<Cosecha>
    {
        public List<Cosecha> ObtenerCosechas()
        {
            List<Cosecha> cosechas = new List<Cosecha>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT ID_COSECHA, ID_CULTIVO, ID_ADMIN_REGISTRO, 
                                        FECHA_COSECHA, FECHA_REGISTRO, 
                                        CANTIDAD_OBTENIDA, UNIDAD_MEDIDA, CALIDAD, OBSERVACIONES 
                                 FROM COSECHA";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cosechas.Add(new Cosecha
                        {
                            IdCosecha = Convert.ToInt32(reader["ID_COSECHA"]),
                            IdCultivo = Convert.ToInt32(reader["ID_CULTIVO"]),
                            IdAdminRegistro = Convert.ToInt32(reader["ID_ADMIN_REGISTRO"]),
                            FechaCosecha = Convert.ToDateTime(reader["FECHA_COSECHA"]),
                            FechaRegistro = Convert.ToDateTime(reader["FECHA_REGISTRO"]),
                            CantidadObtenida = Convert.ToDecimal(reader["CANTIDAD_OBTENIDA"]),
                            UnidadMedida = reader["UNIDAD_MEDIDA"].ToString(),
                            Calidad = reader["CALIDAD"].ToString(),
                            Observaciones = reader["OBSERVACIONES"] == DBNull.Value ? null : reader["OBSERVACIONES"].ToString()
                        });
                    }
                }
            }
            return cosechas;
        }

        public void GuardarCosecha(Cosecha cosecha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO COSECHA 
                                (ID_COSECHA, ID_CULTIVO, ID_ADMIN_REGISTRO, FECHA_COSECHA, FECHA_REGISTRO, 
                                 CANTIDAD_OBTENIDA, UNIDAD_MEDIDA, CALIDAD, OBSERVACIONES)
                                VALUES (SEQ_COSECHA.NEXTVAL, :ID_CULTIVO, :ID_ADMIN_REGISTRO, 
                                        :FECHA_COSECHA, :FECHA_REGISTRO, :CANTIDAD_OBTENIDA, 
                                        :UNIDAD_MEDIDA, :CALIDAD, :OBSERVACIONES)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_CULTIVO", cosecha.IdCultivo);
                    cmd.Parameters.Add(":ID_ADMIN_REGISTRO", cosecha.IdAdminRegistro);
                    cmd.Parameters.Add(":FECHA_COSECHA", cosecha.FechaCosecha);
                    cmd.Parameters.Add(":FECHA_REGISTRO", cosecha.FechaRegistro);
                    cmd.Parameters.Add(":CANTIDAD_OBTENIDA", cosecha.CantidadObtenida);
                    cmd.Parameters.Add(":UNIDAD_MEDIDA", cosecha.UnidadMedida);
                    cmd.Parameters.Add(":CALIDAD", cosecha.Calidad);
                    cmd.Parameters.Add(":OBSERVACIONES", cosecha.Observaciones ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCosecha(int idCosecha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM COSECHA WHERE ID_COSECHA = :ID_COSECHA";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_COSECHA", idCosecha);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCosecha(Cosecha cosecha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE COSECHA 
                                 SET ID_CULTIVO = :ID_CULTIVO,
                                     ID_ADMIN_REGISTRO = :ID_ADMIN_REGISTRO,
                                     FECHA_COSECHA = :FECHA_COSECHA,
                                     FECHA_REGISTRO = :FECHA_REGISTRO,
                                     CANTIDAD_OBTENIDA = :CANTIDAD_OBTENIDA,
                                     UNIDAD_MEDIDA = :UNIDAD_MEDIDA,
                                     CALIDAD = :CALIDAD,
                                     OBSERVACIONES = :OBSERVACIONES
                                 WHERE ID_COSECHA = :ID_COSECHA";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_CULTIVO", cosecha.IdCultivo);
                    cmd.Parameters.Add(":ID_ADMIN_REGISTRO", cosecha.IdAdminRegistro);
                    cmd.Parameters.Add(":FECHA_COSECHA", cosecha.FechaCosecha);
                    cmd.Parameters.Add(":FECHA_REGISTRO", cosecha.FechaRegistro);
                    cmd.Parameters.Add(":CANTIDAD_OBTENIDA", cosecha.CantidadObtenida);
                    cmd.Parameters.Add(":UNIDAD_MEDIDA", cosecha.UnidadMedida);
                    cmd.Parameters.Add(":CALIDAD", cosecha.Calidad);
                    cmd.Parameters.Add(":OBSERVACIONES", cosecha.Observaciones ?? (object)DBNull.Value);
                    cmd.Parameters.Add(":ID_COSECHA", cosecha.IdCosecha);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

