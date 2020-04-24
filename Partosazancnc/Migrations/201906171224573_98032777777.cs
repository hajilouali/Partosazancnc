namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _98032777777 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewsLettersMails", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewsLettersMails", "Email", c => c.String());
        }
    }
}
