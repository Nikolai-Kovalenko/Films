using Films.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Films.Models.ViewModels
{
    public class FilmVM
    {
            public FilmDTO FilmDTO { get; set; }
            public IEnumerable<SelectListItem>? CategorySelectList { get; set; }
    }
}
