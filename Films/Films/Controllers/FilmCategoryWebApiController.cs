using AutoMapper;
using Films.Data;
using Films.Models;
using Films.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.Controllers
{
    [Route("api/film-category")]
    [ApiController]
    public class FilmCategoryWebApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FilmCategoryWebApiController(
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmCategoryDTO>>> GetByFilmAsync(int filmId)
        {
            var filmCategories = await _context.FilmCategories
                .Where(fc => fc.FilmId == filmId)
                .ToListAsync();

            var filmCategoryDTOs = _mapper.Map<List<FilmCategoryDTO>>(filmCategories);
            return filmCategoryDTOs;
        }


        [HttpPost]
        public async Task<ActionResult<FilmCategoryDTO>> AddAsync(FilmCategoryDTO filmCategoryDTO)
        {
            var filmCategory = _mapper.Map<FilmCategory>(filmCategoryDTO);
            _context.FilmCategories.Add(filmCategory);
            await _context.SaveChangesAsync();

            var createdFilmCategoryDTO = _mapper.Map<FilmCategoryDTO>(filmCategory);
            return createdFilmCategoryDTO;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var filmCategory = await _context.FilmCategories.FindAsync(id);
            if (filmCategory == null)
            {
                return NotFound();
            }

            _context.FilmCategories.Remove(filmCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
