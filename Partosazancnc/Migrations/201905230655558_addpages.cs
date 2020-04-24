namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenusID = c.Int(nullable: false, identity: true),
                        MenuTitle = c.String(),
                        URL = c.String(),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.MenusID);
            
            CreateTable(
                "dbo.PostTypes",
                c => new
                    {
                        PostTypeID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PostTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostTypes");
            DropTable("dbo.Menus");
        }
    }
}
