namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderConfWithAllProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_orders",
                c => new
                    {
                        cln_id = c.Int(nullable: false, identity: true),
                        //CustomerId = c.Int(nullable: false),
                        cln_date_of_order = c.DateTimeOffset(nullable: false, precision: 7),
                        cln_total_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.cln_id);
            
            CreateTable(
                "dbo.tbl_order_items",
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

            Sql("insert into tbl_orders (cln_date_of_order, cln_total_price) values " +
                "('2013-09-13 12:00:00.0000000 +03:00', 82.00)," +
                " ('2013-09-14 12:00:00.0000000 +03:00', 10750.00)");
                                                                                     
            Sql(@"insert into tbl_order_items (cln_order_id, cln_item_id) values 
                 (1, 1)," +
                "(1, 2)," +
                "(1, 3)," +
                "(2, 1)," +
                "(2, 2)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_order_items", "cln_item_id", "dbo.tbl_items");
            DropForeignKey("dbo.tbl_order_items", "cln_order_id", "dbo.tbl_orders");
            DropIndex("dbo.tbl_order_items", new[] { "cln_item_id" });
            DropIndex("dbo.tbl_order_items", new[] { "cln_order_id" });
            DropTable("dbo.tbl_order_items");
            DropTable("dbo.tbl_orders");
        }
    }
}
