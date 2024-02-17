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
            new Restaurant { Name = "�������� 1", Address = "������ 1", Cuisine = "����� 1" },
            new Restaurant { Name = "�������� 2", Address = "������ 2", Cuisine = "����� 2" }
            // ������� ����� ��������� �� ��������
        };
        }
    }
}
