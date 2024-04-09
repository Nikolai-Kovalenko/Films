using Films.Data;
using Films.Models;
using Films.Models.DTO;
using Films.Repository.IRepository;

namespace Films.Repository
{
    public class Film_сategoryRepository : Repository<Film_сategory>, IFilm_сategoryRepository
    {
        private readonly AppDbContext _db;

        public Film_сategoryRepository(AppDbContext db) : base(db)
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
                throw new ArgumentNullException(nameof(objFromDb), "Film not found");
            }
        }

        public void Update(Film_сategoryDTO obj)
        {
            var objFromDb = base.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.FilmId = obj.FilmId;
                objFromDb.CategoryId = obj.CategoryId;
            }
            else
            {
                throw new ArgumentNullException(nameof(objFromDb), "Film not found");
            }
        }
    }
}
