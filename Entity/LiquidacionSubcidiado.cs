using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionSubcidiado : LiquidacionAfiliado
    {
        public LiquidacionSubcidiado(Afiliado afiliado, int diasAfiliacion) : base(afiliado, diasAfiliacion) { }

        public override double CalcularPrimaAdicional()
        {
            if (Afiliado.Edad < 1) return 2;
            else if (Afiliado.Edad >= 1 && Afiliado.Edad <= 15) return 0.8;
            else if (Afiliado.Edad >= 16 && Afiliado.Edad <= 18 && Afiliado.Sexo.Equals("Masculino")) return 0.2;
            else if (Afiliado.Edad >= 16 && Afiliado.Edad <= 18 && Afiliado.Sexo.Equals("Femenino")) return 0.3;
            else if (Afiliado.Edad >= 19 && Afiliado.Edad <= 44) return 1;
            else if (Afiliado.Edad >= 45 && Afiliado.Edad <= 69) return 2.5;
            else return 3;
        }

        public override double CalcularValorUPCdiario()
        {
            return 2000;
        }
    }
}
