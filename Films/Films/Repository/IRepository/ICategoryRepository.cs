using Films.Models;
using Films.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Films.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(CategoryDTO obj);

        IEnumerable<SelectListItem> GetAllDropdownList(
            string obj,
            Expression<Func<Category, bool>> filter = null);

        void Delete(int id);
    }
}
