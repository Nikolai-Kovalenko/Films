using Films.Data;
using Films.Models;
using Films.Models.DTO;
using Films.Repository.IRepository;

namespace Films.Repository
{
    public class FilmRepository : Repository<Film>, IFilmRepository
    {
        private readonly AppDbContext _db;

        public FilmRepository(AppDbContext db) : base(db)
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

        public void Update(FilmDTO obj)
        {
            var objFromDb = base.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Director = obj.Director;
                objFromDb.Release = obj.Release;
            }
            else
            {
                throw new ArgumentNullException(nameof(objFromDb), "Film not found");
            }
        }
    }
}
