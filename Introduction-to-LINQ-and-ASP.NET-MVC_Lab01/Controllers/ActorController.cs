using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab01.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab01.Models;

namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab01.Controllers
{
    public class ActorController : Controller
    {
        public IActionResult HighestPaidActor()
        {
          
            HashSet<Role> roles = Context.Roles.OrderByDescending(s =>
            {
                return s.Pay;
            }).ToHashSet();
            return View("Details", roles);

            
        }
    }
}
