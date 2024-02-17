using Asp.Net_HW_Module_02_ч1.Services;
using System.Text.Json;

namespace Asp.Net_HW_Module_02_ч1.Models.Animals
{
    public class JsonAnimalSerializer : IAnimalSerializer, IFileFormat
    {
        public string Extension => ".json";

        

        public JsonAnimalSerializer()
        {
            Options = new JsonSerializerOptions
            { 
                WriteIndented = true

            };
            Options.Converters.Add(new AnimalJsonConverter());
        }

        public JsonSerializerOptions Options { get; }

        public void SerializeToFile(IEnumerable<Animal> animals, string filePath)
        {
            var json = JsonSerializer.Serialize(animals, Options);
            File.WriteAllText(filePath, json);
        }

        public IEnumerable<Animal> DeserializeFromFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<IEnumerable<Animal>>(json, Options);
        }
    }
}
