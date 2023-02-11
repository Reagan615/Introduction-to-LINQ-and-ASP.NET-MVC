using Microsoft.AspNetCore.Mvc.TagHelpers;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models;
namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models
{
    public class Rating
    {
        private int _id;
        public int Id { 
            get { return _id; } 
            set { _id = value; }
        }

        private int _value;

        public int Value { 
            get { return _value; } 
            set
            {
                if (value > 0 && value < 11)
                {
                    _value = value;
                } else
                {
                    throw new Exception("Rating must be on a 1 to 10");
                }
            }
        }
        public string Comment { get; set; }
        
        public User User { get; set; }
        public Movie Movie { get; set; }
        public Rating() 
        {
            _id = Context.GetIdCount();
        }

        public Rating(int value, User user, Movie movie, string comment)
        {
           
            Value = value;
            User = user;
            Movie = movie;
            Comment = comment;
        }
    }
}
