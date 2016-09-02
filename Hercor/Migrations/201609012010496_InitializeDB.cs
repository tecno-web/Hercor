namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Content = c.String(nullable: false, maxLength: 500, unicode: false),
                        Create = c.DateTime(nullable: false),
                        Update = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            CreateTable(
                "dbo.ArticleCategory",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.CategoryId })
                .ForeignKey("dbo.Article", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Banner",
                c => new
                    {
                        BannerId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Image = c.String(),
                        Eliminate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BannerId);
            
            CreateTable(
                "dbo.CategoryProduct",
                c => new
                    {
                        IdCategoryProduct = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
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
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                        Content = c.String(),
                        Slug = c.String(),
                        Image = c.String(),
                        Page = c.Int(nullable: false),
                        Eliminate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageProduct = c.String(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CategoryProductPivot", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CategoryProductPivot", "IdCategoryProduct", "dbo.CategoryProduct");
            DropForeignKey("dbo.ArticleCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ArticleCategory", "ArticleId", "dbo.Article");
            DropIndex("dbo.Image", new[] { "ProductId" });
            DropIndex("dbo.CategoryProductPivot", new[] { "IdCategoryProduct" });
            DropIndex("dbo.CategoryProductPivot", new[] { "ProductId" });
            DropIndex("dbo.ArticleCategory", new[] { "CategoryId" });
            DropIndex("dbo.ArticleCategory", new[] { "ArticleId" });
            DropTable("dbo.Image");
            DropTable("dbo.Product");
            DropTable("dbo.CategoryProductPivot");
            DropTable("dbo.CategoryProduct");
            DropTable("dbo.Banner");
            DropTable("dbo.Category");
            DropTable("dbo.ArticleCategory");
            DropTable("dbo.Article");
        }
    }
}
