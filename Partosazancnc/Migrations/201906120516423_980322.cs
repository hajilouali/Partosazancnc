namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980322 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Vaziaat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Vaziaat");
        }
    }
}
