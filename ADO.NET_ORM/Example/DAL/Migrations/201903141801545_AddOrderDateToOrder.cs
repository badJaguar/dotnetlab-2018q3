namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderDateToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_orders", "cln_order_date", c => c.DateTimeOffset(nullable: false, precision: 7));

            Sql(@"update tbl_orders set cln_order_date = '2013-09-13 12:00:00.0000000 +03:00' where cln_id = 1");
            Sql(@"update tbl_orders set cln_order_date = '2013-09-14 12:00:00.0000000 +03:00' where cln_id = 2");
        }

        public override void Down()
        {
            DropColumn("dbo.tbl_orders", "cln_order_date");
        }
    }
}
