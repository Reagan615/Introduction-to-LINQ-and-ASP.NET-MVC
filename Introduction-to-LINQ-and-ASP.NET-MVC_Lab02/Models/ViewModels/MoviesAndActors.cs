using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models;

namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models.ViewModels
{
    public class MoviesAndActors
    {
        public string?Message { get; set; }
        public HashSet<Movie> Movies { get; set;}
        public HashSet<Actor> Actors { get; set;}

        public MoviesAndActors(HashSet<Movie> movies, HashSet<Actor> actors, string message) 
        {
            Movies = movies;
            Actors = actors;
            Message = message;
        }
    }
}
