namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postcommentsss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostComments", "CreateDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostComments", "CreateDate");
        }
    }
}
