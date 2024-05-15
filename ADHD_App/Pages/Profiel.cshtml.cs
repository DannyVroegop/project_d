using Microsoft.AspNetCore.Mvc.RazorPages;
using ADHD_App.Models;
using ADHD_App.Services;
namespace ADHD_App.Pages
{

    public class Profiel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFilePeopleService PeopleService;
        public JsonFileUserInfoService UserInfoService;
        public Person People { get; private set; }
        public Extra_userinfo userinfo { get; private set; }

        public Profiel(ILogger<IndexModel> logger,
            JsonFilePeopleService productService,
            JsonFileUserInfoService userinfoservice)
        {
            _logger = logger;
            PeopleService = productService;
            UserInfoService = userinfoservice;
        }

        public void OnGet(Person user)
        {
            if (PeopleService.GetProducts() != null)
            {
                People = user;
            }
            if (UserInfoService.LoadInfo(People) != null)
            {
                userinfo = UserInfoService.LoadInfo(People.Id);
            }
        }
    }
}
