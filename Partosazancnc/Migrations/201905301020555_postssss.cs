namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postssss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "PostTypeID", "dbo.PostTypes");
            DropIndex("dbo.Posts", new[] { "PostTypeID" });
            AlterColumn("dbo.Posts", "PostTypeID", c => c.Int());
            CreateIndex("dbo.Posts", "PostTypeID");
            AddForeignKey("dbo.Posts", "PostTypeID", "dbo.PostTypes", "PostTypeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PostTypeID", "dbo.PostTypes");
            DropIndex("dbo.Posts", new[] { "PostTypeID" });
            AlterColumn("dbo.Posts", "PostTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "PostTypeID");
            AddForeignKey("dbo.Posts", "PostTypeID", "dbo.PostTypes", "PostTypeID", cascadeDelete: true);
        }
    }
}
