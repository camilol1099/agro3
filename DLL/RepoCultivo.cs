using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class RepoCultivo : BaseRepo<Cultivo>
    {
        public List<Cultivo> ObtenerCultivos()
        {
            List<Cultivo> cosecha = new List<Cultivo>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT IdCultivo , NombreLote, FechaSiembra ,FechaCosechaEstimada,AlertaNBn FROM cosecha";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cosecha.Add(new Cultivo
                            {
                                IdCultivo = reader.GetInt16("IdEmpleado"),
                                NombreLote = reader.GetString("MontoPorHora"),
                                FechaSiembra = reader.GetDateTime("MontoMensual"),
                                FechaCosechaEstimada = reader.GetDateTime("ID_Usu"),
                                AlertaNBn = reader.GetString("AlertaNBn")
                            });
                        }
                    }
                }
            }
            return cosecha;
        }


        public void GuardarCultivo(Cultivo cultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO cosecha (IdCosecha, NombreLote, FechaSiembra ,FechaCosechaEstimada,AlertaNBn) VALUES (@IdCosecha,@NombreLote, @FechaSiembra, @FechaCosechaEstimada,@AlertaNBn)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdCosecha", cultivo.IdCultivo);
                    cmd.Parameters.AddWithValue("@NombreLote", cultivo.NombreLote);
                    cmd.Parameters.AddWithValue("@FechaSiembra", cultivo.FechaSiembra);
                    cmd.Parameters.AddWithValue("@FechaCosechaEstimada", cultivo.FechaCosechaEstimada);
                    cmd.Parameters.AddWithValue("@AlertaNBn", cultivo.AlertaNBn);
                    int filas = cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCultivo(int idCultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM cultivo WHERE IdCultivo = @IdCultivo";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdCultivo", idCultivo);
                    int filas = cmd.ExecuteNonQuery();
                }
            }

        }

        public void ActualizarCultivo(Cultivo cultivo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE cultivo SET NombreLote = @NombreLote, FechaSiembra = @FechaSiembra, FechaCosechaEstimada = @FechaCosechaEstimada, AlertaNBn = @AlertaNBn WHERE IdCultivo = @IdCultivo";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdCultivo", cultivo.IdCultivo);
                    cmd.Parameters.AddWithValue("@NombreLote", cultivo.NombreLote);
                    cmd.Parameters.AddWithValue("@FechaSiembra", cultivo.FechaSiembra);
                    cmd.Parameters.AddWithValue("@FechaCosechaEstimada", cultivo.FechaCosechaEstimada);
                    cmd.Parameters.AddWithValue("@AlertaNBn", cultivo.AlertaNBn);
                    int filas = cmd.ExecuteNonQuery();
                }
            }
        }


    }
}





