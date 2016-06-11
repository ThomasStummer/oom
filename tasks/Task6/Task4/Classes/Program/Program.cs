using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

using static Task6.StaticDemoClass;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            var werkzeugMaschinen = new IWerkzeugmaschine[]
            {
                new Drehmaschine(1, 4),
                new Drehmaschine(2, 4),
                new Fraesmaschine(3, 4),
                new Fraesmaschine(4, 4)
            };

            // Mit den Maschinen arbeiten
            //ArbeitenMitMaschinen(werkzeugMaschinen);          // Uncomment to execute

            // JSON
            //DoJsonStuff(werkzeugMaschinen);          // Uncomment to execute

            // Asynchroner Teil
            UseAsynchronFeatures(werkzeugMaschinen);          // Uncomment to execute
        }              

        private static void ArbeitenMitMaschinen(IWerkzeugmaschine[] werkzeugMaschinen)
        {
            // Print initial state of all machines
            Console.WriteLine("Print inital state of machines\n");
            ExecuteActionOnAllWerkzeugmaschinen(werkzeugMaschinen, PrintStateOfWerkzeugmaschine);

            // Werkzeug aufruesten
            Console.WriteLine("Add tools to machines\n");
            ExecuteActionOnAllWerkzeugmaschinen(werkzeugMaschinen, WerkzeugmaschineAufruesten);

            // Print new state of machines
            Console.WriteLine("Print new state of machines\n");
            ExecuteActionOnAllWerkzeugmaschinen(werkzeugMaschinen, PrintStateOfWerkzeugmaschine);

            // Drehen und Fraesen
            Console.WriteLine("Let the work beginn...\n");
            ExecuteActionOnAllWerkzeugmaschinen(werkzeugMaschinen, WerkstueckBearbeiten);
        }

        private static void DoJsonStuff(IWerkzeugmaschine[] werkzeugMaschinen)
        {
            Console.WriteLine("\n#\n# JSON\n#\n");

            // Serialize
            var jsonSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            string json = JsonConvert.SerializeObject(werkzeugMaschinen, jsonSettings);
            Console.WriteLine(json);

            // Store .json on desktop
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "werkzeugmaschinen.json");
            File.WriteAllText(filename, json);

            // Read .json from desktop
            var jsonFile = File.ReadAllText(filename);

            // Deserialize
            var jsonWerkzeugmaschinen = JsonConvert.DeserializeObject<IWerkzeugmaschine[]>(jsonFile, jsonSettings);
            Console.WriteLine("\nDeserialization completed\n");

            // Work with imported Werkzeugmaschinen
            ExecuteActionOnAllWerkzeugmaschinen(jsonWerkzeugmaschinen, WerkstueckBearbeiten);
        }

        private static void UseAsynchronFeatures(IWerkzeugmaschine[] werkzeugMaschinen)
        {
            //PullExample.Run();          // Uncomment to execute
            PushExampleWithSubject.Run();          // Uncomment to execute
            //TasksExample.Run();          // Uncomment to execute
        }

    }
}
