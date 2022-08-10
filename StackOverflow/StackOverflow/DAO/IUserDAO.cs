using StackOverflow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflow.DAO
{
    public interface IUserDAO
    {
        public User GetUser(string userName, string password);
        public Task<List<User>> GetAllUsers();
        public void CreateUser(User user);
       
    }
}