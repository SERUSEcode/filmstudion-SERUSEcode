using System.ComponentModel.DataAnnotations;

namespace Program.Models.Film
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  string Description { get; set; }
        public int Copies { get; set; }
    }
}