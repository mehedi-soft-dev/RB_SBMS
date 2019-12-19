namespace RecycleBin.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifypurchases : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PurchaseDetails_Id", c => c.Int());
            AddColumn("dbo.PurchaseDetails", "Product_Id", c => c.Int());
            CreateIndex("dbo.Products", "PurchaseDetails_Id");
            CreateIndex("dbo.PurchaseDetails", "Product_Id");
            AddForeignKey("dbo.Products", "PurchaseDetails_Id", "dbo.PurchaseDetails", "Id");
            AddForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "PurchaseDetails_Id", "dbo.PurchaseDetails");
            DropIndex("dbo.PurchaseDetails", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "PurchaseDetails_Id" });
            DropColumn("dbo.PurchaseDetails", "Product_Id");
            DropColumn("dbo.Products", "PurchaseDetails_Id");
        }
    }
}
