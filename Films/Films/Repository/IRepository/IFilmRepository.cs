using Films.Models;
using Films.Models.DTO;

namespace Films.Repository.IRepository
{
    public interface IFilmRepository : IRepository<Film>
    {
        void Update(FilmDTO obj);

        void Delete(int id);
    }
}
