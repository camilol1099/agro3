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
        protected string ruta;

        protected BaseRepo(string nombreArchivo)
        {
            this.ruta = nombreArchivo;
        }

        public string Guardar(T entidad)
        {
            StreamWriter sw = new StreamWriter(ruta,true);
            sw.WriteLine(entidad.ToString());
            sw.Close();
            return $"se guardo los datos de la entidad {typeof(T).Name}";
        }

        public abstract IList<T> Consultar();
        public abstract T ObtenerPorId(int id);

    }
}
