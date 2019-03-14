using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            ToTable("tbl_items").HasKey(item => item.Id);
            Property(item => item.Id).HasColumnName("cln_id");
            Property(item => item.Description).HasColumnName("cln_description");
            Property(item => item.Price).HasColumnName("cln_price");
        }
    }
}