namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postcomments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        PostCommentID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Comment = c.String(nullable: false),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.PostCommentID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComments", "PostID", "dbo.Posts");
            DropIndex("dbo.PostComments", new[] { "PostID" });
            DropTable("dbo.PostComments");
        }
    }
}
