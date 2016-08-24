namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryProduct",
                c => new
                    {
                        IdCategoryProduct = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.Int(nullable: false),
                        slug = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategoryProduct);
            
            CreateTable(
                "dbo.CategoryProductPivot",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        IdCategoryProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.IdCategoryProduct })
                .ForeignKey("dbo.CategoryProduct", t => t.IdCategoryProduct, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.IdCategoryProduct);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryProductPivot", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CategoryProductPivot", "IdCategoryProduct", "dbo.CategoryProduct");
            DropIndex("dbo.CategoryProductPivot", new[] { "IdCategoryProduct" });
            DropIndex("dbo.CategoryProductPivot", new[] { "ProductId" });
            DropTable("dbo.CategoryProductPivot");
            DropTable("dbo.CategoryProduct");
        }
    }
}
