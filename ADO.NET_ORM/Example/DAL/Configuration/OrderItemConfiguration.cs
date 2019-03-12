using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class OrderItemConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfiguration()
        {
            ToTable("tbl_order_items").HasKey(item => new 
            {
                item.ItemId,
                item.OrderId
            });
            Property(item => item.OrderId).HasColumnName("cln_order_id");
            Property(item => item.ItemId).HasColumnName("cln_item_id");
            Property(item => item.Quantity).HasColumnName("cln_qty");

            HasRequired(o => o.Order)
                .WithMany(order => order.OrderItems)
                .HasForeignKey(item => item.OrderId);
            HasRequired(i => i.Item)
                .WithMany(item => item.OrderItems)
                .HasForeignKey(item => item.ItemId);
        }
    }
}