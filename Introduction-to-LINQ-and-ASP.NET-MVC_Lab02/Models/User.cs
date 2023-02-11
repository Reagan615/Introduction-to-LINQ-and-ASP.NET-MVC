using Microsoft.AspNetCore.Mvc.TagHelpers;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models;
namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models
{
    public class User
    {
        private int _id;
        public int Id { 
            get { return _id; } 
            set { _id = value; }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if(value.Length > 2 && value.Length <=30)
                {
                    _userName = value;
                } else
                {
                    throw new Exception("");
                }
            }
        }

        private HashSet<Rating> _ratings = new HashSet<Rating>();
        public HashSet<Rating> GetRatings()
        {
            return _ratings.ToHashSet();
        }

        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
        }
        public User() 
        {
            _id = Context.GetIdCount();
        }

        public User(string userName)
        {
            UserName = userName;
            _id = Context.GetIdCount();
        }
    }
}
