using Films.Models;
using Films.Models.DTO;

namespace Films.Repository.IRepository
{
    public interface IFilmCategoryRepository : IRepository<FilmCategory>
    {
        void Update(FilmCategoryDTO obj);

        void Delete(int id);
    }
}
