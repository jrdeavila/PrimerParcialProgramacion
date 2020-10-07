using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionContributivo : LiquidacionAfiliado
    {
        public LiquidacionContributivo(Afiliado afiliado, int diasAfiliacion) : base(afiliado, diasAfiliacion)
        {
        }

        public override double CalcularPrimaAdicional()
        {
            if (Afiliado.Edad < 1) return 2.5;
            else if (Afiliado.Edad >= 1 && Afiliado.Edad <= 15) return 0.9;
            else if (Afiliado.Edad >= 16 && Afiliado.Edad <= 18) return 0.3;
            else if (Afiliado.Edad >= 19 && Afiliado.Edad <= 44) return 1.5;
            else if (Afiliado.Edad >= 45 && Afiliado.Edad <= 69) return 3;
            else return 3.5;
        }

        public override double CalcularValorUPCdiario()
        {
            return 2400;
        }
    }
}
