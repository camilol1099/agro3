using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL
{
    public class ServicioActivoFijo
    {
        RepoActivoFijo repo = new RepoActivoFijo();
        public List<Entidades.ActivooFijp> ObtenerActivoFijo()
        {
            return repo.ObtenerTodos();
        }

        public void GuardarActivoFijo(Entidades.ActivooFijp activooFijp)
        {
            if (activooFijp.InsumoId <= 0)
                throw new Exception("El ID del activo fijo no es válido.");
            repo.Insertar(activooFijp);
        }

        public void EliminarActivoFijo(int idActivoFijo)
        {
            if (idActivoFijo <= 0)
                throw new Exception("El ID del activo fijo no es válido.");
            repo.Eliminar(idActivoFijo);
        }

        public void ActualizarActivoFijo(Entidades.ActivooFijp activooFijp)
        {
            if (activooFijp.InsumoId <= 0)
                throw new Exception("El ID del activo fijo no es válido.");
            
            repo.Actualizar(activooFijp);
        }
    }
}
