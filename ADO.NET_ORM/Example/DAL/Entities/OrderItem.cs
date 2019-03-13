﻿namespace DAL.Entities
{
    /// <summary>
    /// Represents an intermediate entity binding 'Item' and 'Order'.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Gets or sets an item ID.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets an order ID.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets a total ordered quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets an item.
        /// </summary>
        public virtual Item Item { get; set; }

        /// <summary>
        /// Gets or sets an order.
        /// </summary>
        public virtual Order Order { get; set; }
    }
}