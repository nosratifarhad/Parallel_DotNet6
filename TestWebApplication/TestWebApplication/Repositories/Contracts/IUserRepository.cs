using TestWebApplication.Dtos;

namespace TestWebApplication.Repositories.Contracts
{
    public interface IUserRepository
    {
        User? GetUser(int id);

        List<User> GetAllUser();

        void AddUser(User User);

    }
}
