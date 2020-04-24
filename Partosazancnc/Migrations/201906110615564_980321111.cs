namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980321111 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LayerSliders", "data_elementdelay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.LayerSliders", "data_endelementdelay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LayerSliders", "data_endelementdelay", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.LayerSliders", "data_elementdelay", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
