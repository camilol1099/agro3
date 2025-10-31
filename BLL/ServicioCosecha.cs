using DLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ServicioCosecha
    {
        RepoCosecha repo = new RepoCosecha();

        public List<Cosecha> ObtenerCosecha()
        {
            return repo.ObtenerCosechas();
        }

        public void GuardarCosecha(Cosecha cosecha)
        {
            if (cosecha.IdCosecha <= 0)
                throw new Exception("El ID de la cosecha no es válido.");
            if (string.IsNullOrWhiteSpace(cosecha.NombreLote))
                throw new Exception("El nombre del lote no puede estar vacío.");
            if (cosecha.FechaSiembra >= cosecha.FechaCosechaEstimada)
                throw new Exception("La fecha de siembra debe ser anterior a la fecha estimada de cosecha.");
            repo.GuardarCosecha(cosecha);
        }

        public void EliminarCosecha(int idCosecha)
        {
            if (idCosecha <= 0)
                throw new Exception("El ID de la cosecha no es válido.");
            repo.EliminarCosecha(idCosecha);
        }

        public void ActualizarCosecha(Cosecha cosecha)
        {
            if (cosecha.IdCosecha <= 0)
                throw new Exception("El ID de la cosecha no es válido.");
            if (string.IsNullOrWhiteSpace(cosecha.NombreLote))
                throw new Exception("El nombre del lote no puede estar vacío.");
            if (cosecha.FechaSiembra >= cosecha.FechaCosechaEstimada)
                throw new Exception("La fecha de siembra debe ser anterior a la fecha estimada de cosecha.");
            repo.ActualizarCosecha(cosecha);
        }

    }
}
