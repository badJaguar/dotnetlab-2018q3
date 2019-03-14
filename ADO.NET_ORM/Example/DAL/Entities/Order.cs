using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}