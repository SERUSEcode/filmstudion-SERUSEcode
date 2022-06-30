using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Program.Models;

namespace Program.Models.User
{
    public class DbUserRepository : IUserRepository
    {
        private AppDbContext _appDbContext;

        public DbUserRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        public IEnumerable<User> AllUsers => _appDbContext.User;

        public User GetUserById(int id)
        {
            return _appDbContext.User.Where(User => User.Id == id).SingleOrDefault(); 
        }        
    }
}








