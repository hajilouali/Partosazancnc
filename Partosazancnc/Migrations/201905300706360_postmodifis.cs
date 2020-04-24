namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postmodifis : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PostShortDiscription", c => c.String(nullable: false, maxLength: 190));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostShortDiscription", c => c.String(maxLength: 190));
        }
    }
}
