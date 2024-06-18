using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ADHD_App.Models;
using ADHD_App.Services;
namespace ADHD_App.Pages
{

    public class Snakegame : PageModel
    {
        private readonly ILogger<Snakegame> _logger;
        public JsonFilePeopleService PeopleService;
        public JsonFileHandler Jsonfilehandler;
        public BreakService breakService;
        //public JsonFileUserInfoService UserInfoService;
        public Person People { get; set; }

        public Snakegame(ILogger<Snakegame> logger,
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