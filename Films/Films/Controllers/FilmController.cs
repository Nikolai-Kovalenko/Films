using AutoMapper;
using Films.Models;
using Films.Models.DTO;
using Films.Models.ViewModels;
using Films.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Films.Controllers
{
    public class FilmController : Controller
    {
        public readonly IFilmRepository _filmRepo;
        public readonly ICategoryRepository _categoryRepo;
        public readonly IFilmCategoryRepository _filmCategoryRepo;

        public IMapper _mapper { get; set; }


        public FilmController(
            IFilmRepository filmRepo,
            ICategoryRepository categoryRepo,
            IFilmCategoryRepository filmCategoryRepo,
            IMapper mapper)
        {
            _filmRepo = filmRepo;
            _categoryRepo = categoryRepo;
            _filmCategoryRepo = filmCategoryRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
            {
            return View();
        }

        public IActionResult Create()
        {
/*            FilmVM filmVM = new()
            {
                FilmDTO = new FilmDTO(),
                CategorySelectList = _categoryRepo.GetAllDropdownList(WC.CategotyName, u => u.DeleteTime == null)
            };*/

            FilmDTO filmDTO = new FilmDTO();

            return View(filmDTO);
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FilmDTO obj)
        {
            if (ModelState.IsValid)
            {
                Film film = new()
                {
                    Name = obj.Name,
                    Director = obj.Director,
                    Release = obj.Release,
                    CreateTime = DateTime.Now
                };
                
                _filmRepo.Add(film);
                _filmRepo.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Details(int id)
        {

            var film = _filmRepo.Find(id);

            if (film != null)
            {
                FilmVM filmVM = new()
                {
                    FilmDTO = _mapper.Map<FilmDTO>(film),
                    CategorySelectList = _categoryRepo.GetAllDropdownList(WC.CategotyName, u => u.DeleteTime == null)
                };

                return View(filmVM);
            }

            return RedirectToAction("Film", "Index");
        }

        [ActionName("Details")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost(FilmVM obj)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            return View();
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetFilmList()
        {
            var films = _filmRepo.GetAll(u => u.DeleteTime == null);
            var filmDTOs = new List<FilmDTO>();

            foreach (var film in films)
            {
                var filmCategory = _filmCategoryRepo.GetAll(c => c.FilmId == film.Id && c.DeleteTime == null)
                                              .Select(c => c.Category.Id)
                                              .ToList();

                var filmDTO = new FilmDTO
                {
                    Id = film.Id,
                    Name = film.Name,
                    Director = film.Director,
                    Release = film.Release,
                    CategoryIdList = _categoryRepo.GetAll(u => filmCategory.Contains(u.Id) 
                                                && u.DeleteTime == null)
                                                .ToList()
                };

                filmDTOs.Add(filmDTO);
            }


            return Json(new { data = filmDTOs });
        }
        #endregion
    }
}
