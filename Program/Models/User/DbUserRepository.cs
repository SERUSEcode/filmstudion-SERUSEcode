using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Program.Models;
using Microsoft.EntityFrameworkCore;

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

        public User CheckUser(string username, string password)
        {
            // var user = _appDbContext.User.Include(u => u.Filmstudio).SingleOrDefault(x => x.UserName == username && x.Password == password);   
            // var user = _appDbContext.User.Where(User => User.Id == id).SingleOrDefault(); 
            return _appDbContext.User.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

            
        }      
    }
}








