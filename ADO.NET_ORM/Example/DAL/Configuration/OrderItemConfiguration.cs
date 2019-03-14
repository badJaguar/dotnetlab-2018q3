using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class OrderItemConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfiguration()
        {
            ToTable("tbl_orders_items").HasKey(item => new
            {
                item.ItemId, item.OrderId
            });
            Property(item => item.ItemId).HasColumnName("cln_item_id");
            Property(item => item.OrderId).HasColumnName("cln_order_id");
            Property(item => item.Quantity).HasColumnName("cln_qty");

            HasRequired(o => o.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(item => item.OrderId);

            HasRequired(o => o.Item)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(item => item.ItemId);
        }
    }
}