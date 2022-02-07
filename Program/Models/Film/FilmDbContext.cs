using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Program.Models.Film
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Film> Film { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=mydb.db");
    }
}