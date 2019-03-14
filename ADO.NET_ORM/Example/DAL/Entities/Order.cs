using System.Collections.Generic;
using System.Security.AccessControl;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}