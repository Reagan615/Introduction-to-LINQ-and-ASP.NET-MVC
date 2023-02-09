using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab01.Data;
using Introduction_to_LINQ_and_ASP.NET_MVC_Lab01.Models;

namespace Introduction_to_LINQ_and_ASP.NET_MVC_Lab01.Models
{
    public class Actor
    {
        private int _id;
        public int Id { get { return _id; } }

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

        private HashSet<Role> _roles = new HashSet<Role>();
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
            Name = name;
        }

    }
}
