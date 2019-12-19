namespace RecycleBin.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesDetails", "UnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Sales", "DiscountPercentage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "DiscountPercentage", c => c.Double(nullable: false));
            DropColumn("dbo.SalesDetails", "UnitPrice");
        }
    }
}
