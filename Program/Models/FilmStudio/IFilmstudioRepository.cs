using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program.Models.Filmstudio
{
    public interface IFilmstudioRepository
    {
        public IEnumerable<Filmstudio> AllFilmstudios { get; }
    }
}


