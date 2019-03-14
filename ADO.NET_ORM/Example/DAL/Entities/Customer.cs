using System.Collections.Generic;

namespace DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}