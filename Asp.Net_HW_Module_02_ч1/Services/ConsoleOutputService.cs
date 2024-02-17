namespace Asp.Net_HW_Module_02_ч1.Services
{
    public class ConsoleOutputService : IOutputService
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
