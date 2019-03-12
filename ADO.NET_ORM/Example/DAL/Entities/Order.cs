using System.Collections.Generic;

namespace DAL.Entities
{
    /// <summary>
    /// Represents an order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets an order ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a customer ID.
        /// </summary>
        public int CustomerId { get; set; }
        
        /// <summary>
        /// Gets or sets an ordered customer.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets a collection of ordered items.
        /// </summary>
        public virtual ICollection<Item> ItemCollection { get; set; }
    }
}
