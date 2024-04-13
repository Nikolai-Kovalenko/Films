using Films.Data;
using Films.Models;
using Films.Models.DTO;
using Films.Repository.IRepository;

namespace Films.Repository
{
    public class FilmCategoryRepository : Repository<FilmCategory>, IFilmCategoryRepository
    {
        private readonly AppDbContext _db;

        public FilmCategoryRepository(AppDbContext db) : base(db)
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

        public void Update(FilmCategoryDTO obj)
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
