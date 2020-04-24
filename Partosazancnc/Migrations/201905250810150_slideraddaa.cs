namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slideraddaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "data_transition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sliders", "data_transition");
        }
    }
}
