using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Program.Models;

namespace Program.Models.Film
{
    public class DbFilmRepository : IFilmRepository
    {
        private AppDbContext _appDbContext;

        public DbFilmRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        public IEnumerable<Film> AllFilms => _appDbContext.Film;
    }
}








