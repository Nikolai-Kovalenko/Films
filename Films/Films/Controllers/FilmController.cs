using AutoMapper;
using Films.Models;
using Films.Models.DTO;
using Films.Models.ViewModels;
using Films.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(FilmVM obj) 
        {
            if (ModelState.IsValid)
            {
                FilmDTO filmDTO = new()
                {
                    Id = obj.FilmDTO.Id,
                    Name = obj.FilmDTO.Name,
                    Director = obj.FilmDTO.Director,
                    Release = obj.FilmDTO.Release
                };

                _filmRepo.Update(filmDTO);
                _filmRepo.Save();

                IEnumerable<FilmCategory> filmCategory = _filmCategoryRepo.GetAll(u => 
                                                            u.FilmId == obj.FilmDTO.Id 
                                                            && u.DeleteTime == null);
                var currentDate = DateTime.Now;

                if (!filmCategory.Any())
                {  
                    foreach(var fCat in obj.FilmDTO.SelectedCategoryIds)
                    {
                        FilmCategory newFilmCategory = new()
                        {
                            FilmId = obj.FilmDTO.Id,
                            CategoryId = fCat,
                            CreateTime = currentDate
                        };

                        _filmCategoryRepo.Add(newFilmCategory);
                    };

                    _filmCategoryRepo.Save();
                }
                else
                {
                    var objCategoryID = obj.FilmDTO.CategoryList.Select(u => u.Id);
                    var exceptFilmCategory = filmCategory.Select(u => u.CategoryId).Except(objCategoryID);

                    foreach(var deleteCategory in exceptFilmCategory)
                    {
                        _filmCategoryRepo.Delete(deleteCategory);
                    };

                    var addFilmCategory = objCategoryID.Except(filmCategory.Select(u => u.CategoryId)) ;

                    foreach (var addCategory in addFilmCategory)
                    {
                        FilmCategory newFilmCategory = new()
                        {
                            FilmId = obj.FilmDTO.Id,
                            CategoryId = addCategory,
                            CreateTime = currentDate
                        };

                        _filmCategoryRepo.Add(newFilmCategory);
                    };

                    _filmCategoryRepo.Save();
                }

                return RedirectToAction("Index");

            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _filmRepo.Find(id.GetValueOrDefault());
            if (id == null)
            {
                return NotFound();
            }

            _filmRepo.Delete(obj.Id);
            _filmRepo.Save();

            return RedirectToAction("Index");
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
                                              .Select(c => c.CategoryId)
                                              .ToList();

                var filmDTO = new FilmDTO
                {
                    Id = film.Id,
                    Name = film.Name,
                    Director = film.Director,
                    Release = film.Release,
                    CategoryList = _categoryRepo.GetAll(u => filmCategory.Contains(u.Id) 
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
