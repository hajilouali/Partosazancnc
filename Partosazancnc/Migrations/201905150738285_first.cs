namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleTitle = c.String(nullable: false, maxLength: 150),
                        RoleName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        RollID = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 150),
                        UserName = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false, maxLength: 150),
                        ActiveCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        Roles_RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.Roles_RoleID)
                .Index(t => t.Roles_RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Roles_RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Roles_RoleID" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
