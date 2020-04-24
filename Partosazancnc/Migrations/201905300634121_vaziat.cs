namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vaziat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Vaziaat", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Vaziaat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Vaziaat");
            DropColumn("dbo.Products", "Vaziaat");
        }
    }
}
