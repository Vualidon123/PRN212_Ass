using BO;
using DataAccessLayer;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public User? Login(string email, string password)
            => UserDAO.GetUserByEmailAndPassword(email, password);
        

        public void Register(User user)
        {
            if (!_userDAO.IsEmailRegistered(user.Email!))
            {
                _userDAO.AddUser(user);
            }
            else
            {
                throw new Exception("Email already registered");
            }
        }

        public bool IsEmailRegistered(string email)
        {
            return _userDAO.IsEmailRegistered(email);
        }
    }
}