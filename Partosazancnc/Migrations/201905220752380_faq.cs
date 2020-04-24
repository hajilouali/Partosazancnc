namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        FaqsID = c.Int(nullable: false, identity: true),
                        FaqsTitle = c.String(),
                        FaqsDiscription = c.String(),
                        ProductTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaqsID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId, cascadeDelete: true)
                .Index(t => t.ProductTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Faqs", "ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Faqs", new[] { "ProductTypeId" });
            DropTable("dbo.Faqs");
        }
    }
}
