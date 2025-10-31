using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DLL
{
   public  abstract class BaseRepo<T>
    {
        protected string connectionString =
           "Server=localhost;Database=agro_smart;Uid=root;Pwd=Santi2223;";

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
