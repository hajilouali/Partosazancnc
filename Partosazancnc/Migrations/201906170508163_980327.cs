namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980327 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewsLetterLists", "NewsLetterListTitle", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewsLetterLists", "NewsLetterListTitle", c => c.String());
        }
    }
}
