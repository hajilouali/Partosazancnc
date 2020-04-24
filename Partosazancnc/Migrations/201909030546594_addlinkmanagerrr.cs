namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlinkmanagerrr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LinkManagers", "Url", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.LinkManagers", "RedirectToUrl", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LinkManagers", "RedirectToUrl", c => c.String(nullable: false));
            AlterColumn("dbo.LinkManagers", "Url", c => c.String(nullable: false));
        }
    }
}
