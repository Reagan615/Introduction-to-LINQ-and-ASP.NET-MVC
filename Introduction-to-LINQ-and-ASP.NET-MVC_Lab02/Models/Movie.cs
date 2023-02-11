using Microsoft.AspNetCore.Mvc.TagHelpers;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models;

namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models
{
    public class Movie
    {
        //poco "Plain old c# object"
        private  int _id;

        public int Id { 
            get { return _id; } 
            set { _id = value; }
        }

        private string _title;
        public string Title { 
            get { return _title;}
            set
            {
                if(value.Length > 0)
                {
                    _title = value;
                } else
                {
                    throw new ArgumentException("");
                }
            }
        }

        private DateTime _releaseDate;

        public DateTime ReleaseDate { 
            get { return _releaseDate; } 
            set { _releaseDate = value; }
        }

        private int _budget;
        public int Budget { 
            get { return _budget; } 
            set
            {
                if (value >= 0)
                {
                    _budget = value;
                }
            }
        }

        public Genre Genre { get; set; }

        private HashSet<Rating> _ratings = new HashSet<Rating>();
        public HashSet<Rating> GetRatings()
        {
            return _ratings.ToHashSet();
        }
        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
        }

        private HashSet<Role> _roles = new HashSet<Role>();
        public HashSet<Role> GetRoles()
        {
            return _roles.ToHashSet();
        }

        public void AddRole(Role role)
        {
            _roles.Add(role);
        }


        public Movie()
        {
            _id = Context.GetIdCount();
        }

        public Movie(string title, DateTime releaseDate, int budget,  Genre genre)
        {
            _id = Context.GetIdCount();
            Title = title;
            ReleaseDate = releaseDate;
            Budget = budget;
            Genre = genre;
           
        }
    }
}
