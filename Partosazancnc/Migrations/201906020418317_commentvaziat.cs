namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentvaziat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostComments", "Vaziaat", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostComments", "Vaziaat");
        }
    }
}
