using System.ComponentModel.DataAnnotations;

namespace BeanAndDrops.Models.Entities
{
    public class Customer
    {
        [Key]
        public string? Customer_Id { get; set; }

        public string? Customer_Email { get; set; }

        public string? Customer_Password { get; set; }

        public string? Customer_Address { get; set; }

        public string? Customer_Name { get; set; }
    }
}
