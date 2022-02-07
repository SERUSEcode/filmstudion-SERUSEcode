using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program.Models.Film
{
    public interface IAltserRepository
    {
        public IEnumerable<Film> Film { get; }

    }
}