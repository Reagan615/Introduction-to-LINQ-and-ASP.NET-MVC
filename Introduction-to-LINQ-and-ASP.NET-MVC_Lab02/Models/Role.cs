using Microsoft.AspNetCore.Mvc.TagHelpers;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models;
namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models
{
    public class Role
    {
        private int _id;
        public int Id { get { return _id; } }

        private string _credit;
        public string Credit
        {
            get { return _credit; }
            set
            {
                if(value.Length > 0)
                {
                    _credit = value;
                } else
                {
                    throw new Exception("");
                }
            }
        }
        private int _pay;
        public int Pay { 
            get { return _pay; }
            set
            {
                if(value >= 0)
                {
                    _pay = value;
                }
            }
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
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
        public Role()
        {
            _id = Context.GetIdCount();
        }

        public Role(string credit, int pay, Actor actor, Movie movie)
        {
            Credit = credit;
            Pay = pay;
            Actor = actor;
            Movie = movie;
            _id= Context.GetIdCount();
        }
    }
}
