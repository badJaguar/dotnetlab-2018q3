using System.Collections.Generic;

namespace DAL.Entities
{
    /// <summary>
    /// Represents a customer entity.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets customers ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets customers company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets customers address (street, building)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets customer location  city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets customers location state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets customers collection orders.
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}