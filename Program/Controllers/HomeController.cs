using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Models.Film;

namespace NewAPI.Controllers
{
    [ApiController]
    [Route("api/film/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IFilmRepository _FilmRepository;

        public HomeController(IFilmRepository filmRepository)
        {
            _FilmRepository = filmRepository;
        }

        // [HttpGet]
        // public IEnumerable<Film> GetFilms()
        // {
        //     var films = filmRepository.AllFilms();

        //     return films;
        // }

        [HttpPost]
        public IEnumerable<Film> CreateFilm()
        {
            List<Film> films = new()
            { 
                new Film { Id = 0, Title = "böba", Description = "curiosity"},
                new Film { Id = 1, Title = "doda", Description = "curiosity"},
                new Film { Id = 2, Title = "sodar", Description = "curiosity"},
                new Film { Id = 3, Title = "kloddar", Description = "curiosity"}
            };

            return films;

        }
    }
}