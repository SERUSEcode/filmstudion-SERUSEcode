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
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}