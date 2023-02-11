using Microsoft.AspNetCore.Mvc.Rendering;

namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models.ViewModels
{
    public class CreateRoleVm
    {
        
        public List<SelectListItem> Actors { get; } = new List<SelectListItem>();
        public List<SelectListItem> Movies { get; } = new List<SelectListItem>();

        public string ActorId { get; set; }

        public string MovieId { get; set; }

        public string Credit { get; set; }

        public int Pay { get; set; }

        public CreateRoleVm(HashSet<Movie> movies, HashSet<Actor> actors)
        {
            foreach(Actor  a in actors)
            {
                Actors.Add(new SelectListItem(a.Name, a.Id.ToString()));
            }

            foreach(Movie m in movies)
            {
                Movies.Add(new SelectListItem(m.Title, m.Id.ToString()));
            }
        }

        public CreateRoleVm() 
        {

        }
    }
}
