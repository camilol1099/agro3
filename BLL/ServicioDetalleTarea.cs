using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL
{
    public class ServicioDetalleTarea
    {
        RepoDetalleTarea repoDetalleTarea = new RepoDetalleTarea();

        public List<DetalleTarea> ObtenerDetallesTarea()
        {
            return repoDetalleTarea.ObtenerDetallesTarea();
        }

       public void GuardarDetalleTarea(DetalleTarea detalle)
        {
            repoDetalleTarea.GuardarDetalleTarea(detalle);
        }
        public void EliminarDetalleTarea(int idDetalleTarea)
        {
            repoDetalleTarea.EliminarDetalleTarea(idDetalleTarea);
        }

        public void ActualizarDetalleTarea(DetalleTarea detalle)
        {
            repoDetalleTarea.ActualizarDetalleTarea(detalle);
        }
    }
}
