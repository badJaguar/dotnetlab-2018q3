using System;
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
        /// Gets or sets an order total price.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets a date of order.
        /// </summary>
        public DateTimeOffset OrderDate { get; set; }

        /// <summary>
        /// Gets or sets an item collection.
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}