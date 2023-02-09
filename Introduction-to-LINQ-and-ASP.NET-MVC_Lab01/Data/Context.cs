using Introduction_to_LINQ_and_ASP.NET_MVC_Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;



namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab01.Data 
{
    public static class Context
    {
        public static HashSet<Movie> Movies = new HashSet<Movie>();
        public static HashSet<Actor> Actiors = new HashSet<Actor>();
        public static HashSet<Rating> Ratings = new HashSet<Rating>();
        public static HashSet<Role> Roles= new HashSet<Role>();
        public static HashSet<User> Users = new HashSet<User>(); 
        private static int _idCount = 0;
        public static int GetIdCount()
        {
            _idCount++;
            return _idCount;
        }
        private static void _seedMethod()
        {
            Movie movie1 = new Movie("Die Hard", new DateTime(1988, 1, 1), 100, Genre.Action);
            Movie movie2 = new Movie("Blade Runner", new DateTime(1972, 1, 1), 70, Genre.Horror);
            Movie movie3 = new Movie("Scream", new DateTime(1999, 1, 1), 200, Genre.Horror);
            Movie movie4 = new Movie("Back to future", new DateTime(1985, 7, 13), 19, Genre.Comedy);

            Movies.Add(movie1);
            Movies.Add(movie2);     
            Movies.Add(movie3);
            Movies.Add(movie4);

            User user1 = new User("Popc");
            User user2 = new User("OnlyRo");
            User user3 = new User("Over9000");

            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);

            Rating rating1 = new Rating(6, user2, movie4);
            user2.AddRating(rating1);
            movie4.AddRating(rating1);

            Rating rating2 = new Rating(10, user3, movie3);
            user3.AddRating(rating2);
            movie4.AddRating(rating2);

            Rating rating3 = new Rating(3, user1, movie3);
            user1.AddRating(rating3);
            movie3.AddRating(rating3);

            Rating rating4 = new Rating(5, user2, movie3);
            user1.AddRating(rating4);
            movie3.AddRating(rating4);

            Ratings.Add(rating1);
            Ratings.Add(rating2);
            Ratings.Add(rating3);
            Ratings.Add(rating4);

            Actor actor1 = new Actor("Bruce Willis");
            Actor actor2 = new Actor("Harrison Ford");
            Actor actor3 = new Actor("Neve Campbell");
            Actor actor4 = new Actor("Michael J. Fox");

            Actiors.Add(actor1);
            Actiors.Add(actor2);
            Actiors.Add(actor3);
            Actiors.Add(actor4);

            Role role1 = new Role(8, actor1, movie1);
            Roles.Add(role1);
            actor1.AddRole(role1);
            movie1.AddRole(role1);

            Role role2 = new Role(10, actor2, movie2);
            Roles.Add(role2);
            actor2.AddRole(role2);
            movie2.AddRole(role2);

            Role role3 = new Role(6, actor3, movie3);
            Roles.Add(role3);
            actor3.AddRole(role3);
            movie3.AddRole(role3);

            Role role4 = new Role(13, actor4, movie4);
            Roles.Add(role4);
            actor4.AddRole(role4);
            movie4.AddRole(role4);


        }

        static Context()
        {
            _seedMethod();
        }
    }
    public enum Genre
    {
        Action,
        Horror,
        Comedy,
        Drama,
        Documentary,
        Romance

    }


}
