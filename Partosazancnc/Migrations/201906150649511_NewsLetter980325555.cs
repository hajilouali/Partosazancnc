namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsLetter980325555 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.NewsLettersMails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NewsLettersMails",
                c => new
                    {
                        NewsLetterID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        SubmitTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewsLetterID);
            
        }
    }
}
