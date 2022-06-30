using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program.Models.User
{
    public interface IUserRepository
    {
        public IEnumerable<User> AllUsers { get; }
        
        User GetUserById(int id);
    }
}