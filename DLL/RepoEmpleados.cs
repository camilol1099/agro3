using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace DLL
{
    public class RepoEmpleados : BaseRepo<Empleado>
    {
        public List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT IdEmpleado, MontoPorHora, MontoMensual, Monto_Por_Jornal, UsuarioId FROM Empleado";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empleados.Add(new Empleado
                        {
                            IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]),
                            MontoPorHora = Convert.ToDecimal(reader["MontoPorHora"]),
                            MontoMensual = Convert.ToDecimal(reader["MontoMensual"]),
                            Monto_Por_Jornal = Convert.ToInt32(reader["Monto_Por_Jornal"]),
                            IdUsuario = Convert.ToInt32(reader["UsuarioId"])
                        });
                    }
                }
            }

            return empleados;
        }

        public void GuardarEmpleado(Empleado empleado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // ⚙️ Usamos la secuencia SEQ_EMPLEADO para generar el Id automáticamente
                string query = @"INSERT INTO Empleado 
                                (IdEmpleado, MontoPorHora, MontoMensual, Monto_Por_Jornal, UsuarioId)
                                 VALUES (:IdEmpleado, :MontoPorHora, :MontoMensual, :Monto_Por_Jornal, :UsuarioId)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":IdEmpleado", empleado.IdEmpleado);
                    cmd.Parameters.Add(":MontoPorHora", empleado.MontoPorHora);
                    cmd.Parameters.Add(":MontoMensual", empleado.MontoMensual);
                    cmd.Parameters.Add(":Monto_Por_Jornal", empleado.Monto_Por_Jornal);
                    cmd.Parameters.Add(":UsuarioId", empleado.IdUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarEmpleado(int idEmpleado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Empleado WHERE IdEmpleado = :IdEmpleado";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":IdEmpleado", idEmpleado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE Empleado
                                 SET MontoPorHora = :MontoPorHora,
                                     MontoMensual = :MontoMensual,
                                     Monto_Por_Jornal = :Monto_Por_Jornal,
                                     UsuarioId = :UsuarioId
                                 WHERE IdEmpleado = :IdEmpleado";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":MontoPorHora", empleado.MontoPorHora);
                    cmd.Parameters.Add(":MontoMensual", empleado.MontoMensual);
                    cmd.Parameters.Add(":Monto_Por_Jornal", empleado.Monto_Por_Jornal);
                    cmd.Parameters.Add(":UsuarioId", empleado.IdUsuario);
                    cmd.Parameters.Add(":IdEmpleado", empleado.IdEmpleado);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}





