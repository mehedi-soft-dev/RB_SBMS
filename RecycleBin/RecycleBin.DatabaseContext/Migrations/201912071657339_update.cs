namespace RecycleBin.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "PurchaseDetails_Id", "dbo.PurchaseDetails");
            DropForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products");
            DropIndex("dbo.Products", new[] { "PurchaseDetails_Id" });
            DropIndex("dbo.PurchaseDetails", new[] { "Product_Id" });
            DropColumn("dbo.Products", "PurchaseDetails_Id");
            DropColumn("dbo.PurchaseDetails", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseDetails", "Product_Id", c => c.Int());
            AddColumn("dbo.Products", "PurchaseDetails_Id", c => c.Int());
            CreateIndex("dbo.PurchaseDetails", "Product_Id");
            CreateIndex("dbo.Products", "PurchaseDetails_Id");
            AddForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Products", "PurchaseDetails_Id", "dbo.PurchaseDetails", "Id");
        }
    }
}
