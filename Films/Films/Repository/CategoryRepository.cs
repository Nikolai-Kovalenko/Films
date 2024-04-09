using Films.Data;
using Films.Models;
using Films.Models.DTO;
using Films.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Films.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var objFromDb = base.Find(id);
            if (objFromDb != null)
            {
                objFromDb.DeleteTime = DateTime.Now;
            }
            else
            {
                throw new ArgumentNullException(nameof(objFromDb), "Category not found");
            }
        }

        public void Update(CategoryDTO obj)
        {
            var objFromDb = base.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Parent_category_id = obj.Parent_category_id;
            }
            else
            {
                throw new ArgumentNullException(nameof(objFromDb), "Category not found");
            }
        }

        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if (obj == WC.CategotyName)
            {
                return _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            return null;
        }
    }
}
