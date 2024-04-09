using Films.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Films.Models.ViewModels
{
    public class CategoryVM
    {
        public CategoryDTO CategoryDTO { get; set; }
        public IEnumerable<SelectListItem>? CategorySelectList { get; set; }
    }
}
