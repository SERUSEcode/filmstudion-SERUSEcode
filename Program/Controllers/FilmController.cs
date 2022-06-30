using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Models.Film;
using Program.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace NewAPI.Controllers
{
    [Route("api/Film")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository _FilmRepository;

        public FilmController(IFilmRepository filmRepository)
        {
            this._FilmRepository = filmRepository;
        }

        [HttpGet]
        public IEnumerable<Film> GetFilms()
        {
            var films = _FilmRepository.AllFilms;

            return films;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetFilmById(int id)
        {
            try
            {
                var film = _FilmRepository.GetFilmById(id);
                return Ok(film); 
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ActionName("AddFilm")]
        public IActionResult AddFilm(string title, int copies, string description)
        {
            // List<Film> films = new()
            // { 
            //     new Film { Id = 0, Title = title, Copies = copies, Description = description}
            // };

            var films = new Film()
            {
                Title = title,
                Copies = copies,
                Description = description
            };



            using (var db = new AppDbContext())
            {
                db.Add(films);
                db.SaveChanges();
            }

            return Ok(films);
        }
    }
}