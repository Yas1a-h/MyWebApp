using System.Collections.Generic;
using System.Linq;
using MyWebApp.Models;
using MyWebApp.Data;
using MyWebApp.DTOs;
using MyWebApp.Observers;

namespace MyWebApp.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly UserSubject _subject;

        public UserService(AppDbContext context)
        {
            _context = context;
            _subject = new UserSubject();
        }

        public void AddObserver(IObserver observer)
        {
            _subject.Attach(observer);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void CreateUser(UserDto dto)
        {
            CreateUser(0, dto.Name, dto.Email);
        }

        public void CreateUser(int id, string name, string email)
        {
            var user = new User
            {
                Id = id,
                Name = name,
                Email = email
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            _subject.Notify($"User created: {user.Name}");
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

                _subject.Notify($"User deleted: {id}");
            }
        }
    }
}