namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_orders_items",
                c => new
                    {
                        cln_id = c.Int(nullable: false, identity: true),
                        cln_total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.cln_id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        cln_order_id = c.Int(nullable: false),
                        cln_item_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.cln_order_id, t.cln_item_id })
                .ForeignKey("dbo.tbl_orders_items", t => t.cln_order_id, cascadeDelete: true)
                .ForeignKey("dbo.tbl_items", t => t.cln_item_id, cascadeDelete: true)
                .Index(t => t.cln_order_id)
                .Index(t => t.cln_item_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "cln_item_id", "dbo.tbl_items");
            DropForeignKey("dbo.OrderItems", "cln_order_id", "dbo.tbl_orders_items");
            DropIndex("dbo.OrderItems", new[] { "cln_item_id" });
            DropIndex("dbo.OrderItems", new[] { "cln_order_id" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.tbl_orders_items");
        }
    }
}
