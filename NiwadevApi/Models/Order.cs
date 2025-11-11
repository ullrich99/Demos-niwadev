using System.ComponentModel.DataAnnotations;

namespace NiwadevApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerZipCode { get; set; }
        public string CustomerCity { get; set; }
        public float Consumption { get; set; }
        public float TotalPrice { get; set; }

    }
}
