namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slideraddaas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sliders", "datatransition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "datatransition", c => c.String());
        }
    }
}
