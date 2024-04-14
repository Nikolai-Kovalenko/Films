using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Director { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Release { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
