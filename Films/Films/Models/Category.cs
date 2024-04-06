using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Films.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        public int? Parent_category_id { get; set; }
        [ForeignKey("Parent_category_id")]
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
