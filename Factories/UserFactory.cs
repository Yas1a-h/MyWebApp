using MyWebApp.Models;

namespace MyWebApp.Factories
{
    public class UserFactory
    {
        public static User CreateUser(int id, string name, string email)
        {
            return new User(id, name, email);
        }
    }
}