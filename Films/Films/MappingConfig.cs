using AutoMapper;
using Films.Models;
using Films.Models.DTO;

namespace Films
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Film, FilmDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<FilmCategory, FilmCategoryDTO>().ReverseMap();
        }
    }
}
