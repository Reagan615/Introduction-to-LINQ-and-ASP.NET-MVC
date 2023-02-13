using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ViewModels;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateRoleVm vm = new CreateRoleVm(Context.Movies, Context.Actiors);

            return View(vm);
        }

        [HttpPost]

        public IActionResult Create([Bind("ActorId", "MovieId", "Credit", "Pay")]CreateRoleVm vm, string secret)
        {
            try
            {
                Actor actor = Context.Actiors.First(s => s.Id == Int32.Parse(vm.ActorId));
                Movie movie = Context.Movies.First(m => m.Id == Int32.Parse(vm.MovieId));
                string credit = vm.Credit;
                int pay = vm.Pay;

                //create new role and add to context relationships

                Role newRole = new Role(credit, pay, actor, movie);
                actor.AddRole(newRole);
                movie.AddRole(newRole);

                Context.Roles.Add(newRole);

                return RedirectToAction("Info", "Movie", new { id = movie.Id});
            } catch (Exception ex)
            {
                return NotFound();
            }
            
        }
    }
}
