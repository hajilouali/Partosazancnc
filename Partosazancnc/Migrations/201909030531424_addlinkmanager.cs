namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlinkmanager : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LinkManagers",
                c => new
                    {
                        LinkMAnagerId = c.Int(nullable: false, identity: true),
                        ReDirectName = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false),
                        RedirectToUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LinkMAnagerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LinkManagers");
        }
    }
}
