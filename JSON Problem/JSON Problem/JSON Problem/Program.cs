using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace JSON_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Init arrays
            var objectsWithArrays = new ClassWithArray[] { new ClassWithArray(new int[] { 1, 2, 3 }), new ClassWithArray(new int[] { 4, 5, 6 }) };
            var objectsWithLists = new ClassWithList[] { new ClassWithList(new List<int> { 1, 2, 3 }), new ClassWithList(new List<int> { 4, 5, 6 }) };

            DoJsonStuff<ClassWithArray>(objectsWithArrays);
            DoJsonStuff<ClassWithList>(objectsWithLists);
        }

        static void DoJsonStuff<T>(T[] objectArray)
        {
            // Serialize
            var jsonSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            string json = JsonConvert.SerializeObject(objectArray, jsonSettings);
            Console.WriteLine(json);

            // Store .json on desktop
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, $"JSON_{objectArray[0].ToString()}.json");
            File.WriteAllText(filename, json);

            // Read .json from desktop
            var jsonFile = File.ReadAllText(filename);

            // Deserialize
            var deserializedObjects = JsonConvert.DeserializeObject<T[]>(jsonFile, jsonSettings);
            Console.WriteLine("\nDeserialization completed\n");
            json = JsonConvert.SerializeObject(objectArray, jsonSettings);
            Console.WriteLine(json);
        }
    }
}
