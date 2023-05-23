using OnlineFoodOrderingSystem.OrderMicroservice.Exceptions;
using System;

namespace OnlineFoodOrderingSystem.OrderMicroservice.DataAccessLayer
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MenuItemId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }


}
