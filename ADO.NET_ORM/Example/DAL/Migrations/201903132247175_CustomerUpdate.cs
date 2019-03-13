namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_orders", "Customer_Id", "dbo.tbl_customers");
            DropIndex("dbo.tbl_orders", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.tbl_orders", name: "Customer_Id", newName: "cln_cust_id");
            AlterColumn("dbo.tbl_orders", "cln_cust_id", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_orders", "cln_cust_id");
            
            Sql("update dbo.tbl_orders set cln_cust_id = 56 where cln_id = 1");
            Sql("update dbo.tbl_orders set cln_cust_id = 2 where cln_id = 2");
            Sql("insert into dbo.tbl_customers (cln_id, cln_comp_name, cln_address, cln_city, cln_state)" +
                " values (56, 'Foo, Inc', '23 Main St.', 'Thorpleburg', 'TX')");
            Sql("insert into dbo.tbl_customers (cln_id, cln_comp_name, cln_address, cln_city, cln_state)" +
                " values (2, 'Freens R US', '1600 Pennsylvania Avenue', 'Washington', 'DC')");

            AddForeignKey("dbo.tbl_orders", "cln_cust_id", "dbo.tbl_customers", "cln_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_orders", "cln_cust_id", "dbo.tbl_customers");
            DropIndex("dbo.tbl_orders", new[] { "cln_cust_id" });
            AlterColumn("dbo.tbl_orders", "cln_cust_id", c => c.Int());
            RenameColumn(table: "dbo.tbl_orders", name: "cln_cust_id", newName: "Customer_Id");
            CreateIndex("dbo.tbl_orders", "Customer_Id");
            AddForeignKey("dbo.tbl_orders", "Customer_Id", "dbo.tbl_customers", "cln_id");
        }
    }
}
