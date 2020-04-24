namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _98032000000 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "Vaziaat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "Vaziaat");
        }
    }
}
