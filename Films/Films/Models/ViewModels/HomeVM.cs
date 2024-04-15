using Films.Models.DTO;
using static System.Collections.Specialized.BitVector32;

namespace Films.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<FilmDTO> FilmDTO { get; set; }
        public IEnumerable<Category> Category { get; set; }

    }
}
