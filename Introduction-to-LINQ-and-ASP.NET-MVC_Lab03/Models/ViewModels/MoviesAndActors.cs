using WebApplication3.Data;

namespace WebApplication3.Models.ViewModels
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
