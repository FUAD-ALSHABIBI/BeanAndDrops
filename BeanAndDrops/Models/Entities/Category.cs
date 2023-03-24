using System.ComponentModel.DataAnnotations;

namespace BeanAndDrops.Models.Entities
{
    public class Category
    {
        [Key]
        public string? Category_Id { get; set; }

        public string? Category_Name { get; set; }

        public string? Category_Description { get; set; }

    }
}
