using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program.Models.Filmstudio
{
    public interface IFilmstudioRepository
    {
        public IEnumerable<Filmstudio> AllFilmstudios { get; }
        
        Filmstudio GetFilmstudioById(int id);

        Filmstudio CheckFilmstudio(string UserName, string Password);
    }
}