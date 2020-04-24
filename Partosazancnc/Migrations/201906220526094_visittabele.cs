namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class visittabele : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitorLogs",
                c => new
                    {
                        VisiteId = c.Int(nullable: false, identity: true),
                        VisitCount = c.Double(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VisiteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisitorLogs");
        }
    }
}
