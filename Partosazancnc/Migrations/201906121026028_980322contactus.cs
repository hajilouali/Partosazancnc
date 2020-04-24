namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980322contactus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUsMessages",
                c => new
                    {
                        ContactUsID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Message = c.String(),
                        DateSend = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactUsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactUsMessages");
        }
    }
}
