namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slideraddaasghhj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LayerSliders", "ClassCostom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LayerSliders", "ClassCostom");
        }
    }
}
