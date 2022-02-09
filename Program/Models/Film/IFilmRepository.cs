using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program.Models.Film
{
    public interface IFilmRepository
    {
        public IEnumerable<Film> AllFilms { get; }
        Film GetFilmById(int id);
    }
}


