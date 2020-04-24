namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slideraddaasghhjas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LayerSliders", "data_captionhidden", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LayerSliders", "data_captionhidden");
        }
    }
}
