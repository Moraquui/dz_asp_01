using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dz_asp_01.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public int DayOfYear { get; set; }

        public void OnGet()
        {
            //1
            DayOfYear = DateTime.Now.DayOfYear;

            //2
            Random rnd = new Random();
            char randomChar = (char)('A' + rnd.Next(0, 26));
            ViewData["RandomChar"] = randomChar;
        }
    }
}
