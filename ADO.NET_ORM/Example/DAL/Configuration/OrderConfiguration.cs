using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("tbl_orders").HasKey(key => key.Id);
            Property(order => order.Id).HasColumnName("cln_id");
            Property(order => order.CustomerId).HasColumnName("cln_cust_id");
            Property(order => order.OrderDate).HasColumnName("cln_date_of_order");
            Property(order => order.TotalPrice).HasColumnName("cln_total_price");

            HasRequired(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}