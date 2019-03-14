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
            Property(order => order.Total).HasColumnName("cln_total");

            HasMany(i => i.Items)
                .WithMany(o => o.Orders)
                .Map(conf =>
                {
                    conf.MapLeftKey("cln_order_id");
                    conf.MapRightKey("cln_item_id");
                    conf.ToTable("tbl_orders_items");
                });
        }
    }
}