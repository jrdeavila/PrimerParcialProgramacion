using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class LiquidacionAfiliado
    {
        public Afiliado Afiliado { get; set; }
        public long NumeroLiquidacion { get; set; }
        public double PrimaAdicional { get; set; }
        public int DiasAfiliacion { get; set; }
        public double ValorUPCdiaria { get; set; }
        public double LiquidacionAficiliacion { get; set; }

        public LiquidacionAfiliado(Afiliado afiliado, int diasAfiliacion)
        {
            Afiliado = afiliado;
            DiasAfiliacion = diasAfiliacion;
            NumeroLiquidacion = new Random().Next(100000, 999999);
            PrimaAdicional = CalcularPrimaAdicional();
            ValorUPCdiaria = CalcularValorUPCdiario();
            LiquidacionAficiliacion = CalcularLiquidacionAfiliacion();
        }

        public abstract double CalcularPrimaAdicional();
        public abstract double CalcularValorUPCdiario();

        public double CalcularLiquidacionAfiliacion()
        {
            return DiasAfiliacion * ValorUPCdiaria * PrimaAdicional;
        }
    }
}
