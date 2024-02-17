using Asp.Net_HW_Module_02_ч1.Models.Animals;
using Asp.Net_HW_Module_02_ч1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp.Net_HW_Module_02_ч1.Pages
{
    public class AnimalModel : PageModel
    {
        private readonly IEnumerable<IAnimalSerializer> _serializers;
        private readonly IWebHostEnvironment _environment;
        IOutputService _OutputService;

        public List<Animal> animals =  new List<Animal>();
        public AnimalModel(IEnumerable<IAnimalSerializer> serializers, IWebHostEnvironment environment, IOutputService outputService)
        {
            _serializers = serializers;
            _environment = environment;
            _OutputService = outputService;
        }
        public IActionResult OnPost()
        {
            if (Request.Form["action"] == "SaveAnimals")
            {
                OnPostSaveAnimals(Format);
            }
            else if (Request.Form["action"] == "LoadAnimals")
            {
                OnPostLoadAnimals(Format);
            }

            return Page();
        }

        [BindProperty]
        public string Format { get; set; }

        public void OnPostSaveAnimals(string format)
        {
            var serializer = _serializers.FirstOrDefault(s => (s as IFileFormat)?.Extension == format);
            if (serializer != null)
            {
                var filePath = Path.Combine(_environment.WebRootPath, $"animals{format}");
                serializer.SerializeToFile(animals, filePath);
            }
        }


        public void OnPostLoadAnimals(string format)
        {
            var serializer = _serializers.FirstOrDefault(s => (s as IFileFormat)?.Extension == format);
            if (serializer != null)
            {
                var filePath = Path.Combine(_environment.WebRootPath, $"animals{format}");
                animals = (List<Animal>)serializer.DeserializeFromFile(filePath);

            }
        }
    }
}
