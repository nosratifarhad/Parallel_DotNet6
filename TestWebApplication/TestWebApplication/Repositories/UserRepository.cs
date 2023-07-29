using TestWebApplication.Dtos;
using TestWebApplication.Repositories.Contracts;

namespace TestWebApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public void AddUser(User User)
        {
            _users.Add(User);
            Console.WriteLine($"Add User {_users.Count()}");
        }

        public User? GetUser(int id)
        {
            return _users.SingleOrDefault(a => a.Id == id);
        }

        public List<User> GetAllUser()
        {
            return _users;
        }

    }
}
