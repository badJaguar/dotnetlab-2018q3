using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("tbl_orders").HasKey(order => order.Id);
            Property(order => order.Id).HasColumnName("cln_id");
            Property(order => order.CustomerId).HasColumnName("cln_customer_id");
            Property(order => order.Total).HasColumnName("cln_total");

            HasRequired(o => o.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(order => order.CustomerId);
        }
    }
}