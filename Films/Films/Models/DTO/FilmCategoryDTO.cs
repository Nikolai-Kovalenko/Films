using System.ComponentModel.DataAnnotations.Schema;

namespace Films.Models.DTO
{
    public class FilmCategoryDTO
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int CategoryId { get; set; }
    }
}
