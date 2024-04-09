using Films.Models;
using Films.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Films.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(CategoryDTO obj);

        IEnumerable<SelectListItem> GetAllDropdownList(string obj);

        void Delete(int id);
    }
}
