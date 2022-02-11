using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Models.Register;
using Program.Models.Film;
using Program.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace NewAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ActionName("register")]
        public IActionResult Register(string username, string password, bool isAdmin)
        {
            List<User> users = new()
            { 
                new User { UserName = username, PasswordHash = password, IsAdmin = isAdmin}
            };

            Guid userGuid = Guid.Parse(users[0].Id);
            Guid roleGuid = Guid.Parse("dd385684-facb-45ba-be92-0fa28ff3c9cd");

            List<IdentityUserRole<Guid>> UserRole = new()
            { 
                new IdentityUserRole<Guid> { UserId = userGuid, RoleId = roleGuid }
            };

            
            using (var db = new AppDbContext())
            {
                db.Add(UserRole[0]);
                db.SaveChanges();
            }


            using (var db = new AppDbContext())
            {
                db.Add(users[0]);
                db.SaveChanges();
            }

            return Ok(users);
        }
    }
}