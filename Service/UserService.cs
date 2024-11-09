// Service/UserService.cs
using System.Linq;
using BO;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly TestyContext _context;

        public UserService()
        {
            _context = new TestyContext();
        }

        public User? Login(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        public void Register(User user)
        {
            if (_context.Users.Any(u => u.Email != user.Email))
            {

                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }
    }
}