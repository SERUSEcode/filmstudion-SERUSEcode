using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Program.Models.User
{
    public interface IUserRepository
    {
        public IEnumerable<User> AllUsers { get; }
        
        User GetUserById(int id);

    }

    
}