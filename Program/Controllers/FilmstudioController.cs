using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Models.Filmstudio;
using Program.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace NewAPI.Controllers
{
    [Route("api/Filmstudio")]
    [ApiController]
    public class FilmstudioController : ControllerBase
    {
        private readonly IFilmstudioRepository _FilmstudioRepository;

        public FilmstudioController(IFilmstudioRepository filmstudioRepository)
        {
            this._FilmstudioRepository = filmstudioRepository;
        }

        
        [HttpGet]
        public IEnumerable<Filmstudio> GetFilmstudios()
        {
            var filmstudios = _FilmstudioRepository.AllFilmstudios;

            return filmstudios;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetFilmstudioById(int id)
        {
            try
            {
                var filmstudio = _FilmstudioRepository.GetFilmstudioById(id);
                return Ok(filmstudio); 
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult AddFilmstudio(string name, string password)
        {

            var filmstudios = new Filmstudio()
            {
                Name = name,
                Password = password
            };


            using (var db = new AppDbContext())
            {
                db.Add(filmstudios);
                db.SaveChanges();
            }

            return Ok(filmstudios);
        }
    }
}