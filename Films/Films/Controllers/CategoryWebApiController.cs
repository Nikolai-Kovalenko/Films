using AutoMapper;
using Films.Data;
using Films.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryWebApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryWebApiController(
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            var categoryDTOs = _mapper.Map<List<CategoryDTO>>(categories);
            return categoryDTOs;
        }

    }
}
