using Asp.Net_HW_Module_02_ч1.Models.Animals;
using Asp.Net_HW_Module_02_ч1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp.Net_HW_Module_02_ч1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOutputService _outputService;

        public IndexModel(ILogger<IndexModel> logger, IOutputService outputService)
        {
            _logger = logger;
            _outputService = outputService;
        }

        public void OnGet()
        {
            var dog = new Dog(_outputService, "Buddy", 5);
            dog.DisplayInfo();
        }
    }
}
