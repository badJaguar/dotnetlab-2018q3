namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerWithAllProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_customers",
                c => new
                    {
                        cln_id = c.Int(nullable: false, identity: true),
                        cln_comp_name = c.String(),
                        cln_address = c.String(),
                        cln_city = c.String(),
                        cln_state = c.String(),
                    })
                .PrimaryKey(t => t.cln_id);
            
            AddColumn("dbo.tbl_orders", "Customer_Id", c => c.Int());
            CreateIndex("dbo.tbl_orders", "Customer_Id");
            AddForeignKey("dbo.tbl_orders", "Customer_Id", "dbo.tbl_customers", "cln_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_orders", "Customer_Id", "dbo.tbl_customers");
            DropIndex("dbo.tbl_orders", new[] { "Customer_Id" });
            DropColumn("dbo.tbl_orders", "Customer_Id");
            DropTable("dbo.tbl_customers");
        }
    }
}
