using System.Collections.Generic;

namespace DAL.Entities
{
    /// <summary>
    /// Represents an item entity.
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
