namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9803266 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewsLetters", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewsLetters", "DateTime", c => c.DateTime());
        }
    }
}
