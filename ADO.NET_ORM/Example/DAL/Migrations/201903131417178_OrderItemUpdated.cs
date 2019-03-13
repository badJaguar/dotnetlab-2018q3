namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemUpdated : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tbl_order_items");
            AddPrimaryKey("dbo.tbl_order_items", new[] { "cln_order_id", "cln_item_id", "cln_qty" });

            Sql("update tbl_order_items set cln_qty = 4 where cln_order_id = 1 and cln_item_id = 1,"+
               "update tbl_order_items set cln_qty = 5 where cln_order_id = 1 and cln_item_id = 2,"+
               "update tbl_order_items set cln_qty = 32 where cln_order_id = 1 and cln_item_id = 3");

            Sql("update tbl_order_items set cln_qty = 500 where cln_order_id = 2 and cln_item_id = 1,"+
                "update tbl_order_items set cln_qty = 750 where cln_order_id = 2 and cln_item_id = 2");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tbl_order_items");
            AddPrimaryKey("dbo.tbl_order_items", new[] { "cln_item_id", "cln_order_id", "cln_qty" });
        }
    }
}
