using AutoMapper;
using Films.Models.DTO;
using Films.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Films.Controllers
{
    public class FilmController : Controller
    {
        public readonly IFilmRepository _filmRepo;
        public IMapper _mapper { get; set; }


        public FilmController(
            IFilmRepository filmRepo,
            IMapper mapper)
        {
            _filmRepo = filmRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var objList = _filmRepo.GetAll(u => u.DeleteTime == null);
            var filmDTOs = _mapper.Map<List<FilmDTO>>(objList);
            return View(filmDTOs);
        }
    }
}
