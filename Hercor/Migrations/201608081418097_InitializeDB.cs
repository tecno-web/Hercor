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
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                        Image = c.Binary(),
                        Proyect = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ArticleCategory", "ArticleId", "dbo.Article");
            DropIndex("dbo.ArticleCategory", new[] { "CategoryId" });
            DropIndex("dbo.ArticleCategory", new[] { "ArticleId" });
            DropTable("dbo.Product");
            DropTable("dbo.Category");
            DropTable("dbo.ArticleCategory");
            DropTable("dbo.Article");
        }
    }
}
