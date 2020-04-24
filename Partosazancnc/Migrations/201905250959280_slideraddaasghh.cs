namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slideraddaasghh : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LayerSliders", "LayerIsImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LayerSliders", "LayerIsImage", c => c.Boolean(nullable: false));
        }
    }
}
