using Films.Models;
using Films.Models.DTO;

namespace Films.Repository.IRepository
{
    public interface IFilm_сategoryRepository : IRepository<Film_сategory>
    {
        void Update(Film_сategoryDTO obj);

        void Delete(int id);
    }
}
