using System.Collections.Generic;

namespace DAL.Entities
{
    /// <summary>
    /// Represents an item entity.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets an item ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets an item description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets an item price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets a collection of orders.
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
