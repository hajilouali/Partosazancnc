namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _98032000000000 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sliders", "SliderTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "SliderTitle", c => c.String());
        }
    }
}
