using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

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
            SubcidiadoServices servicesS = new SubcidiadoServices();
            ContributivoServices servicesC = new ContributivoServices();
            //servicesS.GuardarLiquidacionSubcidiado((LiquidacionSubcidiado)liquidacionS);
            servicesC.GuardarLiquidacionContributivo((LiquidacionContributivo)liquidacion);
            foreach (LiquidacionContributivo i in servicesC.GetTodasLasLiquidacionContributivo())
            {
                Console.WriteLine(i.LiquidacionAficiliacion);
                Console.WriteLine(i.Afiliado.Nombre);
                Console.WriteLine(i.NumeroLiquidacion);
            }

            liquidacion = servicesC.BuscarPorNumeroDeLiquidacion(long.Parse(Console.ReadLine()));
            Console.WriteLine(liquidacion.Afiliado.Cedula);
            Console.ReadKey();
        }
    }
}
