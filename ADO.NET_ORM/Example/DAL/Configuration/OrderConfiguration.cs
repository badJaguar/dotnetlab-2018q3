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
            //Property(order => order.CustomerId).HasColumnName("cln_customer_id");
            Property(order => order.OrderDate).HasColumnName("cln_date_of_order");
            Property(order => order.TotalPrice).HasColumnName("cln_total_price");
            HasMany(i => i.Items)
                .WithMany(o => o.Orders)
                .Map(configuration =>
                {
                    configuration.MapLeftKey("cln_order_id");
                    configuration.MapRightKey("cln_item_id");
                    configuration.ToTable("tbl_order_items");
                });
        }
    }
}