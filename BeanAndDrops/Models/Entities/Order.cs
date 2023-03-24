using System.ComponentModel.DataAnnotations;

namespace BeanAndDrops.Models.Entities
{
    public class Order
    {
        [Key]
        public string? Order_Id { get; set; }

        public string? Order_status { get; set; }

        public DateTime Order_Date { get; set; }

        public double Total_price { get; set; }

        public double net_price { get; set; }

    }
}
