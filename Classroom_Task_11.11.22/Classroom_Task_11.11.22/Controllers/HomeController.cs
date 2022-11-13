using Classroom_Task_11._11._22.Entity;
using Classroom_Task_11._11._22.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Classroom_Task_11._11._22.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // private readonly UserManager<User> userManager;
        public HomeController(ILogger<HomeController> logger /*, UserManager<User> userManager*/)
        {
            //this.userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
           // var users = userManager.Users.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}