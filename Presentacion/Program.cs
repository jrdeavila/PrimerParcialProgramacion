using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;


namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Afiliado afiliado = new Afiliado("Jose Ricardo", 1003316620, "Masculino", 19, "Contributivo");
            Afiliado afiliadoS = new Afiliado("Jose Ricardo", 1003316620, "Masculino", 19, "Subcidiado");
            LiquidacionAfiliado liquidacion = new LiquidacionContributivo(afiliado, 29);
            LiquidacionAfiliado liquidacionS = new LiquidacionSubcidiado(afiliadoS, 29);
            Console.WriteLine(liquidacionS.LiquidacionAficiliacion);
            Console.WriteLine(liquidacion.LiquidacionAficiliacion);
            Console.ReadKey();
        }
    }
}
