namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _98032111111111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LayerSliders", "data_endspeed", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LayerSliders", "data_endspeed");
        }
    }
}
