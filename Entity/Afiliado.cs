using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Afiliado
    {
        public string Nombre { get; set; }
        public long Cedula { get; set; }
        public string Afiliacion { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }

        public Afiliado(string nombre, long cedula, string sexo, int edad, string afiliacion)
        {
            Nombre = nombre;
            Cedula = cedula;
            Sexo = sexo;
            Edad = edad;
            Afiliacion = afiliacion;
        }

    }
}
