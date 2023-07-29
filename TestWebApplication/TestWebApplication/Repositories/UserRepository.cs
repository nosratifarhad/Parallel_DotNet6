﻿using TestWebApplication.Dtos;
using TestWebApplication.Repositories.Contracts;

namespace TestWebApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        private static readonly object LockCount = new object();
        public void AddUser(User user)
        {

            try
            {
                Thread.Sleep(1000);

                lock (LockCount)
                {
                    user.Id++;

                    _users.Add(user);
                }
                Console.WriteLine($"Add User {_users.Count()}");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
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
