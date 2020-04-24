namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsLetter980325555555 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsLetters", "Days", c => c.String());
            AddColumn("dbo.NewsLetters", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsLetters", "IsActive");
            DropColumn("dbo.NewsLetters", "Days");
        }
    }
}
