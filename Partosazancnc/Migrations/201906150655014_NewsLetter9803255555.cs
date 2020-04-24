namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsLetter9803255555 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsLetterLists",
                c => new
                    {
                        NewsLetterListId = c.Int(nullable: false, identity: true),
                        NewsLetterListTitle = c.String(),
                    })
                .PrimaryKey(t => t.NewsLetterListId);
            
            CreateTable(
                "dbo.NewsLetterMembers",
                c => new
                    {
                        NewsLetterMemberId = c.Int(nullable: false, identity: true),
                        NewsLetterListId = c.Int(nullable: false),
                        NewsLettersMailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsLetterMemberId)
                .ForeignKey("dbo.NewsLetterLists", t => t.NewsLetterListId, cascadeDelete: true)
                .ForeignKey("dbo.NewsLettersMails", t => t.NewsLettersMailID, cascadeDelete: true)
                .Index(t => t.NewsLetterListId)
                .Index(t => t.NewsLettersMailID);
            
            CreateTable(
                "dbo.NewsLettersMails",
                c => new
                    {
                        NewsLettersMailID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        SubmitTime = c.DateTime(nullable: false),
                        DeActivatCode = c.String(),
                    })
                .PrimaryKey(t => t.NewsLettersMailID);
            
            CreateTable(
                "dbo.NewsLetters",
                c => new
                    {
                        NewsLetterId = c.Int(nullable: false, identity: true),
                        NewsLetterListId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        NewsLetterBody = c.String(),
                    })
                .PrimaryKey(t => t.NewsLetterId)
                .ForeignKey("dbo.NewsLetterLists", t => t.NewsLetterListId, cascadeDelete: true)
                .Index(t => t.NewsLetterListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsLetters", "NewsLetterListId", "dbo.NewsLetterLists");
            DropForeignKey("dbo.NewsLetterMembers", "NewsLettersMailID", "dbo.NewsLettersMails");
            DropForeignKey("dbo.NewsLetterMembers", "NewsLetterListId", "dbo.NewsLetterLists");
            DropIndex("dbo.NewsLetters", new[] { "NewsLetterListId" });
            DropIndex("dbo.NewsLetterMembers", new[] { "NewsLettersMailID" });
            DropIndex("dbo.NewsLetterMembers", new[] { "NewsLetterListId" });
            DropTable("dbo.NewsLetters");
            DropTable("dbo.NewsLettersMails");
            DropTable("dbo.NewsLetterMembers");
            DropTable("dbo.NewsLetterLists");
        }
    }
}
