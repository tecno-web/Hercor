namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyFieldImage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "Proyect");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Proyect", c => c.String());
        }
    }
}
