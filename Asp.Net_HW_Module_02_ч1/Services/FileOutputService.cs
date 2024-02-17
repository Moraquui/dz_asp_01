namespace Asp.Net_HW_Module_02_ч1.Services
{
    public class FileOutputService
    {
        private readonly string _filePath;

        public FileOutputService(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}
