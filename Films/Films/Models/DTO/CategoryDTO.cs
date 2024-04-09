using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.Models.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Parent Categoty")]
        public int? Parent_category_id { get; set; }
        [ForeignKey("Parent_category_id")]
        public virtual CategoryDTO? ParentCategory { get; set; }
        public int? NestingLevel { get; set; }
    }
}
