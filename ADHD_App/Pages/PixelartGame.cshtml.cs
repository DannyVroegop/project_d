using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ADHD_App.Models;
using ADHD_App.Services;
using ADHD_App.Pages;
namespace ADHD_App.Pages
{

    public class PixelartGame : PageModel
    {
        private readonly ILogger<PixelartGame> _logger;
        public JsonFilePeopleService PeopleService;
        public JsonFileHandler Jsonfilehandler;
        public BreakService breakService {get; set;}
        //public JsonFileUserInfoService UserInfoService;
        public Person People { get; set; }

        public PixelartGame(ILogger<PixelartGame> logger,
            JsonFilePeopleService productService, JsonFileHandler jsonfilehandler)
        {
            _logger = logger;
            PeopleService = productService;
            Jsonfilehandler = jsonfilehandler;
            breakService = new BreakService(Jsonfilehandler);
            //UserInfoService = userinfoservice;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Cookies["id"]);
            if (PeopleService.getUserById(id) != null)
                People = PeopleService.getUserById(id);
            //if (UserInfoService.LoadInfo(People) != null)
            //{
                //userinfo = UserInfoService.LoadInfo(People);
            //}
        }

        public IActionResult OnPostTakeBreak()
        {
            if (People == null)
            {
                int id = int.Parse(Request.Cookies["id"]);
                if (PeopleService.getUserById(id) != null)
                    People = PeopleService.getUserById(id);
            }
            
            if (breakService.BreakOngoing(People) == false)
            {
                breakService.CreateBreak(People);
            }

            return RedirectToPage("/Break");
        }
    }
}