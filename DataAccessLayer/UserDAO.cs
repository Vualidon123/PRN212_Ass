// DataAccessLayer/UserDAO.cs
using BO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer
{
    public class UserDAO
    {
        private readonly TestyContext _context;

        public UserDAO(TestyContext context)
        {
            _context = context;
        }

        public static User? GetUserByEmailAndPassword(string email, string password)
        {
            using var db = new TestyContext();
            return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool IsEmailRegistered(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}