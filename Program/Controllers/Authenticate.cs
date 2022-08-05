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



namespace NewAPI.Controllers
{
    
    //Ta in användarnamn och lösenord kolla om det är korrekt. 
    //om det är korrekt så skicka token


    public class AuthenticateController : Controller
    {
        // private IUserRepository _UserRepository;

        // [AllowAnoymous]
        [HttpPost]
        [Route("authenticate")]
        public object Authenticate(string UserName, string Password)
        {
            // var user = _UserRepository.Authenticate(UserName, Password);

            var claims = new List<Claim>();
            claims.Add(new Claim("Username","kevva"));
            claims.Add(new Claim("displayname","Kevin"));

            // foreach(var role in user.Roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role, role.Name));
            // }
            
            var token = JwtHelper.GetJwtToken(
                // loginUser.Username,
                "TestUsername",
                Startup.Configuration["Auth:SigningKey"],
                Startup.Configuration["Auth:Issuer"],
                Startup.Configuration["Auth:Audience"],
                TimeSpan.FromMinutes(Convert.ToDouble(Startup.Configuration["Auth:TokenTimeoutMinutes"])),
                // TimeSpan.FromMinutes(Configuration.JwtToken.TokenTimeoutMinutes),
                claims.ToArray());

            return new 
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = token.ValidTo
            };
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
                // this guarantees the token is unique
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




// using System;
// using Program;
// using System.Security.Claims;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using Program.Models.Film;
// using Program.Models;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Authorization;
// using System.IdentityModel.Tokens;
// using Microsoft.IdentityModel;
// using System.IdentityModel.Tokens.Jwt;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;

// namespace NewAPI.Controllers
// {
    
//     //Ta in användarnamn och lösenord kolla om det är korrekt. 
//     //om det är korrekt så skicka


//     public class AuthenticateController : ControllerBase
//     {
//         // [AllowAnoymous]
//         [HttpPost]
//         [Route("authenticate")]
//         public object Authenticate()
//         {
//             var claims = new List<Claim>();
//             claims.Add(new Claim("Username","kevva"));
//             claims.Add(new Claim("displayname","Kevin"));

//             // foreach(var role in user.Roles)
//             // {
//             //     claims.Add(new Claim(ClaimTypes.Role, role.Name));
//             // }
            
            
//             var token = JwtHelper.GetJwtToken(
//                 // loginUser.Username,
//                 "TestUsername",
//                 Startup.Configuration["Auth:SigningKey"],
//                 Startup.Configuration["Auth:Issuer"],
//                 Startup.Configuration["Auth:Audience"],
//                 TimeSpan.FromMinutes(Convert.ToDouble(Startup.Configuration["Auth:TokenTimeoutMinutes"])),
//                 // TimeSpan.FromMinutes(Configuration.JwtToken.TokenTimeoutMinutes),
//                 claims.ToArray());

//             return new 
//             {
//                 token = new JwtSecurityTokenHandler().WriteToken(token),
//                 expires = token.ValidTo
//             };
//         }
//     }

//     public class JwtHelper
//     {
//         public static JwtSecurityToken GetJwtToken(
//             string username,
//             string signingKey,
//             string issuer,
//             string audience,
//             TimeSpan expiration,
//             Claim[] additionalClaims = null)
//         {
//             var claims = new[]
//             {
//                 new Claim(JwtRegisteredClaimNames.Sub,username),
//                 // this guarantees the token is unique
//                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//             };

//             if (additionalClaims is object)
//             {
//                 var claimList = new List<Claim>(claims);
//                 claimList.AddRange(additionalClaims);
//                 claims = claimList.ToArray();
//             }

//             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
//             var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//             return new JwtSecurityToken(
//                 issuer: issuer,
//                 audience: audience,
//                 expires: DateTime.UtcNow.Add(expiration),
//                 claims: claims,
//                 signingCredentials: creds
//             );
//         }
//     }
// }
