namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyFieldImage1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Image", c => c.Binary());
        }
    }
}
