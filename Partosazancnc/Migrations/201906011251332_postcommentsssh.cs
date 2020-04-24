namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postcommentsssh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostComments", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostComments", "CreateDate", c => c.Int(nullable: false));
        }
    }
}
