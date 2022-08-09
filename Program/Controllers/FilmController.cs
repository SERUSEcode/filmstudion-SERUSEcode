using System.Data;
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
        [Authorize(Roles = "Admin")]
        [ActionName("AddFilm")]
        public IActionResult AddFilm(string title, int copies, string description)
        {
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

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateFilm(int id, string title, string copies, string description)
        {
            var film = _FilmRepository.GetFilmById(id);

            if(title != null){
                film.Title = title;
            } else {
                film.Title = film.Title;
            }

            if(copies != null){
                film.Copies = int.Parse(copies);
            } else {
                film.Copies = film.Copies;
            }

            if(description != null){
                film.Description = description;
            } else {
                film.Description = film.Description;
            }

            using (var db = new AppDbContext())
            {
                db.Update(film);
                db.SaveChanges();
            }

            return Ok(film); 
        }
    }
}