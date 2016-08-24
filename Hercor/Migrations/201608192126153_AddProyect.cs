namespace Hercor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProyect : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proyect",
                c => new
                    {
                        ProyectId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                        Latitude = c.String(nullable: false),
                        Longitude = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProyectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proyect");
        }
    }
}
