using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("tbl_customers").HasKey(customer => customer.Id);
            Property(customer => customer.Id).HasColumnName("cln_id");
            Property(customer => customer.Address).HasColumnName("cln_address");
            Property(customer => customer.City).HasColumnName("cln_city");
            Property(customer => customer.CompanyName).HasColumnName("cln_co_name");
            Property(customer => customer.State).HasColumnName("cln_state");
        }
    }
}
