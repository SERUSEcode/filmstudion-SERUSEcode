using System;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Program.Models.Film;
using Program.Models.Filmstudio;
using Program.Models.Register;

namespace Program.Models
{

    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext() {
            this.Database.EnsureCreated();
        }

        public DbSet<Film.Film> Film { get; set; }
        public DbSet<Filmstudio.Filmstudio> Filmstudio { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<IdentityUserRole<Guid>> IdentityUserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=mydb.db");
        }
    }
}