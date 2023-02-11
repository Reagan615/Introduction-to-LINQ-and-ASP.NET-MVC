using Microsoft.AspNetCore.Mvc.Rendering;

namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models.ViewModels
{
    public class CreateRating
    {
        public List<SelectListItem> Movies { get; } = new List<SelectListItem>();

        public List<SelectListItem> Actors { get; } = new List<SelectListItem>();
        public List<SelectListItem> Users { get; } = new List<SelectListItem>();
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public CreateRating(HashSet<Movie> movies, HashSet<Actor> actors, HashSet<User> users)
        {
            foreach(Movie m in movies)
            {
                Movies.Add(new SelectListItem(m.Title, m.Id.ToString()));
            }

            foreach (Actor a in actors)
            {
                Actors.Add(new SelectListItem(a.Name, a.Id.ToString()));
            }

            

        }
    }
}
