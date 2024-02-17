using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dz_asp_01.Models;

namespace dz_asp_01.Pages
{
    public class CountriesModel : PageModel
    {
        public List<Country> CountryList { get; set; } = new List<Country>
        {
            new Country { Name = "Україна", Capital = "Київ", Population = 43000000 },
            new Country { Name = "Канада", Capital = "Оттава", Population = 38000000 },
            new Country { Name = "Китай", Capital = "Пекин", Population =    1411750000 },
            new Country { Name = "Индонезия", Capital = "Джакарта", Population =  274900000 }
        };

        public void OnGet()
        {
        }
    }
}
