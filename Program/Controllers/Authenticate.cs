using System.Diagnostics;
using System;
using Program;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Models.Film;
using Program.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Program.Models.User;
using Program.Models.Filmstudio;



namespace NewAPI.Controllers
{
    
    //Ta in användarnamn och lösenord kolla om det är korrekt. 
    //om det är korrekt så skicka token


    public class AuthenticateController : Controller
    {
        private readonly IUserRepository _UserRepository;
        private readonly IFilmstudioRepository _FilmstudioRepository;

        public AuthenticateController(IUserRepository userRepository, IFilmstudioRepository filmstudioRepository)
        {
            this._UserRepository = userRepository;
            this._FilmstudioRepository = filmstudioRepository;
        }

        // [AllowAnoymous]
        [HttpPost]
        [Route("authenticate")]
        public object Authenticate(string UserName, string Password)
        {
            // var users = _UserRepository.AllUsers;

            // var exist = false;
            // var savedUserRole = "";
            
            var user = _UserRepository.CheckUser(UserName, Password);
            var filmstudio = _FilmstudioRepository.CheckFilmstudio(UserName, Password);

            if (user == null && filmstudio == null) { return BadRequest(new { message = "Username or password was not correct" , user }); }

            if (user == null) {
                var claims = new List<Claim>();
                claims.Add(new Claim("Username",filmstudio.Name));
                claims.Add(new Claim("displayname",filmstudio.Name));

                claims.Add(new Claim(ClaimTypes.Role, "Filmstudio"));
            
                var token = JwtHelper.GetJwtToken(
                // loginUser.Username,
                "TestUsername",
                Startup.Configuration["Auth:SigningKey"],
                Startup.Configuration["Auth:Issuer"],
                Startup.Configuration["Auth:Audience"],
                TimeSpan.FromMinutes(Convert.ToDouble(Startup.Configuration["Auth:TokenTimeoutMinutes"])),
                claims.ToArray());

                return new 
                {
                    role = "Filmstudio",
                    username = filmstudio.Name,
                    city = filmstudio.City,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expires = token.ValidTo
                };
            }
            else 
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("Username",user.UserName));
                claims.Add(new Claim("displayname",user.UserName));

                claims.Add(new Claim(ClaimTypes.Role, user.Role));
                
                var token = JwtHelper.GetJwtToken(
                    "TestUsername",
                    Startup.Configuration["Auth:SigningKey"],
                    Startup.Configuration["Auth:Issuer"],
                    Startup.Configuration["Auth:Audience"],
                    TimeSpan.FromMinutes(Convert.ToDouble(Startup.Configuration["Auth:TokenTimeoutMinutes"])),
                    claims.ToArray());

                return new 
                {
                    role = user.Role,
                    username = UserName,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expires = token.ValidTo
                };
            }
        }
    }

    public class JwtHelper
    {
        public static JwtSecurityToken GetJwtToken(
            string username,
            string signingKey,
            string issuer,
            string audience,
            TimeSpan expiration,
            Claim[] additionalClaims = null)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (additionalClaims is object)
            {
                var claimList = new List<Claim>(claims);
                claimList.AddRange(additionalClaims);
                claims = claimList.ToArray();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.UtcNow.Add(expiration),
                claims: claims,
                signingCredentials: creds
            );
        }
    }
}