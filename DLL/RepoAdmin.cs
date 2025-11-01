using Entidades;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class RepoAdmin: BaseRepo<Administrador>
    {
        public List<Administrador> ObtenerEmpleados()
        {
            List<Administrador> admin = new List<Administrador>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT IdEmpleado, MontoPorHora, MontoMensual, ID_Usu FROM empleado";
                using (var cmd = new OracleCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admin.Add(new Administrador
                            {
                                IdAdministrador = reader.GetInt32(0),
                                MontoMensual = reader.GetDecimal(2),
                                UsuarioId = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return admin;
        }

        public void GuardarAdmin(Administrador admin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO empleado (IdEmpleado, MontoMensual, ID_Usu) " +
                               "VALUES (:IdEmpleado, :MontoMensual, :ID_Usu)";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdEmpleado", admin.IdAdministrador));
                    cmd.Parameters.Add(new OracleParameter(":MontoMensual", admin.MontoMensual));
                    cmd.Parameters.Add(new OracleParameter(":ID_Usu", admin.UsuarioId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAdmin(int idAdmin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM empleado WHERE IdEmpleado = :IdEmpleado";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":IdEmpleado", idAdmin));
                    cmd.ExecuteNonQuery();
                }
            }
        }

       public void ActualizarAdmin(Administrador admin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE empleado SET MontoMensual = :MontoMensual, ID_Usu = :ID_Usu WHERE IdEmpleado = :IdEmpleado";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter(":MontoMensual", admin.MontoMensual));
                    cmd.Parameters.Add(new OracleParameter(":ID_Usu", admin.UsuarioId));
                    cmd.Parameters.Add(new OracleParameter(":IdEmpleado", admin.IdAdministrador));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

