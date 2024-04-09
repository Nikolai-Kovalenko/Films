using System.ComponentModel.DataAnnotations.Schema;

namespace Films.Models.DTO
{
    public class Film_сategoryDTO
    {
        public int Id { get; set; }
        public string FilmId { get; set; }
        public int CategoryId { get; set; }
    }
}
