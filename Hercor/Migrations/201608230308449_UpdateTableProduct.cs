namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Content");
        }
    }
}
