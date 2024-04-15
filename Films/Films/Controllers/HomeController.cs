using AutoMapper;
using Films.Data;
using Films.Models;
using Films.Models.DTO;
using Films.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Films.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;
        public IMapper _mapper { get; set; }


        public HomeController(
            ILogger<HomeController> logger,
            AppDbContext db,
            IMapper mapper
            )
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var filmList = _db.Films.Where(u => u.DeleteTime == null);
            var filmDtoList = new List<FilmDTO>();

            foreach ( var film in filmList )
            {
                FilmDTO filmDTO = _mapper.Map<FilmDTO>( film );

                var FilmCategory = _db.FilmCategories.Where(u =>
                                        u.DeleteTime == null
                                        && u.FilmId == film.Id).Select(u => u.CategoryId);

                filmDTO.CategoryList = _db.Categories.Where(u => FilmCategory.Contains(u.Id)).ToList();

                filmDtoList.Add(filmDTO);
            }

            HomeVM homeVM = new HomeVM()
            {
                FilmDTO = filmDtoList,
                Category = _db.Categories.Where(u => u.DeleteTime == null)
            };

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}