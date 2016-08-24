namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableProductSlug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Slug");
        }
    }
}
