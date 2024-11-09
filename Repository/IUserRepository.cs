using BO;

namespace Repository
{
    public interface IUserRepository
    {
        User? Login(string email, string password);
        void Register(User user);
        bool IsEmailRegistered(string email);
    }
}