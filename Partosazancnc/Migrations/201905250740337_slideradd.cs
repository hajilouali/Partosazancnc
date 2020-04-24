namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slideradd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LayerSliders",
                c => new
                    {
                        LayerID = c.Int(nullable: false, identity: true),
                        SlideID = c.Int(nullable: false),
                        LayerIsImage = c.Boolean(nullable: false),
                        LayerImage = c.String(),
                        LayerText = c.String(),
                        CostomCss = c.String(),
                        data_x = c.String(),
                        data_y = c.String(),
                        data_speed = c.String(),
                        data_start = c.String(),
                        data_easing = c.String(),
                        data_splitin = c.String(),
                        data_splitout = c.String(),
                        data_elementdelay = c.String(),
                        data_endelementdelay = c.String(),
                        data_endspeed = c.String(),
                        data_endeasing = c.String(),
                        data_hoffset = c.String(),
                    })
                .PrimaryKey(t => t.LayerID)
                .ForeignKey("dbo.Sliders", t => t.SlideID, cascadeDelete: true)
                .Index(t => t.SlideID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SlideID = c.Int(nullable: false, identity: true),
                        SliderTitle = c.String(),
                        SliderDiscription = c.String(),
                        SliderURL = c.String(),
                        datatransition = c.String(),
                        datAslotamount = c.String(),
                        datAmasterspeed = c.String(),
                        dataDelay = c.String(),
                        dataSaveperformance = c.String(),
                        ImageSlider = c.String(),
                        Imagedatabgposition = c.String(),
                        Imagedatabgfit = c.String(),
                        CostomCss = c.String(),
                    })
                .PrimaryKey(t => t.SlideID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LayerSliders", "SlideID", "dbo.Sliders");
            DropIndex("dbo.LayerSliders", new[] { "SlideID" });
            DropTable("dbo.Sliders");
            DropTable("dbo.LayerSliders");
        }
    }
}
