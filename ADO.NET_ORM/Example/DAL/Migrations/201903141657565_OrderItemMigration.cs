namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tbl_orders_items");
            AddColumn("dbo.tbl_orders_items", "cln_qty", c => c.Int(nullable: false));

            Sql(@"update tbl_orders_items set cln_qty = 4 where cln_order_id = 1 and cln_item_id = 1");
            Sql(@"update tbl_orders_items set cln_qty = 5 where cln_order_id = 1 and cln_item_id = 2");
            Sql(@"update tbl_orders_items set cln_qty = 32 where cln_order_id = 1 and cln_item_id = 3");
            Sql(@"update tbl_orders_items set cln_qty = 500 where cln_order_id = 2 and cln_item_id = 1");
            Sql(@"update tbl_orders_items set cln_qty = 750 where cln_order_id = 2 and cln_item_id = 2");

            AddPrimaryKey("dbo.tbl_orders_items", new[] { "cln_item_id", "cln_order_id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tbl_orders_items");
            DropColumn("dbo.tbl_orders_items", "cln_qty");
            AddPrimaryKey("dbo.tbl_orders_items", new[] { "cln_order_id", "cln_item_id" });
        }
    }
}
