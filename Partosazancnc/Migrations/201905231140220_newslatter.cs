namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newslatter : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.NewsLettersMails");
        }
    }
}
