using System;

namespace OnlineFoodOrderingSystem.OrderMicroservice.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
