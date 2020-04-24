namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980319addproductcomments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductComments",
                c => new
                    {
                        ProductCommentID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Comment = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ParentID = c.Int(),
                        Vaziaat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCommentID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductComments", "ProductID", "dbo.Products");
            DropIndex("dbo.ProductComments", new[] { "ProductID" });
            DropTable("dbo.ProductComments");
        }
    }
}
