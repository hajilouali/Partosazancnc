namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rols : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Title", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Roles", "RoleTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "RoleTitle", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Roles", "Title");
        }
    }
}
