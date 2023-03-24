using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanAndDrops.Models.Entities
{
    public class Product
    {
        [Key]
        public string? Product_id { get; set; }

        public string? Product_Name { get; set; }

        public string? Product_Description { get; set; }

        public Category category { get; set; }

        public int Product_Size { get; set; }

        public int Product_Price { get; set; }

        public int Product_Count { get; set; }

        public string? image { get; set; }

        public DateTime Product_Date { get; set; }
    }
}
