using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.Models.DTO
{
    public class FilmDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }
        public DateTime Release { get; set; }
    }
}
