namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9803211 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LayerSliders", "data_elementdelay", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.LayerSliders", "data_endelementdelay", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.LayerSliders", "data_hoffset", c => c.Int());
            DropColumn("dbo.LayerSliders", "data_speed");
            DropColumn("dbo.LayerSliders", "data_start");
            DropColumn("dbo.LayerSliders", "data_endspeed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LayerSliders", "data_endspeed", c => c.String());
            AddColumn("dbo.LayerSliders", "data_start", c => c.String());
            AddColumn("dbo.LayerSliders", "data_speed", c => c.String());
            AlterColumn("dbo.LayerSliders", "data_hoffset", c => c.String());
            AlterColumn("dbo.LayerSliders", "data_endelementdelay", c => c.String());
            AlterColumn("dbo.LayerSliders", "data_elementdelay", c => c.String());
        }
    }
}
