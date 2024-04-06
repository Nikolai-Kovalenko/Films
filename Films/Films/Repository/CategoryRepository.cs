using Films.Data;
using Films.Models;
using Films.Repository.IRepository;

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
                base.Remove(objFromDb);
            }
            else
            {
                throw new ArgumentNullException(nameof(objFromDb), "Category not found");
            }
        }

        public void Update(Category obj)
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
    }
}
