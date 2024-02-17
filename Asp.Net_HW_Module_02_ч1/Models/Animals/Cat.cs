using Asp.Net_HW_Module_02_ч1.Services;

namespace Asp.Net_HW_Module_02_ч1.Models.Animals
{
    public class Cat : Animal
    {
        public Cat(IOutputService outputService, string name, int age) : base(outputService, name, age) { }
        public Cat() { }
        public override string GetName() => "Cat Name is: " + Name;
        public override string GetSound() => "Meow";
    }
}
