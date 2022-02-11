using System.Diagnostics.SymbolStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Program.Models.Register
{
    public class FilmStudio : IdentityUser
    {
        public string CompanyName { get; set; }
    }
}