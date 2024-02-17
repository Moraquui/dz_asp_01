using Asp.Net_HW_Module_02_ч1.Models.Animals;

namespace Asp.Net_HW_Module_02_ч1.Services
{
    public interface IAnimalSerializer
    {
        void SerializeToFile(IEnumerable<Animal> animals, string filePath);
        IEnumerable<Animal> DeserializeFromFile(string filePath);
    }
}
