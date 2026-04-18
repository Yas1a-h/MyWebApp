using System.Collections.Generic;
using System.Linq;
using MyWebApp.Models;

namespace MyWebApp.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>();

        public List<User> GetAll()
        {
            return _users;
        }

        public User? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Remove(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}