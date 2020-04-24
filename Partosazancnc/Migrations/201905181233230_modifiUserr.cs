namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiUserr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Roles_RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Roles_RoleID" });
            RenameColumn(table: "dbo.Users", name: "Roles_RoleID", newName: "RoleID");
            AlterColumn("dbo.Users", "RoleID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
            DropColumn("dbo.Users", "RollID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RollID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleID" });
            AlterColumn("dbo.Users", "RoleID", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "RoleID", newName: "Roles_RoleID");
            CreateIndex("dbo.Users", "Roles_RoleID");
            AddForeignKey("dbo.Users", "Roles_RoleID", "dbo.Roles", "RoleID");
        }
    }
}
