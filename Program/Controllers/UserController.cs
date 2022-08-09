using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Models.User;
using Program.Models.Film;
using Program.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace NewAPI.Controllers
{
    
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _UserRepository;

        public UserController(IUserRepository userRepository)
        {
            this._UserRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var users = _UserRepository.AllUsers;

            return users;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(string username, string password, Boolean Roles)
        {

            var users = new User()
            {
                UserName = username, 
                Password = password, 
                Role = Roles ? "Admin" : "none"
            };

            using (var db = new AppDbContext())
            {
                db.Add(users);
                db.SaveChanges();
            }

            return Ok(users);
        }
    }
}