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

                string query = "SELECT ID_USUARIO, MONTO_POR_HORA, MONTO_POR_JORNAL FROM EMPLEADO";

                using (var cmd = new OracleCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empleados.Add(new Empleado
                        {
                            IdUsuario = Convert.ToInt32(reader["ID_USUARIO"]),
                            MontoPorHora = Convert.ToDecimal(reader["MONTO_POR_HORA"]),
                            MontoPorJornal = Convert.ToDecimal(reader["MONTO_POR_JORNAL"])
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

                string query = @"INSERT INTO EMPLEADO 
                                (ID_USUARIO, MONTO_POR_HORA, MONTO_POR_JORNAL)
                                VALUES (:ID_USUARIO, :MONTO_POR_HORA, :MONTO_POR_JORNAL)";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_USUARIO", empleado.IdUsuario);
                    cmd.Parameters.Add(":MONTO_POR_HORA", empleado.MontoPorHora);
                    cmd.Parameters.Add(":MONTO_POR_JORNAL", empleado.MontoPorJornal);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarEmpleado(int idUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM EMPLEADO WHERE ID_USUARIO = :ID_USUARIO";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":ID_USUARIO", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE EMPLEADO 
                                 SET MONTO_POR_HORA = :MONTO_POR_HORA,
                                     MONTO_POR_JORNAL = :MONTO_POR_JORNAL
                                 WHERE ID_USUARIO = :ID_USUARIO";

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":MONTO_POR_HORA", empleado.MontoPorHora);
                    cmd.Parameters.Add(":MONTO_POR_JORNAL", empleado.MontoPorJornal);
                    cmd.Parameters.Add(":ID_USUARIO", empleado.IdUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}







