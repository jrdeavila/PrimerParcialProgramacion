using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class GestionLiquidacionAfiliado
    {
        public SubcidiadoServices SubcidiadoServices { get; set; }
        public ContributivoServices ContributivoServices { get; set; }

        public GestionLiquidacionAfiliado()
        {
            SubcidiadoServices = new SubcidiadoServices();
            ContributivoServices = new ContributivoServices();
        }

        public double isNumber(string Cadena)
        {
            double value = 0;
            try
            {
                Console.Write(Cadena); value = double.Parse(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine("El valor ingresado no es numerico");
                value = isNumber(Cadena);
            }
            return value;
        }
        public int MostrarItems()
        {
            Console.Clear();
            Console.WriteLine("\t\tOpciones\n");
            Console.WriteLine("Guardar.............(1)");
            Console.WriteLine("Consultar..........(2)");
            Console.WriteLine("Eliminar...........(3)");
            Console.WriteLine("Modificar..........(4)\n");
            Console.WriteLine("Salir..............(0)\n");
            return (int)isNumber("Selecione: ");
        }

        public void TodasLasOpciones(int item)
        {
            switch (item)
            {
                case 0: { break; }
                case 1: { GuardarInformacion(DiligenciarInformacion()); new GestionLiquidacionAfiliado(); break; }
                case 2: { ConsultarInformacion(); new GestionLiquidacionAfiliado(); break; }
                case 3: { EliminarLiquidacion(); new GestionLiquidacionAfiliado(); break; }
                case 4: { new GestionLiquidacionAfiliado(); break; }
                default: { new GestionLiquidacionAfiliado(); break; }
            } 
        }

        public Afiliado DiligenciarAfiliado()
        {
            Console.Clear();
            string Nombre, Sexo, Afiliacion = "S";
            long Cedula;
            int Edad;
            Console.WriteLine("Informacion del afiliado\n");
            Console.Write("Nombre: "); Nombre = Console.ReadLine();
            Cedula = (long)isNumber("Cedula: ");
            Edad = (int)isNumber("Edad: ");
            Console.Write("Sexo M/F:"); Sexo = Console.ReadLine();
            Sexo = Sexo.ToUpper();
            if (Sexo.Equals("M")) Sexo = "Masculino";
            else if (Sexo.Equals("F")) Sexo = "Femenino";
            Console.WriteLine("\tAfiliacion");
            Console.Write("(C) Contributivo (S) Subcidiado : "); Afiliacion = Console.ReadLine();
            Afiliacion = Afiliacion.ToUpper();
            if (Afiliacion.Equals("S")) { Afiliacion = "Subcidiado"; return new Afiliado(Nombre, Cedula, Sexo, Edad, Afiliacion); }
            else if (Afiliacion.Equals("C")) { Afiliacion = "Contributivo"; return new Afiliado(Nombre, Cedula, Sexo, Edad, Afiliacion); }
            else return DiligenciarAfiliado();
        }
        public LiquidacionAfiliado DiligenciarInformacion()
        {
            int DiasAfiliacion;            
            Afiliado NuevoAfiliado = DiligenciarAfiliado();
            DiasAfiliacion = (int)isNumber("Dias de afiliacion: ");
            if (NuevoAfiliado.Afiliacion.Equals("Subcidiado")) return new LiquidacionSubcidiado(NuevoAfiliado, DiasAfiliacion);
            else return new LiquidacionContributivo(NuevoAfiliado, DiasAfiliacion);
        }

        public void GuardarInformacion(LiquidacionAfiliado LiquidacionAGuardar)
        {
            string OP = "S";
            Console.Write("Desea guardar esta informacion S/N: "); OP = Console.ReadLine();
            OP = OP.ToUpper();
            if (OP.Equals("S"))
            {
                if (LiquidacionAGuardar is LiquidacionContributivo) ContributivoServices.GuardarLiquidacionContributivo((LiquidacionContributivo)LiquidacionAGuardar);
                else SubcidiadoServices.GuardarLiquidacionSubcidiado((LiquidacionSubcidiado)LiquidacionAGuardar);
            }
            else Console.WriteLine("La informacion no se guardo...");
        }

        public LiquidacionAfiliado BuscarLiquidacion()
        {
            long NumeroLiquidacion;
            LiquidacionAfiliado LiquidacionEncontrada = null;
            Console.Clear();
            Console.WriteLine("\tLiquidaciones registradas\n");
            List<LiquidacionAfiliado> TodasLasLiquidaciones = new List<LiquidacionAfiliado>();
            TodasLasLiquidaciones.AddRange(SubcidiadoServices.GetTodasLasLiquidacionSubcidiado());
            TodasLasLiquidaciones.AddRange(ContributivoServices.GetTodasLasLiquidacionContributivo());
            if (TodasLasLiquidaciones.Count() == 0) Console.WriteLine("No hay liquidaciones registradas");
            foreach (LiquidacionAfiliado i in TodasLasLiquidaciones)
            {
                Console.WriteLine("{0} Afiliacion: {1} Liquidacion del afiliado: {2}", i.NumeroLiquidacion, i.Afiliado.Afiliacion, i.LiquidacionAficiliacion);
            }
            //Console.WriteLine("\nEscriba el numero de liquidaicion para ver la informacion");
            NumeroLiquidacion = (long)isNumber("\nNumero de Liquidacion: ");
            foreach (LiquidacionAfiliado i in TodasLasLiquidaciones) { if (NumeroLiquidacion == i.NumeroLiquidacion) LiquidacionEncontrada = i; }
            if (LiquidacionEncontrada == null) Console.WriteLine("Este numero de liquidacion no esta registrado");
            return LiquidacionEncontrada;
        }
        public void ConsultarInformacion()
        {
            LiquidacionAfiliado LiquidacionAMostrar = BuscarLiquidacion();
            Console.WriteLine();
            MostrarInformacionLiquidacion(LiquidacionAMostrar);
        }
        public void EliminarLiquidacion()
        {
            LiquidacionAfiliado LiquidacionAEliminar = BuscarLiquidacion();
            if(LiquidacionAEliminar != null)
            {
                if (LiquidacionAEliminar is LiquidacionContributivo) ContributivoServices.EliminarLiquidacion(LiquidacionAEliminar.NumeroLiquidacion);
                else SubcidiadoServices.EliminarLiquidacion(LiquidacionAEliminar.NumeroLiquidacion);
            }
            
            
        }

        public void ModificarLiquidacion()
        {
            LiquidacionAfiliado Liquidacion = BuscarLiquidacion();
        }
        public void MostrarInformacionLiquidacion(LiquidacionAfiliado LiquidacionAMostrar)
        {
            Console.WriteLine("\tInformacion de la liquidacion");
            Console.WriteLine("Numero de liquidacion: {0}", LiquidacionAMostrar.NumeroLiquidacion);
            Console.WriteLine("\tInformacion del afiliado");
            Console.WriteLine("Nombre: {0}", LiquidacionAMostrar.Afiliado.Nombre);
            Console.WriteLine("Cedula: {0}", LiquidacionAMostrar.Afiliado.Cedula);
            Console.WriteLine("Edad: {0}", LiquidacionAMostrar.Afiliado.Edad);
            Console.WriteLine("Sexo: {0}", LiquidacionAMostrar.Afiliado.Sexo);
            Console.WriteLine("\tInformacion financiera");
            Console.WriteLine("Costo de liquidacion: ${0}", LiquidacionAMostrar.LiquidacionAficiliacion);
        }

    }
}
