namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slideradda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "data_slotamount", c => c.String());
            AddColumn("dbo.Sliders", "data_masterspeed", c => c.String());
            AddColumn("dbo.Sliders", "data_Delay", c => c.String());
            AddColumn("dbo.Sliders", "data_saveperformance", c => c.String());
            DropColumn("dbo.Sliders", "datAslotamount");
            DropColumn("dbo.Sliders", "datAmasterspeed");
            DropColumn("dbo.Sliders", "dataDelay");
            DropColumn("dbo.Sliders", "dataSaveperformance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "dataSaveperformance", c => c.String());
            AddColumn("dbo.Sliders", "dataDelay", c => c.String());
            AddColumn("dbo.Sliders", "datAmasterspeed", c => c.String());
            AddColumn("dbo.Sliders", "datAslotamount", c => c.String());
            DropColumn("dbo.Sliders", "data_saveperformance");
            DropColumn("dbo.Sliders", "data_Delay");
            DropColumn("dbo.Sliders", "data_masterspeed");
            DropColumn("dbo.Sliders", "data_slotamount");
        }
    }
}
