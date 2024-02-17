using Asp.Net_HW_Module_02_ч1.Services;
using System.Xml.Serialization;

namespace Asp.Net_HW_Module_02_ч1.Models.Animals
{
    public class XmlAnimalSerializer : IAnimalSerializer, IFileFormat
    {
        public string Extension => ".xml";

        public void SerializeToFile(IEnumerable<Animal> animals, string filePath)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Animal>));
            using var writer = new StreamWriter(filePath);
            xmlSerializer.Serialize(writer, animals.ToList());
        }

        public IEnumerable<Animal> DeserializeFromFile(string filePath)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Animal>));
            using var reader = new StreamReader(filePath);
            return (IEnumerable<Animal>)xmlSerializer.Deserialize(reader);
        }
    }
}
