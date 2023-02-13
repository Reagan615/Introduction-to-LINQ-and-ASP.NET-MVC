using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;
using WebApplication3.Models.ViewModels;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MoviesAndActors vm = new MoviesAndActors(Context.Movies, Context.Actiors, "This is a web app about movies and actors");
            return View(vm);
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