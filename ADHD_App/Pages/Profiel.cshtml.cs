using Microsoft.AspNetCore.Mvc.RazorPages;
using ADHD_App.Models;
using ADHD_App.Services;
namespace ADHD_App.Pages
{

    public class Profiel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFilePeopleService PeopleService;
        public Person[] Products { get; private set; }

        public Profiel(ILogger<IndexModel> logger,
            JsonFilePeopleService productService)
        {
            _logger = logger;
            PeopleService = productService;
        }

        public void OnGet()
        {
            if (PeopleService.GetProducts() != null)
            {
                Products = PeopleService.GetProducts();
            }
        }
    }
}
