namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faqs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFaqs",
                c => new
                    {
                        UserFaqsID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        UserQuestion = c.String(),
                        Vaziaat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserFaqsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserFaqs");
        }
    }
}
