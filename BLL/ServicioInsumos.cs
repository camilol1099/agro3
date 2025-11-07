using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using Entidades;

namespace BLL
{
    public class ServicioInsumos
    {
        RepoInsumos repoInsumos = new RepoInsumos();
        public List<Insumo> ObtenerInsumos()
        {
            return repoInsumos.ObtenerInsumos();
        }

        public void AgregarInsumo(Insumo insumo)
        {
            if (insumo.IdInsumo <= 0)
            {
                throw new Exception("El ID del insumo no es válido.");
            }
            if (insumo.StockActual < 0)
            {
                throw new Exception("El stock actual no puede ser negativo.");
            }
            if (insumo.CostoUnitario < 0)
            {
                throw new Exception("El costo unitario no puede ser negativo.");
            }
            if (string.IsNullOrWhiteSpace(insumo.Nombre))
            {
                throw new Exception("El nombre del insumo no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(insumo.Tipo))
            {
                throw new Exception("El tipo de insumo no puede estar vacío.");
            }
            if (insumo.StockMinimo < 0)
            {
                throw new Exception("El stock mínimo no puede ser negativo.");
            }

            repoInsumos.GuardarInsumo(insumo);
        }

        public void EliminarInsumo(int id)
        {
            if (id <= 0)
                throw new Exception("El ID del insumo no es válido.");
            repoInsumos.EliminarInsumo(id);
        }
        public void ActualizarInsumo(Insumo insumo)
        {
            if (insumo.IdInsumo <= 0)
            {
                throw new Exception("El ID del insumo no es válido.");
            }
            if (insumo.StockActual < 0)
            {
                throw new Exception("El stock actual no puede ser negativo.");
            }
            if (insumo.CostoUnitario < 0)
            {
                throw new Exception("El costo unitario no puede ser negativo.");
            }
            if (string.IsNullOrWhiteSpace(insumo.Nombre))
            {
                throw new Exception("El nombre del insumo no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(insumo.Tipo))
            {
                throw new Exception("El tipo de insumo no puede estar vacío.");
            }
            if (insumo.StockMinimo < 0)
            {
                throw new Exception("El stock mínimo no puede ser negativo.");
            }
            repoInsumos.ActualizarInsumo(insumo);
        }
    }
}
