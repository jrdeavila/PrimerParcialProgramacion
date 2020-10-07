using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SubcidiadoServices
    {
        public RepositorySubcidiado Repository { get; set; }
        public SubcidiadoServices() { Repository = new RepositorySubcidiado(); }

        public void GuardarLiquidacionSubcidiado(LiquidacionSubcidiado LiquidacionAGuardar)
        {
            Repository.GuardarLiquidacionSubcidiado(LiquidacionAGuardar);
            Repository.GuardarEnRepostorio();
        }

        public List<LiquidacionSubcidiado> GetTodasLasLiquidacionSubcidiado()
        {
            return Repository.ListSubcidiados;
        }
        public void EliminarLiquidacion(long NumeroLiquidacion)
        {
            List<LiquidacionSubcidiado> NuevaListaSubcidiados = new List<LiquidacionSubcidiado>();
            foreach(LiquidacionSubcidiado i  in Repository.ListSubcidiados)
            {
                if (NumeroLiquidacion != i.NumeroLiquidacion)
                {
                    NuevaListaSubcidiados.Add(i);
                }
            }
            Repository.ListSubcidiados = NuevaListaSubcidiados;
            Repository.GuardarEnRepostorio();
            
        }
        public LiquidacionSubcidiado BuscarPorNumeroDeLiquidacion(long NumeroLiquidacion)
        {
            LiquidacionSubcidiado liquidacionEncontrada = null;
            foreach(LiquidacionSubcidiado i in Repository.ListSubcidiados){
                if (i.NumeroLiquidacion == NumeroLiquidacion) { liquidacionEncontrada = i; break; }
            }
            return liquidacionEncontrada;
        }
    }
}
