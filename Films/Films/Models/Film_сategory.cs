using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Films.Models
{
    public class Film_сategory
    {
        [Key]
        public int Id { get; set; }

        public string FilmId { get; set; }
        [ForeignKey("UsFilmIderId")]
        public virtual Film Film { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
