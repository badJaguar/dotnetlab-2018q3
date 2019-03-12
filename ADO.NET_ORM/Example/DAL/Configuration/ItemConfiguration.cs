using DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configuration
{
    class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            ToTable("tbl_items").HasKey(key => key.Id);
            Property(item => item.Id).HasColumnName("cln_id");
            Property(item => item.Description).HasColumnName("cln_description");
            Property(item => item.Price).HasColumnName("cln_price");
        }
    }
}
