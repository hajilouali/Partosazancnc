namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsLetter98032555555555 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsLetters", "NewsLetterListId", "dbo.NewsLetterLists");
            DropIndex("dbo.NewsLetters", new[] { "NewsLetterListId" });
            AlterColumn("dbo.NewsLetters", "NewsLetterListId", c => c.Int());
            AlterColumn("dbo.NewsLetters", "DateTime", c => c.DateTime());
            CreateIndex("dbo.NewsLetters", "NewsLetterListId");
            AddForeignKey("dbo.NewsLetters", "NewsLetterListId", "dbo.NewsLetterLists", "NewsLetterListId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsLetters", "NewsLetterListId", "dbo.NewsLetterLists");
            DropIndex("dbo.NewsLetters", new[] { "NewsLetterListId" });
            AlterColumn("dbo.NewsLetters", "DateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NewsLetters", "NewsLetterListId", c => c.Int(nullable: false));
            CreateIndex("dbo.NewsLetters", "NewsLetterListId");
            AddForeignKey("dbo.NewsLetters", "NewsLetterListId", "dbo.NewsLetterLists", "NewsLetterListId", cascadeDelete: true);
        }
    }
}
