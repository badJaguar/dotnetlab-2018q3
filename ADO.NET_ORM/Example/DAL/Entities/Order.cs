using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public virtual DateTimeOffset OrderDate { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}