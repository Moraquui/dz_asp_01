using Asp.Net_HW_Module_02_ч1.Services;

namespace Asp.Net_HW_Module_02_ч1.Models.Animals
{
    public class Dog : Animal
    {

        public Dog(IOutputService outputService, string name, int age) : base(outputService, name, age) { }
        public Dog(string name, int age) : base(new ConsoleOutputService(), name, age) { }
        public Dog() { }
        public override string GetName()
        {
            return "Dog name is: " + Name; 
        }
        public override string GetSound() => "Woof";
    }
}
