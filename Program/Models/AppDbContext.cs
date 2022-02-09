using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Program.Models.Film;
using Program.Models.Filmstudio;

namespace Program.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext() {
            this.Database.EnsureCreated();
        }

        public DbSet<Film.Film> Film { get; set; }
        public DbSet<Filmstudio.Filmstudio> Filmstudio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite(@"Data Source=mydb.db");
        }
    }



    // public class AppDbContext : DbContext
    // {
    //     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //     {
    //         this.Database.EnsureCreated();
    //     }
    //     public DbSet<Film> Film { get; set; }

    //     protected override void OnConfiguring(DbContextOptionsBuilder options)
    //         => options.UseSqlite(@"Data Source=mydb.db");
    // }
}