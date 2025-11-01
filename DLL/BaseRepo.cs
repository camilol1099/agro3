using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
   public  abstract class BaseRepo<T>
    {
       
       string connectionString = "User Id=root;Password=Santi2223;Data Source=localhost:1521/XEPDB1;";


        protected OracleConnection GetConnection()
        {
            
            return new OracleConnection(connectionString);
        }
       
    }
}
