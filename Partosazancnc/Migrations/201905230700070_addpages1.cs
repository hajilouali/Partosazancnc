namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpages1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        PageTitle = c.String(nullable: false, maxLength: 65),
                        PageContent = c.String(),
                        KeyWord = c.String(maxLength: 200),
                        PageShortDiscription = c.String(maxLength: 160),
                        ImageThumline = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(nullable: false, maxLength: 150),
                        PostText = c.String(),
                        PostTypeID = c.Int(nullable: false),
                        PostShortDiscription = c.String(maxLength: 350),
                        PostDate = c.DateTime(nullable: false),
                        KeyWord = c.String(maxLength: 300),
                        UserID = c.Int(nullable: false),
                        PostImage = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.PostTypes", t => t.PostTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.PostTypeID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "PostTypeID", "dbo.PostTypes");
            DropForeignKey("dbo.Pages", "UserID", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.Posts", new[] { "PostTypeID" });
            DropIndex("dbo.Pages", new[] { "UserID" });
            DropTable("dbo.Posts");
            DropTable("dbo.Pages");
        }
    }
}
