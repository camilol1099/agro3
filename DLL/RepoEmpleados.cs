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
                string query = "SELECT IdEmpleado, MontoPorHora, MontoMensual, Monto_Por_Jornal, ID_Usu FROM empleado";
                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empleados.Add(new Empleado
                            {
                                IdEmpleado = reader.GetInt32(0),
                                MontoPorHora = reader.GetDecimal(1),
                                MontoMensual = reader.GetDecimal(2),
                                Monto_Por_Jornal = reader.GetDecimal(3),
                                IdUsuario = reader.GetInt32(4)
                            });
                        }
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
                string query = "INSERT INTO empleado (IdEmpleado, MontoPorHora, MontoMensual, Monto_Por_Jornal, ID_Usu) " +
                               "VALUES (:IdEmpleado, :MontoPorHora, :MontoMensual, :Monto_Por_Jornal, :ID_Usu)";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdEmpleado", empleado.IdEmpleado));
                    cmd.Parameters.Add(new OracleParameter(":MontoPorHora", empleado.MontoPorHora));
                    cmd.Parameters.Add(new OracleParameter(":MontoMensual", empleado.MontoMensual));
                    cmd.Parameters.Add(new OracleParameter(":Monto_Por_Jornal", empleado.Monto_Por_Jornal));
                    cmd.Parameters.Add(new OracleParameter(":ID_Usu", empleado.IdUsuario));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarEmpleado(int idEmpleado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM empleado WHERE IdEmpleado = :IdEmpleado";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdEmpleado", idEmpleado));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE empleado " +
                               "SET MontoPorHora = :MontoPorHora, MontoMensual = :MontoMensual, Monto_Por_Jornal = :Monto_Por_Jornal, ID_Usu = :ID_Usu " +
                               "WHERE IdEmpleado = :IdEmpleado";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":MontoPorHora", empleado.MontoPorHora));
                    cmd.Parameters.Add(new OracleParameter(":MontoMensual", empleado.MontoMensual));
                    cmd.Parameters.Add(new OracleParameter(":Monto_Por_Jornal", empleado.Monto_Por_Jornal));
                    cmd.Parameters.Add(new OracleParameter(":ID_Usu", empleado.IdUsuario));
                    cmd.Parameters.Add(new OracleParameter(":IdEmpleado", empleado.IdEmpleado));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}




