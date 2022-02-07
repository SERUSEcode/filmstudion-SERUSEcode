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
        private readonly InMemoryFilmRepositories repository;

        public HomeController()
        {
            repository = new InMemoryFilmRepositories();
        }

        [HttpGet]
        public IEnumerable<Film> GetFilms()
        {
            var films = repository.GetFilms();

            return films;
        }
    }
}