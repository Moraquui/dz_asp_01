using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dz_asp_01.Models;

namespace dz_asp_01.Pages
{
    public class CountriesModel : PageModel
    {
        public List<Country> CountryList { get; set; } = new List<Country>
        {
            new Country { Name = "������", Capital = "���", Population = 43000000 },
            new Country { Name = "������", Capital = "������", Population = 38000000 },
            new Country { Name = "�����", Capital = "�����", Population =    1411750000 },
            new Country { Name = "���������", Capital = "��������", Population =  274900000 }
        };

        public void OnGet()
        {
        }
    }
}
