using Microsoft.EntityFrameworkCore;
using StackOverflow.Data;
using StackOverflow.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.DAO
{
    public class UserDAO: IUserDAO
    {
        private readonly SOContext _context;
        public UserDAO(SOContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User GetUser(string userName, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
        public Task<List<User>> GetAllUsers()
        {
            return _context.Users.ToListAsync();
        }

       

       
    }
}
