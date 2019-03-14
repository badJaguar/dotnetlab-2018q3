namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_orders",
                c => new
                    {
                        cln_id = c.Int(nullable: false, identity: true),
                        cln_total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.cln_id);
            
            CreateTable(
                "dbo.tbl_orders_items",
                c => new
                    {
                        cln_order_id = c.Int(nullable: false),
                        cln_item_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.cln_order_id, t.cln_item_id })
                .ForeignKey("dbo.tbl_orders", t => t.cln_order_id, cascadeDelete: true)
                .ForeignKey("dbo.tbl_items", t => t.cln_item_id, cascadeDelete: true)
                .Index(t => t.cln_order_id)
                .Index(t => t.cln_item_id);

            Sql(@"insert into tbl_orders (cln_total) values (82.00)");
            Sql(@"insert into tbl_orders (cln_total) values (10750.00)");

            Sql(@"insert into tbl_orders_items (cln_order_id, cln_item_id) values (1, 1)");
            Sql(@"insert into tbl_orders_items (cln_order_id, cln_item_id) values (1, 2)");
            Sql(@"insert into tbl_orders_items (cln_order_id, cln_item_id) values (1, 3)");
            Sql(@"insert into tbl_orders_items (cln_order_id, cln_item_id) values (2, 1)");
            Sql(@"insert into tbl_orders_items (cln_order_id, cln_item_id) values (2, 2)");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_orders_items", "cln_item_id", "dbo.tbl_items");
            DropForeignKey("dbo.tbl_orders_items", "cln_order_id", "dbo.tbl_orders");
            DropIndex("dbo.tbl_orders_items", new[] { "cln_item_id" });
            DropIndex("dbo.tbl_orders_items", new[] { "cln_order_id" });
            DropTable("dbo.tbl_orders_items");
            DropTable("dbo.tbl_orders");
        }
    }
}
