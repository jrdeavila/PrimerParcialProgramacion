using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DAL
{
    public class RepositorySubcidiado
    {
        public static string Path = "RepositorySubcidiado.json";
        public string SerialJson { get; set; }

        public List<LiquidacionSubcidiado> ListSubcidiados { get; set; }

        public RepositorySubcidiado()
        {
            if (File.Exists(Path))
            {
                SerialJson = ExtraerSerialDelRepositorio();
                ListSubcidiados = ExtraerListSubcidiadosDelRepositorio();
            }
            else
            {
                ListSubcidiados = new List<LiquidacionSubcidiado>();
                SerialJson = CrearSerialJson();
            }
        }
        public void GuardarLiquidacionSubcidiado(LiquidacionSubcidiado LiquidacionAGuardar) 
        { 
            ListSubcidiados.Add(LiquidacionAGuardar);
            SerialJson = CrearSerialJson();
        }

        public string CrearSerialJson() { return JsonConvert.SerializeObject(ListSubcidiados, Formatting.Indented); }
        public void GuardarEnRepostorio()
        {
            SerialJson = CrearSerialJson();
            using (StreamWriter Writer = File.CreateText(Path))
            {
                Writer.Write(SerialJson);
            }
        }
        public string ExtraerSerialDelRepositorio()
        {
            string InformacionExtraida;
            try
            {
                using (StreamReader Reader = File.OpenText(Path))
                {
                    InformacionExtraida = Reader.ReadToEnd();
                }
            }
            catch(IOException e)
            {
                InformacionExtraida = SerialJson;
            }

            return InformacionExtraida;
        }

        public List<LiquidacionSubcidiado> ExtraerListSubcidiadosDelRepositorio()
        { 
            return JsonConvert.DeserializeObject<List<LiquidacionSubcidiado>>(ExtraerSerialDelRepositorio());
        }
        
    }
}
