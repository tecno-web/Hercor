namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableBanner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banner", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Banner", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Banner", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Banner", "Image", c => c.String());
            DropColumn("dbo.Banner", "Description");
            DropColumn("dbo.Banner", "Title");
        }
    }
}
