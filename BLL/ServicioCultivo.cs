using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using Entidades;

namespace BLL
{
    public class ServicioCultivo
    {
        RepoCultivo repo = new RepoCultivo();
        public List<Cultivo> ObtenerCultivo()
        {
            return repo.ObtenerCultivos();
        }
        public void GuardarCultivo(Cultivo cultivo)
        {
            if (cultivo.IdCultivo <= 0)
                throw new Exception("El ID del cultivo no es válido.");
            if (string.IsNullOrWhiteSpace(cultivo.NombreLote))
                throw new Exception("El nombre del lote no puede estar vacío.");
            if (cultivo.FechaSiembra >= cultivo.FechaCosechaEstimada)
                throw new Exception("La fecha de siembra debe ser anterior a la fecha estimada de cosecha.");
            repo.GuardarCultivo(cultivo);
        }
    }
}
