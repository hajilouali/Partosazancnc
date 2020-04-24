namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _98032111111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LayerSliders", "data_speed", c => c.String());
            AddColumn("dbo.LayerSliders", "data_start", c => c.String());
            AlterColumn("dbo.LayerSliders", "data_elementdelay", c => c.String());
            AlterColumn("dbo.LayerSliders", "data_endelementdelay", c => c.String());
            AlterColumn("dbo.LayerSliders", "data_hoffset", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LayerSliders", "data_hoffset", c => c.Int());
            AlterColumn("dbo.LayerSliders", "data_endelementdelay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.LayerSliders", "data_elementdelay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.LayerSliders", "data_start");
            DropColumn("dbo.LayerSliders", "data_speed");
        }
    }
}
