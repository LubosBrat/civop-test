namespace CivopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsPriceToOrderProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderProducts", "Price", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderProducts", "Price");
        }
    }
}
