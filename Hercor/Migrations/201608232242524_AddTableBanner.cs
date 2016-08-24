namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableBanner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banner",
                c => new
                    {
                        BannerId = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Eliminate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BannerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Banner");
        }
    }
}
