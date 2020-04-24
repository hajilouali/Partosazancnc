namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980323 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faqs", "FaqsTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Faqs", "FaqsDiscription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faqs", "FaqsDiscription", c => c.String());
            AlterColumn("dbo.Faqs", "FaqsTitle", c => c.String());
        }
    }
}
