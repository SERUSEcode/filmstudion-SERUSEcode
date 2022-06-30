using System.Diagnostics.SymbolStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Program.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}



// using System.Diagnostics.SymbolStore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity;
// using System.ComponentModel.DataAnnotations;

// namespace Program.Models.Register
// {
//     public class User : IdentityUser
//     {
//         public bool IsAdmin { get; set; }
//         [Required]
//         [ProtectedPersonalData]
//         public override string UserName { get; set; }
//         [Required]
//         public override string PasswordHash { get; set; }
//     }
// }