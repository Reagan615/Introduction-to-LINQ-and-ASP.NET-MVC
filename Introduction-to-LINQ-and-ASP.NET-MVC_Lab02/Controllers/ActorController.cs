using Microsoft.AspNetCore.Mvc;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models;

namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Controllers
{
    public class ActorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageTitle = "All Actors";
            return View(Context.Actiors);
        }
        public IActionResult HighestPaidActor()
        {
          
            HashSet<Role> roles = Context.Roles.OrderByDescending(s =>
            {
                return s.Pay;
            }).ToHashSet();
            return View("Details", roles);  
        }

        public IActionResult Info(int id)
        {
            try
            {
                Actor actor = Context.Actiors.First(a =>
                {
                    return a.Id == id;
                });

                return View("Details",actor);
                
            } catch(Exception ex)
            {
                return NotFound();
            }
        }

    }
}
