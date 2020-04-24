namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980322contactusmodifi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUsMessages", "Vaziaat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactUsMessages", "Vaziaat");
        }
    }
}
