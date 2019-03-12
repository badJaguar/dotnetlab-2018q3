namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderItemConfWithAllProperties : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tbl_order_items");
            AddColumn("dbo.tbl_order_items", "cln_qty", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tbl_order_items", new[] { "cln_item_id", "cln_order_id" });
            //DropColumn("dbo.tbl_orders", "CustomerId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.tbl_orders", "CustomerId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.tbl_order_items");
            DropColumn("dbo.tbl_order_items", "cln_qty");
            AddPrimaryKey("dbo.tbl_order_items", new[] { "cln_order_id", "cln_item_id" });
        }
    }
}
