namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minfiedfaqs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFaqs", "Qdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserFaqs", "Qdate");
        }
    }
}
