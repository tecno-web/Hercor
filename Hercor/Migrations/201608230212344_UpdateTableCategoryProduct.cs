namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCategoryProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CategoryProduct", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CategoryProduct", "Description", c => c.Int(nullable: false));
        }
    }
}
