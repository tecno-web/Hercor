namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Eliminate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Eliminate");
        }
    }
}
