using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program.Models.Register
{
    public interface IUserRegister
    {
        public IEnumerable<User> AllUsers { get; }
    }
}


