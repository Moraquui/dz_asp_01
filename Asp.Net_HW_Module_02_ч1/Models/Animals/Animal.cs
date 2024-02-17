using Asp.Net_HW_Module_02_ч1.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Asp.Net_HW_Module_02_ч1.Models.Animals
{
    public abstract class Animal
    {
        protected IOutputService OutputService;

        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(IOutputService outputService, string name, int age)
        {
            OutputService = outputService;
            Name = name;
            Age = age;
        }
        public Animal() { }
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract string GetName();
        public abstract string GetSound();

        public void DisplayInfo()
        {
            OutputService.Write($"Name: {GetName()}, Sound: {GetSound()}");
        }
    }
    public class AnimalWrapper 
    {
        public int TypeDiscriminator { get; set; }
        public Animal TypeValue { get; set; }
    }
}
