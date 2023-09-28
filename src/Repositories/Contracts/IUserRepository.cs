using TestWebApplication.Dtos;

namespace TestWebApplication.Repositories.Contracts
{
    public interface IUserRepository
    {
        User? GetUser(int id);

        List<User> GetAllUser();

        void AddUserWithLock(User User);

        void AddUserWithOutLock(User User);

    }
}
