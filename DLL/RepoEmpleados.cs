using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class RepoEmpleados : BaseRepo<Empleado>
    {
        public RepoEmpleados(string nombreArchivo) : base(nombreArchivo)
        {
        }
       

        public override IList<Empleado> Consultar()
        {
            try
            {
                StreamReader lector = new StreamReader(ruta);
                List<Empleado> lista = new List<Empleado>();

                while (!lector.EndOfStream)
                {

                    lista.Add(Mappear(lector.ReadLine()));
                }
                lector.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private Empleado Mappear(string linea)
        {
            Empleado empleado = new Empleado();

            var aux = linea.Split(';');

            empleado.IdEmpleado= int.Parse(aux[0]);
            empleado.Nombre = aux[1];
            empleado.Telefono = aux[2];
            empleado.MontoPorHora = decimal.Parse(aux[3]);
            empleado.MontoMensual = decimal.Parse(aux[4]);
            empleado.UsuarioId = int.Parse(aux[5]);



            return empleado;
        }

        public override Empleado ObtenerPorId(int id)
        {
            return Consultar().FirstOrDefault(x => x.IdEmpleado == id);
        }

    }
}
