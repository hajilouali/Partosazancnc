namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _98032000 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "UserID", "dbo.Users");
            DropForeignKey("dbo.Pages", "UserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropIndex("dbo.Products", new[] { "UserID" });
            DropIndex("dbo.Pages", new[] { "UserID" });
            DropIndex("dbo.Posts", new[] { "UserID" });
            AlterColumn("dbo.Products", "UserID", c => c.Int());
            AlterColumn("dbo.Pages", "UserID", c => c.Int());
            AlterColumn("dbo.Posts", "UserID", c => c.Int());
            CreateIndex("dbo.Products", "UserID");
            CreateIndex("dbo.Pages", "UserID");
            CreateIndex("dbo.Posts", "UserID");
            AddForeignKey("dbo.Products", "UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Pages", "UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Posts", "UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Pages", "UserID", "dbo.Users");
            DropForeignKey("dbo.Products", "UserID", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.Pages", new[] { "UserID" });
            DropIndex("dbo.Products", new[] { "UserID" });
            AlterColumn("dbo.Posts", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Pages", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "UserID");
            CreateIndex("dbo.Pages", "UserID");
            CreateIndex("dbo.Products", "UserID");
            AddForeignKey("dbo.Posts", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Pages", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
