using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class ContributivoServices
    {
        public RepositoryContributivo Repository { get; set; }
        public ContributivoServices() { Repository = new RepositoryContributivo(); }

        public void GuardarLiquidacionContributivo(LiquidacionContributivo LiquidacionAGuardar)
        {
            Repository.GuardarLiquidacionContributivo(LiquidacionAGuardar);
            Repository.GuardarEnRepostorio();
        }

        public List<LiquidacionContributivo> GetTodasLasLiquidacionContributivo()
        {
            return Repository.ListContributivos;
        }

        public LiquidacionContributivo BuscarPorNumeroDeLiquidacion(long NumeroLiquidacion)
        {
            LiquidacionContributivo liquidacionEncontrada = null;
            foreach (LiquidacionContributivo i in Repository.ListContributivos)
            {
                if (i.NumeroLiquidacion == NumeroLiquidacion) { liquidacionEncontrada = i; break; }
            }
            return liquidacionEncontrada;
        }
    }
}
