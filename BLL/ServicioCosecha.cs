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
            if (cosecha.IdAdminRegistro <= 0)
                throw new Exception("El ID del Admin no es válido.");
            if (cosecha.IdCultivo <= 0)
                throw new Exception("El ID del cultivo no es válido.");
            if (string.IsNullOrWhiteSpace(cosecha.Calidad))
                throw new Exception("la calidad del lote no puede estar vacío.");
            if (cosecha.FechaCosecha <= cosecha.FechaRegistro)
                throw new Exception("La fecha de cosecha debe ser posterior a la fecha de registro.");
            if (cosecha.CantidadObtenida <= 0)
                throw new Exception("La cantidad obtenida debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(cosecha.UnidadMedida))
                throw new Exception("La unidad de medida no puede estar vacía.");
            if (cosecha.Observaciones != null && cosecha.Observaciones.Length > 500)
                throw new Exception("Las observaciones no pueden exceder los 500 caracteres.");
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
            if (cosecha.IdAdminRegistro <= 0)
                throw new Exception("El ID del Admin no es válido.");
            if (cosecha.IdCultivo <= 0)
                throw new Exception("El ID del cultivo no es válido.");
            if (string.IsNullOrWhiteSpace(cosecha.Calidad))
                throw new Exception("la calidad del lote no puede estar vacío.");
            if (cosecha.FechaCosecha <= cosecha.FechaRegistro)
                throw new Exception("La fecha de cosecha debe ser posterior a la fecha de registro.");
            if (cosecha.CantidadObtenida <= 0)
                throw new Exception("La cantidad obtenida debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(cosecha.UnidadMedida))
                throw new Exception("La unidad de medida no puede estar vacía.");
            if (cosecha.Observaciones != null && cosecha.Observaciones.Length > 500)
                throw new Exception("Las observaciones no pueden exceder los 500 caracteres.");
            repo.ActualizarCosecha(cosecha);
        }

    }
}
