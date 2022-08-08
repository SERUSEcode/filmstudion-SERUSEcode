using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Program.Models;

namespace Program.Models.Filmstudio
{
    public class DbFilmstudioRepository : IFilmstudioRepository
    {
        private AppDbContext _appDbContext;

        public DbFilmstudioRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        public IEnumerable<Filmstudio> AllFilmstudios => _appDbContext.Filmstudio;

        public Filmstudio GetFilmstudioById(int id)
        {
            return _appDbContext.Filmstudio.Where(Filmstudio => Filmstudio.Id == id).SingleOrDefault(); 
        }        

        public Filmstudio CheckFilmstudio(string username, string password)
        {
            return _appDbContext.Filmstudio.Where(x => x.Name == username && x.Password == password).FirstOrDefault();
        }  
    }
}








