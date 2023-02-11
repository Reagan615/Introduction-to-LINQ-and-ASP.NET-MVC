using Microsoft.AspNetCore.Mvc.TagHelpers;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models;

namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab02.Models
{
    public class Actor
    {
        private int _id;
        public int Id { 
            get { return _id; } 
            set { _id = value; }
        }

        private string _name;
        public string Name { 
            get { return _name; }
            set
            { 
                if(value.Length <= 0)
                {
                    throw new ArgumentException("Name can not be ");
                } else
                {
                    _name = value;
                }
            }
        }

        public Role Role { get; set; }

      public HashSet<Role> _roles = new HashSet<Role>();
        public HashSet<Role> GetRoles()
        {
            return _roles.ToHashSet();
        }

        public void AddRole(Role role)
        {
            _roles.Add(role);
        }


        public Actor()
        {
            _id = Context.GetIdCount();
        }

        public Actor(string name)
        {
            _id = Context.GetIdCount();
            Name = name;
        }

    }
}
