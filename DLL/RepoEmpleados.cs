using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;

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
                string query = "SELECT IdEmpleado, MontoPorHora, MontoMensual , ID_Usu FROM empleado";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empleados.Add(new Empleado
                            {
                                IdEmpleado = reader.GetInt16("IdEmpleado"),
                                MontoPorHora = reader.GetDecimal("MontoPorHora"),
                                MontoMensual = reader.GetDecimal("MontoMensual"),
                                IdUsuario = reader.GetInt16("ID_Usu")
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
                string query = "INSERT INTO empleado (IdEmpleado, MontoPorHora, MontoMensual , ID_Usu) VALUES (@IdEmpleado,@MontoPorHora, @MontoMensual, @ID_Usu)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("@MontoPorHora", empleado.MontoPorHora);
                    cmd.Parameters.AddWithValue("@MontoMensual", empleado.MontoMensual);
                    cmd.Parameters.AddWithValue("@ID_Usu", empleado.IdUsuario);

                    int filas = cmd.ExecuteNonQuery();
                }

            }
        }
            public void EliminarEmpleado(int idEmpleado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM empleado WHERE IdEmpleado = @IdEmpleado";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                    int filas = cmd.ExecuteNonQuery();
                }
            }
        }

                public void ActualizarEmpleado(Empleado empleado)
                {
                    using (var connection = GetConnection())
                    {
                        connection.Open();
                        string query = "UPDATE empleado SET MontoPorHora = @MontoPorHora, MontoMensual = @MontoMensual, ID_Usu = @ID_Usu WHERE IdEmpleado = @IdEmpleado";
                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                            cmd.Parameters.AddWithValue("@MontoPorHora", empleado.MontoPorHora);
                            cmd.Parameters.AddWithValue("@MontoMensual", empleado.MontoMensual);
                            cmd.Parameters.AddWithValue("@ID_Usu", empleado.IdUsuario);
                            int filas = cmd.ExecuteNonQuery();
                        }
                    }
        }
    }
    }



