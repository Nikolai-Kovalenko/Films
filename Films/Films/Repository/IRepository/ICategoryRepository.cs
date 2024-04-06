using Films.Models;

namespace Films.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);

        void Delete(int id);
    }
}
