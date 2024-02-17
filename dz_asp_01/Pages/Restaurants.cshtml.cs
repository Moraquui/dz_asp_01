using dz_asp_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace dz_asp_01.Pages
{

    public class RestaurantsModel : PageModel
    {
        public List<Restaurant> Restaurants { get; set; }

        public void OnGet()
        {
            Restaurants = new List<Restaurant>
        {
            new Restaurant { Name = "Ресторан 1", Address = "Адреса 1", Cuisine = "Кухня 1" },
            new Restaurant { Name = "Ресторан 2", Address = "Адреса 2", Cuisine = "Кухня 2" }
            // Додайте більше ресторанів за потребою
        };
        }
    }
}
