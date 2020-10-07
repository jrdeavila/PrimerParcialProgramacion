using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL
{
    public class RepositoryContributivo
    {
        public static string Path = "RepositoryContributivo.json";
        public string SerialJson { get; set; }

        public List<LiquidacionContributivo> ListContributivos { get; set; }

        public RepositoryContributivo()
        {
            if (File.Exists(Path))
            {
                SerialJson = ExtraerSerialDelRepositorio();
                ListContributivos = ExtraerListContributivosDelRepositorio();
            }
            else
            {
                ListContributivos = new List<LiquidacionContributivo>();
                SerialJson = CrearSerialJson();
            }
        }
        public void GuardarLiquidacionContributivo(LiquidacionContributivo LiquidacionAGuardar)
        {
            ListContributivos.Add(LiquidacionAGuardar);
            SerialJson = CrearSerialJson();
        }

        public string CrearSerialJson() { return JsonConvert.SerializeObject(ListContributivos, Formatting.Indented); }
        public void GuardarEnRepostorio()
        {
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
            catch (IOException e)
            {
                InformacionExtraida = SerialJson;
            }

            return InformacionExtraida;
        }

        public List<LiquidacionContributivo> ExtraerListContributivosDelRepositorio()
        {
            return JsonConvert.DeserializeObject<List<LiquidacionContributivo>>(ExtraerSerialDelRepositorio());
        }
    }
}
